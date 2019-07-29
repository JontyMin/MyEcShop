using DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEcShop
{


	//public enum MyOrders
	//{
	//	新订单=1,
	//	确认订单=2,
	//	发货订单=3,
	//	完成订单=4
	//}


	public partial class Orders : System.Web.UI.Page
	{



		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["AID"] == null)
			{
				Response.Redirect("Default.aspx");
			}
			//if (Request.QueryString["Ostate"]!=null)
			//{
			//	int Ostate = Convert.ToInt32(Request.QueryString["Ostate"]);
			//	this.Repeater1.DataSource = OrdersDAL.GetOrdersByOstate(Ostate,5,1);
			//	this.Repeater1.DataBind();
			//}
			if (!IsPostBack)
			{
				this.Repeater1.DataSource = OrdersDAL.getOrders(this.txtID.Text, this.txtName.Text, 5, 1);
				this.Repeater1.DataBind();
			}
		}

		protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
		{
			this.AspNetPager1.RecordCount = OrdersDAL.getOrdersRows(this.txtID.Text, this.txtName.Text);
			this.Repeater1.DataSource = OrdersDAL.getOrders(this.txtID.Text, this.txtName.Text, 5, e.NewPageIndex);
			this.Repeater1.DataBind();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			//条件查询订单
			this.Repeater1.DataSource = OrdersDAL.getOrders(this.txtID.Text, this.txtName.Text, 5, 1);
			this.Repeater1.DataBind();
		}

		protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			//显示订单状态

			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Button btu2 = e.Item.FindControl("Button2") as Button;
				Label lbl = e.Item.FindControl("Label1") as Label;
				int state = Convert.ToInt32(btu2.CommandArgument);
				switch (state)
				{
					case 1:
						lbl.Text = "新订单";
						btu2.Text = "确认订单";
						break;
					case 2:
						lbl.Text = "确认订单";
						btu2.Text = "发货订单";
						break;
					case 3:
						lbl.Text = "发货订单";
						btu2.Text = "成交订单";
						break;
					default:
						lbl.Text = "成交订单";
						btu2.Enabled = false;
						btu2.Text = "已完成";
						break;
				}
				if (Convert.ToInt32(btu2.CommandArgument) > 3)
				{
					btu2.Enabled = false;
				}
			}
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			//修改订单状态
			Button btu = sender as Button;
			foreach (RepeaterItem item in Repeater1.Items)
			{
				Button btu2 = item.FindControl("Button2") as Button;
				Label lbl = item.FindControl("Label1") as Label;
				if (btu2 == btu)
				{
					btu2.CommandArgument = (Convert.ToInt32(btu2.CommandArgument) + 1).ToString();
					//修改数据库
					if (OrdersDAL.updateStateByOID(btu2.CommandName) > 0)
					{
						Alert("修改数据库订单状态成功");
					}
					else
					{
						return;
					}
					if (Convert.ToInt32(btu2.CommandArgument) > 3)
					{
						btu2.Enabled = false;
					}
					switch (Convert.ToInt32(btu2.CommandArgument))
					{
						case 1:
							lbl.Text = "新订单";
							btu2.Text = "确认订单";
							break;
						case 2:
							lbl.Text = "确认订单";
							btu2.Text = "发货订单";
							break;
						case 3:
							lbl.Text = "发货订单";
							btu2.Text = "成交订单";
							break;
						default:
							lbl.Text = "成交订单";
							btu2.Enabled = false;
							btu2.Text = "已完成";
							break;
					}
				}
			}
		}

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}