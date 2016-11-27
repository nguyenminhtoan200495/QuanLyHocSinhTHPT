using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class Lop
    {
        public string _MaLop { get; set; }
        public string _TenLop { get; set; }
        public GiaoVienChuNhiem _GVCN { get; set; }
        public NamHoc _NamHoc { get; set; }
        public Khoi _KhoiLop { get; set; }
        public List<HocSinh> _DanhSachHocSinh { get; set; }

        public Lop(string MaLop)
        {
            _MaLop = MaLop;
        }
        public Lop(string MaLop, string TenLop, Khoi KhoiLop, NamHoc NamHoc, GiaoVienChuNhiem GVCN)
        {
            _MaLop = MaLop;
            _TenLop = TenLop;
            _KhoiLop = KhoiLop;
            _NamHoc = NamHoc;
            _GVCN = GVCN;
        }       
        public Lop(Lop Lop)
        {
            _MaLop = Lop._MaLop;
            _TenLop = Lop._TenLop;
            _GVCN = Lop._GVCN;
            _NamHoc = Lop._NamHoc;
            _KhoiLop = Lop._KhoiLop;
            if(Lop._DanhSachHocSinh != null) _DanhSachHocSinh = new List<HocSinh>(Lop._DanhSachHocSinh);
        }
        ~Lop()
        {
        }

        //public void ThemHocSinh(HocSinh HocSinh)
        //{
        //}
        //public bool XoaHoaSinh(string MaHocSinh)
        //{
        //    return true;
        //}
        //public HocSinh TimKiemHocSinh(string MaHocSinh)
        //{
        //    return null;
        //}

        //public void CapNhatGVCN(GiaoVienChuNhiem GVCN)
        //{
        //}
    }
}
