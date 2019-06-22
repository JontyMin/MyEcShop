using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class OrdersDAL
    {
        /// <summary>
        /// 添加入订单表 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int addOrders(Order o)
        {
            string sql = string.Format("insert into Orders values('{0}',{1},getdate(),'{2}','{3}','{4}',{5},{6})", o.OID, o.MID, o.OConsignee,o.OAddress,o.OTelephone,o.OSumPrice,o.OState);
            return DBHelp.MyExecuteNonQuery(sql, null);
        }
        /// <summary>
        /// 查询订单表
        /// </summary>
        /// <returns></returns>
        public static List<Order> getOrders(string ID, string name, int PageSize, int PageIndex)
        {
            List<Order> list = new List<Order>();
            string sql = string.Format("select top(5) * from dbo.Orders where OID not in(select top({0}*({1}-1)) OID from Orders where OID like '%{2}%' and OConsignee like '%{3}%') and OID like '%{4}%' and OConsignee like '%{5}%'", PageSize, PageIndex, ID, name,ID,name);
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql,null);
            while (sdr.Read())
            {
                Order o = new Order();
                o.MID = Convert.ToInt32(sdr["MID"]);
                o.OAddress = sdr["OAddress"].ToString();
                o.OConsignee = sdr["OConsignee"].ToString();
                o.ODate = Convert.ToDateTime(sdr["ODate"]);
                o.OID = sdr["OID"].ToString();
                o.OState = Convert.ToInt32(sdr["OState"]);
                o.OSumPrice = Convert.ToInt32(sdr["OSumPrice"]);
                o.OTelephone = sdr["OTelephone"].ToString();
                list.Add(o);
            }
            return list;
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int getOrdersRows(string ID,string name)
        {
            string sql = string.Format("select count(*) from dbo.Orders where OID like '%{0}%' and OConsignee like '%{1}%'",ID,name);
            int count = Convert.ToInt32(DBHelp.MyExecuteScalar(sql, null));
            return count;
        }
        /// <summary>
        /// 生成新订单编号
        /// </summary>
        /// <returns></returns>
        public static string GetNewOrderID()
        {
            
            string newOderID = "DD";
            string NewDate = DateTime.Now.ToString("yyyyMMdd");
            string sql = "select max(OID) from Orders";
            //最大的订单号
            string maxOrderID = DBHelp.MyExecuteScalar(sql, null).ToString();
            //截取日期部分
            if (maxOrderID != "" && maxOrderID.Substring(2, 8) == NewDate)//如果当天存在了订单
            {
                //就在当天订单的后面+1
                //1000?
                int ls = Convert.ToInt32(maxOrderID.Substring(maxOrderID.Length - 4)) + 1 + 10000; //获取最后4位流水码
                //流水码
                string lsm = ls.ToString().Substring(1);
                //新订单
                newOderID = newOderID + NewDate + lsm;
            }
            else//如果当天不存在订单
            {
                //新订单
                newOderID = newOderID + NewDate + "0001";
            }
            return newOderID;
        }
        /// <summary>
        /// 保存订单
        /// </summary>
        /// <returns></returns>
        public static int SavaOrder(Order order, List<OrderDetails> listDeta)
        {
            int count = 0;
            try
            {

                //--1>.插入订单表
                AddOrders(order);
                foreach (OrderDetails deta in listDeta)
                {
                    //--2>.插入订单详细表
                    AddOrderDetails(deta);
                    //--3>.消除相应的购物车数据
                    DeleteTrade(order, deta);
                    //--4>.修改书籍表中的库存数量:BCount和 销量:BSaleCount
                    UpdateBookNum(deta);
                }
                count = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return count;
        }

        /// <summary>
        /// 插入订单表
        /// </summary>
        /// <returns></returns>
        private static int AddOrders(Order order)
        {
            //--1>.插入订单表
            string sql = string.Format(@"insert into Orders(OID,MID,ODate,OConsignee,OAddress,OTelephone,OSumPrice,OState)
values('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})", order.OID, order.MID, order.ODate, order.OConsignee, order.OAddress, order.OTelephone, order.OSumPrice, order.OState);
            int count = DBHelp.MyExecuteNonQuery(sql, null);
            return count;
        }
        /// <summary>
        /// 插入订单详细表
        /// </summary>
        /// <param name="listDeta"></param>
        /// <returns></returns>
        private static int AddOrderDetails(OrderDetails deta)
        {
            string sql = string.Format(@"insert into OrderDetails(OID,BID,BPrice,BCount)
values('{0}',{1},{2},{3})", deta.OID, deta.BID, deta.BPrice, deta.BCount);
            int count = DBHelp.MyExecuteNonQuery(sql, null);
            return count;
        }

        private static int DeleteTrade(Order order, OrderDetails deta)
        {
            string sql = string.Format(@"delete Trade where BID={0} and MID={1}",
                 deta.BID, order.MID);
            int count = DBHelp.MyExecuteNonQuery(sql, null);
            return count;
        }
        private static int UpdateBookNum(OrderDetails deta)
        {
            string sql = string.Format(@"update Book set BCount=BCount-{0},BSaleCount=BSaleCount+{0}
where BID={1}", deta.BCount, deta.BID);
            int count = DBHelp.MyExecuteNonQuery(sql, null);
            return count;
        }
        /// <summary>
        /// 根据订单号查询订单表
        /// </summary>
        /// <returns></returns>
        public static List<Order> getOrdersByOID(string OID)
        {
            List<Order> list = new List<Order>();
            string sql = string.Format("select * from dbo.Orders where OID='{0}'", OID);
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql, null);
            while (sdr.Read())
            {
                Order o = new Order();
                o.MID = Convert.ToInt32(sdr["MID"]);
                o.OAddress = sdr["OAddress"].ToString();
                o.OConsignee = sdr["OConsignee"].ToString();
                o.ODate = Convert.ToDateTime(sdr["ODate"]);
                o.OID = sdr["OID"].ToString();
                o.OState = Convert.ToInt32(sdr["OState"]);
                o.state = "新订单";
                switch (o.OState)
                {
                    case 1: o.state = "新订单";
                        break;
                    case 2: o.state = "确认订单";
                        break;
                    case 3: o.state = "发货订单";
                        break;
                    default: o.state = "成交订单";
                        break;
                }
                o.OSumPrice = Convert.ToInt32(sdr["OSumPrice"]);
                o.OTelephone = sdr["OTelephone"].ToString();
                list.Add(o);
            }
            return list;
        }
        /// <summary>
        /// 根据订单号修改订单状态
        /// </summary>
        /// <returns></returns>
        public static int updateStateByOID(string OID)
        {
            string sql = string.Format("update Orders set OState=OState+1 where OID='{0}'", OID);
            return DBHelp.MyExecuteNonQuery(sql, null);
        }
        /// <summary>
        /// 查询订单状态
        /// </summary>
        /// <returns></returns>
        public static int selectOrderState(int state)
        {
            int count = 0;
            string sql = string.Format("select count(*) from Orders where OState={0}", state);
            object obj = DBHelp.MyExecuteScalar(sql, null);
            try
            {
                count = Convert.ToInt32(obj);
            }
            catch (Exception)
            {

            }
            return count;
        }

    }
}
