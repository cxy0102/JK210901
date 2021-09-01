using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testJK2.helper
{
    public class SqlServerHelper
    {
        public static SqlConnection getSqlServerConnection() {
            //http://192.168.12.53:9012/TestWebService.asmx/add?x=10&y=12
            //string dbIP = "192.168.12.53";
            string dbIP = "192.168.3.183";
            string dbName = "cmis20190904230604";
            string dbUserName = "sa";
            string dbPwd = "abc123";
            string connStr = String.Format("Server = {0}; Database = {1}; UID = {2}; PWD = {3};", dbIP, dbName, dbUserName, dbPwd);
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            //aaa
            return conn;        
        }

        public static void closeSqlServerConnection(SqlConnection conn)
        {
            if(conn!=null)
                conn.Close();
        }
    }
}