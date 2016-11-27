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
    class KetQuaHocTapBUS
    {
        public static DataTable LayKetQuaHocKyTongHop(string MaNamHoc, string MaLop, string MaHocKy)
        {
            return KetQuaHocTapDAO.LayKetQuaHocKyTongHop(MaNamHoc, MaLop, MaHocKy);
        }

        public static DataTable LayKetQuaCaNamTongHop(string MaNamHoc, string MaLop)
        {
            return KetQuaHocTapDAO.LayKetQuaCaNamTongHop(MaNamHoc, MaLop);
        }
        public static void LoadDanhSach()
        {
            try
            {
                KetQuaHocTapDAO.LoadDanhSach();
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
        }
        public static void LuuHanhKiem(string MaHocSinh, string MaLop, string MaHocKy, string MaHanhKiem)
        {
            try
            {
                KetQuaHocTapDAO.LuuHanhKiem(MaHocSinh, MaLop, MaHocKy, MaHanhKiem);
            }
            catch (SqlException)
            {
                MessageBox.Show("Cập nhật hạnh kiểm thất bại");
            }
        }
    }
}
