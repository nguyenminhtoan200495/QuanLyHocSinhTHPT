using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.Entity;

namespace QuanLyHocSinhTHPT.DAO
{
    class LopDAO
    {
        public static DataTable LayBangLop(string DieuKien)
        {
            DataTable dt = SqlConn.LayBang("Lop", DieuKien);            
            return dt;
        }
        public static DataTable LayDanhSachLop()
        {
            string TruyVan = "Select MaLop, TenLop, MaKhoiLop, MaNamHoc, SiSo, TenGiaoVien from Lop, GiaoVien where Lop.MaGiaoVien = GiaoVien.MaGiaoVien";
            DataTable dt = SqlConn.LayBang(TruyVan);
            return dt;
        }
        public static DataTable LayDanhSachLop(string Khoi, string NamHoc)
        {
            string TruyVan = "Select MaLop, TenLop, TenKhoiLop, TenNamHoc, SiSo, TenGiaoVien from Lop, GiaoVien, KhoiLop, NamHoc"
            + " where Lop.MaGiaoVien = GiaoVien.MaGiaoVien"
            + " and KhoiLop.MaKhoiLop = Lop.MaKhoiLop and NamHoc.MaNamHoc = Lop.MaNamHoc"
            +" and Lop.MaKhoiLop = '" + Khoi + "' and Lop.MaNamHoc ='" + NamHoc + "'";

            DataTable dt = SqlConn.LayBang(TruyVan);
            return dt;
        }
        public static void XoaLop(string MaLop)
        {
            SqlConn.XoaDong("PhanLop", "MaLop = '" + MaLop + "'");
            SqlConn.XoaDong("KQ_Ca_Nam_Mon_Hoc", "MaLop = '" + MaLop + "'");
            SqlConn.XoaDong("PhanCong", "MaLop = '" + MaLop + "'");
            SqlConn.XoaDong("KQ_Hoc_Ky_Mon_Hoc", "MaLop = '" + MaLop + "'");
            SqlConn.XoaDong("KQ_Ca_Nam_Tong_Hop", "MaLop = '" + MaLop + "'");
            SqlConn.XoaDong("KQ_Hoc_Ky_Tong_Hop", "MaLop = '" + MaLop + "'");
            SqlConn.SetNull("Diem", "MaLop", MaLop);

            SqlConn.XoaDong("Lop", "MaLop = '" + MaLop + "'");
        }
        public static void SuaLop(Lop lop)
        {
            string Query = "Update Lop set TenLop = '" + lop._TenLop + "', MaNamHoc = '" + lop._NamHoc._MaNamHoc + "', MaGiaoVien = '" + lop._GVCN._MaGiaoVien + "'";
            Query = Query + " where MaLop = '" + lop._MaLop + "'";

            SqlConn.ThucHienLenh(Query);
        }
        public static void ThemLop(Lop lop, int SiSo)
        {
            string Query = "Insert into Lop values('" + lop._MaLop + "', '" + lop._TenLop + "', '" + lop._KhoiLop._MaKhoiLop + "', '" + lop._NamHoc._MaNamHoc + "', " + SiSo + ", '" + lop._GVCN._MaGiaoVien + "')";
            SqlConn.ThucHienLenh(Query);
        }
        public static void PhanLop(string MaHocSinh, string MaNamHoc, string MaKhoiLop, string MaLop)
        {
            string Query = "Insert into PhanLop values('" + MaNamHoc + "', '" + MaKhoiLop + "', '" + MaLop + "', '" + MaHocSinh + "')";
            SqlConn.ThucHienLenh(Query);

            int SiSo = (int)SqlConn.ThucHienLenhCoTruyVan("Select SiSo from Lop where MaLop = '" + MaLop + "'");
            string ThemSiSo = "Update Lop set SiSo = " + (SiSo + 1).ToString() + " where MaLop = '" + MaLop + "'";
            SqlConn.ThucHienLenh(ThemSiSo);
        }
        public static Lop LayLopTheoMa(string MaLop)
        {
            Lop lop = new Lop(MaLop);
            DataTable dtLop = LayBangLop("MaLop = '" + MaLop + "'");

            lop._TenLop = dtLop.Rows[0].Field<string>("TenLop");
            lop._GVCN = new GiaoVienChuNhiem(dtLop.Rows[0].Field<string>("MaGiaoVien"));
            DataTable dtGVCN = GiaoVienDAO.LayBangGiaoVien("MaGiaoVien = '" + lop._GVCN._MaGiaoVien + "'");
            lop._GVCN._TenGiaoVien = dtGVCN.Rows[0].Field<string>("TenGiaoVien");
            lop._KhoiLop = new Khoi(dtLop.Rows[0].Field<string>("MaKhoiLop"));
            DataTable dtKhoi = SqlConn.LayBang("KhoiLop", "MaKhoiLop = '" + lop._KhoiLop._MaKhoiLop + "'");
            lop._KhoiLop._TenKhoiLop = dtKhoi.Rows[0].Field<string>("TenKhoiLop");
            lop._NamHoc = new NamHoc(dtLop.Rows[0].Field<string>("MaNamHoc"));
            DataTable dtNamHoc = NamHocDAO.LayBangNamHoc("MaNamHoc = '" + lop._NamHoc._MaNamHoc + "'");
            lop._NamHoc._TenNamHoc = dtNamHoc.Rows[0].Field<string>("TenNamHoc");

            return lop;
        }
        public static void LoaiHocSinhRaKhoiLop(string MaLop, string MaHocSinh)
        {
            SqlConn.XoaDong("PhanLop", "MaLop = '" + MaLop + "' and MaHocSinh = '" + MaHocSinh + "'");
        }
    }
}
