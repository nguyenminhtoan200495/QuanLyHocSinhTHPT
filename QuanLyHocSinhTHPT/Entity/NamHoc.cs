using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class NamHoc
    {
        public string _MaNamHoc { get; set; }
        public string _TenNamHoc { get; set; }

        public NamHoc(string MaNamHoc, string TenNamHoc)
        {
            _MaNamHoc = MaNamHoc;
            _TenNamHoc = TenNamHoc;
        }
        public NamHoc(string MaNamHoc)
        {
            _MaNamHoc = MaNamHoc;
        }
    }
}
