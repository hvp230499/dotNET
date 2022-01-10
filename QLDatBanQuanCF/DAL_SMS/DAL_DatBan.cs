using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_DatBan : DBConnection
    {
        public DataTable getDatBan()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ThongTinDatBan", con);
            DataTable daTable = new DataTable();
            da.Fill(daTable);

            return daTable;
        }

        public DataTable getDatBan(string key)
        {
            string sql = string.Format("select * from ThongTinDatBan where SoBan like '%{0}%' or SDTNguoiDat like '%{0}%'", key);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daTable = new DataTable();
            da.Fill(daTable);
            return daTable;
        }

        public bool themLich(int soBan, string thoiGianBatDau, string thoiGianKetThuc, string SDTNguoiDat)
        {
            string str = string.Format("insert into ThongTinDatBan(SoBan,ThoiGianBatDau,ThoiGianKetThuc,SDTNguoiDat) values ({0},N'{1}',N'{2}',N'{3}')", soBan, thoiGianBatDau, thoiGianKetThuc, SDTNguoiDat);
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

        public bool suaLich(int maDatBan , int soBan, string thoiGianBatDau, string thoiGianKetThuc, string SDTNguoiDat)
        {
            string str = string.Format("update ThongTinDatBan set SoBan={0}, ThoiGianBatDau = N'{1}', ThoiGianKetThuc = N'{2}', SDTNguoiDat = N'{3}' where MaDatBan={4}", soBan, thoiGianBatDau, thoiGianKetThuc, SDTNguoiDat, maDatBan);
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

        public bool xoaLich(int maDatBan)
        {
            string str = string.Format("delete from ThongTinDatBan where MaDatBan ={0}", maDatBan);
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
