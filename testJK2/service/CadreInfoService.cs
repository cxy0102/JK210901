using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testJK2.dao;
using testJK2.dao.impl;

namespace testJK2.service
{
    public class CadreInfoService : CadreInfoDao
    {
        public string getDataBase()
        {
            CadreInfoDao cadreDao = new CadreInfoDaoImpl();
            return cadreDao.getDataBase();
        }
    }
}