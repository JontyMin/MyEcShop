using System;

namespace MyEcShop
{
	public partial class done : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.Label1.Text = Request.QueryString["OID"];

			}
		}
	}
}