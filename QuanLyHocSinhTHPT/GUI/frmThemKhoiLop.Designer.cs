namespace QuanLyHocSinhTHPT.GUI
{
    partial class frmThemKhoiLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemKhoiLop));
            this.gbxKhoiLop = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtTenKhoiLop = new System.Windows.Forms.TextBox();
            this.txtMaKhoiLop = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbxKhoiLop.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxKhoiLop
            // 
            this.gbxKhoiLop.Controls.Add(this.label28);
            this.gbxKhoiLop.Controls.Add(this.label29);
            this.gbxKhoiLop.Controls.Add(this.txtTenKhoiLop);
            this.gbxKhoiLop.Controls.Add(this.txtMaKhoiLop);
            this.gbxKhoiLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxKhoiLop.Location = new System.Drawing.Point(24, 27);
            this.gbxKhoiLop.Name = "gbxKhoiLop";
            this.gbxKhoiLop.Size = new System.Drawing.Size(334, 175);
            this.gbxKhoiLop.TabIndex = 16;
            this.gbxKhoiLop.TabStop = false;
            this.gbxKhoiLop.Text = "Khối lớp";
            this.gbxKhoiLop.Enter += new System.EventHandler(this.gbxKhoiLop_Enter);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 105);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(94, 20);
            this.label28.TabIndex = 14;
            this.label28.Text = "Tên khối lớp";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 38);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 20);
            this.label29.TabIndex = 13;
            this.label29.Text = "Mã khối lớp";
            // 
            // txtTenKhoiLop
            // 
            this.txtTenKhoiLop.Location = new System.Drawing.Point(129, 102);
            this.txtTenKhoiLop.Name = "txtTenKhoiLop";
            this.txtTenKhoiLop.Size = new System.Drawing.Size(190, 26);
            this.txtTenKhoiLop.TabIndex = 0;
            // 
            // txtMaKhoiLop
            // 
            this.txtMaKhoiLop.Location = new System.Drawing.Point(129, 35);
            this.txtMaKhoiLop.Name = "txtMaKhoiLop";
            this.txtMaKhoiLop.ReadOnly = true;
            this.txtMaKhoiLop.Size = new System.Drawing.Size(190, 26);
            this.txtMaKhoiLop.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::QuanLyHocSinhTHPT.Properties.Resources.OK;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(133, 222);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmThemKhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 288);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxKhoiLop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThemKhoiLop";
            this.Text = "Thêm khối lớp";
            this.Load += new System.EventHandler(this.frmThemKhoiLop_Load);
            this.gbxKhoiLop.ResumeLayout(false);
            this.gbxKhoiLop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbxKhoiLop;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtTenKhoiLop;
        private System.Windows.Forms.TextBox txtMaKhoiLop;
    }
}