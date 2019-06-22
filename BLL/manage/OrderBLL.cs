using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.manage;
using Model;

namespace BLL.Admin
{
    public class OrderBLL
    {
        /// <summary>
        /// 根据订单号查询订单表
        /// </summary>
        /// <returns></returns>
        public static List<Order> getOrdersByOID(string OID)
        {
            return OrdersDAL.getOrdersByOID(OID);
        }
         /// <summary>
        /// 根据订单号修改订单状态
        /// </summary>
        /// <returns></returns>
        public static int updateStateByOID(string OID)
        {
            return OrdersDAL.updateStateByOID(OID);
        }
         /// <summary>
        /// 查询订单状态
        /// </summary>
        /// <returns></returns>
        public static int selectOrderState(int state)
        {
            return OrdersDAL.selectOrderState(state);
        }
    }
}
