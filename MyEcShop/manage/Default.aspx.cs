using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.manage;


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
                Session["AID"] = AdminDAL.CKLogin(TextBox1.Text, TextBox2.Text);
                Response.Write("<script>alert('登陆成功')</script>");
                Response.Redirect("Index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "alert('管理员姓名或密码错误')", true);
            }
        }
    }
}