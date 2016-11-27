using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.BUS
{
    public class LoaiHocLucBUS
    {
        public static void SuaHocLuc(string MaHocLuc, string TenHocLuc, float DiemCanDuoi, float DiemKhongChe)
        {
            try
            {
                LoaiHocLucDAO.SuaHocLuc(MaHocLuc, TenHocLuc, DiemCanDuoi, DiemKhongChe);
            }
            catch (SqlException)
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }
    }
}
