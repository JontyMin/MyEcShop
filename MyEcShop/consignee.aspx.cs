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
    public partial class consignee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if(Request.QueryString["ids"]==null)return;
                string ids=Request.QueryString["ids"];
                ids=ids.Substring(0,ids.Length-1);
                this.Repeater1.DataSource = TradeDAL.getTradeByMIDAndBIDS(Convert.ToInt32(Session["login"]), ids);
                this.Repeater1.DataBind();
                double sumPrice=0;
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Label lblprice = item.FindControl("lblPrice") as Label;
                    Label lblBCount = item.FindControl("lblBCount") as Label;
                    int price = Convert.ToInt32(lblprice.Text);
                    int count = Convert.ToInt32(lblBCount.Text);
                    sumPrice += price * count;
                }
                this.Label1.Text = sumPrice.ToString();
            }
        }
        protected void Button1_Click(object o, EventArgs e)
        {
            //1>.构建订单表对象:
            Order orders = new Order();
            orders.OID = OrdersDAL.GetNewOrderID();//订单编号
            orders.MID = Convert.ToInt32(Session["login"]);
            orders.ODate = Convert.ToDateTime(DateTime.Now.ToString());
            orders.OConsignee = this.txtName.Text;
            orders.OAddress = this.txtAddress.Text;
            orders.OTelephone = this.txtTel.Text;
            orders.OState = 1;//新订单
            //2>.构建订单详细表集合
            List<OrderDetails> listDetails = new List<OrderDetails>();
            //得到购物车集合
            if (Request.QueryString["ids"] == null) return;
            string ids = Request.QueryString["ids"];
            ids = ids.Substring(0, ids.Length - 1);
            List<Trade> listTrade = TradeDAL.getTradeByMIDAndBIDS(Convert.ToInt32(Session["login"]), ids);
            
            foreach (Trade trade in listTrade)
            {
                OrderDetails details = new OrderDetails();
                details.OID = orders.OID;//订单编号
                details.BID = trade.BID;//书籍编号
                details.BPrice = trade.BPrice;//书籍价格
                details.BCount = trade.BCount;//购买数量
                
                listDetails.Add(details);
            }
            orders.OSumPrice = Convert.ToInt32(this.Label1.Text);//总计;
            //保存订单:
            int count = OrdersDAL.SavaOrder(orders, listDetails);
            if (count > 0)
            {
                Response.Redirect("done.aspx?OID=" + orders.OID);
            }
        }
    }
}