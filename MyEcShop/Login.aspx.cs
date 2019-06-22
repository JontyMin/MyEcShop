using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

namespace MyEcShop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
			
            //登录
            string name = this.TextBox1.Text;
            string pwd = this.TextBox2.Text;
            Member m = LoginDAL.select(name,pwd);
            if (m.MName != null)
            {
                Session["Name"] = m.MName;
                Session["login"] = m.MID;
                if (Request.QueryString["url"]==null)
                {
					if (Session["Code"].ToString() == this.TextBox7.Text)
					{
						Response.Redirect("Main.aspx");
					}
					else
					{
						Alert("验证码错误");
					}
					
                }
                else
                {
                    Response.Redirect(Request.QueryString["url"]+"?id="+Request.QueryString["id"]);
                }
            }
            else
            {
					Alert("密码错误");
			}
		
		}
        //注册
        protected void Button2_Click(object sender, EventArgs e)
        {
			string name = this.TextBox3.Text;
			if (LoginDAL.selectByName(name) != null)
			{
				this.Label1.Text = "用户名已存在";
			}
			else
			{
				this.Label1.Text = "";
			}

			if (this.Label1.Text=="用户名已存在")
            {
                return;
            }
            string a = this.TextBox3.Text;
            Member m = new Member();
            m.MName = this.TextBox3.Text;
            m.MEmail = this.TextBox4.Text;
            m.MPassword = this.TextBox5.Text;
            int count = LoginDAL.add(m);
            if (count > 0)
            {
				Alert("注册成功");
			}
            else
            {
				Alert("注册失败");
			}    
        }

        //验证码验证
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.TextBox7.Text == Session["code"].ToString().ToLowerInvariant();
        }

        protected void TextBox3_TextChanged1(object sender, EventArgs e)
        {
            string name = this.TextBox3.Text;
            if (LoginDAL.selectByName(name) != null)
            {
                this.Label1.Text = "用户名已存在";
            }
            else
            {
                this.Label1.Text = "";
            }
        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.TextBox7.Text == Session["code"].ToString().ToLowerInvariant();
        }

		public void Alert(string str_Message)
		{
		
			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}