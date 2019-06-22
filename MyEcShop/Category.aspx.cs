using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MyEcShop
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name=Request.QueryString["BooName"];
            string BLID=Request.QueryString["BLID"];
            string BSID=Request.QueryString["BSID"];
            if (!IsPostBack)
            {
                this.Repeater1.DataSource = BookDAL.selectBookByType(BLID,BSID,4,1,name);
                this.Repeater1.DataBind();
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            string name=Request.QueryString["BooName"];
            string BLID = Request.QueryString["BLID"];
            string BSID = Request.QueryString["BSID"];
            this.AspNetPager1.RecordCount = BookDAL.dataRows(BLID, BSID, name);
            this.Repeater1.DataSource = BookDAL.selectBookByType(BLID, BSID, 4, e.NewPageIndex, name);
            this.Repeater1.DataBind();
        }

        protected void ImageButton1_Click(object o, EventArgs e)
        {
            ImageButton img = o as ImageButton;
            int id = int.Parse(img.CommandArgument);
            Response.Redirect("goods.aspx?url=Category.aspx&id=" + id);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
        }
    }
}