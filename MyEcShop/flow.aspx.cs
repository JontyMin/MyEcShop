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
    public partial class flow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowDate();
            }

        }

        private void ShowDate()
        {
            this.Repeater1.DataSource = TradeDAL.getTradeByMID(Convert.ToInt32(Session["login"]));
            this.Repeater1.DataBind();
        }
        protected void LinkButton_Click(object o, EventArgs e)
        {
            LinkButton lbu=o as  LinkButton;
            int TID = int.Parse(lbu.CommandArgument);
            if (TradeDAL.DeleteByTID(TID) > 0)
            {
				Alert("删除成功");
                ShowDate();
            }
            else
            {
				Alert("删除失败");
				
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }
        protected void TextBox1_Changed(object sender,EventArgs args)
        {
            
            foreach (RepeaterItem item in Repeater1.Items)
            {
                TextBox txt = item.FindControl("TextBox1") as TextBox;
                Label lblPrice = item.FindControl("lblPrice") as Label;
                Label lblSum = item.FindControl("lblSum") as Label;
                
                //检查库存
                LinkButton lbt = item.FindControl("LinkButton1") as LinkButton;
                //Response.Write(lbt.CommandName);
                int BID = int.Parse(lbt.CommandName);
                List<Book> list = BookDAL.selectByID(BID);
                if (Convert.ToInt32(txt.Text) > list[0].BCount)
                {
					Alert("");
                    txt.Text = list[0].BCount.ToString();
                    return;
                }
                //根据数量改变总价lblSum
                lblSum.Text = (Convert.ToDouble(lblPrice.Text) * Convert.ToInt32(txt.Text)).ToString();
                //根据商品数量变动修改购物车商品数量

                if (TradeDAL.UpdateByTID(BID, Convert.ToInt32(txt.Text)) > 0)
                {
                    //Response.Write("购物车数量改变")
                }
                else
                {
					Alert("请重新操作");
                }
            }
        }
        protected void ImageButton1_Click(object sender,EventArgs args)
        {
            
            //foreach (RepeaterItem item in Repeater1.Items)
            //{
            //    CheckBox cbo = item.FindControl("CheckBox1") as CheckBox;
            //    LinkButton lbtu = item.FindControl("LinkButton1") as LinkButton;
            //    if (cbo.Checked)
            //    {
            //        list.Add(Convert.ToInt32(lbtu.CommandName));
            //    }
            //}
            //foreach (int item in list)
            //{
            //    Response.Write("BID"+item);
            //}
          
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    CheckBox cbo = item.FindControl("CheckBox1") as CheckBox;
                    cbo.Checked = true;
                }
            } 
            else
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    CheckBox cbo = item.FindControl("CheckBox1") as CheckBox;
                    cbo.Checked = false;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
			
			int mid = Convert.ToInt32(Session["login"]);

			if ((TradeDAL.getTradeRows(mid))>0)
			{
				
				string ids = "";
				CheckBox ck1 = null;
				int id = 0;
				foreach (RepeaterItem item in Repeater1.Items)
				{
					 ck1 = item.FindControl("CheckBox1") as CheckBox;
					
					if (ck1.Checked)
					{
						LinkButton lbt1 = item.FindControl("LinkButton1") as LinkButton;
						ids += (lbt1.CommandArgument + ",");
						id++;
					}
				
				}

				if (ids!= null && id>0)
				{
					Response.Redirect("consignee.aspx?ids=" + ids);
					
				}
				else
				{
					ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要下单的商品')</script>");
				}
				

			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('购物车是空的哦，快去主页选购商品吧')</script>");
				//Response.Redirect("main.aspx");
			}

           
            
        }
        protected void CheckBox1_OnCheckedChanged(object sender,EventArgs e)
        {
            CheckBox ck1 = sender as CheckBox;
            if (ck1.Checked == false) this.CheckBox2.Checked = false;
        }

		/// <summary>
		/// 提示框
		/// </summary>
		/// <param name="str_Message"></param>
		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
		protected void Button2_Click(object sender, EventArgs e)
		{

		}
		int id = 0;
		protected void Button1_Click(object sender, EventArgs e)
		{
			
			foreach (RepeaterItem item in Repeater1.Items)
			{
				CheckBox ck1 = item.FindControl("CheckBox1") as CheckBox;
				if (ck1.Checked)
				{
					LinkButton lbt1 = item.FindControl("LinkButton1") as LinkButton;
					//ids += (lbt1.CommandArgument + ",");
					if (TradeDAL.DeleteByTID(Convert.ToInt32(lbt1.CommandArgument))>0)
					{
						id++;
					}
					
				}

			}
			if (id > 0)
			{

				Alert("空空如也");
				CheckBox2.Checked = false;
				ShowDate();
			}
			else
			{
				Alert("啥也没选中");
			}
		}
	}
}