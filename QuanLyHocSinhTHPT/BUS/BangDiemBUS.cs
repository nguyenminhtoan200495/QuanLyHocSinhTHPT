using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.Entity;

namespace QuanLyHocSinhTHPT.BUS
{
    class BangDiemBUS
    {
        public static void ThemVaoBangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy)
        {
            try
            {
                BangDiemDAO.ThemVaoBangDiem(MaHocSinh, MaLop, MaMonHoc, MaHocKy);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thêm học sinh trùng lặp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void XoaKhoiBangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy)
        {
            try
            {
                BangDiemDAO.XoaKhoiBangDiem(MaHocSinh, MaLop, MaMonHoc, MaHocKy);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable LayBangDiemMon(string MaLop, string MaMonHoc, string MaHocKy)
        {
            return BangDiemDAO.LayBangDiemMon(MaLop, MaMonHoc, MaHocKy);
        }

        public static void NhapDiem(BangDiem bangdiem)
        {
            try
            {
                BangDiemDAO.NhapDiem(bangdiem);
            }
            catch (SqlException)
            {
                MessageBox.Show("Nhập điểm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        public static void LuuKetQuaDiem()
        {
            try
            {
                BangDiemDAO.LuuKetQuaDiem();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }
    }
}
