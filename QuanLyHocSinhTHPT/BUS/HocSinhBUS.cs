using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;

namespace QuanLyHocSinhTHPT.BUS
{
    class HocSinhBUS
    {
        public static DataTable LayDanhSachHocSinh(string DieuKien)
        {
            return HocSinhDAO.LayDanhSachHocSinh(DieuKien);
        }
        public static DataTable LayDanhSachHocSinhRutGon(string DieuKien)
        {
            return HocSinhDAO.LayDanhSachHocSinhRutGon(DieuKien);
        }
        public static HocSinh LayHocSinhTheoMa(string MaHocSinh)
        {
            return HocSinhDAO.LayHocSinhTheoMa(MaHocSinh);
        }
        public static void SuaHocSinh(HocSinh hocsinh)
        {
            HocSinhDAO.SuaHocSinh(hocsinh);
        }
        public static void XoaHocSinh(string MaHocSinh)
        {
            HocSinhDAO.XoaHocSinh(MaHocSinh);
        }
        public static void ThemHocSinh(HocSinh hocsinh)
        {
            HocSinhDAO.ThemHocSinh(hocsinh);
        }
    }
}
