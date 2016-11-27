using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{   
    class KetQua
    {
        public string _MaHocSinh { get; set; }
        public string _MaLop { get; set; }
        public string _MaHocKy { get; set; }
        public float _DTB { get; set; }
        public string _MaHocLuc { get; set; }
        public string _MaHanhKiem { get; set; }

        public KetQua(string MaHocSinh, string MaLop, string MaHocKy)
        {
            _MaHocSinh = MaHocSinh;
            _MaLop = MaLop;
            _MaHocKy = MaHocKy;
        }
    }
}
