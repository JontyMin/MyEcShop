using DAL;
using System;
using System.Web.UI.WebControls;

namespace MyEcShop.manage
{
	public partial class OrderDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["AID"] == null)
			{
				Response.Redirect("Default.aspx");
			}
			if (!IsPostBack)
			{
				string OID = Request.QueryString["OID"];
				this.Repeater1.DataSource = OrdersDAL.getOrdersByOID(OID);
				this.Repeater1.DataBind();
				this.Repeater2.DataSource = OrderDetailsDAL.getOrderDetailByOID(OID);
				this.Repeater2.DataBind();

			}
		}
		double CountPrice;
		//
		protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item)
			{
				Label lblPrice = e.Item.FindControl("lblPrice") as Label;
				Label lblCount = e.Item.FindControl("lblCount") as Label;
				CountPrice += Convert.ToInt32(lblPrice.Text) * Convert.ToInt32(lblCount.Text);
			}
			this.lblCountPrice.Text = CountPrice.ToString();
		}

		protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
		{

		}


	}
}