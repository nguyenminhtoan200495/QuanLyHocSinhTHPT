using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.BUS
{
    class KhoiLopBUS
    {
        public static DataTable LayBangKhoiLop(string DieuKien)
        {
            return KhoiLopDAO.LayBangKhoiLop(DieuKien);
        }

        public static string PhatSinhMaKhoiLop(string TenKhoiLop)
        {
            string MaKhoiLop = "KHOI";

            MaKhoiLop += TenKhoiLop.Substring(TenKhoiLop.Length - 2);
            return MaKhoiLop;
        }
    }
}
