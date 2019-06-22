using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL.Admin
{
    public class OrderDetailBLL
    {
        /// <summary>
        /// 根据订单号查询订单详细表
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static List<OrderDetails> getOrderDetailByOID(string OID)
        {
            return OrderDetailDAL.getOrderDetailByOID(OID);
        }
    }
}
