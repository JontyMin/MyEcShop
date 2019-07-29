namespace DAL
{
	public class BSCategoryDAL
	{
		public static int selBystype(int BLID, string BSName) {
			return DBHelp.MyExecuteNonQuery(string.Format("select count(*) from dbo.BSCategory where BSName='{0}' and BLID={1}",BSName,BLID),null);
		}
		/// <summary>
		/// 添加大类
		/// </summary>
		/// <param name="BLID"></param>
		/// <param name="BLName"></param>
		/// <returns></returns>
		public static int addBLCategory(int BLID, string BSName)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("insert into BSCategory values({0},'{1}')", BLID, BSName), null);
		}
		/// <summary>
		/// 根据id修改
		/// </summary>
		/// <param name="BSID"></param>
		/// <param name="BLName"></param>
		/// <returns></returns>
		public static int updateByBSID(int BLID, string BLName, int BSID)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("update BSCategory set BLID={0},BSName='{1}' where BSID={2}", BLID, BLName, BSID), null);
		}
		/// <summary>
		/// 根据id删除
		/// </summary>
		/// <param name="BSID"></param>
		/// <returns></returns>
		public static int deleteByBSID(int BSID)
		{
			return DBHelp.MyExecuteNonQuery(string.Format("delete from BSCategory where BSID={0}", BSID), null);
		}
	}
}
