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

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class frmDGHK : Form
    {
        public string _MaHanhKiem;

        public frmDGHK()
        {
            InitializeComponent();
        }

        private void frmDGHK_Load(object sender, EventArgs e)
        {
            DataTable dtHanhKiem = SqlConn.LayBang("HanhKiem", "");

            cmbHanhKiem.DataSource = dtHanhKiem;
            cmbHanhKiem.DisplayMember = "TenHanhKiem";
            cmbHanhKiem.ValueMember = "MaHanhKiem";
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            _MaHanhKiem = cmbHanhKiem.SelectedValue.ToString();
            this.Close();
        }
    }
}
