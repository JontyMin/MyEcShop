using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CategoryBLL
    {
        /// <summary>
        /// 查询所有大类
        /// </summary>
        /// <returns></returns>
        public static List<BLCategory> getBLCategoryList()
        {
            return CategoryDAL.getBLCategoryList();
        }
           /// <summary>
        /// 查询小类节点
        /// </summary>
        /// <returns></returns>
        public static List<BSCategory> getBSCategoryList(int BLID)
        {
            return CategoryDAL.getBSCategoryList(BLID);
        }
        /// <summary>
        /// 查询大，小类节点
        /// </summary>
        /// <returns></returns>
        public static List<BSCategory> getBSCategoryList()
        {
            return CategoryDAL.getBSCategoryList();
        }
    }
}
