using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MyEcShop
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Repeater1.DataSource = CategoryDAL.getBLCategoryList();
                this.Repeater1.DataBind();
            }
            if (Session["Name"] != null)
            {
                this.Label1.Text = Session["Name"].ToString();

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx?BooName=" + this.TextBox1.Text);
        }

		protected void Button2_Click(object sender, EventArgs e)
		{
			
		}
	}
}