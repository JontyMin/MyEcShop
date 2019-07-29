using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using DAL.manage;

namespace MyEcShop.manage
{
    public partial class goodAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"]==null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                this.DropDownList1.DataSource = CategoryDAL.getBSCategoryList();
                this.DropDownList1.DataTextField = "BSName";
                this.DropDownList1.DataValueField = "BSID";
                this.DropDownList1.DataBind();
            }
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BName = this.txtName.Text;
            b.BAuthor = this.txtAuthor.Text;
            b.BISBN = this.txtbisd.Text;
            b.BSID = Convert.ToInt32(DropDownList1.SelectedValue);
            b.BPrice = Convert.ToInt32(this.txtPrice.Text);
            b.BCount = Convert.ToInt32(this.txtBcount.Text);
            b.BPic = FileUpload1.FileName;
			if (FileUpload1.FileName == "")
			{
				Alert("请选择文件");
			}
			else
			{
				string path = Server.MapPath("~/BookImages/" + b.BPic);
				this.FileUpload1.SaveAs(path);
				if (BookDAL.addBook(b) > 0)
				{
					Alert("添加成功");

					//恢复默认
					this.txtName.Text = "";
					this.txtAuthor.Text = "";
					this.txtbisd.Text = "";
					DropDownList1.SelectedIndex = 0;
					this.txtPrice.Text = "";
					this.txtBcount.Text = "";


				}
				else
				{
					Alert("添加失败");
				}
			}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtPrice.Text = "";
            this.txtAuthor.Text = "";
            this.txtBcount.Text = "";
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}