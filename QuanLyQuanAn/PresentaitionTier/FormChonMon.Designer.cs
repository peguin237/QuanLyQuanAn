namespace QuanLyQuanAn.PresentaitionTier
{
    partial class FormChonMon
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
            this.pnlMonAn = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NupSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbxDanhMuc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NupSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMonAn
            // 
            this.pnlMonAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlMonAn.Location = new System.Drawing.Point(12, 129);
            this.pnlMonAn.Name = "pnlMonAn";
            this.pnlMonAn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlMonAn.Size = new System.Drawing.Size(776, 286);
            this.pnlMonAn.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh Mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số Lượng";
            // 
            // NupSoLuong
            // 
            this.NupSoLuong.Location = new System.Drawing.Point(487, 57);
            this.NupSoLuong.Name = "NupSoLuong";
            this.NupSoLuong.Size = new System.Drawing.Size(120, 22);
            this.NupSoLuong.TabIndex = 5;
            // 
            // cbxDanhMuc
            // 
            this.cbxDanhMuc.FormattingEnabled = true;
            this.cbxDanhMuc.Location = new System.Drawing.Point(111, 44);
            this.cbxDanhMuc.Name = "cbxDanhMuc";
            this.cbxDanhMuc.Size = new System.Drawing.Size(121, 24);
            this.cbxDanhMuc.TabIndex = 7;
            this.cbxDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbxDanhMuc_SelectedIndexChanged);
            // 
            // FormChonMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxDanhMuc);
            this.Controls.Add(this.NupSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMonAn);
            this.Name = "FormChonMon";
            this.Text = "FormChonMon";
            this.Load += new System.EventHandler(this.FormChonMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NupSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMonAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NupSoLuong;
        private System.Windows.Forms.ComboBox cbxDanhMuc;
    }
}