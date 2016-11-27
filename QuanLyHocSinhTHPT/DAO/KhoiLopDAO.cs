using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.DAO
{
    public class KhoiLopDAO
    {
        public static DataTable LayBangKhoiLop(string DieuKien)
        {
            return SqlConn.LayBang("KhoiLop", DieuKien);
        }
    }
}
