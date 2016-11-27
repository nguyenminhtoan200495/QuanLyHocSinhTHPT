using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.DAO
{
    public class LoaiHocLucDAO
    {
        public static void SuaHocLuc(string MaHocLuc, string TenHocLuc, float DiemCanDuoi, float DiemKhongChe)
        {
            string Query = "Update Hocluc set TenHocLuc = '" + TenHocLuc + "', DiemCanDuoi = " + DiemCanDuoi + ", DiemKhongChe = " + DiemKhongChe + " where MaHocLuc = '" + MaHocLuc + "'";
            SqlConn.ThucHienLenh(Query);
        }
    }
}
