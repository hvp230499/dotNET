using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_Table: DBConnection
    {
        public DataTable getTable()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Ban Order By TrangThai", con);
            DataTable daTable = new DataTable();
            da.Fill(daTable);

            return daTable;
        }

        public DataTable getTable(string key)
        {
            string sql = string.Format("select * from Ban where SoBan like '%{0}%' or SoChoNgoi like '%{0}%' or ViTri like '%{0}%' Order By TrangThai", key);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daTable = new DataTable();
            da.Fill(daTable);
            return daTable;
        }

        public bool themBan(int soBan, int soChoNgoi, string viTri, string trangThai)
        {
            string str = string.Format("insert into Ban(SoBan,SoChoNgoi,ViTri,TrangThai) values ({0},{1},N'{2}',N'{3}')", soBan, soChoNgoi, viTri, trangThai);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        public bool suaBan(int soBan, int soChoNgoi, string viTri, string trangThai)
        {
            string str = string.Format("update ban set SoChoNgoi={0}, ViTri = N'{1}', TrangThai = N'{2}' where SoBan={3}", soChoNgoi, viTri, trangThai, soBan);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        public bool xoaBan(int soBan)
        {
            string str = string.Format("delete from Ban where SoBan ={0}", soBan);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
    }
}
