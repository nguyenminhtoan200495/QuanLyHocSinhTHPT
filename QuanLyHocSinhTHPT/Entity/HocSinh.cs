using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public enum GioiTinh: int
    {
        nam = 0,
        nu = 1
    }
    public class HocSinh
    {
        public string _Ten { get; set; }
        public string _ID { get; set; }
        public GioiTinh _GioiTinh { get; set; }
        public DateTime _NgaySinh { get; set; }
        public string _NoiSinh { get; set; }
        public DanToc _DanToc { get; set; }
        public TonGiao _TonGiao { get; set; }
        public string _HoTenCha { get; set; }
        public string _NgheNghiepCha { get; set; }
        public string _HoTenMe { get; set; }
        public string _NgheNghiepMe { get; set; }
        List<Diem> _BangDiem;
        KetQua _KetQua;

        public HocSinh(string ID)
        {
            _ID = ID;
        }
        HocSinh(string Ten, string ID, ThongTinCaNhan ThongTin)
        {
        }
        HocSinh(string Ten, string ID, ThongTinCaNhan ThongTin, List<Diem> BangDiem, KetQua KetQua)
        {
        }
        HocSinh(HocSinh p)
        {
        }
        ~HocSinh()
        {
        }

        void CapNhatThongTin(ThongTinCaNhan ThongTin)
        {
        }
        void CapNhatThongTin(string Ten)
        {
        }
        void CapNhatThongTin(string Ten, ThongTinCaNhan ThongTin)
        {
        }

        void NhapDiem(Diem Diem)
        {
        }
        void SuaDiem(ref Diem Diem)
        {
        }

        void XepLoai()
        {
        }
        void CapNhatHanhKiem(HanhKiem HanhKiem)
        {
        }
    }
}
