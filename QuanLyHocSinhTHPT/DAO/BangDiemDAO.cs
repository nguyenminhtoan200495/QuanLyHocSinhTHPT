using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyHocSinhTHPT.Entity;
using System.Windows.Forms;
namespace QuanLyHocSinhTHPT.DAO
{
    class BangDiemDAO
    {
        public static void ThemVaoBangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy)
        {
            string query = "Insert into BangDiem(MaHocSinh, MaLop, MaMonHoc, MaHocKy) values('" + MaHocSinh + "', '" + MaLop + "', '" + MaMonHoc + "', '" + MaHocKy + "')";
            SqlConn.ThucHienLenh(query);
        }

        public static void XoaKhoiBangDiem(string MaHocSinh, string MaLop, string MaMonHoc, string MaHocKy)
        {
            SqlConn.XoaDong("BangDiem", "MaHocSinh = '" + MaHocSinh + "' and MaLop = '" + MaLop + "' and MaMonHoc = '" + MaMonHoc + "' and MaHocKy = '" + MaHocKy + "'");
        }

        public static DataTable LayBangDiemMon(string MaLop, string MaMonHoc, string MaHocKy)
        {
            DataTable kq = SqlConn.LayBang("Select BangDiem.MaHocSinh, HoTen, Mieng, KiemTra15_1, KiemTra15_2, KiemTra15_3, KiemTra1Tiet_1, KiemTra1Tiet_2, ThiHK from BangDiem, HocSinh where BangDiem.MaHocSinh = HocSinh.MaHocSinh and MaLop = '" + MaLop + "' and MaHocKy = '" + MaHocKy + "' and MaMonHoc = '" + MaMonHoc + "'");           
            return kq;
        }

        public static void NhapDiem(BangDiem bangdiem)
        {
            string query = "Update BangDiem set Mieng = ";

            if (bangdiem._Mieng >= 0) query += bangdiem._Mieng.ToString() + ", KiemTra15_1 = ";
            else query += "null, KiemTra15_1 = ";
            if (bangdiem._KiemTra15_1 >= 0) query += bangdiem._KiemTra15_1.ToString() + ", KiemTra15_2 = ";
            else query += "null, KiemTra15_2 = ";
            if (bangdiem._KiemTra15_2 >= 0) query += bangdiem._KiemTra15_2.ToString() + ", KiemTra15_3 = ";
            else query += "null, KiemTra15_3 = ";
            if (bangdiem._KiemTra15_3 >= 0) query += bangdiem._KiemTra15_3.ToString() + ", KiemTra1Tiet_1 = ";
            else query += "null, KiemTra1Tiet_1 = ";
            if (bangdiem._KiemTra1Tiet_1 >= 0) query += bangdiem._KiemTra1Tiet_1.ToString() + ", KiemTra1Tiet_2 = ";
            else query += "null, KiemTra1Tiet_2 = ";
            if (bangdiem._KiemTra1Tiet_2 >= 0) query += bangdiem._KiemTra1Tiet_2.ToString() + ", ThiHK = ";
            else query += "null, ThiHK = ";
            if (bangdiem._ThiHK >= 0) query += bangdiem._ThiHK.ToString();
            else query += "null";

            query += " where MaHocSinh = '" + bangdiem._MaHocSinh + "' and MaLop = '" + bangdiem._MaLop + "' and MaMonHoc = '" + bangdiem._MaMonHoc + "' and MaHocKy = '" + bangdiem._MaHocKy + "'";
            SqlConn.ThucHienLenh(query);         
        }

        public static double TinhDiemTrungBinh(DataRow row)
        {
            double Tong = 0;
            int HeSo = 0;

            if (row["Mieng"] != DBNull.Value)
            {
                Tong += row.Field<double>("Mieng");
                HeSo += 1;
            }
            if (row["KiemTra15_1"] != DBNull.Value)
            {
                Tong += row.Field<double>("KiemTra15_1");
                HeSo += 1;
            }
            if (row["KiemTra15_2"] != DBNull.Value)
            {
                Tong += row.Field<double>("KiemTra15_2");
                HeSo += 1;
            }
            if (row["KiemTra15_3"] != DBNull.Value)
            {
                Tong += row.Field<double>("KiemTra15_3");
                HeSo += 1;
            }
            if (row["KiemTra1Tiet_1"] != DBNull.Value)
            {
                Tong += row.Field<double>("KiemTra1Tiet_1") * 2;
                HeSo += 2;
            }
            if (row["KiemTra1Tiet_2"] != DBNull.Value)
            {
                Tong += row.Field<double>("KiemTra1Tiet_2") * 2;
                HeSo += 2;
            }
            if (row["ThiHK"] != DBNull.Value)
            {
                Tong += row.Field<double>("ThiHK") * 3;
                HeSo += 3;
            }

            if (HeSo == 0) return -1;
            return Tong / HeSo;
        }
        public static void LuuKetQuaDiem()
        {
            DataTable KetQua = SqlConn.LayBang("KQ_Hoc_Ky_Tong_Hop", "");
            DataTable BangDiem = SqlConn.LayBang("Select HeSo, BangDiem.* from MonHoc, BangDiem where MonHoc.MaMonHoc = BangDiem.MaMonHoc");
            DataTable HocLuc = SqlConn.LayBang("HocLuc", "");

            foreach (DataRow rowKetQua in KetQua.Rows)
            {
                double Tong = 0;
                int TongHeSo = 0;
                double min = 10;
                foreach (DataRow rowBangDiem in BangDiem.Rows)
                {
                    if (rowKetQua.Field<string>("MaHocSinh") == rowBangDiem.Field<string>("MaHocSinh") && rowKetQua.Field<string>("MaHocKy") == rowBangDiem.Field<string>("MaHocKy") && rowKetQua.Field<string>("MaLop") == rowBangDiem.Field<string>("MaLop"))
                    {
                        double TBM = TinhDiemTrungBinh(rowBangDiem);

                        if (TBM > 0)
                        {
                            if (TBM < 10) min = TBM;
                            Tong += (TBM * rowBangDiem.Field<int>("HeSo"));
                            TongHeSo += rowBangDiem.Field<int>("HeSo");
                        }
                    }
                }

                if (TongHeSo > 0)
                {
                    double dtb = Tong / TongHeSo;
                    string MaHocLuc = "HL0005";

                    foreach (DataRow row in HocLuc.Rows)
                    {                      
                        if (dtb >= row.Field<double>("DiemCanDuoi") && min >= row.Field<double>("DiemKhongChe"))
                        {     
                            MaHocLuc = row.Field<string>("MaHocLuc");
                            break;
                        }
                    }
                    string Query = "Update KQ_Hoc_Ky_Tong_Hop set DTBMonHocKy = '" + dtb.ToString() + "', MaHocLuc = '" + MaHocLuc + "' where MaHocSinh = '" + rowKetQua.Field<string>("MaHocSinh") + "' and MaLop = '" + rowKetQua.Field<string>("MaLop") + "' and MaHocKy = '" + rowKetQua.Field<string>("MaHocKy") + "'";
                    SqlConn.ThucHienLenh(Query);
                }
            }
        }
    }
}
