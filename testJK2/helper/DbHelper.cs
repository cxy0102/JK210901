using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace testJK2.helper
{
    public class DbHelper
    {
        public static string getSqlDataReaderData(string sql) {
            SqlConnection scnn = SqlServerHelper.getSqlServerConnection();
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
                    //datetime和int类型不能出现为空的情况,所以将其转换成字符串来进行处理。
                    //需要加""的
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
                    //不需要加""的
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
            //当读取到的数据为空，此时jsonString中只有一个字符"["
            if (jsonString.Length == 1)
            {
                jsonString.Append("]");
            }
            else//数据不为空
            {
                //所有数据读取完成，移除最后三个多余的",},"字符
                jsonString.Remove(jsonString.Length - 3, 3);
                jsonString.Append("}");
                jsonString.Append("]");
            }

            return jsonString.ToString();
        }
    }
}