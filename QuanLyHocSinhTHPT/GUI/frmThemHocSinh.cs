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
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmThemHocSinh : Form
    {
        public frmThemHocSinh()
        {
            InitializeComponent();
        }

        private HocSinh NhanThongTinHocSinh()
        {
            HocSinh hocsinh = new HocSinh(GlobalEntity.PhatSinhMaHocSinh());

            hocsinh._Ten = txtHoTen_tabHocSinh.Text;
            hocsinh._GioiTinh = radNam.Checked ? GioiTinh.nam : GioiTinh.nu;
            hocsinh._NgaySinh = dtpNgaySinh_tabHocSinh.Value;
            hocsinh._NoiSinh = txtNoiSinh_tabHocSinh.Text;
            hocsinh._TonGiao = new TonGiao(cmbTonGiao_tabHocSinh.SelectedValue.ToString());
            hocsinh._DanToc = new DanToc(cmbDanToc_tabHocSinh.SelectedValue.ToString());
            hocsinh._HoTenCha = txtHoTenCha_tabHocSinh.Text;
            hocsinh._NgheNghiepCha = txtNgheNghiepCha_tabHocSinh.Text;
            hocsinh._HoTenMe = txtHoTenMej_tabHocSinh.Text;
            hocsinh._NgheNghiepMe = txtNgheNghiepMe_tabHocSinh.Text;

            return hocsinh;
        }

        private void frmThemHocSinh_Load(object sender, EventArgs e)
        {
            txtMaHocSinh_tabHocSinh.Text = GlobalEntity.PhatSinhMaHocSinh();
            DataTable dtDanToc = SqlConn.LayBang("DanToc", "");
            DataTable dtTonGiao = SqlConn.LayBang("TonGiao", "");

            cmbDanToc_tabHocSinh.DataSource = dtDanToc;
            cmbDanToc_tabHocSinh.DisplayMember = "TenDanToc";
            cmbDanToc_tabHocSinh.ValueMember = "MaDanToc";

            cmbTonGiao_tabHocSinh.DataSource = dtTonGiao;
            cmbTonGiao_tabHocSinh.DisplayMember = "TenTonGiao";
            cmbTonGiao_tabHocSinh.ValueMember = "MaTonGiao";

            radNam.Checked = true;
        }

        private void btnDongYSuaHocSinh_Click(object sender, EventArgs e)
        {
            HocSinh hocsinh = NhanThongTinHocSinh();
            HocSinhBUS.ThemHocSinh(hocsinh);
            MessageBox.Show("Thêm thành công học sinh " + hocsinh._ID + " vào danh sách học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            frmThemHocSinh_Load(new object(), new EventArgs());
        }
    }
}
