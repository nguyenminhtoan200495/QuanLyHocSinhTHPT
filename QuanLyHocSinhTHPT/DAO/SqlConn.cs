using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    class SqlConn
    {
        public static string _ConnectionString = @"Data Source=MESSI;Initial Catalog=QLHocSinhTHPT;Integrated Security=True";
        //public static Quyen DangNhap(string username, string pass)
        //{
        //    Quyen result = NguoiDungDAO.KiemTraNguoiDung(username, pass, NguoiDungDAO.LayDSNguoiDung());
        //    return result;
        //}
        public static DataTable LayBang(string TenBang, string DieuKien)
        {
            SqlConnection conn = new SqlConnection(SqlConn._ConnectionString);
            conn.Open();
            if (DieuKien != "")
            {
                TenBang = TenBang + " where " + DieuKien;
            }
            SqlDataAdapter da = new SqlDataAdapter("Select * from " + TenBang, conn);
            if (da == null) return null;           
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }
        public static DataTable LayBang(string TruyVan)
        {
            SqlConnection conn = new SqlConnection(SqlConn._ConnectionString);
            conn.Open();
            
            SqlDataAdapter da = new SqlDataAdapter(TruyVan, conn);
            if (da == null) return null;

            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }
        public static void ThucHienLenh(string TruyVan)
        {
            SqlConnection conn = new SqlConnection(SqlConn._ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = TruyVan;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static object ThucHienLenhCoTruyVan(string TruyVan)
        {
            SqlConnection conn = new SqlConnection(SqlConn._ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = TruyVan;
            cmd.Connection = conn;
            object res = cmd.ExecuteScalar();
            conn.Close();

            return res;
        }
        public static void SetNull(string TenBang, string ThuocTinh, string GiaTri)
        {
            SqlConnection conn = new SqlConnection(SqlConn._ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update " + TenBang + " set " + ThuocTinh + " = null where " + ThuocTinh + " = '" + GiaTri + "'";         
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaDong(string TenBang, string DieuKien)
        {
            string Query = "Delete from " + TenBang;
            if (DieuKien != "") Query = Query + " where " + DieuKien;

            ThucHienLenh(Query);
        }
        public static object LayGiaTriTheoKhoa(string TenBang, string ThuocTinh, string TenKhoa, string GiaTriKhoa)
        {
            string Query = "Select " + ThuocTinh + " from " + TenBang + " where " + TenKhoa + " = " + "'" + GiaTriKhoa + "'";
            return ThucHienLenhCoTruyVan(Query);
        }
        public static void CapNhat(string TenBang, string ThuocTinh, string GiaTri, string DieuKien)
        {
            string Query = "Update " + TenBang + " set " + ThuocTinh + " = N'" + GiaTri + "' where " + DieuKien;
            SqlConn.ThucHienLenh(Query);
        }
    }
}
