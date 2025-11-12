namespace QuanLiThuVien
{
    partial class fmain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmain));
            menuStrip1 = new MenuStrip();
            mnuQuanLiSach = new ToolStripMenuItem();
            mnuQuanLyDocGia = new ToolStripMenuItem();
            mnuMuonTraSach = new ToolStripMenuItem();
            mnuMTS_TaoPhieuMuon = new ToolStripMenuItem();
            mnuMTS_TraSach = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            mnuDuLieu = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Plum;
            menuStrip1.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuQuanLiSach, mnuQuanLyDocGia, mnuMuonTraSach, mnuBaoCao, mnuDuLieu, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(2030, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuQuanLiSach
            // 
            mnuQuanLiSach.BackColor = Color.Plum;
            mnuQuanLiSach.Name = "mnuQuanLiSach";
            mnuQuanLiSach.Size = new Size(169, 36);
            mnuQuanLiSach.Text = "Quản lý sách";
            mnuQuanLiSach.Click += mnuQuanLiSach_Click;
            // 
            // mnuQuanLyDocGia
            // 
            mnuQuanLyDocGia.Name = "mnuQuanLyDocGia";
            mnuQuanLyDocGia.Size = new Size(198, 36);
            mnuQuanLyDocGia.Text = "Quản lý độc giả";
            mnuQuanLyDocGia.Click += mnuQuanLyDocGia_Click;
            // 
            // mnuMuonTraSach
            // 
            mnuMuonTraSach.DropDownItems.AddRange(new ToolStripItem[] { mnuMTS_TaoPhieuMuon, mnuMTS_TraSach });
            mnuMuonTraSach.Name = "mnuMuonTraSach";
            mnuMuonTraSach.Size = new Size(193, 36);
            mnuMuonTraSach.Text = "Mượn/Trả sách";
            mnuMuonTraSach.Click += mnuMuonTraSach_Click;
            // 
            // mnuMTS_TaoPhieuMuon
            // 
            mnuMTS_TaoPhieuMuon.Name = "mnuMTS_TaoPhieuMuon";
            mnuMTS_TaoPhieuMuon.Size = new Size(294, 40);
            mnuMTS_TaoPhieuMuon.Text = "Tạo phiếu mượn";
            mnuMTS_TaoPhieuMuon.Click += mnuMTS_TaoPhieuMuon_Click;
            // 
            // mnuMTS_TraSach
            // 
            mnuMTS_TraSach.Name = "mnuMTS_TraSach";
            mnuMTS_TraSach.Size = new Size(294, 40);
            mnuMTS_TraSach.Text = "Trả sách";
            mnuMTS_TraSach.Click += mnuMTS_TraSach_Click;
            // 
            // mnuBaoCao
            // 
            mnuBaoCao.DropDownItems.AddRange(new ToolStripItem[] { báoCáoToolStripMenuItem });
            mnuBaoCao.Name = "mnuBaoCao";
            mnuBaoCao.Size = new Size(115, 36);
            mnuBaoCao.Text = "Báo cáo";
            mnuBaoCao.Click += mnuBaoCao_Click;
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(203, 40);
            báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // mnuDuLieu
            // 
            mnuDuLieu.Checked = true;
            mnuDuLieu.CheckState = CheckState.Checked;
            mnuDuLieu.Name = "mnuDuLieu";
            mnuDuLieu.Size = new Size(133, 36);
            mnuDuLieu.Text = "Thống Kê";
            mnuDuLieu.Click += mnuDuLieu_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(118, 36);
            mnuTroGiup.Text = "Trợ giúp";
            mnuTroGiup.Click += mnuTroGiup_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.download;
            pictureBox1.Location = new Point(0, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2030, 299);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download__1_;
            pictureBox2.Location = new Point(0, 795);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(2030, 295);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Ảnh_bìa_Facebook_Trích_dẫn_Ảnh_Sách_Văn_học_Thư_viện_Nâu_và_Màu_be__1_;
            pictureBox4.Location = new Point(0, 348);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(2030, 441);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // fmain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(2030, 1090);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "fmain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UEH - Phần mềm quản lý mượn trả sách.";
            Load += fmain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuQuanLiSach;
        private ToolStripMenuItem mnuQuanLyDocGia;
        private ToolStripMenuItem mnuMuonTraSach;
        private ToolStripMenuItem mnuMTS_TaoPhieuMuon;
        private ToolStripMenuItem mnuMTS_TraSach;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuDuLieu;
        private ToolStripMenuItem mnuTroGiup;
        private ContextMenuStrip contextMenuStrip1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
    }
}