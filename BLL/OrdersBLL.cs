using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class OrdersBLL
    {
         /// <summary>
        /// 添加入订单表 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int addOrders(Order o)
        {
            return OrdersDAL.addOrders(o);
        }
          /// <summary>
        /// 查询订单表
        /// </summary>
        /// <returns></returns>
        public static List<Order> getOrders(string ID, string name,int PageSize, int PageIndex)
        {
            return OrdersDAL.getOrders(ID,name,PageSize,PageIndex);
        }
         /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int getOrdersRows(string ID, string name)
        {
            return OrdersDAL.getOrdersRows(ID,name);
        }
        /// <summary>
        /// 生成新订单编号
        /// </summary>
        /// <returns></returns>
        public static string GetNewOrderID()
        {
            return OrdersDAL.GetNewOrderID();
        }
        /// <summary>
        /// 保存订单
        /// </summary>
        /// <returns></returns>
        public static int SavaOrder(Order order, List<OrderDetails> listDeta)
        {
            return OrdersDAL.SavaOrder(order, listDeta);
        }
    }
}
