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
    public partial class goodLTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string BLName = this.TextBox1.Text;
            if (BLCategoryDAL.addBLCategory(BLName)>0)
            {
				Alert("添加成功");
            }
            else
            {
				Alert("添加失败");

            }
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}