using DAL;
using System;
using System.Web.UI;


namespace MyEcShop.manage
{
	public partial class goodSTypeAdd : System.Web.UI.Page
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
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			int BLID = Convert.ToInt32(this.DropDownList1.SelectedValue);
			string BSName = this.TextBox1.Text;
			//if (BSCategoryDAL.selBystype(BLID, BSName) == 0)
			//{
		
			//}
			//else
			//{
			//	Alert("此类别已存在");
			//}

			if (BSName == "")
			{
				Alert("请输入小类别名");
			}
			else
			{
				if (BSCategoryDAL.addBLCategory(BLID, BSName) > 0)
				{
					Alert("添加小类成功");
					Response.Redirect("goodSType.aspx");
				}
				else
				{
					Alert("添加小类失败");
				}
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

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}