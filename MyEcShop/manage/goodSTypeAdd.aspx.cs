using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace MyEcShop.manage
{
    public partial class goodSTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = CategoryDAL.getBLCategoryList();
                DropDownList1.DataTextField = "BLName";
                DropDownList1.DataValueField = "BLID";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int BLID = Convert.ToInt32(this.DropDownList1.SelectedValue);
            string BLName = this.TextBox1.Text;
            if (BSCategoryDAL.addBLCategory(BLID,BLName)>0)
            {
				Alert("添加小类成功");
            }
            else
            {
                Alert("添加小类失败");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "";
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}