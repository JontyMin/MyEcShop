using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace MyEcShop.manage
{
    public partial class goodSTypeUpdate : System.Web.UI.Page
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
                this.DropDownList1.SelectedValue = Request.QueryString["BLID"];
                this.TextBox1.Text = Request.QueryString["BSName"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int BLID = Convert.ToInt32(Request.QueryString["BLID"]);
            int BSID = Convert.ToInt32(Request.QueryString["BSID"]);
            string BSName = this.TextBox1.Text;
            if (BSCategoryDAL.updateByBSID(BLID,BSName,BSID)>0)
            {
				Alert("编辑成功");
				Response.Redirect("goodSType.aspx");
            }
            else
            {
				Alert("编辑失败");
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