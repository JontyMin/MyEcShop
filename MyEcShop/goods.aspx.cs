using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;


namespace MyEcShop
{
    public partial class goods : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null) return;
                int id = int.Parse(Request.QueryString["id"]);
              
                //绑定数据
                List<Book> list = BookDAL.selectByID(id);
                this.Repeater1.DataSource = list;
                this.Repeater1.DataBind();
                //判断库存
                if (list[0].BCount<1)
                {
                   TextBox txt= Repeater1.Items[0].FindControl("TextBox1") as TextBox;
                   txt.Text = "0";
                   txt.Enabled = false;

                   ImageButton img = Repeater1.Items[0].FindControl("ImageButton1") as ImageButton;
                   img.Enabled = false;
                }
                //把历史id保存在session中
                for (int i = 1; i < 5; i++)
                {
                    if (Session["zhuji" + i] == null)
                    {
                        Session["zhuji" + i] = id.ToString();
                        return;
                    }
                    
                }
                //保存最近的4条记录
                if (Session["zhuji4"] != null)
                {
                    Session["zhuji1"] = Session["zhuji2"];
                    Session["zhuji2"] = Session["zhuji3"];
                    Session["zhuji3"] = Session["zhuji4"];
                    Session["zhuji4"] = id.ToString();
                }
            }
        }
		
        protected void ImageButton1_Click(object sender,EventArgs e)
        {
            if (Session["login"] == null)
            {
				Alert("请先登录");
                Response.Redirect("Login.aspx?url=goods.aspx&id="+Request.QueryString["id"]);
            }
            int BID=int.Parse(Request.QueryString["id"]);
            int MID = Convert.ToInt32(Session["login"]);
            int number = 1;
            //获取数量
            TextBox lbl = Repeater1.Items[0].FindControl("TextBox1") as TextBox;
            number = Convert.ToInt32(lbl.Text);

			Trade t = new Trade() {
				BID = BID,
				MID = MID,
				BCount = number
				
			};
			bool ecits = TradeDAL.Exits(t);
			if (ecits == true)
			{
				int id = TradeDAL.update_Bcount(t);
				if (id > 0)
				{
					Alert("商品已加入购物车");
				}
			}
			else
			{


				if (TradeDAL.addTrade(BID, MID, number) > 0)
				{

					Alert("商品已加入购物车");
					int id = TradeDAL.updateBcountByid(number, BID);
					if (id > 0)
					{
						if (Request.QueryString["id"] == null) return;
						//绑定数据
						List<Book> list = BookDAL.selectByID(int.Parse(Request.QueryString["id"]));
						this.Repeater1.DataSource = list;
						this.Repeater1.DataBind();
					}
					//Response.Redirect("flow.aspx");
					if (Request.QueryString["url"] != null)
					{
						Response.Redirect(Request.QueryString["url"]);
					}
				}
			}
        }
        protected void TextBox1_Changed(object o,EventArgs e)
        {
            ImageButton img = Repeater1.Items[0].FindControl("ImageButton1") as ImageButton;
            int id = int.Parse(Request.QueryString["id"]);
            List<Book> list = BookDAL.selectByID(id);
            TextBox txt = o as TextBox;
            //判断购买数量
            if (txt.Text == ""||txt.Text=="0" )
            {
				Alert("购买数量不能为空");
                img.Enabled = false;
                return;
            }
            if (Convert.ToInt32(txt.Text) > list[0].BCount)
            {
				Alert("库存不足");
                img.Enabled = false;
                return;
            }
            img.Enabled = true;
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}