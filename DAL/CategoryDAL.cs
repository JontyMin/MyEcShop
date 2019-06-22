using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoryDAL
    {
        /// <summary>
        /// 查询大类节点
        /// </summary>
        /// <returns></returns>
        public static List<BLCategory> getBLCategoryList()
        {
            List<BLCategory> list = new List<BLCategory>();
            SqlDataReader sdr = DBHelp.MyExecuteReader("select * from BLCategory",null);
            while (sdr.Read())
            {
                BLCategory bl = new BLCategory();
                bl.BLID = Convert.ToInt32(sdr["BLID"]);
                bl.BLName = sdr["BLName"].ToString();
                list.Add(bl);
            }
            return list;
        }
        /// <summary>
        /// 查询小类节点
        /// </summary>
        /// <returns></returns>
        public static List<BSCategory> getBSCategoryList(int BLID)
        {
            List<BSCategory> list = new List<BSCategory>();
            SqlDataReader sdr = DBHelp.MyExecuteReader(string.Format("select * from BSCategory where BLID={0}",BLID), null);
            while (sdr.Read())
            {
                BSCategory bs = new BSCategory();
                bs.BLID = Convert.ToInt32(sdr["BLID"]);
                bs.BSID = Convert.ToInt32(sdr["BSID"]);
                bs.BSName = sdr["BSName"].ToString();
                list.Add(bs);
            }
            return list;
        }
        /// <summary>
        /// 查询大，小类节点
        /// </summary>
        /// <returns></returns>
        public static List<BSCategory> getBSCategoryList()
        {
            List<BSCategory> list = new List<BSCategory>();
            SqlDataReader sdr = DBHelp.MyExecuteReader("select * from dbo.BLCategory l inner join dbo.BSCategory s on l.BLID=s.BLID", null);
            while (sdr.Read())
            {
                BSCategory bs = new BSCategory();
                bs.BLID = Convert.ToInt32(sdr["BLID"]);
                bs.BSID = Convert.ToInt32(sdr["BSID"]);
                bs.BLName = sdr["BLName"].ToString();
                bs.BSName = sdr[4].ToString();
                list.Add(bs);
            }
            return list;
        }
    }
}
