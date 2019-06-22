using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class TradeBLL
    {
         /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <returns></returns>
        public static int addTrade(int BID, int MID, int number)
        {
            return TradeDAL.addTrade(BID,MID,number);
        }
        /// <summary>
        /// 显示购物车
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static List<Trade> getTradeByMID(int MID)
        {
            return TradeDAL.getTradeByMID(MID);
        }
        /// <summary>
        /// 根据用户id和多个书籍id显示结账数据
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static List<Trade> getTradeByMIDAndBIDS(int MID, string ids)
        {
            return TradeDAL.getTradeByMIDAndBIDS(MID,ids);
        }
        /// <summary>
        /// 根据用户id查询购物车共有多小条数据
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static int getTradeRows(int MID)
        {
            return TradeDAL.getTradeRows(MID);
        }
         /// <summary>
        /// 根据id查询购物车里面的总价
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static double getTradeSumPriceByMID(int MID)
        {
            return TradeDAL.getTradeSumPriceByMID(MID);
        }
         /// <summary>
        /// 根据id删除购物车
        /// </summary>
        /// <param name="TID"></param>
        /// <returns></returns>
        public static int DeleteByTID(int TID)
        {
            return TradeDAL.DeleteByTID(TID);
        }
         /// <summary>
        /// 修改数量
        /// </summary>
        /// <returns></returns>
        public static int UpdateByTID(int TID, int BCount)
        {
            return TradeDAL.UpdateByTID(TID,BCount);
        }
    }
}
