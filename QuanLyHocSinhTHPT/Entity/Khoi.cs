using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class Khoi
    {
        public string _MaKhoiLop { get; set; }
        public string _TenKhoiLop { get; set; }

        public Khoi(string MaKhoiLop)
        {
            _MaKhoiLop = MaKhoiLop;
        }
        public Khoi(string MaKhoiLop, string TenKhoiLop)
        {
            _TenKhoiLop = TenKhoiLop;
        }
    }
}
