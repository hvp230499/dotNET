using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_SMS;

namespace BUS_SMS
{
    public class BUS_Table
    {
        DAL_Table daTable = new DAL_Table();

        public DataTable getTable()
        {
            return daTable.getTable();
        }

        public DataTable getTable(string key)
        {
            return daTable.getTable(key);
        }

        public bool themBan(int soBan, int soChoNgoi, string viTri, string trangThai)
        {
            return daTable.themBan(soBan, soChoNgoi, viTri, trangThai);
        }

        public bool suaBan(int soBan, int soChoNgoi, string viTri, string trangThai)
        {
            return daTable.suaBan(soBan, soChoNgoi, viTri, trangThai);
        }

        public bool xoaBan(int soBan)
        {
            return daTable.xoaBan(soBan);
        }
    }
}
