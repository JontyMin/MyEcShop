using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL.manage;
using DAL;


namespace MyEcShop.manage
{
    public partial class goodEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {//绑定类别
                this.DropDownList1.DataSource = CategoryDAL.getBSCategoryList();
                this.DropDownList1.DataTextField = "BSName";
                this.DropDownList1.DataValueField = "BSID";
                this.DropDownList1.DataBind();
                //根据图书ID查询出商品
                string a = Request.QueryString["BID"];
                int BID = Convert.ToInt32(a);
                Book b = BookDAL.selectByID(BID)[0];
                this.txtName.Text = b.BName;
                this.txtAuthor.Text = b.BAuthor;
                this.txtbisd.Text = b.BISBN.ToString();
                this.txtPrice.Text = b.BPrice.ToString();
                this.txtBcount.Text = b.BCount.ToString();
                this.DropDownList1.SelectedValue = b.BSID.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtPrice.Text = "";
            this.txtAuthor.Text = "";
            this.txtBcount.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BID = Convert.ToInt32(Request.QueryString["BID"]);
            b.BName = this.txtName.Text;
            b.BAuthor = this.txtAuthor.Text;
            b.BISBN = this.txtbisd.Text;
            b.BSID = Convert.ToInt32(DropDownList1.SelectedValue);
            b.BPrice = Convert.ToInt32(this.txtPrice.Text);
            b.BCount = Convert.ToInt32(this.txtBcount.Text);
            b.BPic = FileUpload1.FileName;
            string path = Server.MapPath("~/BookImages/" + b.BPic);
            this.FileUpload1.SaveAs(path);
            if (BookDAL.update(b)> 0)
            {
				Alert("修改成功");
				Response.Redirect("goods.aspx");
            }
            else
            {
				Alert("修改失败");
			}
        }

		public void Alert(string str_Message)
		{

			Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
		}
	}
}