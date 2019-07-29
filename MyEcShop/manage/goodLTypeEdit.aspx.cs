using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.manage;

namespace MyEcShop.manage
{
    public partial class goodLTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                this.TextBox1.Text = Request.QueryString["BLName"];
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int BLID = Convert.ToInt32(Request.QueryString["BLID"]);
            if (BLCategoryDAL.update(this.TextBox1.Text,BLID)>0)
            {
				Alert("修改成功");
				Response.Redirect("goodLType.aspx");
            }
            else
            {
				Alert("修改失败");
            }
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}