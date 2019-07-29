using Model;
using System.Data.SqlClient;

namespace DAL
{
	public class LoginDAL
	{
		/// <summary>
		/// 登录
		/// </summary>
		/// <returns></returns>
		public static Member select(string name, string pwd)
		{
			Member m = new Member();
			string sql = string.Format("select * from dbo.Member where MName = @name and MPassword =  @pwd");

			SqlParameter[] pare = new SqlParameter[]
		   {
			new SqlParameter("@name",name),
			new SqlParameter("@pwd",pwd)
		   };
			using (SqlDataReader sdr = DBHelp.MyExecuteReader(sql, pare))
			{
				while (sdr.Read())
				{
					m.MID = int.Parse(sdr["MID"].ToString());
					m.MName = sdr["MName"].ToString();
					m.MEmail = sdr["MEmail"].ToString();
					m.MPassword = sdr["MPassword"].ToString();
				}
			}
			return m;
		}
		/// <summary>
		/// 注册新用户
		/// </summary>
		/// <returns></returns>
		public static int add(Member m)
		{
			string sql = string.Format("insert into Member values(@name,@email,@pwd)");
			SqlParameter[] pare = new SqlParameter[]
			{
				new SqlParameter("@name",m.MName),
				new SqlParameter("@email",m.MEmail),
				new SqlParameter("@pwd",m.MPassword)
			};
			int count = DBHelp.MyExecuteNonQuery(sql, pare);
			return count;
		}

		/// <summary>
		/// 根据用户名判断用户存在与否
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static object selectByName(string name)
		{
			Member m = new Member();
			string sql = string.Format("select * from dbo.Member where MName = @name");
			SqlParameter[] pare = new SqlParameter[] { new SqlParameter("@name", name) };
			object o = DBHelp.MyExecuteScalar(sql, pare);
			return o;
		}
	}
}
