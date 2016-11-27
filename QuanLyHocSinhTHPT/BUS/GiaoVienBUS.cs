using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.BUS
{
    public class GiaoVienBUS
    {
        public static DataTable LayBangGiaoVien(string DieuKien)
        {
            return GiaoVienDAO.LayBangGiaoVien(DieuKien);
        }

        public static DataTable LayBangGiaoVienBoMon()
        {
            return GiaoVienDAO.LayBangGiaoVienBoMon();
        }

        public static void ThemGiaoVien(GiaoVien giaovien)
        {
            try
            {
                GiaoVienDAO.ThemGiaoVien(giaovien);
                MessageBox.Show("Thêm giáo viên thành công!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Thêm giáo viên thất bại!");
            }
        }

        public static void XoaGiaoVien(string MaGiaoVien)
        {
            try
            {
                GiaoVienDAO.XoaGiaoVien(MaGiaoVien);
                MessageBox.Show("Xóa thành công giáo viên " + MaGiaoVien + " ra khỏi danh sách");
            }
            catch (SqlException)
            {
                MessageBox.Show("Hãy hủy các công tác của giáo viên " + MaGiaoVien + " trước khi xóa");
            }
        }

        public static GiaoVien LayGiaoVien(string MaGiaoVien)
        {
            return GiaoVienDAO.LayGiaoVien(MaGiaoVien);
        }

        public static void SuaGiaoVien(GiaoVien giaovien)
        {
            try
            {
                GiaoVienDAO.SuaGiaoVien(giaovien);
                MessageBox.Show("Thành công!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }
    }
}
