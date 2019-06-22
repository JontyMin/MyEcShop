using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Security.Cryptography;

namespace DAL.manage
{
    public class AdminDAL
    {
        public static Admin CKLogin(string name, string pwd)
        {
            //一句话MD5加密
            //pwd = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(pwd))).Replace("-", "");
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@name", name);
            pars[1] = new SqlParameter("@pwd", pwd);
            using (SqlDataReader sdr = DBHelp.MyExecuteReader("select * from Admin where AName=@name and APassword=@pwd", pars))
            {
                if (sdr.Read())
                {
                    //登录成功,返回此用户的对象
                    Admin a = new Admin();
                    a.AID = int.Parse(sdr["AID"].ToString());
                    a.AName = sdr["AName"].ToString();
                    a.APassword = sdr["Apassword"].ToString();

                    return a;
                }
                else
                {
                    //登录失败，返回Null
                    return null;
                }
            }
        }
    }
}
