namespace QuanLyHocSinhTHPT.GUI
{
    partial class frmThemNamHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNamHoc));
            this.gbxNamHoc = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtTenNamHoc = new System.Windows.Forms.TextBox();
            this.txtMaNamHoc = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbxNamHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxNamHoc
            // 
            this.gbxNamHoc.Controls.Add(this.label28);
            this.gbxNamHoc.Controls.Add(this.label29);
            this.gbxNamHoc.Controls.Add(this.txtTenNamHoc);
            this.gbxNamHoc.Controls.Add(this.txtMaNamHoc);
            this.gbxNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxNamHoc.Location = new System.Drawing.Point(26, 30);
            this.gbxNamHoc.Name = "gbxNamHoc";
            this.gbxNamHoc.Size = new System.Drawing.Size(334, 175);
            this.gbxNamHoc.TabIndex = 18;
            this.gbxNamHoc.TabStop = false;
            this.gbxNamHoc.Text = "Năm học";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 102);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 20);
            this.label28.TabIndex = 14;
            this.label28.Text = "Tên năm học";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(27, 35);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 20);
            this.label29.TabIndex = 13;
            this.label29.Text = "Mã năm học";
            // 
            // txtTenNamHoc
            // 
            this.txtTenNamHoc.Location = new System.Drawing.Point(129, 102);
            this.txtTenNamHoc.Name = "txtTenNamHoc";
            this.txtTenNamHoc.Size = new System.Drawing.Size(190, 26);
            this.txtTenNamHoc.TabIndex = 12;
            // 
            // txtMaNamHoc
            // 
            this.txtMaNamHoc.Location = new System.Drawing.Point(129, 35);
            this.txtMaNamHoc.Name = "txtMaNamHoc";
            this.txtMaNamHoc.ReadOnly = true;
            this.txtMaNamHoc.Size = new System.Drawing.Size(190, 26);
            this.txtMaNamHoc.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::QuanLyHocSinhTHPT.Properties.Resources.OK;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(133, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmThemNamHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 291);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxNamHoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThemNamHoc";
            this.Text = "Thêm năm học";
            this.Load += new System.EventHandler(this.frmThemNamHoc_Load);
            this.gbxNamHoc.ResumeLayout(false);
            this.gbxNamHoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbxNamHoc;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtTenNamHoc;
        private System.Windows.Forms.TextBox txtMaNamHoc;
    }
}