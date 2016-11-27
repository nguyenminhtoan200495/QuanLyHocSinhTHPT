using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.BUS
{
    class NguoiDungBUS
    {
        public static NguoiDung DangNhap(string TenDangNhap, string MatKhau)
        {
            try
            {
                NguoiDung nguoidung = NguoiDungDAO.DangNhap(TenDangNhap, MatKhau);

                if (nguoidung == null)
                {
                    BaoLoi();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return nguoidung;
            }
            catch (SqlException)
            {
                BaoLoi();
                return null;
            }
        }

        private static void BaoLoi()
        {
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DoiMatKhau(NguoiDung nguoidung, string MatKhauMoi)
        {
            try
            {
                NguoiDungDAO.DoiMatKhau(nguoidung, MatKhauMoi);
                MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }
        }
    }
}
