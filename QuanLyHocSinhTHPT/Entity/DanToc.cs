using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class DanToc
    {
        public string _MaDanToc { get; set; }
        public string _TenDanToc { get; set; }

        public DanToc(string MaDanToc)
        {
            _MaDanToc = MaDanToc;
        }
    }
}
