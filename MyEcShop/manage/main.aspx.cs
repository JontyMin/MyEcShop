using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.manage;
using DAL;

namespace MyEcShop.manage
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Label1.Text = OrdersDAL.selectOrderState(1).ToString();
                this.Label2.Text = OrdersDAL.selectOrderState(2).ToString();
                this.Label3.Text = OrdersDAL.selectOrderState(3).ToString();
                this.Label4.Text = OrdersDAL.selectOrderState(4).ToString();
            }
        }
    }
}