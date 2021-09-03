using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using testJK2.service;

namespace testJK2
{
    /// <summary>
    /// TestWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
     [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {

        [WebMethod]//测试
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]//测试求和
        public string add(int x, int y)
        {
            //test
            int result = x + y;
            return getJsonResult(result + "");
        }



        [WebMethod]//验证登录
        public string getLogin(string userID,string psw)
        {
            LoginService loginServie = new LoginService();
            return getJsonResult(loginServie.getLogin(userID, psw)+"");
        }


        [WebMethod]//测试求和
        public string getTestData()
        {
            LoginService loginServie = new LoginService();
            return getJsonResult(loginServie.getTestData());
        }

        [WebMethod]//获取数据库
        public string getBaseDatabase()
        {
            CadreInfoService cadreInfoService = new CadreInfoService();
            return getJsonResult(cadreInfoService.getDataBase());
        }


        private string getJsonResult(string result)
        {
            Context.Response.Charset = "GB2312"; //设置字符集类型  
            Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Context.Response.Write(result);
            Context.Response.End();
            return result;
        }
    }
}
