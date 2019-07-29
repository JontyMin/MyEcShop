using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
	public class TradeDAL
	{
		/// <summary>
		/// 添加到购物车
		/// </summary>
		/// <returns></returns>
		public static int addTrade(int BID, int MID, int number)
		{
			SqlParameter[] sp = new SqlParameter[] {
				new SqlParameter("@BID",BID),
				new SqlParameter("@MID",MID),
				new SqlParameter("@number",number)
			};
			string sql = string.Format("insert into Trade values(@BID,@MID,@number)");
			return DBHelp.MyExecuteNonQuery(sql, sp);
		}
		/// <summary>
		/// 根据用户id和多个书籍id显示结账数据
		/// </summary>
		/// <param name="MID"></param>
		/// <returns></returns>
		public static List<Trade> getTradeByMIDAndBIDS(int MID, string ids)
		{
			List<Trade> list = new List<Trade>();
			string sql = string.Format("select * from Trade inner join Book on Trade.BID=Book.BID where MID={0} and Trade.TID in ({1})", MID, ids);
			using (SqlDataReader sdr = DBHelp.MyExecuteReader(sql, null))
			{
				while (sdr.Read())
				{
					Trade t = new Trade();
					t.TID = Convert.ToInt32(sdr["TID"]);
					t.BID = Convert.ToInt32(sdr["BID"]);
					t.MID = Convert.ToInt32(sdr["MID"]);
					t.BCount = Convert.ToInt32(sdr["BCount"]);
					t.BName = sdr["BName"].ToString();
					t.BPic = sdr["BPic"].ToString();
					t.BPrice = Convert.ToInt32(sdr["BPrice"]);
					list.Add(t);
				}
			}
			
		
			return list;
		}
		/// <summary>
		/// 根据id显示购物车
		/// </summary>
		/// <param name="MID"></param>
		/// <returns></returns>
		public static List<Trade> getTradeByMID(int MID)
		{
			List<Trade> list = new List<Trade>();
			string sql = "select * from Trade inner join Book on Trade.BID=Book.BID where MID=@MID";
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@MID",MID)
			};
			using (SqlDataReader sdr = DBHelp.MyExecuteReader(sql, pare))
			{
				while (sdr.Read())
				{
					Trade t = new Trade();
					t.TID = Convert.ToInt32(sdr["TID"]);
					t.BID = Convert.ToInt32(sdr["BID"]);
					t.MID = Convert.ToInt32(sdr["MID"]);
					t.BCount = Convert.ToInt32(sdr["BCount"]);
					t.BName = sdr["BName"].ToString();
					t.BPic = sdr["BPic"].ToString();
					t.BPrice = Convert.ToInt32(sdr["BPrice"]);
					list.Add(t);
				}
			}
			
			
			return list;
		}
		/// <summary>
		/// 根据用户Mid查询购物车数据行
		/// </summary>
		/// <param name="MID"></param>
		/// <returns></returns>
		public static int getTradeRows(int MID)
		{
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@MID",MID)
			};
			try
			{
				return Convert.ToInt32(DBHelp.MyExecuteScalar("select count(*) from Trade where MID=@MID", pare));
			}
			catch (Exception)
			{

				return 0;
			}
		}
		/// <summary>
		/// 根据MID查询购物车里面的总价
		/// </summary>
		/// <param name="MID"></param>
		/// <returns></returns>
		public static double getTradeSumPriceByMID(int MID)
		{
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@MID",MID)
			};
			try
			{
				return Convert.ToDouble(DBHelp.MyExecuteScalar("select sum(Trade.BCount*BPrice) from Trade inner join Book on Trade.BID=Book.BID where MID=@MID", pare));
			}
			catch (Exception)
			{

				return 0;
			}
		}
		/// <summary>
		/// 根据id删除购物车
		/// </summary>
		/// <param name="TID"></param>
		/// <returns></returns>
		public static int DeleteByTID(int TID)
		{
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@TID",TID)
			};

			return DBHelp.MyExecuteNonQuery("delete  from Trade where TID=@TID", pare);
		}
		/// <summary>
		/// 修改数量
		/// </summary>
		/// <returns></returns>
		public static int UpdateByTID(int TID, int BCount)
		{
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@TID",TID),
				new SqlParameter("@BCount",BCount)
			};
			string sql = "update Trade set BCount=@BCount where BID=@TID";
			return DBHelp.MyExecuteNonQuery(sql, pare);
		}

		/// <summary>
		/// 修改库存
		/// </summary>
		/// <param name="number"></param>
		/// <param name="bid"></param>
		/// <returns>影响行数</returns>
		public static int updateBcountByid(int number,int bid) {
			String sql = string.Format("update Book set BCount-=@number where BID=@bid");
			SqlParameter[] sp = new SqlParameter[] {

				new SqlParameter("@number",number),
				new  SqlParameter("@bid",bid)
			};
			return DBHelp.MyExecuteNonQuery(sql,sp);
		}

		/// <summary>
		/// 修改Bcount
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public static int update_Bcount(Trade t) {
			String sql = string.Format("update Trade set BCount+=@BCount where MID=@MID and BID=@BID");
			SqlParameter[] sp = new SqlParameter[] {
				new SqlParameter("@BCount",t.BCount),
				new SqlParameter("@MID",t.MID),
				new SqlParameter("@BID",t.BID),
			};
			return DBHelp.MyExecuteNonQuery(sql,sp);
		}
		/// <summary>
		/// 判断数据是否存在
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public static bool Exits(Trade t) {
			String sql = string.Format("select count(*) from trade where Bid=@Bid and Mid=@Mid");
			SqlParameter[] sp = new SqlParameter[] {
				new SqlParameter("@Bid",t.BID),
				new SqlParameter("@Mid",t.MID)
			};
			return Convert.ToInt32(DBHelp.MyExecuteScalar(sql, sp)) > 0 ? true : false;
		}
    }
}
