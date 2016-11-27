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
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmChiTietLop : Form
    {
        public Lop _lop { get; set; }
        public frmChiTietLop(Lop lop)
        {
            _lop = new Lop(lop);
            InitializeComponent();
        }

        private void frmChiTietLop_Load(object sender, EventArgs e)
        {
            txtMaLop.Text = _lop._MaLop;
            txtGVCN.Text = _lop._GVCN._TenGiaoVien;
            txtKhoiLop.Text = _lop._KhoiLop._TenKhoiLop;
            txtTenLop.Text = _lop._TenLop;
            txtNamHoc.Text = _lop._NamHoc._TenNamHoc;

            DataTable dtDSHS = HocSinhBUS.LayDanhSachHocSinhRutGon("MaHocSinh in (Select MaHocSinh from PhanLop where MaLop = '" + _lop._MaLop + "')");

            cmbTimHS.DataSource = dtDSHS;
            cmbTimHS.DisplayMember = "HoTen";
            cmbTimHS.ValueMember = "MaHocSinh";

            dgvDanhSachHocSinh.DataSource = dtDSHS;
            for (int i = 0; i < dgvDanhSachHocSinh.Rows.Count; i++)
                dgvDanhSachHocSinh.Rows[i].Cells["STT"].Value = i + 1;

            DataTable dtPhanCong = GlobalEntity.LayBang("SELECT TENMONHOC, GIAOVIEN.MAGIAOVIEN, TENGIAOVIEN FROM PHANCONG, GIAOVIEN, MONHOC WHERE PHANCONG.MAMONHOC = MONHOC.MaMonHoc AND PHANCONG.MaGiaoVien = GIAOVIEN.MaGiaoVien AND MaLop = '" + _lop._MaLop + "'");
            dgvDanhSachGiaoVienBoMon.DataSource = dtPhanCong;
            cmbTimBoMon.DataSource = dtPhanCong;
            cmbTimBoMon.DisplayMember = "TenMonHoc";     
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dgvDanhSachHocSinh.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvDanhSachHocSinh.Columns[i - 1].HeaderText;
            }            
            for (int i = 0; i < dgvDanhSachHocSinh.Rows.Count; i++)
            {
                for (int j = 0; j < dgvDanhSachHocSinh.Columns.Count; j++)
                {
                    if (dgvDanhSachHocSinh.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvDanhSachHocSinh.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }

            for (int i = 1; i < dgvDanhSachGiaoVienBoMon.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i + 5] = dgvDanhSachGiaoVienBoMon.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgvDanhSachGiaoVienBoMon.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvDanhSachGiaoVienBoMon.Columns.Count; j++)
                {
                    if (dgvDanhSachGiaoVienBoMon.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 6] = dgvDanhSachGiaoVienBoMon.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 6] = "";
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn loại các học sinh ra khỏi lớp", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvDanhSachHocSinh.SelectedRows)
                    {
                        string MaHocSinh = row.Cells["MaHocSinh"].Value.ToString();
                        LopBUS.LoaiHocSinhRaKhoiLop(_lop._MaLop, MaHocSinh);
                    }

                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmChiTietLop_Load(new object(), new EventArgs());
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể loại học sinh ra khỏi lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_XoaPhanCong_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa phân công cho giáo viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvDanhSachGiaoVienBoMon.SelectedRows)
                    {
                        string MaGiaoVien = row.Cells["MaGiaoVien"].Value.ToString();
                        string MaLop = txtMaLop.Text;
                        SqlConn.XoaDong("PhanCong", "MaGiaoVien = '" + MaGiaoVien + "' and MaLop = '" + MaLop + "'");
                    }

                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmChiTietLop_Load(new object(), new EventArgs());
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể hủy bỏ phân công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
