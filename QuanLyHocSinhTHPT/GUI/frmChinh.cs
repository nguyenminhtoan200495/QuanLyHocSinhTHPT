using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.GUI;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.Entity;
using QuanLyHocSinhTHPT.DAO;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }
        

        #region Quản lý lớp
        private void tabLop_Layout(object sender, LayoutEventArgs e)
        {
            DataTable dtNamHoc = NamHocBUS.LayBangNamHoc("");
            cmbNamHoc.DataSource = dtNamHoc;
            cmbNamHoc.DisplayMember = "TenNamHoc";
            cmbNamHoc.ValueMember = "MaNamHoc";
            tabLop_LoadData();

            radKhoi10.Checked = true;
            cmbNamHoc.SelectedIndex = 0;            
        }

        private void tabLop_LoadData()
        {
            string Khoi = ""; ;
            if (radKhoi10.Checked) Khoi = "KHOI10";
            else if (radKhoi11.Checked) Khoi = "KHOI11";
            else if (radKhoi12.Checked) Khoi = "KHOI12";

            DataTable dtLop = LopBUS.LayDanhSachLop(Khoi, cmbNamHoc.SelectedValue.ToString());
            dgvLop.DataSource = dtLop;
        }

        private void radKhoi12_CheckedChanged(object sender, EventArgs e)
        {
            tabLop_LoadData();
        }

        private void radKhoi10_CheckedChanged(object sender, EventArgs e)
        {
            tabLop_LoadData();
        }

        private void cmbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabLop_LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = dgvLop.SelectedRows[0].Index;
            string MaLop = dgvLop.Rows[index].Cells["MaLop"].Value.ToString();

            DialogResult res = MessageBox.Show("Xóa lớp " + MaLop + " ra khỏi danh sách lớp?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    LopBUS.XoaLop(MaLop);
                    MessageBox.Show("Xóa thành công lớp " + MaLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabLop_LoadData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Xóa thất bại! Vui lòng kiểm tra cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            int index = dgvLop.SelectedRows[0].Index;

            string MaLop = dgvLop.Rows[index].Cells["MaLop"].Value.ToString();
            DataTable dtLop = LopBUS.LayBangLop("MaLop = '" + MaLop + "'");
            string TenLop = dtLop.Rows[0].Field<string>("TenLop");
            NamHoc namhoc = new NamHoc(dtLop.Rows[0].Field<string>("MaNamHoc"));
            GiaoVienChuNhiem giaovien = new GiaoVienChuNhiem(dtLop.Rows[0].Field<string>("MaGiaoVien"));
            Khoi khoilop = new Khoi(dtLop.Rows[0].Field<string>("MaKhoiLop"));
            Lop lop = new Lop(MaLop, TenLop, khoilop, namhoc, giaovien);

            frmSuaLop frm = new frmSuaLop(lop);
            frm.ShowDialog();

            try
            {
                LopBUS.SuaLop(frm._Lop);
            }
            catch (SqlException)
            {
                MessageBox.Show("Thông tin sửa đổi không hợp lệ, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabLop_LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLop frm = new frmThemLop();
            frm.ShowDialog();

            tabLop_LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tabLop_LoadData();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            int index = dgvLop.SelectedRows[0].Index;

            string MaLop = dgvLop.Rows[index].Cells["MaLop"].Value.ToString();
            DataTable dtLop = LopBUS.LayBangLop("MaLop = '" + MaLop + "'");

            string TenLop = dtLop.Rows[0].Field<string>("TenLop");

            NamHoc namhoc = new NamHoc(dtLop.Rows[0].Field<string>("MaNamHoc"), dgvLop.Rows[index].Cells["TenNamHoc"].Value.ToString());

            GiaoVienChuNhiem giaovien = new GiaoVienChuNhiem(dtLop.Rows[0].Field<string>("MaGiaoVien"), dgvLop.Rows[index].Cells["TenGiaoVien"].Value.ToString());

            Khoi khoilop = new Khoi(dtLop.Rows[0].Field<string>("MaKhoiLop"), dgvLop.Rows[index].Cells["TenKhoiLop"].Value.ToString());
            Lop lop = new Lop(MaLop, TenLop, khoilop, namhoc, giaovien);

            frmChiTietLop frm = new frmChiTietLop(lop);
            frm.ShowDialog();
        }               
        #endregion

        #region Quản lý học sinh
        private void tabHocSinh_Layout(object sender, LayoutEventArgs e)
        {
            tabHocSinh_LoadData();
        }

        private void tabHocSinh_LoadData()
        {
            DataTable dtDanhSachHocSinhRutGon = HocSinhBUS.LayDanhSachHocSinhRutGon("");
            DataTable dtDanToc = GlobalEntity.LayBang("DanToc", "");
            DataTable dtTonGiao = GlobalEntity.LayBang("TonGiao", "");

            dgvDanhSachHocSinh.DataSource = dtDanhSachHocSinhRutGon;

            cmbTimHocSinh.DataSource = dtDanhSachHocSinhRutGon;
            cmbTimHocSinh.DisplayMember = "HoTen";

            cmbDanToc_tabHocSinh.DataSource = dtDanToc;
            cmbDanToc_tabHocSinh.DisplayMember = "TenDanToc";
            cmbDanToc_tabHocSinh.ValueMember = "MaDanToc";

            cmbTonGiao_tabHocSinh.DataSource = dtTonGiao;
            cmbTonGiao_tabHocSinh.DisplayMember = "TenTonGiao";
            cmbTonGiao_tabHocSinh.ValueMember = "MaTonGiao";

            HocSinh hocsinh = HocSinhBUS.LayHocSinhTheoMa(dgvDanhSachHocSinh.Rows[0].Cells["MaHocSinh"].Value.ToString());
            HienThongTinHocSinh(hocsinh);

            KetThucSuaThongTinHocSinh();
        }

        private void HienThongTinHocSinh(HocSinh hocsinh)
        {
            txtHoTen_tabHocSinh.Text = hocsinh._Ten;
            txtMaHocSinh_tabHocSinh.Text = hocsinh._ID;

            if (hocsinh._GioiTinh == GioiTinh.nam) radNam.Checked = true;
            else radNu.Checked = true;

            dtpNgaySinh_tabHocSinh.Value = hocsinh._NgaySinh;
            txtNoiSinh_tabHocSinh.Text = hocsinh._NoiSinh;
            cmbDanToc_tabHocSinh.Text = hocsinh._DanToc._TenDanToc;
            cmbTonGiao_tabHocSinh.Text = hocsinh._TonGiao._TenTonGiao;
            txtHoTenCha_tabHocSinh.Text = hocsinh._HoTenCha;
            txtHoTenMej_tabHocSinh.Text = hocsinh._HoTenMe;
            txtNgheNghiepCha_tabHocSinh.Text = hocsinh._NgheNghiepCha;
            txtNgheNghiepMe_tabHocSinh.Text = hocsinh._NgheNghiepMe;
            
            DataTable dtDanToc = GlobalEntity.LayBang("DanToc", "");
            DataTable dtTonGiao = GlobalEntity.LayBang("TonGiao", "");

            cmbDanToc_tabHocSinh.SelectedIndex = GlobalEntity.LayChiSo(dtDanToc, "MaDanToc", hocsinh._DanToc._MaDanToc);
            cmbTonGiao_tabHocSinh.SelectedIndex = GlobalEntity.LayChiSo(dtTonGiao, "MaTonGiao", hocsinh._TonGiao._MaTonGiao);

            if (hocsinh._GioiTinh == GioiTinh.nam) radNam.Checked = true;
            else radNu.Checked = true;
        }

        private void dgvDanhSachHocSinh_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvDanhSachHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvDanhSachHocSinh.SelectedRows[0].Index;
            HocSinh hocsinh = HocSinhBUS.LayHocSinhTheoMa(dgvDanhSachHocSinh.Rows[index].Cells["MaHocSinh"].Value.ToString());
            HienThongTinHocSinh(hocsinh);
        }

        private void btnSuaHocSinh_Click(object sender, EventArgs e)
        {
            KichHoatSuaThongTinHocSinh();
        }

        private void btnDongYSuaHocSinh_Click(object sender, EventArgs e)
        {
            HocSinh hocsinh = NhanThongTinHocSinh();

            DialogResult res = MessageBox.Show("Bạn có muốn sửa thông tin của học sinh " + hocsinh._ID + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                HocSinhBUS.SuaHocSinh(hocsinh);
                tabHocSinh_LoadData();
            }
        }

        private HocSinh NhanThongTinHocSinh()
        {
            HocSinh hocsinh = new HocSinh(txtMaHocSinh_tabHocSinh.Text);

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
        private void KichHoatSuaThongTinHocSinh()
        {
            txtHoTen_tabHocSinh.ReadOnly = false;
            dtpNgaySinh_tabHocSinh.Enabled = true;
            txtNoiSinh_tabHocSinh.ReadOnly = false;
            radNam.Enabled = true;
            radNu.Enabled = true;
            cmbDanToc_tabHocSinh.Enabled = true;
            cmbTonGiao_tabHocSinh.Enabled = true;
            txtHoTenCha_tabHocSinh.ReadOnly = false;
            txtNgheNghiepCha_tabHocSinh.ReadOnly = false;
            txtHoTenMej_tabHocSinh.ReadOnly = false;
            txtNgheNghiepMe_tabHocSinh.ReadOnly = false;
            btnDongYSuaHocSinh.Enabled = true;
        }
        private void KetThucSuaThongTinHocSinh()
        {
            txtHoTen_tabHocSinh.ReadOnly = true;
            dtpNgaySinh_tabHocSinh.Enabled = false;
            txtNoiSinh_tabHocSinh.ReadOnly = true;
            radNam.Enabled = false;
            radNu.Enabled = false;
            cmbDanToc_tabHocSinh.Enabled = false;
            cmbTonGiao_tabHocSinh.Enabled = false;
            txtHoTenCha_tabHocSinh.ReadOnly = true;
            txtNgheNghiepCha_tabHocSinh.ReadOnly = true;
            txtHoTenMej_tabHocSinh.ReadOnly = true;
            txtNgheNghiepMe_tabHocSinh.ReadOnly = true;
            btnDongYSuaHocSinh.Enabled = false;
        }

        private void btnRefreshHocSinh_Click(object sender, EventArgs e)
        {
            tabHocSinh_LoadData();
        }

        private void btnXoaHocSinh_Click(object sender, EventArgs e)
        {
            int index = dgvDanhSachHocSinh.SelectedRows[0].Index;
            string MaHocSinh = dgvDanhSachHocSinh.Rows[index].Cells["MaHocSinh"].Value.ToString();

            DialogResult res = MessageBox.Show("Xóa học sinh " + MaHocSinh + " ra khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {

                    HocSinhBUS.XoaHocSinh(MaHocSinh);
                    tabHocSinh_LoadData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể xóa học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemHocSinh_Click(object sender, EventArgs e)
        {
            frmThemHocSinh frm = new frmThemHocSinh();
            frm.ShowDialog();

            tabHocSinh_LoadData();
        }
        #endregion

        #region Xếp lớp
        private void btnXepLop_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachHocSinh_tabXepLop.Rows)
            {
                if ((bool)row.Cells["Chon"].Value == true)
                {
                    TreeNode node = treeViewLop.SelectedNode;
                    if (node == null)
                    {
                        MessageBox.Show("Hãy chọn lớp để xếp vào", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (node.Nodes.Count == 0)
                    {
                        try
                        {
                            if ((bool)row.Cells["Chon"].Value == true)
                            {
                                LopBUS.PhanLop(row.Cells[1].Value.ToString(), node.Parent.Parent.Name, node.Parent.Name, node.Name);
                                MessageBox.Show("Đã xếp thành công học sinh " + row.Cells[1].Value.ToString() + " vào lớp " + node.Name + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Không thể xếp lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn lớp để xếp vào", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tabPage2_Layout(object sender, LayoutEventArgs e)
        {
            treeViewLop.Nodes.Clear();
            DataTable dtKhoiLop = GlobalEntity.LayBang("KhoiLop", "");
            DataTable dtLop = LopBUS.LayDanhSachLop();
            DataTable dtDSHS = HocSinhBUS.LayDanhSachHocSinhRutGon("");
            dgvDanhSachHocSinh_tabXepLop.DataSource = dtDSHS;

            cmbTimHocSinh_tabXepLop.DataSource = dtDSHS;
            cmbTimHocSinh_tabXepLop.DisplayMember = "HoTen";
            cmbTimHocSinh_tabXepLop.ValueMember = "MaHocSinh";

            DataTable dtNamHoc = GlobalEntity.LayBang("NamHoc", "");

            foreach (DataGridViewRow row in dgvDanhSachHocSinh_tabXepLop.Rows)
            {
                row.Cells["Chon"].Value = false;
            }
            foreach (DataRow namhoc in dtNamHoc.Rows)
            {
                TreeNode node = new TreeNode();
                node.Name = namhoc["MaNamHoc"].ToString();
                node.Text = namhoc["TenNamHoc"].ToString();

                treeViewLop.Nodes.Add(node);
                for (int i = 0; i < dtKhoiLop.Rows.Count; i++)
                {
                    TreeNode nodeKhoi = new TreeNode();
                    nodeKhoi.Name = dtKhoiLop.Rows[i].Field<string>("MaKhoiLop").ToString();
                    nodeKhoi.Text = dtKhoiLop.Rows[i].Field<string>("TenKhoiLop").ToString();

                    node.Nodes.Add(nodeKhoi);

                    foreach (DataRow row in dtLop.Rows)
                    {
                        if (row["MaKhoiLop"].ToString() == nodeKhoi.Name && row["MaNamHoc"].ToString() == node.Name)
                        {
                            TreeNode childnode = new TreeNode();
                            childnode.Name = row["MaLop"].ToString();
                            childnode.Text = row["TenLop"].ToString();

                            nodeKhoi.Nodes.Add(childnode);
                        }
                    }

                }     
            }            
        }

        private void treeViewLop_DoubleClick(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)sender;

            TreeNode node = tree.SelectedNode;
            if (node != null)
            {
                if (node.Nodes.Count == 0)
                {
                    string MaLop = node.Name.ToString();

                    frmChiTietLop frm = new frmChiTietLop(LopBUS.LayLopTheoMa(MaLop));
                    frm.Show();
                }
            }
        }

        #endregion

        #region Học vụ

        #region Quản lý học vụ
        private void tabQLHocVu_Layout(object sender, LayoutEventArgs e)
        {
            treeView_QuanLyHocVu.Nodes.Clear();

            DataTable dtNamHoc = GlobalEntity.LayBang("NamHoc", "");
            DataTable dtKhoiLop = GlobalEntity.LayBang("KhoiLop", "");
            DataTable dtLop = GlobalEntity.LayBang("Lop", "");

            foreach (DataRow row in dtNamHoc.Rows)
            {
                TreeNode node = new TreeNode();
                node.Name = row["MaNamHoc"].ToString();
                node.Text = row["TenNamHoc"].ToString();
                treeView_QuanLyHocVu.Nodes.Add(node);

                foreach (DataRow rowKhoiLop in dtKhoiLop.Rows)
                {
                    TreeNode nodeKhoiLop = new TreeNode();
                    nodeKhoiLop.Name = rowKhoiLop["MaKhoiLop"].ToString();
                    nodeKhoiLop.Text = rowKhoiLop["TenKhoiLop"].ToString();
                    node.Nodes.Add(nodeKhoiLop);

                    foreach (DataRow rowLop in dtLop.Rows)
                    {
                        if (rowLop["MaNamHoc"].ToString() == row["MaNamHoc"].ToString() && rowLop["MaKhoiLop"].ToString() == rowKhoiLop["MaKhoiLop"].ToString())
                        {
                            TreeNode nodeLop = new TreeNode();
                            nodeLop.Name = rowLop["MaLop"].ToString();
                            nodeLop.Text = rowLop["TenLop"].ToString();
                            nodeKhoiLop.Nodes.Add(nodeLop);

                        }
                    }
                }
            }
        }
      
        private void treeView_QuanLyHocVu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView_QuanLyHocVu.SelectedNode;
            if (node == null) return;

            switch (node.Level)
            {
                case 0:
                    txtMaNamHoc_QuanLyHocVu.Text = node.Name;
                    txtTenNamHoc_QuanLyHocVu.Text = node.Text;

                    if (node.Nodes.Count > 0)
                    {
                        txtMaKhoiLop_QuanLyHocVu.Text = node.Nodes[0].Name;
                        txtTenKhoiLop_QuanLyHocVu.Text = node.Nodes[0].Text;
                    }

                    break;
                case 1:
                    txtMaNamHoc_QuanLyHocVu.Text = node.Parent.Name;
                    txtTenNamHoc_QuanLyHocVu.Text = node.Parent.Text;
                    txtMaKhoiLop_QuanLyHocVu.Text = node.Name;
                    txtTenKhoiLop_QuanLyHocVu.Text = node.Text;
                    break;
                case 2:
                    txtMaNamHoc_QuanLyHocVu.Text = node.Parent.Parent.Name;
                    txtTenNamHoc_QuanLyHocVu.Text = node.Parent.Parent.Text;
                    txtMaKhoiLop_QuanLyHocVu.Text = node.Parent.Name;
                    txtTenKhoiLop_QuanLyHocVu.Text = node.Parent.Text;
                    break;
            }
        }

        private void btnSua_QuanLyHocVu_Click(object sender, EventArgs e)
        {
            if (treeView_QuanLyHocVu.SelectedNode != null)
            {
                txtTenNamHoc_QuanLyHocVu.ReadOnly = false;
                txtTenKhoiLop_QuanLyHocVu.ReadOnly = false;
                btnOK_QuanLyHocVu.Enabled = true;
            }
        }

        private void btnOK_QuanLyHocVu_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn thay đổi dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                GlobalEntity.CapNhat("NamHoc", "TenNamHoc", txtTenNamHoc_QuanLyHocVu.Text, "MaNamHoc = '" + txtMaNamHoc_QuanLyHocVu.Text + "'");
                GlobalEntity.CapNhat("KhoiLop", "TenKhoiLop", txtTenKhoiLop_QuanLyHocVu.Text, "MaKhoiLop = '" + txtMaKhoiLop_QuanLyHocVu.Text + "'");

                tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));

                txtTenKhoiLop_QuanLyHocVu.ReadOnly = true;
                txtTenNamHoc_QuanLyHocVu.ReadOnly = true;
                btnOK_QuanLyHocVu.Enabled = false;
            }
        }

        private void btnXoa_QuanLyHocVu_Click(object sender, EventArgs e)
        {
            if (treeView_QuanLyHocVu.SelectedNode != null)
            {
                DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    TreeNode node = treeView_QuanLyHocVu.SelectedNode;

                    try
                    {
                        switch (node.Level)
                        {
                            case 0:
                                GlobalEntity.XoaDong("NamHoc", "MaNamHoc = '" + txtMaNamHoc_QuanLyHocVu.Text + "'");
                                break;
                            case 1:
                                GlobalEntity.XoaDong("KhoiLop", "MaKhoiLop = '" + txtMaKhoiLop_QuanLyHocVu.Text + "'");
                                break;
                            case 2:
                                LopBUS.XoaLop(node.Name);
                                break;
                        }

                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thể xóa dữ liệu, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemKhoi_QuanLyHocVu_Click(object sender, EventArgs e)
        {
            frmThemKhoiLop frm = new frmThemKhoiLop();
            frm.ShowDialog();

            tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));
        }

        private void btnThemLop_QuanLyGiaoVu_Click(object sender, EventArgs e)
        {
            frmThemLop frm = new frmThemLop();
            frm.ShowDialog();

            tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));
        }

        private void btnThemNamHoc_Click(object sender, EventArgs e)
        {
            frmThemNamHoc frm = new frmThemNamHoc();
            frm.ShowDialog();

            tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));
        }

        private void btnRefresh_QuanLyHocVu_Click(object sender, EventArgs e)
        {
            tabQLHocVu_Layout(new object(), new LayoutEventArgs(new Control(), ""));
        }
        #endregion

        #region Kết quả học tập
        private void tabKetQuaHocTap_Layout(object sender, LayoutEventArgs e)
        {
            DataTable dtNamHoc = NamHocBUS.LayBangNamHoc("");
            DataTable dtKhoiLop = KhoiLopBUS.LayBangKhoiLop("");

            cmbNamHoc_KQ.DataSource = dtNamHoc;
            cmbNamHoc_KQ.DisplayMember = "TenNamHoc";
            cmbNamHoc_KQ.ValueMember = "MaNamHoc";

            cmbKhoi_KQ.DataSource = dtKhoiLop;
            cmbKhoi_KQ.DisplayMember = "TenKhoiLop";
            cmbKhoi_KQ.ValueMember = "MaKhoiLop";

            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_KQ.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoi_KQ.SelectedValue.ToString() + "'");
            cmbLop_KQ.DataSource = dtLop;
            cmbLop_KQ.DisplayMember = "TenLop";
            cmbLop_KQ.ValueMember = "MaLop";

            LoadBangKetQua();
        }

        private void LoadBangKetQua()
        {
            string MaLop = cmbLop_KQ.SelectedValue.ToString();
            string MaNamHoc = cmbNamHoc_KQ.SelectedValue.ToString();
            DataTable dtBangKetQua = null;
            DataTable dtHanhKiem = SqlConn.LayBang("HanhKiem", "");
            
            if (radHK1_KetQuaHocTap.Checked)
            {
                dtBangKetQua = KetQuaHocTapBUS.LayKetQuaHocKyTongHop(MaNamHoc, MaLop, "HK1");
                dgvKetQuaHocTap.DataSource = dtBangKetQua;
            }
            else if (radHK2_KetQuaHocTap.Checked)
            {
                dtBangKetQua = KetQuaHocTapBUS.LayKetQuaHocKyTongHop(MaNamHoc, MaLop, "HK2");
                dgvKetQuaHocTap.DataSource = dtBangKetQua;
            }
            else
            {
                dtBangKetQua = KetQuaHocTapBUS.LayKetQuaCaNamTongHop(MaNamHoc, MaLop);
            }                    
        }

        private void cmbKhoi_KQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_KQ.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoi_KQ.SelectedValue.ToString() + "'");
            cmbLop_KQ.DataSource = dtLop;
            cmbLop_KQ.DisplayMember = "TenLop";
            cmbLop_KQ.ValueMember = "MaLop";

            LoadBangKetQua();
        }

        private void cmbLop_KQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBangKetQua();
        }

        private void cmbNamHoc_KQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_KQ.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoi_KQ.SelectedValue.ToString() + "'");
            cmbLop_KQ.DataSource = dtLop;
            cmbLop_KQ.DisplayMember = "TenLop";
            cmbLop_KQ.ValueMember = "MaLop";

            LoadBangKetQua();
        }

        private void btnRefresh_KQ_Click(object sender, EventArgs e)
        {
            KetQuaHocTapBUS.LoadDanhSach();
            BangDiemBUS.LuuKetQuaDiem();
            LoadBangKetQua();
        }


        private void radHK1_KetQuaHocTap_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangKetQua();
        }

        private void radHK2_KetQuaHocTap_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangKetQua();
        }

        private void radCaNam_KetQuaHocTap_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangKetQua();
        }

        private void btnLuu_KQ_Click(object sender, EventArgs e)
        {
            KetQuaHocTapBUS.LoadDanhSach();
            BangDiemBUS.LuuKetQuaDiem();
            LoadBangKetQua();
        }

        private void btnDanhGiaHanhKiem_Click(object sender, EventArgs e)
        {
            frmDGHK frm = new frmDGHK();
            frm.ShowDialog();

            string MaHanhKiem = frm._MaHanhKiem;
            if (MaHanhKiem == "") return;
            string MaLop = cmbLop_KQ.SelectedValue.ToString();
            string MaHocKy = "HK1";
            if (radHK2_KetQuaHocTap.Checked) MaHocKy = "HK2";

            foreach (DataGridViewRow row in dgvKetQuaHocTap.SelectedRows)
            {
                string MaHocSinh = row.Cells["MaHocSinh_KQ"].Value.ToString();
                KetQuaHocTapBUS.LuuHanhKiem(MaHocSinh, MaLop, MaHocKy, MaHanhKiem);
            }

            LoadBangKetQua();
        }
        #endregion
        #endregion

        #region Bộ môn
        private void tabPhanCongBoMon_Layout(object sender, LayoutEventArgs e)
        {
            tabPhanCongBoMon_LoadData();
        }

        private void tabPhanCongBoMon_LoadData()
        {
            DataTable dtGiaoVienBoMon = GiaoVienBUS.LayBangGiaoVienBoMon();
            DataTable dtMonHoc = MonHocBUS.LayBangMonHocRutGon("");
            DataTable dtNamHoc = NamHocBUS.LayBangNamHoc("");
            DataTable dtKhoiLop = KhoiLopBUS.LayBangKhoiLop("");

            dgvGiaoVienBoMon_PhanCong.DataSource = dtGiaoVienBoMon;
            dgvMonHoc_BoMon.DataSource = dtMonHoc;
            
            cmbKhoi_BoMon.DataSource = dtKhoiLop;
            cmbKhoi_BoMon.ValueMember = "MaKhoiLop";
            cmbKhoi_BoMon.DisplayMember = "TenKhoiLop";

            cmbNamHoc_BoMon.DataSource = dtNamHoc;
            cmbNamHoc_BoMon.DisplayMember = "TenNamHoc";
            cmbNamHoc_BoMon.ValueMember = "MaNamHoc";

            DataTable dtLop = GlobalEntity.LayBang("Select MaLop, TenLop from Lop where MaKhoiLop = '" + cmbKhoi_BoMon.SelectedValue + "' and MaNamHoc = '" + cmbNamHoc_BoMon.SelectedValue + "'");
            cmbLop_BoMon.DataSource = dtLop;
            cmbLop_BoMon.DisplayMember = "TenLop";
            cmbLop_BoMon.ValueMember = "MaLop";
        }

        private void btnPhanCong_BoMon_Click(object sender, EventArgs e)
        {
            int index = dgvGiaoVienBoMon_PhanCong.SelectedRows[0].Index;
            string MaGiaoVien = dgvGiaoVienBoMon_PhanCong.Rows[index].Cells["MaGiaoVien"].Value.ToString();
            string TenGiaoVien = dgvGiaoVienBoMon_PhanCong.Rows[index].Cells["TenGiaoVien_PhanCong"].Value.ToString();
            string MaMonHoc_GiaoVien = dgvGiaoVienBoMon_PhanCong.Rows[index].Cells["MaMonHoc_PhanCong"].Value.ToString();

            index = dgvMonHoc_BoMon.SelectedRows[0].Index;
            string MaMonHoc = dgvMonHoc_BoMon.Rows[index].Cells["MaMonHoc"].Value.ToString();
            string TenMonHoc = dgvMonHoc_BoMon.Rows[index].Cells["TenMonHoc"].Value.ToString();

            if (MaMonHoc != MaMonHoc_GiaoVien)
            {
                MessageBox.Show("Môn học không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MaNamHoc = cmbNamHoc_BoMon.SelectedValue.ToString();
            string MaLop = cmbLop_BoMon.SelectedValue.ToString();
            string TenLop = cmbLop_BoMon.Text;

            try
            {
                MonHocBUS.XepLop(MaNamHoc, MaLop, MaMonHoc, MaGiaoVien);

                MessageBox.Show("Đã phân công cho giáo viên " + TenGiaoVien + " dạy môn " + TenMonHoc + " của lớp " + TenLop + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi xảy ra với cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChiTietPhanCong_Click(object sender, EventArgs e)
        {
            Lop lop = LopBUS.LayLopTheoMa(cmbLop_BoMon.SelectedValue.ToString());
            frmChiTietLop frm = new frmChiTietLop(lop);
            frm.ShowDialog();
        }

        private void cmbNamHoc_BoMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = GlobalEntity.LayBang("Select MaLop, TenLop from Lop where MaKhoiLop = '" + cmbKhoi_BoMon.SelectedValue + "' and MaNamHoc = '" + cmbNamHoc_BoMon.SelectedValue + "'");
            cmbLop_BoMon.DataSource = dtLop;
            cmbLop_BoMon.DisplayMember = "TenLop";
            cmbLop_BoMon.ValueMember = "MaLop";
        }

        private void cmbKhoi_BoMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = GlobalEntity.LayBang("Select MaLop, TenLop from Lop where MaKhoiLop = '" + cmbKhoi_BoMon.SelectedValue + "' and MaNamHoc = '" + cmbNamHoc_BoMon.SelectedValue + "'");
            cmbLop_BoMon.DataSource = dtLop;
            cmbLop_BoMon.DisplayMember = "TenLop";
            cmbLop_BoMon.ValueMember = "MaLop";
        }
        #endregion

        #region Quản lý điểm các môn
        private void tabNhapDiemBoMon_Layout(object sender, LayoutEventArgs e)
        {
            tabNhapDiemBoMon_LoadData();
        }

        private void tabNhapDiemBoMon_LoadData()
        {
            DataTable dtNamHoc = NamHocBUS.LayBangNamHoc("");
            DataTable dtKhoiLop = KhoiLopBUS.LayBangKhoiLop("");
            DataTable dtMonHoc = MonHocBUS.LayBangMonHocRutGon("");

            cmbNamHoc_NhapDiem.DataSource = dtNamHoc;
            cmbNamHoc_NhapDiem.DisplayMember = "TenNamHoc";
            cmbNamHoc_NhapDiem.ValueMember = "MaNamHoc";

            cmbKhoiLop_NhapDiem.DataSource = dtKhoiLop;
            cmbKhoiLop_NhapDiem.DisplayMember = "TenKhoiLop";
            cmbKhoiLop_NhapDiem.ValueMember = "MaKhoiLop";
          
            cmbMon_NhapDiem.DataSource = dtMonHoc;
            cmbMon_NhapDiem.DisplayMember = "TenMonHoc";
            cmbMon_NhapDiem.ValueMember = "MaMonHoc";

            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_NhapDiem.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoiLop_NhapDiem.SelectedValue.ToString() + "'");
            cmbLop_NhapDiem.DataSource = dtLop;
            cmbLop_NhapDiem.DisplayMember = "TenLop";
            cmbLop_NhapDiem.ValueMember = "MaLop";

            LoadBangDiemMon();
        }

        private void LoadBangDiemMon()
        {
            string MaLop = cmbLop_NhapDiem.SelectedValue.ToString();
            string MaMonHoc = cmbMon_NhapDiem.SelectedValue.ToString();
            string MaHocKy;

            if (radHKI_BangDiem.Checked) MaHocKy = "HK1";
            else MaHocKy = "HK2";

            DataTable dtBangDiemMon = BangDiemBUS.LayBangDiemMon(MaLop, MaMonHoc, MaHocKy);
            dgvBangDiemMon.DataSource = dtBangDiemMon;

            foreach (DataGridViewRow row in dgvBangDiemMon.Rows)
            {
                BangDiem bangdiem = LayDiemTuDataGridViewRow(row);
                float dtb = bangdiem.TinhTrungBinh();
                if (dtb >= 0)
                {
                    row.Cells["Tong_NhapDiem"].Value = dtb;
                }
            }
        }

        private void btnThem_NhapDiem_Click(object sender, EventArgs e)
        {
            string MaLop = cmbLop_NhapDiem.SelectedValue.ToString();
            string MaMonHoc = cmbMon_NhapDiem.SelectedValue.ToString();
            string MaHocKy;

            if (radHKI_BangDiem.Checked) MaHocKy = "HK1";
            else MaHocKy = "HK2";
            frmThemHocSinhNhapDiem frm = new frmThemHocSinhNhapDiem(MaLop, MaMonHoc, MaHocKy);
            frm.ShowDialog();

            LoadBangDiemMon();
        }

        private void cmbKhoiLop_NhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_NhapDiem.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoiLop_NhapDiem.SelectedValue.ToString() + "'");
            cmbLop_NhapDiem.DataSource = dtLop;
            cmbLop_NhapDiem.DisplayMember = "TenLop";
            cmbLop_NhapDiem.ValueMember = "MaLop";

            LoadBangDiemMon();
        }

        private void cmbNamHoc_NhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtLop = LopBUS.LayBangLop("MaNamHoc = '" + cmbNamHoc_NhapDiem.SelectedValue.ToString() + "' and MaKhoiLop = '" + cmbKhoiLop_NhapDiem.SelectedValue.ToString() + "'");
            cmbLop_NhapDiem.DataSource = dtLop;
            cmbLop_NhapDiem.DisplayMember = "TenLop";
            cmbLop_NhapDiem.ValueMember = "MaLop";

            LoadBangDiemMon();
        }

        private void cmbLop_NhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBangDiemMon();
        }

        private void cmbMon_NhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBangDiemMon();
        }

        private void radHKI_BangDiem_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangDiemMon();
        }

        private void radHKII_BangDiem_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangDiemMon();
        }

        private void btnXoa_NhapDiem_Click(object sender, EventArgs e)
        {
            int index = dgvBangDiemMon.SelectedCells[0].RowIndex;
            string MaHocSinh = dgvBangDiemMon.Rows[index].Cells["MaHocSinh_NhapDiem"].Value.ToString();
            
            DialogResult res = MessageBox.Show("Điểm của học sinh " + MaHocSinh + " sẽ bị mất, bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string MaLop = cmbLop_NhapDiem.SelectedValue.ToString();
            string MaMonHoc = cmbMon_NhapDiem.SelectedValue.ToString();
            string MaHocKy = "HK1";
            if (radHKII_BangDiem.Checked) MaHocKy = "HK2";

            BangDiemBUS.XoaKhoiBangDiem(MaHocSinh, MaLop, MaMonHoc, MaHocKy);
            LoadBangDiemMon();
        }

        private void btnXacNhan_NhapDiem_Click(object sender, EventArgs e)
        {           
            foreach (DataGridViewRow row in dgvBangDiemMon.Rows)
            {                
                BangDiem bangdiem = LayDiemTuDataGridViewRow(row);             
                BangDiemBUS.NhapDiem(bangdiem);
            }

            MessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LoadBangDiemMon();
        }

        private BangDiem LayDiemTuDataGridViewRow(DataGridViewRow row)
        {
            string MaHK = "HK1";
            if (radHKII_BangDiem.Checked) MaHK = "HK2";
            string MaLop = cmbLop_NhapDiem.SelectedValue.ToString();
            string MaMonHoc = cmbMon_NhapDiem.SelectedValue.ToString();

            string MaHocSinh = row.Cells["MaHocSinh_NhapDiem"].Value.ToString();
            float mieng = -1;
            if (row.Cells["Mieng_NhapDiem"].Value.ToString() != "") mieng = float.Parse(row.Cells["Mieng_NhapDiem"].Value.ToString().Trim());
            float kt15_1 = -1;
            if (row.Cells["KiemTra15_1_NhapDiem"].Value.ToString() != "") kt15_1 = float.Parse(row.Cells["KiemTra15_1_NhapDiem"].Value.ToString().Trim());
            float kt15_2 = -1;
            if (row.Cells["KiemTra15_2_NhapDiem"].Value.ToString() != "") kt15_2 = float.Parse(row.Cells["KiemTra15_2_NhapDiem"].Value.ToString().Trim());
            float kt15_3 = -1;
            if (row.Cells["KiemTra15_3_NhapDiem"].Value.ToString() != "") kt15_3 = float.Parse(row.Cells["KiemTra15_3_NhapDiem"].Value.ToString().Trim());
            float kt1_1 = -1;
            if (row.Cells["KiemTra1Tiet_1_NhapDiem"].Value.ToString() != "") kt1_1 = float.Parse(row.Cells["KiemTra1Tiet_1_NhapDiem"].Value.ToString().Trim());
            float kt1_2 = -1;
            if (row.Cells["KiemTra1Tiet_2_NhapDiem"].Value.ToString() != "") kt1_2 = float.Parse(row.Cells["KiemTra1Tiet_2_NhapDiem"].Value.ToString().Trim());
            float thi = -1;
            if (row.Cells["ThiHK_NhapDiem"].Value.ToString() != "") thi = float.Parse(row.Cells["ThiHK_NhapDiem"].Value.ToString().Trim());

            BangDiem bangdiem = new BangDiem(MaHocSinh, MaLop, MaMonHoc, MaHK, mieng, kt15_1, kt15_2, kt15_3, kt1_1, kt1_2, thi);

            return bangdiem;
        }

        
#endregion                             
        
        #region Quản lý giáo viên
        private void btnThem_GV_Click(object sender, EventArgs e)
        {
            frmThemGiaoVien frm = new frmThemGiaoVien();
            frm.ShowDialog();

            if (frm._GiaoVien != null)
            {
                GiaoVienBUS.ThemGiaoVien(frm._GiaoVien);
            }

            LoadBangGiaoVien_GV();
        }

        private void tabGiaoVien_Layout(object sender, LayoutEventArgs e)
        {
            LoadBangGiaoVien_GV();
        }

        private void LoadBangGiaoVien_GV()
        {
            DataTable dtGiaoVien = GiaoVienBUS.LayBangGiaoVien("");
            dgvGiaoVien_GV.DataSource = dtGiaoVien;

            foreach (DataGridViewRow row in dgvGiaoVien_GV.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
            }
        }

        private void btnXoa_GV_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGiaoVien_GV.SelectedRows)
            {
                string MaGiaoVien = row.Cells["MaGiaoVien_GV"].Value.ToString();
                GiaoVienBUS.XoaGiaoVien(MaGiaoVien);
            }

            LoadBangGiaoVien_GV();
        }

        private void btnSua_GV_Click(object sender, EventArgs e)
        {
            string MaGiaoVien = dgvGiaoVien_GV.SelectedRows[0].Cells["MaGiaoVien_GV"].Value.ToString();
            GiaoVien giaovien = GiaoVienBUS.LayGiaoVien(MaGiaoVien);

            frmSuaGiaoVien frm = new frmSuaGiaoVien(giaovien);
            frm.ShowDialog();

            LoadBangGiaoVien_GV();
        }
        #endregion

        #region Quy định học lực
        private void tabQuyDinh_Layout(object sender, LayoutEventArgs e)
        {
            LoadBangHocLuc();
        }

        private void LoadBangHocLuc()
        {
            string Query = "Select MaHocLuc, TenHocLuc, DiemCanDuoi, DiemKhongChe from HocLuc";
            DataTable dtHocLuc = SqlConn.LayBang(Query);

            dgvHocLuc.DataSource = dtHocLuc;
            LoadHocLuc();
        }

        

        private void LoadHocLuc()
        {
            DataGridViewRow row;
            if (dgvHocLuc.SelectedRows.Count < 1) row = dgvHocLuc.Rows[0];
            else row = dgvHocLuc.SelectedRows[0];
            txtMaHocLuc.Text = row.Cells["MaHocLuc"].Value.ToString();
            txtTenHocLuc.Text = row.Cells["TenHocLuc"].Value.ToString();
            txtDiemKhongChe.Text = row.Cells["DiemKhongChe"].Value.ToString();
            txtDiemCanDuoi.Text = row.Cells["DiemCanDuoi"].Value.ToString();
        }

        private void dgvHocLuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadHocLuc();
        }

        private void btnChinhSua_HocLuc_Click(object sender, EventArgs e)
        {
            gbxHocLuc.Enabled = true;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            float DiemCanDuoi = 0, DiemKhongChe = 0;
            bool flag = false;

            flag = float.TryParse(txtDiemCanDuoi.Text, out DiemCanDuoi) && float.TryParse(txtDiemKhongChe.Text, out DiemKhongChe);

            if (!flag)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng!");
            }
            else
            {
                LoaiHocLucBUS.SuaHocLuc(txtMaHocLuc.Text, txtTenHocLuc.Text, DiemCanDuoi, DiemKhongChe);
                gbxHocLuc.Enabled = false;
                LoadBangHocLuc();
            }
        }
        #endregion

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalEntity._Acc != null)
            {
                MessageBox.Show("Bạn chưa đăng xuất!");
                return;
            }
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();

            if (GlobalEntity._Acc == null) return;

            PhanQuyen(GlobalEntity._Acc);

            lblUserName.Text = GlobalEntity._Acc._TenDangNhap;
            lblUserType.Text = GlobalEntity._Acc._Quyen.ToString();
        }

        private void PhanQuyen(NguoiDung nguoidung)
        {
            if (nguoidung == null)
            {
                tabControl.Enabled = false;
            }
            else
            {
                tabControl.Enabled = true;
                switch (nguoidung._Quyen)
                {
                    case Quyen.GiaoVu:
                        btnXacNhan_NhapDiem.Enabled = btnXoa_NhapDiem.Enabled = btnThem_NhapDiem.Enabled = false;
                        btnLuu_KQ.Enabled = btnDanhGiaHanhKiem.Enabled = false;

                        btnThem.Enabled = btnXoa.Enabled = btnChinhSua.Enabled = btnThemHocSinh.Enabled = true;
                        btnThemHS.Enabled = btnSuaHocSinh.Enabled = btnXoaHocSinh.Enabled = true;
                        btnXepLop.Enabled = true;
                        btnThemNamHoc.Enabled = btnThemKhoi_QuanLyHocVu.Enabled = btnThemLop_QuanLyGiaoVu.Enabled = btnXoa_QuanLyHocVu.Enabled = btnSua_QuanLyHocVu.Enabled = true;
                        btnPhanCong_BoMon.Enabled = true;
                        btnChinhSua_HocLuc.Enabled = true;
                        btnThem_GV.Enabled = btnXoa_GV.Enabled = btnSua_GV.Enabled = true;
                        btnChiTiet.Enabled = btnChiTietPhanCong.Enabled = true;
                        break;
                    case Quyen.GiaoVien:
                        btnThem.Enabled = btnXoa.Enabled = btnChinhSua.Enabled = btnThemHocSinh.Enabled = false;
                        btnThemHS.Enabled = btnSuaHocSinh.Enabled = btnXoaHocSinh.Enabled = false;
                        btnXepLop.Enabled = false;
                        btnThemNamHoc.Enabled = btnThemKhoi_QuanLyHocVu.Enabled = btnThemLop_QuanLyGiaoVu.Enabled = btnXoa_QuanLyHocVu.Enabled = btnSua_QuanLyHocVu.Enabled = false;
                        btnPhanCong_BoMon.Enabled = false;
                        btnChinhSua_HocLuc.Enabled = false;
                        btnThem_GV.Enabled = btnXoa_GV.Enabled = btnSua_GV.Enabled = false;

                        btnXacNhan_NhapDiem.Enabled = btnXoa_NhapDiem.Enabled = btnThem_NhapDiem.Enabled = true;
                        btnLuu_KQ.Enabled = btnDanhGiaHanhKiem.Enabled = true;
                        btnChiTiet.Enabled = btnChiTietPhanCong.Enabled = false;
                        break;
                    case Quyen.QuanLy:
                        btnXacNhan_NhapDiem.Enabled = btnXoa_NhapDiem.Enabled = btnThem_NhapDiem.Enabled = true;
                        btnLuu_KQ.Enabled = btnDanhGiaHanhKiem.Enabled = true;

                        btnThem.Enabled = btnXoa.Enabled = btnChinhSua.Enabled = btnThemHocSinh.Enabled = true;
                        btnThemHS.Enabled = btnSuaHocSinh.Enabled = btnXoaHocSinh.Enabled = true;
                        btnXepLop.Enabled = true;
                        btnThemNamHoc.Enabled = btnThemKhoi_QuanLyHocVu.Enabled = btnThemLop_QuanLyGiaoVu.Enabled = btnXoa_QuanLyHocVu.Enabled = btnSua_QuanLyHocVu.Enabled = true;
                        btnPhanCong_BoMon.Enabled = true;
                        btnChinhSua_HocLuc.Enabled = true;
                        btnThem_GV.Enabled = btnXoa_GV.Enabled = btnSua_GV.Enabled = true;
                        btnChiTiet.Enabled = btnChiTietPhanCong.Enabled = true;
                        break;
                    default:
                        tabControl.Enabled = false;
                        break;
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalEntity._Acc == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
                return;
            }
            tabControl.Enabled = false;
            GlobalEntity._Acc = null;
            lblUserName.Text = "User name";
            lblUserType.Text = "User type";
        }
        
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalEntity._Acc == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
                return;
            }

            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();

            if (GlobalEntity._Acc == null)
            {
                tabControl.Enabled = false;
                GlobalEntity._Acc = null;
            }
        }
      
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.Yes) this.Close();
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
        }

        private void btnKetXuatHocSinh_Click(object sender, EventArgs e)
        {

        }

        private void btnKetXuat_KQ_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dgvKetQuaHocTap.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvKetQuaHocTap.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgvKetQuaHocTap.Rows.Count; i++)
            {
                for (int j = 0; j < dgvKetQuaHocTap.Columns.Count; j++)
                {
                    if (dgvKetQuaHocTap.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvKetQuaHocTap.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }

        }
    }
}
