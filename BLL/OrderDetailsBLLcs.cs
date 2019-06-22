using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class OrderDetailsBLLcs
    {
        public static int addOrderDetails(OrderDetails o)
        {
            return OrderDetailsDAL.addOrderDetails(o);
        }
    }
}
