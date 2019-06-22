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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Name"] != null)
            {
                this.Label1.Text = Session["Name"].ToString();
            }
            if (Session["login"] != null)
            {
                this.Label2.Text = TradeDAL.getTradeRows(Convert.ToInt32(Session["login"])).ToString();
                if (this.Label2.Text!="")
                {
                    this.Label3.Text = TradeDAL.getTradeSumPriceByMID(Convert.ToInt32(Session["login"])).ToString();
                }
            }
            if (!IsPostBack)
            {
                List<BLCategory> bllist = CategoryDAL.getBLCategoryList();
                foreach (BLCategory bl in bllist)
                {
                    //大类节点
                    TreeNode nodeBL = new TreeNode();
                    nodeBL.Text = bl.BLName;
                    nodeBL.Value = bl.BLID.ToString();
                    nodeBL.NavigateUrl = "Category.aspx?BLID="+bl.BLID;
                    this.TreeView1.Nodes.Add(nodeBL);
                    //查询小节点
                    List<BSCategory> listBs = CategoryDAL.getBSCategoryList(bl.BLID);
                    foreach (BSCategory bs in listBs)
                    {
                        TreeNode nodeBS = new TreeNode();
                        nodeBS.Text = bs.BSName;
                        nodeBS.Value = bs.BSID.ToString();
                        nodeBS.NavigateUrl = "Category.aspx?BSID="+bs.BSID;
                        nodeBL.ChildNodes.Add(nodeBS);
                    }
                }
                //绑定Repeater1
                this.Repeater1.DataSource = CategoryDAL.getBLCategoryList();
                this.Repeater1.DataBind();
               
            }
          
        }

        

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Session.Clear();
            }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx?BooName="+this.TextBox1.Text);
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

        }


	}
}