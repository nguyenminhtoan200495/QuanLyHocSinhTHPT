namespace QuanLyHocSinhTHPT.GUI
{
    partial class frmChiTietLop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietLop));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxDanhSachHocSinh = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbTimHS = new System.Windows.Forms.ComboBox();
            this.dgvDanhSachHocSinh = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxGiaoVienBoMon = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbTimBoMon = new System.Windows.Forms.ComboBox();
            this.dgvDanhSachGiaoVienBoMon = new System.Windows.Forms.DataGridView();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtKhoiLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.txtGVCN = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnKetXuat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_XoaPhanCong = new System.Windows.Forms.Button();
            this.TenMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxDanhSachHocSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHocSinh)).BeginInit();
            this.gbxGiaoVienBoMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachGiaoVienBoMon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khối";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm học";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giáo viên chủ nhiệm";
            // 
            // gbxDanhSachHocSinh
            // 
            this.gbxDanhSachHocSinh.Controls.Add(this.pictureBox1);
            this.gbxDanhSachHocSinh.Controls.Add(this.cmbTimHS);
            this.gbxDanhSachHocSinh.Controls.Add(this.dgvDanhSachHocSinh);
            this.gbxDanhSachHocSinh.Location = new System.Drawing.Point(43, 173);
            this.gbxDanhSachHocSinh.Name = "gbxDanhSachHocSinh";
            this.gbxDanhSachHocSinh.Size = new System.Drawing.Size(431, 484);
            this.gbxDanhSachHocSinh.TabIndex = 5;
            this.gbxDanhSachHocSinh.TabStop = false;
            this.gbxDanhSachHocSinh.Text = "Danh sách học sinh";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyHocSinhTHPT.Properties.Resources.Search;
            this.pictureBox1.Location = new System.Drawing.Point(137, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // cmbTimHS
            // 
            this.cmbTimHS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTimHS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTimHS.FormattingEnabled = true;
            this.cmbTimHS.Location = new System.Drawing.Point(183, 31);
            this.cmbTimHS.Name = "cmbTimHS";
            this.cmbTimHS.Size = new System.Drawing.Size(218, 28);
            this.cmbTimHS.TabIndex = 9;
            // 
            // dgvDanhSachHocSinh
            // 
            this.dgvDanhSachHocSinh.AllowUserToAddRows = false;
            this.dgvDanhSachHocSinh.AllowUserToResizeColumns = false;
            this.dgvDanhSachHocSinh.AllowUserToResizeRows = false;
            this.dgvDanhSachHocSinh.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachHocSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaHocSinh,
            this.HoTen});
            this.dgvDanhSachHocSinh.Location = new System.Drawing.Point(21, 80);
            this.dgvDanhSachHocSinh.Name = "dgvDanhSachHocSinh";
            this.dgvDanhSachHocSinh.RowHeadersVisible = false;
            this.dgvDanhSachHocSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachHocSinh.Size = new System.Drawing.Size(380, 384);
            this.dgvDanhSachHocSinh.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // MaHocSinh
            // 
            this.MaHocSinh.DataPropertyName = "MaHocSinh";
            this.MaHocSinh.HeaderText = "Mã học sinh";
            this.MaHocSinh.Name = "MaHocSinh";
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên học sinh";
            this.HoTen.Name = "HoTen";
            // 
            // gbxGiaoVienBoMon
            // 
            this.gbxGiaoVienBoMon.Controls.Add(this.pictureBox2);
            this.gbxGiaoVienBoMon.Controls.Add(this.cmbTimBoMon);
            this.gbxGiaoVienBoMon.Controls.Add(this.dgvDanhSachGiaoVienBoMon);
            this.gbxGiaoVienBoMon.Location = new System.Drawing.Point(503, 173);
            this.gbxGiaoVienBoMon.Name = "gbxGiaoVienBoMon";
            this.gbxGiaoVienBoMon.Size = new System.Drawing.Size(495, 484);
            this.gbxGiaoVienBoMon.TabIndex = 6;
            this.gbxGiaoVienBoMon.TabStop = false;
            this.gbxGiaoVienBoMon.Text = "Danh sách giáo viên bộ môn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyHocSinhTHPT.Properties.Resources.Search;
            this.pictureBox2.Location = new System.Drawing.Point(206, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // cmbTimBoMon
            // 
            this.cmbTimBoMon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTimBoMon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTimBoMon.FormattingEnabled = true;
            this.cmbTimBoMon.Location = new System.Drawing.Point(252, 31);
            this.cmbTimBoMon.Name = "cmbTimBoMon";
            this.cmbTimBoMon.Size = new System.Drawing.Size(218, 28);
            this.cmbTimBoMon.TabIndex = 10;
            // 
            // dgvDanhSachGiaoVienBoMon
            // 
            this.dgvDanhSachGiaoVienBoMon.AllowUserToAddRows = false;
            this.dgvDanhSachGiaoVienBoMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachGiaoVienBoMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachGiaoVienBoMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenMonHoc,
            this.MaGiaoVien,
            this.TenGiaoVien});
            this.dgvDanhSachGiaoVienBoMon.Location = new System.Drawing.Point(30, 80);
            this.dgvDanhSachGiaoVienBoMon.Name = "dgvDanhSachGiaoVienBoMon";
            this.dgvDanhSachGiaoVienBoMon.RowHeadersVisible = false;
            this.dgvDanhSachGiaoVienBoMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachGiaoVienBoMon.Size = new System.Drawing.Size(440, 383);
            this.dgvDanhSachGiaoVienBoMon.TabIndex = 1;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(109, 55);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(118, 26);
            this.txtMaLop.TabIndex = 9;
            // 
            // txtKhoiLop
            // 
            this.txtKhoiLop.Location = new System.Drawing.Point(109, 97);
            this.txtKhoiLop.Name = "txtKhoiLop";
            this.txtKhoiLop.ReadOnly = true;
            this.txtKhoiLop.Size = new System.Drawing.Size(118, 26);
            this.txtKhoiLop.TabIndex = 10;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(371, 52);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.ReadOnly = true;
            this.txtTenLop.Size = new System.Drawing.Size(182, 26);
            this.txtTenLop.TabIndex = 11;
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(371, 94);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.ReadOnly = true;
            this.txtNamHoc.Size = new System.Drawing.Size(182, 26);
            this.txtNamHoc.TabIndex = 12;
            // 
            // txtGVCN
            // 
            this.txtGVCN.Location = new System.Drawing.Point(743, 94);
            this.txtGVCN.Name = "txtGVCN";
            this.txtGVCN.ReadOnly = true;
            this.txtGVCN.Size = new System.Drawing.Size(255, 26);
            this.txtGVCN.TabIndex = 13;
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::QuanLyHocSinhTHPT.Properties.Resources.Close;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(285, 663);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(127, 45);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKetXuat
            // 
            this.btnKetXuat.Image = global::QuanLyHocSinhTHPT.Properties.Resources.Excel;
            this.btnKetXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetXuat.Location = new System.Drawing.Point(44, 669);
            this.btnKetXuat.Name = "btnKetXuat";
            this.btnKetXuat.Size = new System.Drawing.Size(135, 45);
            this.btnKetXuat.TabIndex = 7;
            this.btnKetXuat.Text = "Kết xuất";
            this.btnKetXuat.UseVisualStyleBackColor = true;
            this.btnKetXuat.Click += new System.EventHandler(this.btnKetXuat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(37, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 36);
            this.label6.TabIndex = 15;
            this.label6.Text = "Chi tiết thông tin lớp";
            // 
            // btn_XoaPhanCong
            // 
            this.btn_XoaPhanCong.Image = global::QuanLyHocSinhTHPT.Properties.Resources.Close;
            this.btn_XoaPhanCong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XoaPhanCong.Location = new System.Drawing.Point(846, 669);
            this.btn_XoaPhanCong.Name = "btn_XoaPhanCong";
            this.btn_XoaPhanCong.Size = new System.Drawing.Size(127, 45);
            this.btn_XoaPhanCong.TabIndex = 16;
            this.btn_XoaPhanCong.Text = "Xóa";
            this.btn_XoaPhanCong.UseVisualStyleBackColor = true;
            this.btn_XoaPhanCong.Click += new System.EventHandler(this.btn_XoaPhanCong_Click);
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.DataPropertyName = "TenMonHoc";
            this.TenMonHoc.HeaderText = "Môn học";
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.Width = 180;
            // 
            // MaGiaoVien
            // 
            this.MaGiaoVien.DataPropertyName = "MaGiaoVien";
            this.MaGiaoVien.HeaderText = "Mã GV";
            this.MaGiaoVien.Name = "MaGiaoVien";
            this.MaGiaoVien.Width = 80;
            // 
            // TenGiaoVien
            // 
            this.TenGiaoVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenGiaoVien.DataPropertyName = "TenGiaoVien";
            this.TenGiaoVien.HeaderText = "Giáo viên phụ trách";
            this.TenGiaoVien.Name = "TenGiaoVien";
            // 
            // frmChiTietLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 719);
            this.Controls.Add(this.btn_XoaPhanCong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtGVCN);
            this.Controls.Add(this.txtNamHoc);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.txtKhoiLop);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.btnKetXuat);
            this.Controls.Add(this.gbxGiaoVienBoMon);
            this.Controls.Add(this.gbxDanhSachHocSinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChiTietLop";
            this.Text = "Chi tiết lớp";
            this.Load += new System.EventHandler(this.frmChiTietLop_Load);
            this.gbxDanhSachHocSinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHocSinh)).EndInit();
            this.gbxGiaoVienBoMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachGiaoVienBoMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbxDanhSachHocSinh;
        private System.Windows.Forms.DataGridView dgvDanhSachHocSinh;
        private System.Windows.Forms.GroupBox gbxGiaoVienBoMon;
        private System.Windows.Forms.DataGridView dgvDanhSachGiaoVienBoMon;
        private System.Windows.Forms.Button btnKetXuat;
        private System.Windows.Forms.ComboBox cmbTimHS;
        private System.Windows.Forms.ComboBox cmbTimBoMon;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtKhoiLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.TextBox txtGVCN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_XoaPhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGiaoVien;
    }
}