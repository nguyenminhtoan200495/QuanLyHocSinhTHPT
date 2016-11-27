using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.Entity;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.BUS
{
    public class GlobalEntity
    {
        //public static Quyen _quyen { get; set; }
        //public static string _NguoiDung { get; set; }
        public static NguoiDung _Acc;
        public static void LoadData()
        {
            
        }
        public static int LayChiSo(DataTable table, string TenThuocTinh, string GiaTri)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i].Field<string>(TenThuocTinh) == GiaTri) return i;
            }
            return -1;
        }
        public static object LayGiaTriTheoKhoa(string TenBang, string ThuocTinh, string TenKhoa, string GiaTriKhoa)
        {
            return SqlConn.LayGiaTriTheoKhoa(TenBang, ThuocTinh, TenKhoa, GiaTriKhoa);
        }
        public static DataTable LayBang(string TruyVan)
        {
            return SqlConn.LayBang(TruyVan);
        }
        public static DataTable LayBang(string TenBang, string DieuKien)
        {
            return SqlConn.LayBang(TenBang, DieuKien);
        }
        public static string PhatSinhMaHocSinh()
        {
            DataTable dtHocSinh = HocSinhBUS.LayDanhSachHocSinhRutGon("");
            string MaHocSinh = dtHocSinh.Rows[dtHocSinh.Rows.Count - 1].Field<string>("MaHocSinh");
            MaHocSinh = MaHocSinh.Remove(0, 2);
            int STT = int.Parse(MaHocSinh);
            STT++;
            MaHocSinh = STT.ToString();
            while (MaHocSinh.Length < 4) MaHocSinh = "0" + MaHocSinh;
            MaHocSinh = "HS" + MaHocSinh;
            return MaHocSinh;
        }
        public static string PhatSinhMaGiaoVien()
        {
            DataTable dtGiaoVien = GiaoVienBUS.LayBangGiaoVien("");
            string MaGiaoVien = dtGiaoVien.Rows[dtGiaoVien.Rows.Count - 1].Field<string>("MaGiaoVien");
            MaGiaoVien = MaGiaoVien.Remove(0, 2);
            int STT = int.Parse(MaGiaoVien);
            STT++;
            MaGiaoVien = STT.ToString();
            while (MaGiaoVien.Length < 4) MaGiaoVien = "0" + MaGiaoVien;
            MaGiaoVien = "GV" + MaGiaoVien;
            return MaGiaoVien;
        }
        public static void CapNhat(string TenBang, string ThuocTinh, string GiaTri, string DieuKien)
        {
            SqlConn.CapNhat(TenBang, ThuocTinh, GiaTri, DieuKien);
        }
        public static void XoaDong(string TenBang, string DieuKien)
        {
            SqlConn.XoaDong(TenBang, DieuKien);
        }
        public static void ThucHienLenh(string TruyVan)
        {
            SqlConn.ThucHienLenh(TruyVan);
        }
        public static object ThucHienLenhCoTruyVan(string TruyVan)
        {
            return SqlConn.ThucHienLenhCoTruyVan(TruyVan);
        }
        public static void CapNhatSiSoLop(string MaLop)
        {
        }       
    }
}
