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

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmThemHocSinhNhapDiem : Form
    {
        string _MaLop, _MaMonHoc, _MaHocKy;
        public frmThemHocSinhNhapDiem(string MaLop, string MaMonHoc, string MaHocKy)
        {
            InitializeComponent();
            _MaLop = MaLop;
            _MaMonHoc = MaMonHoc;
            _MaHocKy = MaHocKy;
        }

        private void frmThemHocSinhNhapDiem_Load(object sender, EventArgs e)
        {
            DataTable dtDSHS = HocSinhBUS.LayDanhSachHocSinhRutGon("MaHocSinh in (Select MaHocSinh from PhanLop where MaLop = '" + _MaLop + "')"); 
            dgvDSHS.DataSource = dtDSHS;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDSHS.SelectedRows)
            {
                string MaHocSinh = row.Cells["MaHocSinh"].Value.ToString();
                BangDiemBUS.ThemVaoBangDiem(MaHocSinh, _MaLop, _MaMonHoc, _MaHocKy);
            }
        }       
    }
}
