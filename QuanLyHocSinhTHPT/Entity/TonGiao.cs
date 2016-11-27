using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Entity
{
    public class TonGiao
    {
        public string _MaTonGiao { get; set; }
        public string _TenTonGiao { get; set; }

        public TonGiao(string MaTonGiao)
        {
            _MaTonGiao = MaTonGiao;
        }
    }
}
