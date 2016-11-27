using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.BUS;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class KetQuaHocTapDAO
    {
        public static DataTable LayKetQuaHocKyTongHop(string MaNamHoc, string MaLop, string MaHocKy)
        {
            string Query = "Select MaHocSinh, HoTen, DTBMonHocKy as DTB, TenHocLuc, TenHanhKiem "
            + "from ("
            + "Select KQ_Hoc_Ky_Tong_Hop.MaHocSinh as MaHocSinh, HoTen, DTBMONHOCKY, MaHocLuc, MaHanhKiem "
            + "from KQ_Hoc_Ky_Tong_Hop, HocSinh  "
            + "where KQ_Hoc_Ky_Tong_Hop.MaHocSinh = HocSinh.MaHocSinh and MaNamHoc = '" + MaNamHoc + "' and MaLop = '" + MaLop + "' and MaHocKy = '" + MaHocKy + "' "
            + ") as temp "
            + "left join HocLuc "
            + "on HocLuc.MaHocLuc = temp.MaHocLuc "
            + "left join HANHKIEM "
            + "on HanhKiem.MaHanhKiem = temp.MaHanhKiem ";
          
            DataTable dt = SqlConn.LayBang(Query);

            return dt;
        }

        public static DataTable LayKetQuaCaNamTongHop(string MaNamHoc, string MaLop)
        {
            string Query = "Select MaHocSinh, HoTen, DTBCaNam as DTB, TenHocLuc, TenHanhKiem "
            + "from ("
            + "Select KQ_Ca_Nam_Tong_Hop.MaHocSinh as MaHocSinh, HoTen, DTBCANAM, MaHocLuc, MaHanhKiem "
            + "from KQ_Ca_Nam_Tong_Hop, HocSinh  "
            + "where KQ_Ca_Nam_Tong_Hop.MaHocSinh = HocSinh.MaHocSinh and MaNamHoc = '" + MaNamHoc + "' and MaLop = '" + MaLop + "'"
            + ") as temp "
            + "left join HocLuc "
            + "on HocLuc.MaHocLuc = temp.MaHocLuc "
            + "left join HANHKIEM "
            + "on HanhKiem.MaHanhKiem = temp.MaHanhKiem ";
            DataTable dt = SqlConn.LayBang(Query);

            return dt;
        }

        public static void LoadDanhSach()
        {
            DataTable dtPhanLop = SqlConn.LayBang("PhanLop", "");

            foreach (DataRow row in dtPhanLop.Rows)
            {
                string MaHocSinh = row.Field<string>("MaHocSinh");
                string MaLop = row.Field<string>("MaLop");
                string MaNamHoc = row.Field<string>("MaNamHoc");
                if (SqlConn.ThucHienLenhCoTruyVan("Select * from KQ_CA_NAM_TONG_HOP where MaHocSinh = '" + MaHocSinh + "' and MaLop = '" + MaLop + "' and MaNamHoc = '" + MaNamHoc + "'") == null)
                {                 
                    string query1 = "Insert into KQ_CA_NAM_TONG_HOP(MaHocSinh, MaLop, MaNamHoc) values('" + MaHocSinh + "', '" + MaLop + "', '" + MaNamHoc + "')";
                    string query2 = "Insert into KQ_HOC_KY_TONG_HOP(MaHocSinh, MaLop, MaNamHoc, MaHocKy) values('" + MaHocSinh + "', '" + MaLop + "', '" + MaNamHoc + "', 'HK1')";
                    string query3 = "Insert into KQ_HOC_KY_TONG_HOP(MaHocSinh, MaLop, MaNamHoc, MaHocKy) values('" + MaHocSinh + "', '" + MaLop + "', '" + MaNamHoc + "', 'HK2')";                   

                    SqlConn.ThucHienLenh(query1);
                    SqlConn.ThucHienLenh(query2);
                    SqlConn.ThucHienLenh(query3);
                }
            }
        }

        public static void LuuHanhKiem(string MaHocSinh, string MaLop, string MaHocKy, string MaHanhKiem)
        {
            string Query = "Update KQ_Hoc_Ky_Tong_Hop set MaHanhKiem = '" + MaHanhKiem + "' where MaHocSinh = '" + MaHocSinh + "' and MaLop = '" + MaLop + "' and MaHocKy = '" + MaHocKy + "'";
            SqlConn.ThucHienLenh(Query);
        }
    }
}
