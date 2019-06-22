using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MyEcShop.manage
{
    public partial class goods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            string name = Request.QueryString["BooName"];
            string BLID = Request.QueryString["BLID"];
            string BSID = Request.QueryString["BSID"];
            if (!IsPostBack)
            {
                ShowData(name, BLID, BSID);
            }
        }

        private void ShowData(string name, string BLID, string BSID)
        {
            this.Repeater1.DataSource = BookDAL.selectBookByType(BLID, BSID, 4, 1, name);
            this.Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            string name = Request.QueryString["BooName"];
            string BLID = Request.QueryString["BLID"];
            string BSID = Request.QueryString["BSID"];
            this.AspNetPager1.RecordCount = BookDAL.dataRows(BLID, BSID, name);
            this.Repeater1.DataSource = BookDAL.selectBookByType(BLID, BSID, 4, e.NewPageIndex, name);
            this.Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name =this.TextBox1.Text;
            string BLID = Request.QueryString["BLID"];
            string BSID = Request.QueryString["BSID"];
            this.AspNetPager1.RecordCount = BookDAL.dataRows(BLID, BSID, name);
            this.Repeater1.DataSource = BookDAL.selectBookByType(BLID, BSID, 4, 1, name);
            this.Repeater1.DataBind();
        }
        protected void ImageButton1_Click(object sender,EventArgs e)
        {
			
            ImageButton btu = sender as ImageButton;
            int BID = Convert.ToInt32(btu.CommandArgument);
            if (BookDAL.delete(BID) > 0)
            {
                string name = Request.QueryString["BooName"];
                string BLID = Request.QueryString["BLID"];
                string BSID = Request.QueryString["BSID"];
                ShowData(name, BLID, BSID);
				Alert("删除成功");
			}
            else
            {
				Alert("删除失败");
            }
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}