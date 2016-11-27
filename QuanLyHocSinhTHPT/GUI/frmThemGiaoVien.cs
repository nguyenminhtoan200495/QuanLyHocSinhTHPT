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

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmThemGiaoVien : Form
    {
        public GiaoVien _GiaoVien { get; set; }
        public frmThemGiaoVien()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string MaGiaoVien = GlobalEntity.PhatSinhMaGiaoVien();
            string TenGiaoVien = txtTenGiaoVien.Text;
            string MaMonDay = cmbMonDay.SelectedValue.ToString();

            _GiaoVien = new GiaoVien(MaGiaoVien, TenGiaoVien, MaMonDay);

            this.Close();
        }

        private void frmThemGiaoVien_Load(object sender, EventArgs e)
        {
            DataTable dtMon = MonHocBUS.LayBangMonHocRutGon("");
            cmbMonDay.DataSource = dtMon;
            cmbMonDay.DisplayMember = "TenMonHoc";
            cmbMonDay.ValueMember = "MaMonHoc";
        }
    }
}
