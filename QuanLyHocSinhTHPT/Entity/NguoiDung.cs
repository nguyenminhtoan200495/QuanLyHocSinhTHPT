using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public enum Quyen
    {
        QuanLy,
        GiaoVu,
        GiaoVien,
        Khong
    }
    public class NguoiDung
    {
        public string _TenDangNhap { get; set; }
        public string _MatKhau { get; set; }
        public Quyen _Quyen { get; set; }

        public bool DoiMatKhau(string MatKhauMoi)
        {
            _MatKhau = MatKhauMoi;
            return true;
        }

        public NguoiDung(string TenDangNhap, string MatKhau, Quyen Quyen)
        {
            _TenDangNhap = TenDangNhap;
            _MatKhau = MatKhau;
            _Quyen = Quyen;
        }
    }
}
