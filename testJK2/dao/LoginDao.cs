using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testJK2.dao
{
    interface LoginDao
    {
        Boolean getLogin(string userID, string psw);

        String getTestData();
    }
}
