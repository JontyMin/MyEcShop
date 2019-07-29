using DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEcShop.manage
{
	public partial class goodSType : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				ShowDate();
			}
		}

		private void ShowDate()
		{
			this.Repeater1.DataSource = CategoryDAL.getBSCategoryList();
			this.Repeater1.DataBind();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("goodSTypeAdd.aspx");
		}
		protected void ImageButton1_Click(object sender, EventArgs e)
		{
			ImageButton btu = sender as ImageButton;
			int BSID = Convert.ToInt32(btu.CommandArgument);
			if (BSCategoryDAL.deleteByBSID(BSID) > 0)
			{
				Alert("删除成功");
				ShowDate();
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