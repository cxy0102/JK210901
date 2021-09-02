using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using testJK2.helper;

namespace testJK2.dao.impl
{
    public class LoginDaoImpl : LoginDao
    {
        public bool getLogin(string userID, string psw)
        {
            SqlConnection scnn = SqlServerHelper.getSqlServerConnection();
            string result = "";
            //using (SqlCommand cmd = new SqlCommand(sql, scnn))
            //{
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        result = ToJsonArrayString(reader);
            //        SqlServerHelper.closeSqlServerConnection(scnn);
            //    }
            //}
            string sqls = @"SELECT * FROM [User] where  UserName=@UserName and PSW=@Password";

            SqlCommand cmd = new SqlCommand(sqls, scnn);
            cmd.Parameters.Add(new SqlParameter("@UserName", userID));
            cmd.Parameters.Add(new SqlParameter("@Password", psw));
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>   
        /// DataReaderת��ΪJson   
        /// </summary>   
        /// <param name="dataReader">DataReader����</param>   
        /// <returns>Json�ַ���(���飩</returns>   
        public static string ToJsonArrayString(SqlDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            while (dataReader.Read())
            {
                jsonString.Append("{");
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Type type = dataReader.GetFieldType(i);
                    string strKey = dataReader.GetName(i);
                    string strValue = dataReader[i].ToString();
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = String.Format(strValue, type);
                    //datetime��int���Ͳ��ܳ���Ϊ�յ����,���Խ���ת�����ַ��������д���
                    //��Ҫ��""��
                    if (type == typeof(string) || type == typeof(DateTime) || type == typeof(int))
                    {
                        if (i <= dataReader.FieldCount - 1)
                        {

                            jsonString.Append("\"" + strValue + "\",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    //����Ҫ��""��
                    else
                    {
                        if (i <= dataReader.FieldCount - 1)
                        {
                            jsonString.Append("" + strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                }

                jsonString.Append("},");
            }
            dataReader.Close();
            //����ȡ��������Ϊ�գ���ʱjsonString��ֻ��һ���ַ�"["
            if (jsonString.Length == 1)
            {
                jsonString.Append("]");
            }
            else//���ݲ�Ϊ��
            {
                //�������ݶ�ȡ��ɣ��Ƴ�������������",},"�ַ�
                jsonString.Remove(jsonString.Length - 3, 3);
                jsonString.Append("}");
                jsonString.Append("]");
            }

            return jsonString.ToString();
        }

        public string getTestData()
        {
            SqlConnection scnn = SqlServerHelper.getSqlServerConnection();

            string sql = "select * from CMIS_UNIT_LIBRARY order by InpFrq";
            string result = "";
            using (SqlCommand cmd = new SqlCommand(sql, scnn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    result = ToJsonArrayString(reader);
                    SqlServerHelper.closeSqlServerConnection(scnn);
                }
            }
            return result;
        }
    }
}