namespace DAL.manage
{
	public class BLCategoryDAL
	{
		public static int selByname(string BLName) {
			return DBHelp.MyExecuteNonQuery(string.Format("select count(*) from dbo.BLCategory where BLName='{0}'",BLName),null);
		}
		/// <summary>
		/// 添加大类
		/// </summary>
		/// <returns></returns>
		public static int addBLCategory(string BLName)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("insert into BLCategory values('{0}')", BLName), null);
		}
		/// <summary>
		/// 根据大类ID删除大类
		/// </summary>
		/// <param name="BID"></param>
		/// <returns></returns>
		public static int delete(int BID)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("delete from BLCategory where BLID={0}", BID), null);
		}
		/// <summary>
		/// 根据id修改大类名称
		/// </summary>
		/// <param name="BLName"></param>
		/// <param name="BLID"></param>
		/// <returns></returns>
		public static int update(string BLName, int BLID)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("update BLCategory set BLName='{0}' where BLID={1}", BLName, BLID), null);
		}
	}
}
