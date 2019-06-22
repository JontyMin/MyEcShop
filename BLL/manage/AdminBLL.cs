using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.manage;

namespace BLL.Admin
{
    public class AdminBLL
    {
        public static object CKLogin(string name, string pwd)
        {
            return AdminDAL.CKLogin(name,pwd);
        }
    }
}
