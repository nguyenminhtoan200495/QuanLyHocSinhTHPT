using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class GiaoVien
    {
        public string _MaGiaoVien { get; set; }
        public string _TenGiaoVien { get; set; }
        public string _MaMonDay { get; set; }

        public GiaoVien(string MaGiaoVien, string TenGiaoVien, string MaMonDay)
        {
            _MaGiaoVien = MaGiaoVien;
            _TenGiaoVien = TenGiaoVien;
            _MaMonDay = MaMonDay;
        }
        public GiaoVien(string MaGiaoVien, string TenGiaoVien)
        {
            _MaGiaoVien = MaGiaoVien;
            _TenGiaoVien = TenGiaoVien;
        }
        public GiaoVien()
        {
        }
    }

    public class GiaoVienChuNhiem : GiaoVien
    {
        public Lop _LopChuNhiem { get; set; }

        public GiaoVienChuNhiem(string MaGiaoVien, string TenGiaoVien)
        {
            _MaGiaoVien = MaGiaoVien;
            _TenGiaoVien = TenGiaoVien;
        }
        public GiaoVienChuNhiem(string MaGiaoVien, string TenGiaoVien, Lop LopChuNhiem)
        {
            _MaGiaoVien = MaGiaoVien;
            _TenGiaoVien = TenGiaoVien;
            _LopChuNhiem = LopChuNhiem;
        }
        public GiaoVienChuNhiem(string MaGiaoVien)
        {
            _MaGiaoVien = MaGiaoVien;
        }
    }

    public class GiaoVienBoMon : GiaoVien
    {
    }
}
