using DAL.manage;
using System;
using System.Web.UI;


namespace MyEcShop.manage
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{

			//登录
			if (AdminDAL.CKLogin(TextBox1.Text, TextBox2.Text) != null)
			{
				if (Session["code"].ToString() == this.TextBox3.Text.ToUpper())
				{
					Session["AID"] = AdminDAL.CKLogin(TextBox1.Text, TextBox2.Text);
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('登陆成功');</script>");
					Response.Redirect("Index.aspx");
				}

				else
				{
					ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "alert('验证码错误')", true);
				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "alert('管理员姓名或密码错误')", true);
			}

		}
	}
}