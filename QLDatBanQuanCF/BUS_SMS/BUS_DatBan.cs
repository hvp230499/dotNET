using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;
using System.Data;

namespace BUS_SMS
{
    public class BUS_DatBan
    {
        DAL_DatBan daDatBan = new DAL_DatBan();
        public DataTable getDatBan()
        {
            return daDatBan.getDatBan();
        }
        public DataTable getDatBan(string key)
        {
            return daDatBan.getDatBan(key);
        }
        public bool themLich(int soBan, string thoiGianBatDau, string thoiGianKetThuc, string SDTNguoiDat)
        {
            return daDatBan.themLich(soBan, thoiGianBatDau, thoiGianKetThuc, SDTNguoiDat);
        }
        public bool suaLich(int maDatBan, int soBan, string thoiGianBatDau, string thoiGianKetThuc, string SDTNguoiDat)
        {
            return daDatBan.suaLich(maDatBan, soBan, thoiGianBatDau, thoiGianKetThuc, SDTNguoiDat);
        }
        public bool xoaLich(int maDatBan)
        {
            return daDatBan.xoaLich(maDatBan);
        }
    }
}
