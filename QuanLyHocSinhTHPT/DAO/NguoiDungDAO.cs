using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    class NguoiDungDAO
    {
        public static DataTable LayDSNguoiDung()
        {
            return SqlConn.LayBang("NguoiDung", "");
        }

        public static NguoiDung DangNhap(string TenTaiKhoan, string MatKhau)
        {
            DataTable DanhSachNguoiDung = LayDSNguoiDung();

            foreach (DataRow row in DanhSachNguoiDung.Rows)
            {
                if (row.Field<string>("TenDNhap") == TenTaiKhoan && row.Field<string>("MatKhau") == MatKhau)
                {
                    string MaLoai = row.Field<string>("MaLoai");
                    Quyen quyen = new Quyen();
                    if (MaLoai == "LND001") quyen = Quyen.QuanLy;
                    else if (MaLoai == "LND002") quyen = Quyen.GiaoVu;
                    else if (MaLoai == "LND003") quyen = Quyen.GiaoVien;
                    else quyen = Quyen.Khong;

                    NguoiDung nguoidung = new NguoiDung(TenTaiKhoan, MatKhau, quyen);

                    return nguoidung;
                }
            }

            return null;
        }

        public static void DoiMatKhau(NguoiDung nguoidung, string MatKhauMoi)
        {
            string Query = "Update NguoiDung set MatKhau = '" + MatKhauMoi + "' where TenDNhap = '" + nguoidung._TenDangNhap + "'";
            SqlConn.ThucHienLenh(Query);
        }
    }
}
