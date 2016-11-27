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
    class NamHocBUS
    {
        public static DataTable LayBangNamHoc(string DieuKien)
        {
            return NamHocDAO.LayBangNamHoc(DieuKien);
        }

        public static string PhatSinhMaNamHoc(string TenNamHoc)
        {
            string MaNamHoc = "NH";
            TenNamHoc = TenNamHoc.Remove(4, 5);
            TenNamHoc = TenNamHoc.Remove(0, 2);

            MaNamHoc += TenNamHoc;
            return MaNamHoc;
        }
    }
}
