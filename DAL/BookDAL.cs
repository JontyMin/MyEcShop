using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class BookDAL
    {
        /// <summary>
        /// 书籍精品查询
        /// </summary>
        /// <returns></returns>
        public static List<Book> select()
        {
            List<Book> list=new List<Book>();
            string sql = "select top 5 * from dbo.Book Order by BSaleCount desc";
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql,null);
            while(sdr.Read())
            {
                Book b = new Book();
                b.BID = int.Parse(sdr["BID"].ToString());
                b.BSID = int.Parse(sdr["BSID"].ToString());
                b.BName = sdr["BName"].ToString();
                if (b.BName.Length > 10) b.BName = b.BName.Substring(0,11);
                b.BAuthor = sdr["BAuthor"].ToString();
                b.BISBN = sdr["BISBN"].ToString();
                b.BTOC = sdr["BTOC"].ToString();
                b.BComment=sdr["BComment"].ToString();
                if (b.BComment.Length > 10) b.BComment = b.BComment.Substring(0,10);
                b.BPic = sdr["BPic"].ToString();
                b.BPrice = Double.Parse(sdr["BPrice"].ToString());
                b.BCount = int.Parse(sdr["BCount"].ToString());
                b.BDate = DateTime.Parse(sdr["BDate"].ToString());
                b.BSaleCount = int.Parse(sdr["BSaleCount"].ToString());
                list.Add(b);
            }
            return list;
        }
        /// <summary>
        /// 查询书籍新品
        /// </summary>
        /// <returns></returns>
        public static List<Book> selectNes()
        {
            List<Book> list = new List<Book>();
            string sql = "select top 5 * from dbo.Book Order by BDate desc";
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql, null);
            while (sdr.Read())
            {
                Book b = new Book();
                b.BID = int.Parse(sdr["BID"].ToString());
                b.BSID = int.Parse(sdr["BSID"].ToString());
                b.BName = sdr["BName"].ToString();
                if (b.BName.Length > 10) b.BName = b.BName.Substring(0, 11);
                b.BAuthor = sdr["BAuthor"].ToString();
                b.BISBN = sdr["BISBN"].ToString();
                b.BTOC = sdr["BTOC"].ToString();
                b.BComment = sdr["BComment"].ToString();
                if (b.BComment.Length > 10) b.BComment = b.BComment.Substring(0, 10);
                b.BPic = sdr["BPic"].ToString();
                b.BPrice = Double.Parse(sdr["BPrice"].ToString());
                b.BCount = int.Parse(sdr["BCount"].ToString());
                b.BDate = DateTime.Parse(sdr["BDate"].ToString());
                b.BSaleCount = int.Parse(sdr["BSaleCount"].ToString());
                list.Add(b);
            }
            return list;
        }
        /// <summary>
        /// 根据书籍ID查询书籍详细信息
        /// </summary>
        /// <returns></returns>
        public static List<Book> selectByID(int id)
        {
            List<Book> list = new List<Book>();
            string sql = "select * from Book where BID=@id";
            SqlParameter[] pare = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql,pare);
            while (sdr.Read())
            {
                Book b = new Book();
                b.BID = int.Parse(sdr["BID"].ToString());
                b.BSID = int.Parse(sdr["BSID"].ToString());
                b.BName = sdr["BName"].ToString();
                if (b.BName.Length > 10) b.BName = b.BName.Substring(0, 11);
                b.BAuthor = sdr["BAuthor"].ToString();
                b.BISBN = sdr["BISBN"].ToString();
                b.BTOC = sdr["BTOC"].ToString();
                if (b.BTOC.Length > 100) b.BTOC = b.BTOC.Substring(0,100);
                b.BComment = sdr["BComment"].ToString();
                if (b.BComment.Length > 10) b.BComment = b.BComment.Substring(0, 10);
                b.BPic = sdr["BPic"].ToString();
                b.BPrice = Double.Parse(sdr["BPrice"].ToString());
                b.BCount = int.Parse(sdr["BCount"].ToString());
                b.BDate = DateTime.Parse(sdr["BDate"].ToString());
                b.BSaleCount = int.Parse(sdr["BSaleCount"].ToString());
                list.Add(b);
            }
            sdr.Close();
            return list;
        }
       /// <summary>
        /// 根据图书类型查询
       /// </summary>
       /// <param name="BLID">大类型id</param>
       /// <param name="BSID">小类型id</param>
       /// <returns></returns>
        public static List<Book> selectBookByType(string BLID, string BSID, int PageSize, int PageIndex, string BName)
        {
            string sql = string.Format("select top(4) * from Book where BID not in (select top({0}*({1}-1)) BID from Book where BName like  '%{2}%' )", PageSize, PageIndex,BName);
            if (BSID != null) sql = string.Format(@"select top(4) * from Book where BSID={0} and BID not in 
(select top({1}*({2}-1)) BID from Book where BSID={3})", Convert.ToInt32(BSID), PageSize, PageIndex, Convert.ToInt32(BSID));
            
            if (BLID != null) sql = string.Format(@"select top(4) * from dbo.Book b where BSID in 
(select BSID from BLCategory bl inner join BSCategory bs on bs.BLID=bl.BLID where bl.BLID={0}) 
and BID not in(select top({1}*({2}-1)) BID from Book where  
BSID in (select BSID from BLCategory bl inner join BSCategory bs on bs.BLID=bl.BLID where bl.BLID={3}))", Convert.ToInt32(BLID), PageSize, PageIndex, Convert.ToInt32(BLID));
            List<Book> list = new List<Book>();
            SqlDataReader sdr = DBHelp.MyExecuteReader(sql, null);
            while (sdr.Read())
            {
                Book b = new Book();
                b.BID = int.Parse(sdr["BID"].ToString());
                b.BSID = int.Parse(sdr["BSID"].ToString());
                b.BName = sdr["BName"].ToString();
                if (b.BName.Length > 10) b.BName = b.BName.Substring(0, 11);
                b.BAuthor = sdr["BAuthor"].ToString();
                b.BISBN = sdr["BISBN"].ToString();
                b.BTOC = sdr["BTOC"].ToString();
                b.BComment = sdr["BComment"].ToString();
                if (b.BComment.Length > 10) b.BComment = b.BComment.Substring(0, 10);
                b.BPic = sdr["BPic"].ToString();
                b.BPrice = Double.Parse(sdr["BPrice"].ToString());
                b.BCount = int.Parse(sdr["BCount"].ToString());
                b.BDate = DateTime.Parse(sdr["BDate"].ToString());
                b.BSaleCount = int.Parse(sdr["BSaleCount"].ToString());
                list.Add(b);
            }
            return list;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        }
        /// <summary>
        /// 查询总行数
        /// </summary>
        /// <returns></returns>
        public static int dataRows(string BLID, string BSID, string BName)
        {
            string sql = string.Format("select count(*) from Book where BName like '%{0}%'",BName);
            if (BSID != null) sql = string.Format("select count(*) from Book where BSID={0}", Convert.ToInt32(BSID));
            if (BLID != null) sql = string.Format("select count(*) from dbo.Book b where BSID in (select BSID from BLCategory bl inner join BSCategory bs on bs.BLID=bl.BLID where bl.BLID={0})", Convert.ToInt32(BLID));
            int count = Convert.ToInt32(DBHelp.MyExecuteScalar(sql, null));
            return count;
        }
        /// <summary>
        /// 根据书籍id删除书籍
        /// </summary>
        /// <param name="BID"></param>
        /// <returns></returns>
        public static int delete(int BID)
        {
            return DBHelp.MyExecuteNonQuery(string.Format("delete from Book where BID={0}", BID), null);
        }
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int addBook(Book b)
        {
            string sql = string.Format("insert into Book values({0},'{1}','{2}','{3}','','','{4}',{5},{6},getdate(),{7})", b.BSID, b.BName, b.BAuthor, b.BISBN, b.BPic, b.BPrice, b.BCount, b.BSaleCount);
            return DBHelp.MyExecuteNonQuery(sql, null);
        }
        /// <summary>
        /// 根据书籍id修改书籍信息
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int update(Book b)
        {
            string sql = string.Format("update Book set BSID={0},BName='{1}',BAuthor='{2}',BISBN='{3}',BPic='{4}',BPrice={5},BCount={6} where BID={7}", b.BSID, b.BName, b.BAuthor, b.BISBN, b.BPic, b.BPrice, b.BCount, b.BID);
            return DBHelp.MyExecuteNonQuery(sql, null);
        }
    }
}
