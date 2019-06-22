using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.manage;

namespace BLL.Admin
{
    public class BLCategoryBLL
    {
         /// <summary>
        /// 添加大类
        /// </summary>
        /// <returns></returns>
        public static int addBLCategory(string BLName)
        {
            return BLCategoryDAL.addBLCategory(BLName);
        }
         /// <summary>
        /// 根据大类ID删除大类
        /// </summary>
        /// <param name="BID"></param>
        /// <returns></returns>
        public static int delete(int BID)
        {
            return BLCategoryDAL.delete(BID);
        }
         /// <summary>
        /// 根据id修改大类名称
        /// </summary>
        /// <param name="BLName"></param>
        /// <param name="BLID"></param>
        /// <returns></returns>
        public static int update(string BLName, int BLID)
        {
            return BLCategoryDAL.update(BLName,BLID);
        }
    }
}
