using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.DAO
{
    class NamHocDAO
    {
        public static DataTable LayBangNamHoc(string DieuKien)
        {
            return SqlConn.LayBang("NamHoc", DieuKien);
        }
    }
}
