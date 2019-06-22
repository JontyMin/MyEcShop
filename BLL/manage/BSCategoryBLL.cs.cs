using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.Admin
{
    public class BSCategoryBLL
    {
         /// <summary>
        /// 添加小类
        /// </summary>
        /// <param name="BLID"></param>
        /// <param name="BLName"></param>
        /// <returns></returns>
        public static int addBLCategory(int BLID, string BLName)
        {
            return BSCategoryDAL.addBLCategory(BLID,BLName);
        }
          /// <summary>
        /// 根据id修改
        /// </summary>
        /// <param name="BSID"></param>
        /// <param name="BLName"></param>
        /// <returns></returns>
        public static int updateByBSID(int BLID, string BLName,int BSID)
        {
            return BSCategoryDAL.updateByBSID(BLID,BLName,BSID);
        }
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="BSID"></param>
        /// <returns></returns>
        public static int deleteByBSID(int BSID)
        {
            return BSCategoryDAL.deleteByBSID(BSID);
        }
    }
}
