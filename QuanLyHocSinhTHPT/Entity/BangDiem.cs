using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public enum HocLuc
    {
        Gioi,
        Kha,
        TrungBinh,
        Yeu,
        Kem
    }
    public class BangDiem
    {
        public string _MaHocSinh {get; set;}
        public string _MaLop {get; set;}
        public string _MaMonHoc {get; set;}
        public string _MaHocKy {get; set;}
        public float _Mieng {get; set;}
        public float _KiemTra15_1 {get; set;}
        public float  _KiemTra15_2 {get; set;}
        public float _KiemTra15_3 {get; set;}
        public float _KiemTra1Tiet_1 {get; set;}
        public float _KiemTra1Tiet_2 {get; set;}
        public float _ThiHK { get; set; }

        public BangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy)
        {
            _MaHocSinh = MaHocSinh;
            _MaLop = MaLop;
            _MaMonHoc = MaMonHoc;
            _MaHocKy = MaHocKy;
            _Mieng = -1;
            _KiemTra15_1 = -1;
            _KiemTra15_2 = -1;
            _KiemTra15_3 = -1;
            _KiemTra1Tiet_1 = -1;
            _KiemTra1Tiet_2 = -1;
            _ThiHK = -1;
        }

        public BangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy, float mieng, float kt15_1, float kt15_2, float kt15_3, float kt1_1, float kt1_2, float thi)
        {
            _MaHocSinh = MaHocSinh;
            _MaLop = MaLop;
            _MaMonHoc = MaMonHoc;
            _MaHocKy = MaHocKy;
            _Mieng = mieng;
            _KiemTra15_1 = kt15_1;
            _KiemTra15_2 = kt15_2;
            _KiemTra15_3 = kt15_3;
            _KiemTra1Tiet_1 = kt1_1;
            _KiemTra1Tiet_2 = kt1_2;
            _ThiHK = thi;
        }

        public float TinhTrungBinh()
        {
            int TongHeSo = 0;
            float Tong = 0;

            if (_Mieng >= 0)
            {
                Tong += _Mieng;
                TongHeSo += 1;
            }
            if (_KiemTra15_1 >= 0)
            {
                Tong += _KiemTra15_1;
                TongHeSo += 1;
            }
            if (_KiemTra15_2 >= 0)
            {
                Tong += _KiemTra15_2;
                TongHeSo += 1;
            }
            if (_KiemTra15_3 >= 0)
            {
                Tong += _KiemTra15_3;
                TongHeSo += 1;
            }
            if (_KiemTra1Tiet_1 >= 0)
            {
                Tong += _KiemTra1Tiet_1 * 2;
                TongHeSo += 2;
            }
            if (_KiemTra1Tiet_2 >= 0)
            {
                Tong += _KiemTra1Tiet_2 * 2;
                TongHeSo += 2;
            }
            if (_ThiHK >= 0)
            {
                Tong += _ThiHK * 3;
                TongHeSo += 3;
            }

            if (TongHeSo == 0) return -1;
            else return Tong / TongHeSo;
        }

        public HocLuc XepLoai()
        {
            float dtb = TinhTrungBinh();

            if (dtb >= 9) return HocLuc.Gioi;
            else if (dtb >= 6.5) return HocLuc.Kha;
            else if (dtb >= 5) return HocLuc.TrungBinh;
            else if (dtb >= 3.5) return HocLuc.Yeu;
            else return HocLuc.Kem;
        }
    }
}
