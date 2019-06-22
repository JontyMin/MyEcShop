using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.manage;

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
            if (this.TextBox1.Text!="")
            {
                if (BLCategoryDAL.addBLCategory(this.TextBox1.Text)>0)
                {
                    Response.Write("<script>alert('添加成功')</script>");
                    ShowDate();
                }
                else
                {
                    Response.Write("<script>alert('添加失败')</script>");
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="argds"></param>
        protected void ImageButton1_Click(object sender, EventArgs argds)
        {
            ImageButton btu = sender as ImageButton;
            int BID = Convert.ToInt32(btu.CommandArgument);
            if (BLCategoryDAL.delete(BID)>0)
            {
                //刷新数据
                ShowDate();
            }
            else
            {
                Response.Write("删除失败");
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="argds"></param>
        protected void imgbtu1_Click(object sender, EventArgs argds)
        { 
        
        }
    }
}