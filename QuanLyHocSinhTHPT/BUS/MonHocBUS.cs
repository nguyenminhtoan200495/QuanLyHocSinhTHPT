using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DAO;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.BUS
{
    public class MonHocBUS
    {
        public static DataTable LayBangMonHocRutGon(string DieuKien)
        {
            return MonHocDAO.LayBangMonHocRutGon(DieuKien);
        }
        public static int PhatSinhMaPhanCong()
        {
            int STT = (int)GlobalEntity.ThucHienLenhCoTruyVan("Select Count(*) from PhanCong");
            return STT + 1;
        }
        public static void XepLop(string MaNamHoc, string MaLop, string MaMonHoc, string MaGiaoVien)
        {
            string Query = "Insert into PhanCong values('" + MaNamHoc + "', '" + MaLop + "', '" + MaMonHoc + "', '" + MaGiaoVien + "')";
            GlobalEntity.ThucHienLenh(Query);
        }
    }
}
