﻿using System;

namespace MyEcShop.manage
{
	public partial class Index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["AID"] == null)
			{
				Response.Redirect("Default.aspx");
			}
		}
	}
}