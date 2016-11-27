using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.Entity;
using QuanLyHocSinhTHPT.BUS;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmSuaLop : Form
    {
        public Lop _Lop { get; set; }
        public frmSuaLop(Lop lop)
        {
            InitializeComponent();
            _Lop = new Lop(lop);
        }

        private void frmSuaLop_Load(object sender, EventArgs e)
        {
            lblMaLop.Text = _Lop._MaLop;
            txtTenLop.Text = _Lop._TenLop;

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

            cmbGVCN.SelectedIndex = GlobalEntity.LayChiSo(dtGiaoVien, "MaGiaoVien", _Lop._GVCN._MaGiaoVien);
            cmbKhoiLop.SelectedIndex = GlobalEntity.LayChiSo(dtKhoiLop, "MaKhoiLop", _Lop._KhoiLop._MaKhoiLop);
            cmbNamHoc.SelectedIndex = GlobalEntity.LayChiSo(dtNamHoc, "MaNamHoc", _Lop._NamHoc._MaNamHoc);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dữ liệu của lớp " + lblMaLop.Text + " sẽ thay đổi. Đồng ý?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _Lop = new Lop(lblMaLop.Text, txtTenLop.Text, new Khoi(cmbKhoiLop.SelectedValue.ToString()), new NamHoc(cmbNamHoc.SelectedValue.ToString()), new GiaoVienChuNhiem(cmbGVCN.SelectedValue.ToString()));
                this.Close();   
            }
        }
    }
}
