using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_Login : DBConnection
    {
        public bool checkUser(string username, string password)
        {
            string sql = string.Format("select * from NguoiDung where Username = N'{0}' and Password = N'{1}'", username, password);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);        
            if (dt.Rows.Count > 0)
                return true;
            
            return false;
        }
    }
}
