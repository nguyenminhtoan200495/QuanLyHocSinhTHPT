using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.Entity;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmThemLop : Form
    {
        public Lop _lop { get; set; }
        public frmThemLop()
        {
            InitializeComponent();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
        {
            DataTable dtNamHoc = NamHocBUS.LayBangNamHoc("");
            DataTable dtKhoiLop = KhoiLopBUS.LayBangKhoiLop("");
            DataTable dtGiaoVien = GiaoVienBUS.LayBangGiaoVien("");

            cmbNamHoc.DataSource = dtNamHoc;
            cmbNamHoc.ValueMember = "MaNamHoc";
            cmbNamHoc.DisplayMember = "TenNamHoc";           

            cmbKhoiLop.DataSource = dtKhoiLop;
            cmbKhoiLop.ValueMember = "MaKhoiLop";
            cmbKhoiLop.DisplayMember = "TenKhoiLop";

            cmbGVCN.DataSource = dtGiaoVien;
            cmbGVCN.ValueMember = "MaGiaoVien";
            cmbGVCN.DisplayMember = "TenGiaoVien";

            cmbGVCN.SelectedIndex = cmbKhoiLop.SelectedIndex = cmbGVCN.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string TenLop = txtTenLop.Text;
                string GVCN = cmbGVCN.SelectedValue.ToString();
                string NamHoc = cmbNamHoc.SelectedValue.ToString();
                string Khoi = cmbKhoiLop.SelectedValue.ToString();
                string MaLop = LopBUS.PhatSinhMaLop(TenLop, Khoi, NamHoc);

                Lop lop = new Lop(MaLop, TenLop, new Khoi(Khoi), new NamHoc(NamHoc), new GiaoVienChuNhiem(GVCN));
                LopBUS.ThemLop(lop, 0);

                MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Thêm lớp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
