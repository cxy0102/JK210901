using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace testJK2
{
    /// <summary>
    /// TestWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {

        [WebMethod]//测试
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]//测试求和
        public int add(int x, int y)
        {
            return x+y;
        }
    }
}
