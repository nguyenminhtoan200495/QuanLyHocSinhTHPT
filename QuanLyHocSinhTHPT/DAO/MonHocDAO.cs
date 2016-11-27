using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyHocSinhTHPT.DAO
{
    public class MonHocDAO
    {
        public static DataTable LayBangMonHocRutGon(string DieuKien)
        {
            string Query = "Select MaMonHoc, TenMonHoc from MonHoc";
            if (DieuKien != "") Query += " where " + DieuKien;
            
            DataTable dtMonHoc = SqlConn.LayBang(Query);
            return dtMonHoc;
        }
    }
}
