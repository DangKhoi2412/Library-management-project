namespace QuanLiThuVien
{
    partial class fQuanLiSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQuanLiSach));
            grpSearchBook = new GroupBox();
            grpInputSearch = new GroupBox();
            txtSearchKeyword = new TextBox();
            grpSearchBy = new GroupBox();
            rdoChuDe = new RadioButton();
            rdoTenSach = new RadioButton();
            rdoMaSach = new RadioButton();
            grpBookInfo = new GroupBox();
            cbbTacGia = new ComboBox();
            linkThemTacGia = new LinkLabel();
            cbbTheLoai = new ComboBox();
            txtGhiChu = new TextBox();
            txtSLNhap = new TextBox();
            txtNamXB = new TextBox();
            txtNXB = new TextBox();
            txtTenSach = new TextBox();
            txtMaSach = new TextBox();
            lblGhiChu = new Label();
            lblSLNhap = new Label();
            lblNamXB = new Label();
            lblNXB = new Label();
            lblTheLoai = new Label();
            lblTacGia = new Label();
            lblTenSach = new Label();
            lblMaSach = new Label();
            grpChucNang = new GroupBox();
            btnLoad = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            grpDanhSachSach = new GroupBox();
            dgvBooks = new DataGridView();
            grpSearchBook.SuspendLayout();
            grpInputSearch.SuspendLayout();
            grpSearchBy.SuspendLayout();
            grpBookInfo.SuspendLayout();
            grpChucNang.SuspendLayout();
            grpDanhSachSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // grpSearchBook
            // 
            grpSearchBook.BackColor = SystemColors.Control;
            grpSearchBook.Controls.Add(grpInputSearch);
            grpSearchBook.Controls.Add(grpSearchBy);
            grpSearchBook.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpSearchBook.Location = new Point(37, 3);
            grpSearchBook.Name = "grpSearchBook";
            grpSearchBook.Size = new Size(1543, 140);
            grpSearchBook.TabIndex = 0;
            grpSearchBook.TabStop = false;
            grpSearchBook.Text = "Tìm kiếm sách";
            grpSearchBook.Enter += grpSearchBook_Enter;
            // 
            // grpInputSearch
            // 
            grpInputSearch.BackColor = SystemColors.Control;
            grpInputSearch.Controls.Add(txtSearchKeyword);
            grpInputSearch.Location = new Point(834, 26);
            grpInputSearch.Name = "grpInputSearch";
            grpInputSearch.Size = new Size(698, 90);
            grpInputSearch.TabIndex = 1;
            grpInputSearch.TabStop = false;
            grpInputSearch.Text = "Nhập thông tin cần tìm kiếm";
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Location = new Point(94, 34);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(508, 35);
            txtSearchKeyword.TabIndex = 0;
            // 
            // grpSearchBy
            // 
            grpSearchBy.BackColor = SystemColors.Control;
            grpSearchBy.Controls.Add(rdoChuDe);
            grpSearchBy.Controls.Add(rdoTenSach);
            grpSearchBy.Controls.Add(rdoMaSach);
            grpSearchBy.Location = new Point(93, 26);
            grpSearchBy.Name = "grpSearchBy";
            grpSearchBy.Size = new Size(645, 90);
            grpSearchBy.TabIndex = 0;
            grpSearchBy.TabStop = false;
            grpSearchBy.Text = "Tìm theo";
            // 
            // rdoChuDe
            // 
            rdoChuDe.AutoSize = true;
            rdoChuDe.Location = new Point(462, 35);
            rdoChuDe.Name = "rdoChuDe";
            rdoChuDe.Size = new Size(115, 31);
            rdoChuDe.TabIndex = 3;
            rdoChuDe.TabStop = true;
            rdoChuDe.Text = "Chủ đề";
            rdoChuDe.UseVisualStyleBackColor = true;
            // 
            // rdoTenSach
            // 
            rdoTenSach.AutoSize = true;
            rdoTenSach.Location = new Point(258, 34);
            rdoTenSach.Name = "rdoTenSach";
            rdoTenSach.Size = new Size(136, 31);
            rdoTenSach.TabIndex = 1;
            rdoTenSach.TabStop = true;
            rdoTenSach.Text = "Tên sách";
            rdoTenSach.UseVisualStyleBackColor = true;
            // 
            // rdoMaSach
            // 
            rdoMaSach.AutoSize = true;
            rdoMaSach.Location = new Point(66, 34);
            rdoMaSach.Name = "rdoMaSach";
            rdoMaSach.Size = new Size(127, 31);
            rdoMaSach.TabIndex = 0;
            rdoMaSach.TabStop = true;
            rdoMaSach.Text = "Mã sách";
            rdoMaSach.UseVisualStyleBackColor = true;
            rdoMaSach.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // grpBookInfo
            // 
            grpBookInfo.BackColor = SystemColors.Control;
            grpBookInfo.Controls.Add(cbbTacGia);
            grpBookInfo.Controls.Add(linkThemTacGia);
            grpBookInfo.Controls.Add(cbbTheLoai);
            grpBookInfo.Controls.Add(txtGhiChu);
            grpBookInfo.Controls.Add(txtSLNhap);
            grpBookInfo.Controls.Add(txtNamXB);
            grpBookInfo.Controls.Add(txtNXB);
            grpBookInfo.Controls.Add(txtTenSach);
            grpBookInfo.Controls.Add(txtMaSach);
            grpBookInfo.Controls.Add(lblGhiChu);
            grpBookInfo.Controls.Add(lblSLNhap);
            grpBookInfo.Controls.Add(lblNamXB);
            grpBookInfo.Controls.Add(lblNXB);
            grpBookInfo.Controls.Add(lblTheLoai);
            grpBookInfo.Controls.Add(lblTacGia);
            grpBookInfo.Controls.Add(lblTenSach);
            grpBookInfo.Controls.Add(lblMaSach);
            grpBookInfo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpBookInfo.Location = new Point(37, 149);
            grpBookInfo.Name = "grpBookInfo";
            grpBookInfo.Size = new Size(1543, 335);
            grpBookInfo.TabIndex = 1;
            grpBookInfo.TabStop = false;
            grpBookInfo.Text = "Thông tin sách";
            // 
            // cbbTacGia
            // 
            cbbTacGia.FormattingEnabled = true;
            cbbTacGia.Location = new Point(272, 178);
            cbbTacGia.Name = "cbbTacGia";
            cbbTacGia.Size = new Size(384, 35);
            cbbTacGia.TabIndex = 10;
            // 
            // linkThemTacGia
            // 
            linkThemTacGia.ActiveLinkColor = Color.Lime;
            linkThemTacGia.BackColor = SystemColors.ButtonFace;
            linkThemTacGia.BorderStyle = BorderStyle.Fixed3D;
            linkThemTacGia.Font = new Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkThemTacGia.LinkBehavior = LinkBehavior.HoverUnderline;
            linkThemTacGia.LinkColor = SystemColors.ActiveCaptionText;
            linkThemTacGia.Location = new Point(662, 174);
            linkThemTacGia.Name = "linkThemTacGia";
            linkThemTacGia.Size = new Size(47, 40);
            linkThemTacGia.TabIndex = 16;
            linkThemTacGia.TabStop = true;
            linkThemTacGia.Text = "+";
            linkThemTacGia.TextAlign = ContentAlignment.MiddleCenter;
            linkThemTacGia.LinkClicked += linkLabel1_LinkClicked;
            // 
            // cbbTheLoai
            // 
            cbbTheLoai.FormattingEnabled = true;
            cbbTheLoai.Location = new Point(272, 247);
            cbbTheLoai.Name = "cbbTheLoai";
            cbbTheLoai.Size = new Size(384, 35);
            cbbTheLoai.TabIndex = 11;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(1052, 247);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(384, 72);
            txtGhiChu.TabIndex = 15;
            // 
            // txtSLNhap
            // 
            txtSLNhap.Location = new Point(1052, 183);
            txtSLNhap.Name = "txtSLNhap";
            txtSLNhap.Size = new Size(384, 35);
            txtSLNhap.TabIndex = 14;
            // 
            // txtNamXB
            // 
            txtNamXB.Location = new Point(1052, 110);
            txtNamXB.Name = "txtNamXB";
            txtNamXB.Size = new Size(384, 35);
            txtNamXB.TabIndex = 13;
            // 
            // txtNXB
            // 
            txtNXB.Location = new Point(1052, 39);
            txtNXB.Name = "txtNXB";
            txtNXB.Size = new Size(384, 35);
            txtNXB.TabIndex = 12;
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(272, 110);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.Size = new Size(384, 35);
            txtTenSach.TabIndex = 9;
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(272, 39);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.Size = new Size(384, 35);
            txtMaSach.TabIndex = 8;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(839, 255);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(104, 27);
            lblGhiChu.TabIndex = 7;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // lblSLNhap
            // 
            lblSLNhap.AutoSize = true;
            lblSLNhap.Location = new Point(839, 183);
            lblSLNhap.Name = "lblSLNhap";
            lblSLNhap.Size = new Size(183, 27);
            lblSLNhap.TabIndex = 6;
            lblSLNhap.Text = "Số lượng nhập:";
            // 
            // lblNamXB
            // 
            lblNamXB.AutoSize = true;
            lblNamXB.Location = new Point(839, 118);
            lblNamXB.Name = "lblNamXB";
            lblNamXB.Size = new Size(169, 27);
            lblNamXB.TabIndex = 5;
            lblNamXB.Text = "Năm xuất bản:";
            // 
            // lblNXB
            // 
            lblNXB.AutoSize = true;
            lblNXB.Location = new Point(839, 47);
            lblNXB.Name = "lblNXB";
            lblNXB.Size = new Size(163, 27);
            lblNXB.TabIndex = 4;
            lblNXB.Text = "Nhà xuất bản:";
            // 
            // lblTheLoai
            // 
            lblTheLoai.AutoSize = true;
            lblTheLoai.Location = new Point(134, 255);
            lblTheLoai.Name = "lblTheLoai";
            lblTheLoai.Size = new Size(97, 27);
            lblTheLoai.TabIndex = 3;
            lblTheLoai.Text = "Thể loại";
            // 
            // lblTacGia
            // 
            lblTacGia.AutoSize = true;
            lblTacGia.Location = new Point(134, 186);
            lblTacGia.Name = "lblTacGia";
            lblTacGia.Size = new Size(97, 27);
            lblTacGia.TabIndex = 2;
            lblTacGia.Text = "Tác giả:";
            // 
            // lblTenSach
            // 
            lblTenSach.AutoSize = true;
            lblTenSach.Location = new Point(134, 118);
            lblTenSach.Name = "lblTenSach";
            lblTenSach.Size = new Size(118, 27);
            lblTenSach.TabIndex = 1;
            lblTenSach.Text = "Tên sách:";
            // 
            // lblMaSach
            // 
            lblMaSach.AutoSize = true;
            lblMaSach.Location = new Point(134, 47);
            lblMaSach.Name = "lblMaSach";
            lblMaSach.Size = new Size(109, 27);
            lblMaSach.TabIndex = 0;
            lblMaSach.Text = "Mã sách:";
            // 
            // grpChucNang
            // 
            grpChucNang.BackColor = SystemColors.Control;
            grpChucNang.Controls.Add(btnLoad);
            grpChucNang.Controls.Add(btnHuy);
            grpChucNang.Controls.Add(btnLuu);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpChucNang.Location = new Point(254, 490);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(1193, 108);
            grpChucNang.TabIndex = 2;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.LightSkyBlue;
            btnLoad.Location = new Point(835, 27);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(259, 67);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load danh sách";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.LemonChiffon;
            btnHuy.Location = new Point(653, 30);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 64);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.LightSkyBlue;
            btnLuu.Location = new Point(499, 34);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 63);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.LightCoral;
            btnXoa.Location = new Point(352, 34);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 63);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click_1;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LightSalmon;
            btnSua.Location = new Point(206, 34);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 63);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LawnGreen;
            btnThem.Location = new Point(68, 34);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 63);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // grpDanhSachSach
            // 
            grpDanhSachSach.BackColor = SystemColors.Control;
            grpDanhSachSach.Controls.Add(dgvBooks);
            grpDanhSachSach.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDanhSachSach.Location = new Point(37, 606);
            grpDanhSachSach.Name = "grpDanhSachSach";
            grpDanhSachSach.Size = new Size(1543, 474);
            grpDanhSachSach.TabIndex = 3;
            grpDanhSachSach.TabStop = false;
            grpDanhSachSach.Text = "Danh sách sách";
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(6, 29);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.Size = new Size(1526, 449);
            dgvBooks.TabIndex = 0;
            // 
            // fQuanLiSach
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1618, 1096);
            Controls.Add(grpDanhSachSach);
            Controls.Add(grpChucNang);
            Controls.Add(grpBookInfo);
            Controls.Add(grpSearchBook);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "fQuanLiSach";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lí sách";
            grpSearchBook.ResumeLayout(false);
            grpInputSearch.ResumeLayout(false);
            grpInputSearch.PerformLayout();
            grpSearchBy.ResumeLayout(false);
            grpSearchBy.PerformLayout();
            grpBookInfo.ResumeLayout(false);
            grpBookInfo.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpDanhSachSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSearchBook;
        private GroupBox grpSearchBy;
        private RadioButton rdoChuDe;
        private RadioButton rdoTenSach;
        private RadioButton rdoMaSach;
        private GroupBox grpInputSearch;
        private TextBox txtSearchKeyword;
        private GroupBox grpBookInfo;
        private Label lblGhiChu;
        private Label lblSLNhap;
        private Label lblNamXB;
        private Label lblNXB;
        private Label lblTheLoai;
        private Label lblTacGia;
        private Label lblTenSach;
        private Label lblMaSach;
        private ComboBox cbbTheLoai;
        private TextBox txtGhiChu;
        private TextBox txtSLNhap;
        private TextBox txtNamXB;
        private TextBox txtNXB;
        private TextBox txtTenSach;
        private TextBox txtMaSach;
        private GroupBox grpChucNang;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox grpDanhSachSach;
        private Button btnLoad;
        private DataGridView dgvBooks;
        private LinkLabel linkThemTacGia;
        private ComboBox cbbTacGia;
    }
}