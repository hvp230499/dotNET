using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;

namespace BUS_SMS
{
    public class BUS_Login
    {
        DAL_Login daLogin = new DAL_Login();
        public bool checkUser(string username, string password)
        {
            return daLogin.checkUser(username, password);
        }
    }
}
