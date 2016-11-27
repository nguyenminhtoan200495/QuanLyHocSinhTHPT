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
    class HocSinhDAO
    {
        public static DataTable LayDanhSachHocSinh(string DieuKien)
        {
            return SqlConn.LayBang("HocSinh", DieuKien);
        }
        public static DataTable LayDanhSachHocSinhRutGon(string DieuKien)
        {
            string Query = "Select MaHocSinh, HoTen from HocSinh";
            if (DieuKien != "") Query += " Where " + DieuKien;
            return SqlConn.LayBang(Query);
        }
        public static HocSinh LayHocSinhTheoMa(string MaHocSinh)
        {
            HocSinh hocsinh = new HocSinh(MaHocSinh);
            DataTable dtHocSinh = HocSinhDAO.LayDanhSachHocSinh("MaHocSinh = '" + MaHocSinh + "'");

            hocsinh._Ten = dtHocSinh.Rows[0].Field<string>("HoTen");
            hocsinh._HoTenCha = dtHocSinh.Rows[0].Field<string>("HoTenCha");
            hocsinh._HoTenMe = dtHocSinh.Rows[0].Field<string>("HoTenMe");
            hocsinh._NgaySinh = dtHocSinh.Rows[0].Field<DateTime>("NgaySinh");
            hocsinh._NoiSinh = dtHocSinh.Rows[0].Field<string>("NoiSinh");
            hocsinh._DanToc = new DanToc(dtHocSinh.Rows[0].Field<string>("MaDanToc"));
            DataTable dtDanToc = SqlConn.LayBang("DanToc", "MaDanToc = '" + hocsinh._DanToc._MaDanToc + "'");
            hocsinh._DanToc._TenDanToc = dtDanToc.Rows[0].Field<string>("TenDanToc");
            hocsinh._TonGiao = new TonGiao(dtHocSinh.Rows[0].Field<string>("MaTonGiao"));
            DataTable dtTonGiao = SqlConn.LayBang("TonGiao", "MaTonGiao = '" + hocsinh._TonGiao._MaTonGiao + "'");
            hocsinh._TonGiao._TenTonGiao = dtTonGiao.Rows[0].Field<string>("TenTonGiao");
            hocsinh._NgheNghiepCha = dtHocSinh.Rows[0].Field<string>("NgheNghiepCha");
            hocsinh._NgheNghiepMe = dtHocSinh.Rows[0].Field<string>("NgheNghiepMe");

            if (dtHocSinh.Rows[0].Field<bool>("GioiTinh")) hocsinh._GioiTinh = GioiTinh.nu;
            else hocsinh._GioiTinh = GioiTinh.nam;

            return hocsinh;
        }
        public static void SuaHocSinh(HocSinh hocsinh)
        {
            string Query = "Update HocSinh set HoTen = N'" + hocsinh._Ten + "', GioiTinh = " + ((int)hocsinh._GioiTinh).ToString() + ", NgaySinh = '" + hocsinh._NgaySinh.ToString() + "', NoiSinh = N'" + hocsinh._NoiSinh + "', MaDanToc = '" + hocsinh._DanToc._MaDanToc + "', MaTonGiao = '" + hocsinh._TonGiao._MaTonGiao + "', HoTenCha = N'" + hocsinh._HoTenCha + "', NgheNghiepCha = N'" + hocsinh._NgheNghiepCha + "', HoTenMe = N'" + hocsinh._HoTenMe + "', NgheNghiepMe = N'" + hocsinh._NgheNghiepMe + "' where MaHocSinh = '" + hocsinh._ID + "'";
            SqlConn.ThucHienLenh(Query);
        }
        public static void XoaHocSinh(string MaHocSinh)
        {
            SqlConn.XoaDong("PhanLop", "MaHocSinh = '" + MaHocSinh + "'");
            SqlConn.XoaDong("KQ_Hoc_Ky_Mon_Hoc", "MaHocSinh = '" + MaHocSinh + "'");
            SqlConn.XoaDong("KQ_Hoc_Ky_Tong_Hop", "MaHocSinh = '" + MaHocSinh + "'");
            SqlConn.XoaDong("KQ_Ca_Nam_Mon_Hoc", "MaHocSinh = '" + MaHocSinh + "'");
            SqlConn.XoaDong("KQ_Ca_Nam_Mon_Hoc", "MaHocSinh = '" + MaHocSinh + "'");
            SqlConn.XoaDong("Diem", "MaHocSinh = '" + MaHocSinh + "'");

            SqlConn.XoaDong("HocSinh", "MaHocSinh = '" + MaHocSinh + "'");
        }
        public static void ThemHocSinh(HocSinh hocsinh)
        {
            string Query = "Insert into HocSinh values('" + hocsinh._ID + "', N'" + hocsinh._Ten + "', " + ((int)hocsinh._GioiTinh).ToString() + ", '" + hocsinh._NgaySinh.ToString() + "', '" + hocsinh._NoiSinh.ToString() + "', '" + hocsinh._DanToc._MaDanToc + "', '" + hocsinh._TonGiao._MaTonGiao + "', '" + hocsinh._HoTenCha + "', 'NN0001'" + ", '" + hocsinh._HoTenMe + "', 'NN0001'" + ", '" + hocsinh._NgheNghiepCha + "', '" + hocsinh._NgheNghiepMe + "')";
            SqlConn.ThucHienLenh(Query);
        }
    }
}
