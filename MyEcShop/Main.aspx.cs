using DAL;
using Model;
using System;
using System.Collections.Generic;

namespace MyEcShop
{
	public partial class Main : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				List<Book> list = BookDAL.select();
				this.DataList1.DataSource = list;
				this.DataList1.DataBind();

				this.DataList2.DataSource = BookDAL.selectNes();
				this.DataList2.DataBind();
			}
		}
	}
}