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
    public partial class frmThemKhoiLop : Form
    {
        public frmThemKhoiLop()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string TenKhoiLop = txtTenKhoiLop.Text;
            if (TenKhoiLop.Length < 2)
            {
                MessageBox.Show("Tên khối lớp không hợp lệ!");
            }
            else
            {
                try
                {
                    string MaKhoiLop = KhoiLopBUS.PhatSinhMaKhoiLop(TenKhoiLop);
                    txtMaKhoiLop.Text = MaKhoiLop;
                    string Query = "Insert into KhoiLop values('" + MaKhoiLop + "', N'" + TenKhoiLop + "')";
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

        private void frmThemKhoiLop_Load(object sender, EventArgs e)
        {
            txtTenKhoiLop.Focus();
        }

        private void gbxKhoiLop_Enter(object sender, EventArgs e)
        {

        }
    }
}
