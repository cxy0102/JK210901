using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testJK2.helper;

namespace testJK2.dao.impl
{
    public class CadreInfoDaoImpl : CadreInfoDao
    {
        public string getDataBase()
        {
            string sql= "select * from CMIS_UNIT_LIBRARY order by InpFrq";
            return DbHelper.getSqlDataReaderData(sql);
        }
    }
}