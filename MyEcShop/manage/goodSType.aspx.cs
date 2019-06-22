using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MyEcShop.manage
{
    public partial class goodSType : System.Web.UI.Page
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
            this.Repeater1.DataSource = CategoryDAL.getBSCategoryList();
            this.Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("goodSTypeAdd.aspx");
        }
        protected void ImageButton1_Click(object sender,EventArgs e)
        {
            ImageButton btu = sender as ImageButton;
            int BSID = Convert.ToInt32(btu.CommandArgument);
            if (BSCategoryDAL.deleteByBSID(BSID)>0)
            {
                Response.Write("删除成功");
                ShowDate();
            }
            else
            {
                Response.Write("删除失败");
            }
        }
    }
}