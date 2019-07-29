using DAL;
using DAL.manage;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEcShop.manage
{
	public partial class goodLType : System.Web.UI.Page
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
			this.Repeater1.DataSource = CategoryDAL.getBLCategoryList();
			this.Repeater1.DataBind();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (this.TextBox1.Text != "")
			{
				//if (BLCategoryDAL.selByname(TextBox1.Text) == 0)
				//{
					if (BLCategoryDAL.addBLCategory(this.TextBox1.Text) > 0)
					{
						Alert("添加成功");
						this.TextBox1.Text = "";
						ShowDate();
					}
					else
					{
						Alert("添加失败");
					}
				//}
				//else
				//{
				
				//	Alert("已存在大类别");
				//}
				
			}
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="argds"></param>
		protected void ImageButton1_Click(object sender, EventArgs argds)
		{

		}
		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="argds"></param>
		protected void imgbtu1_Click(object sender, EventArgs argds)
		{

		}
		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}

		protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton btu = sender as ImageButton;
			int BLID = Convert.ToInt32(btu.CommandArgument);
			Response.Redirect("goodSType.aspx?" + BLID);
		}

		protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton btu = sender as ImageButton;
			int BID = Convert.ToInt32(btu.CommandArgument);
			if (BLCategoryDAL.delete(BID) > 0)
			{
				//刷新数据
				ShowDate();
			}
			else
			{
				Alert("删除失败");
			}
		}
	}
}