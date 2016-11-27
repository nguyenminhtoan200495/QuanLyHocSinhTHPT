using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.BUS
{
    class LopBUS
    {       
        public static DataTable LayDanhSachLop()
        {
            return LopDAO.LayDanhSachLop();
        }
        public static DataTable LayDanhSachLop(string KhoiLop, string NamHoc)
        {
            return LopDAO.LayDanhSachLop(KhoiLop, NamHoc);
        }
        public static void XoaLop(string MaLop)
        {
            LopDAO.XoaLop(MaLop);
        }
        public static DataTable LayBangLop(string DieuKien)
        {
            return LopDAO.LayBangLop(DieuKien);
        }
        public static void SuaLop(Lop lop)
        {
            LopDAO.SuaLop(lop);
        }
        public static string PhatSinhMaLop(string TenLop, string MaKhoiLop, string MaNamHoc)
        {
            string MaLop = "LOP";
            MaLop = MaLop + MaKhoiLop.Remove(0, 4) + TenLop.Remove(0, 3) + MaNamHoc.Remove(0, 2);
            return MaLop;
        }
        public static void ThemLop(Lop lop, int SiSo)
        {
            LopDAO.ThemLop(lop, SiSo);
        }
        public static void PhanLop(string MaHocSinh, string MaNamHoc, string MaKhoiLop, string MaLop)
        {
            LopDAO.PhanLop(MaHocSinh, MaNamHoc, MaKhoiLop, MaLop);
        }
        public static Lop LayLopTheoMa(string MaLop)
        {
            return LopDAO.LayLopTheoMa(MaLop);
        }
        public static void LoaiHocSinhRaKhoiLop(string MaLop, string MaHocSinh)
        {
            LopDAO.LoaiHocSinhRaKhoiLop(MaLop, MaHocSinh);
        }
    }
}
