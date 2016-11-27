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
    public partial class frmSuaGiaoVien : Form
    {
        public GiaoVien _GiaoVien { get; set; }

        public frmSuaGiaoVien(GiaoVien giaovien)
        {
            InitializeComponent();

            _GiaoVien = giaovien;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _GiaoVien._TenGiaoVien = txtTenGiaoVien.Text;
            GiaoVienBUS.SuaGiaoVien(_GiaoVien);
            this.Close();
        }

        private void frmSuaGiaoVien_Load(object sender, EventArgs e)
        {
            txtMaGiaoVien.Text = _GiaoVien._MaGiaoVien;
            txtTenGiaoVien.Text = _GiaoVien._TenGiaoVien;

            DataTable dtMon = MonHocBUS.LayBangMonHocRutGon("");
            cmbMonDay.DataSource = dtMon;
            cmbMonDay.DisplayMember = "TenMonHoc";
            cmbMonDay.ValueMember = "MaMonHoc";

            string MaMonHoc = _GiaoVien._MaMonDay;
            foreach (DataRow row in dtMon.Rows)
            {
                if (row.Field<string>("MaMonHoc") == _GiaoVien._MaMonDay)
                {
                    cmbMonDay.Text = row.Field<string>("MaMonHoc");
                    break;
                }
            }
        }

        private void cmbMonDay_DropDownClosed(object sender, EventArgs e)
        {
            _GiaoVien._MaMonDay = cmbMonDay.SelectedValue.ToString();
        }     
    }
}
