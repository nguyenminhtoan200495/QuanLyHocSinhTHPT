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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPass2.Text == "" || txtPass.Text == "") MessageBox.Show("Mật khẩu mới không được rỗng!");
            else if (txtPass.Text != txtPass2.Text) MessageBox.Show("Mật khẩu xác nhận không đúng!");
            else if (txtPass0.Text != GlobalEntity._Acc._MatKhau) MessageBox.Show("Mật khẩu cũ không đúng!");
            else
            {
                NguoiDungBUS.DoiMatKhau(GlobalEntity._Acc, txtPass.Text);
                GlobalEntity._Acc = null;
                this.Close();
            }

        }
    }
}
