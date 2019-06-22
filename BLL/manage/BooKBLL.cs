using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.manage;
using Model;

namespace BLL.Admin
{
    public class BooKBLL
    {
         /// <summary>
        /// 根据书籍id删除书籍
        /// </summary>
        /// <param name="BID"></param>
        /// <returns></returns>
        public static int delete(int BID)
        {
            return BooKDAL.delete(BID);
        }
          /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int addBook(Book b)
        {
            return BooKDAL.addBook(b);
        }
         /// <summary>
        /// 根据书籍id修改书籍信息
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int update(Book b)
        {
            return BooKDAL.update(b);
        }
    }
}
