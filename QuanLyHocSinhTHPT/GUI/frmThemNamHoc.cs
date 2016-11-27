using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.BUS;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmThemNamHoc : Form
    {
        public frmThemNamHoc()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string TenNamHoc = txtTenNamHoc.Text;
            if (TenNamHoc.Length < 11)
            {
                MessageBox.Show("Tên khối lớp không hợp lệ!");
            }
            else
            {
                try
                {
                    string MaNamHoc = NamHocBUS.PhatSinhMaNamHoc(TenNamHoc);
                    txtMaNamHoc.Text = MaNamHoc;
                    string Query = "Insert into NamHoc values('" + MaNamHoc + "', '" + TenNamHoc + "')";
                    GlobalEntity.ThucHienLenh(Query);

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Thêm khối lớp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void frmThemNamHoc_Load(object sender, EventArgs e)
        {
            txtTenNamHoc.Focus();
        }
    }
}
