using System;

namespace MyEcShop
{
	public partial class clear : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session.Clear();
				if (Session["AID"] == null)
				{
					Response.Redirect("Default.aspx");
				}
			}
		}
	}
}