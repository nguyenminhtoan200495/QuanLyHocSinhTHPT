using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyHocSinhTHPT.Entity;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class GiaoVienDAO
    {
        public static DataTable LayBangGiaoVien(string DieuKien)
        {
            string Query = "Select MaGiaoVien, TenGiaoVien, TenMonHoc from GiaoVien, MonHoc where GiaoVien.MaMonHoc = MonHoc.MaMonHoc";
            if (DieuKien != "") Query += " and " + DieuKien;
            return SqlConn.LayBang(Query);
        }

        public static DataTable LayBangGiaoVienBoMon()
        {
            string Query = "Select MaGiaoVien, TenGiaoVien, MaMonHoc from GiaoVien";

            return SqlConn.LayBang(Query);
        }

        public static void ThemGiaoVien(GiaoVien giaovien)
        {
            string Query = "Insert into GiaoVien(MaGiaoVien, TenGiaoVien, MaMonHoc) values('" + giaovien._MaGiaoVien + "', N'" + giaovien._TenGiaoVien + "', '" + giaovien._MaMonDay + "')";

            SqlConn.ThucHienLenh(Query);
        }

        public static void XoaGiaoVien(string MaGiaoVien)
        {
            SqlConn.XoaDong("GiaoVien", "MaGiaoVien = '" + MaGiaoVien + "'");
        }

        public static GiaoVien LayGiaoVien(string MaGiaoVien)
        {
            GiaoVien giaovien = new GiaoVien();
            DataTable dtGiaoVien = SqlConn.LayBang("Select MaGiaoVien, TenGiaoVien, MaMonHoc from GiaoVien where MaGiaoVien = '" + MaGiaoVien + "'");

            giaovien._MaGiaoVien = MaGiaoVien;
            giaovien._MaMonDay = dtGiaoVien.Rows[0].Field<string>("MaMonHoc");
            giaovien._TenGiaoVien = dtGiaoVien.Rows[0].Field<string>("TenGiaoVien");
            return giaovien;
        }

        public static void SuaGiaoVien(GiaoVien giaovien)
        {
            string Query = "Update GiaoVien set TenGiaoVien = N'" + giaovien._TenGiaoVien + "', MaMonHoc = '" + giaovien._MaMonDay + "' where MaGiaoVien = '" + giaovien._MaGiaoVien + "'";
            SqlConn.ThucHienLenh(Query);
        }
    }
}
