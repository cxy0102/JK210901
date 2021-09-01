using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testJK2.dao;
using testJK2.dao.impl;

namespace testJK2.service
{
    public class LoginService : LoginDao
    {
        public bool getLogin(string userID, string psw)
        {
            LoginDao changePswDao = new LoginDaoImpl();
            return changePswDao.getLogin(userID, psw);
        }

        public string getTestData()
        {
            LoginDao changePswDao = new LoginDaoImpl();
            return changePswDao.getTestData();
        }
    }
}