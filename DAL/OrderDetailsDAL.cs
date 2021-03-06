﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
	public class OrderDetailsDAL
	{
		/// <summary>
		/// 添加订单
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static int addOrderDetails(OrderDetails o)
		{
			string sql = string.Format("insert into OrderDetails values('{0}',{1},{2},{3})", o.OID, o.BID, o.BPrice, o.BCount);
			return DBHelp.MyExecuteNonQuery(sql, null);
		}
		/// <summary>
		/// 根据订单号查询订单详细表
		/// </summary>
		/// <param name="OID"></param>
		/// <returns></returns>
		public static List<OrderDetails> getOrderDetailByOID(string OID)
		{
			List<OrderDetails> list = new List<OrderDetails>();
			String sql = string.Format("select * from OrderDetails where OID=@OID");
			SqlParameter[] sp = new SqlParameter[] {
				new SqlParameter("@OID",OID)
			};
			using (SqlDataReader sdr = DBHelp.MyExecuteReader(sql, sp))
			{
				while (sdr.Read())
				{
					OrderDetails o = new OrderDetails();
					o.OID = sdr["OID"].ToString();
					o.BID = Convert.ToInt32(sdr["BID"]);
					o.BPrice = Convert.ToInt32(sdr["BPrice"]);
					o.BCount = Convert.ToInt32(sdr["BCount"]);
					list.Add(o);
				}
			}
			return list;
		}
	}
}
