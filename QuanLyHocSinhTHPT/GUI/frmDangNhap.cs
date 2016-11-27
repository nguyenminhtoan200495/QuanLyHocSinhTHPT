using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.Entity;
using QuanLyHocSinhTHPT.BUS;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NguoiDung nguoidung = NguoiDungBUS.DangNhap(txtUser.Text, txtPass.Text);
            if (nguoidung != null)
            {
                GlobalEntity._Acc = nguoidung;
                this.Close();
            }
            else
            {
                txtUser.ResetText();
                txtPass.ResetText();
                txtUser.Focus();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPass.Focus();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(new object(), new EventArgs());
        }
       
    }
}
