using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DAL
{
    public class DBHelp
    {
        private static string ConStr = ConfigurationManager.ConnectionStrings["con"].ToString();
        /// <summary>
        /// 执行增删改 返回int类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int MyExecuteNonQuery(string sql, SqlParameter[] parame)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConStr))
            {
                sqlcon.Open();
                SqlCommand sqlcomm = new SqlCommand(sql, sqlcon);
                if (parame != null)
                {
                    sqlcomm.Parameters.AddRange(parame);
                }
                int count = sqlcomm.ExecuteNonQuery();
                return count;
            }
        }
        /// <summary>
        /// 执行查询单值 返回object类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object MyExecuteScalar(string sql, SqlParameter[] parame)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConStr))
            {
                sqlcon.Open();
                SqlCommand sqlcomm = new SqlCommand(sql, sqlcon);
                if (parame != null)
                {
                    sqlcomm.Parameters.AddRange(parame);
                }
                object result = sqlcomm.ExecuteScalar();
                return result;
            }
        }
        /// <summary>
        /// 查询一列多行/多列多行 返回SqlDataReader对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader MyExecuteReader(string sql, SqlParameter[] pars)
        {
			SqlConnection sqlcon = new SqlConnection(ConStr);
				sqlcon.Open();
				SqlCommand sqlcomm = new SqlCommand(sql, sqlcon);
				if (pars != null)
				{
					sqlcomm.Parameters.AddRange(pars);
				}
				SqlDataReader dr = sqlcomm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				return dr;

			


		}
        /// <summary>
        /// 查询一列多行/多列多行 返回DataSet数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] parame)
        {
			using (SqlConnection sqlcon = new SqlConnection(ConStr))
			{
				SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
				if (parame != null)
				{
					sqlda.SelectCommand.Parameters.AddRange(parame);
				}
				DataSet ds = new DataSet();
				sqlda.Fill(ds);
				return ds;
			}
		
				
			
         
        
        }
    }
}
