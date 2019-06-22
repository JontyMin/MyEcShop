using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class BookBLL
    {
        //书籍精品查询
        public static List<Book> select()
        {
            return BookDAL.select();
        }
        public static List<Book> selectNes()
        {
            return BookDAL.selectNes();
        }
        //根据书籍ID查询书籍详细信息
        public static List<Book> selectByID(int id)
        {
            return BookDAL.selectByID(id);
        }
        /// <summary>
        /// 根据图书类型查询
        /// </summary>
        /// <param name="BLID">大类型id</param>
        /// <param name="BSID">小类型id</param>
        /// <returns></returns>
        public static List<Book> selectBookByType(string BLID, string BSID, int PageSize, int PageIndex,string name)
        {
            return BookDAL.selectBookByType(BLID,BSID,PageSize,PageIndex,name);
        }
             //   <summary>
             //查询总行数
             //</summary>
             //<returns></returns>
            public static int dataRows(string BLID, string BSID,string name)
            {
                return BookDAL.dataRows(BLID,BSID,name);
            }
    }
}
