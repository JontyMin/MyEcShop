using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        //前台登录
        public static Member select(string name,string pwd)
        {
            return LoginDAL.select(name,pwd);
        }
        //注册新用户
        public static int add(Member m)
        {
            return LoginDAL.add(m);
        }

        //根据名字查询用户存在与否
        public static object selectByName(string name)
        {
            return LoginDAL.selectByName(name);
        }
    }
}
