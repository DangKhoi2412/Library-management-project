namespace QuanLiThuVien
{
    partial class fQuanLiDocGia
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
            dgvReaders = new DataGridView();
            btnLoad = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            grpDanhSachDocGia = new GroupBox();
            grpChucNang = new GroupBox();
            cbbTheLoai = new ComboBox();
            txtDiaChi = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtTenDG = new TextBox();
            txtMaDG = new TextBox();
            grpSearchReader = new GroupBox();
            grpInputSearch = new GroupBox();
            txtSearchKeywordtxtSearchKeyword = new TextBox();
            grpSearchBy = new GroupBox();
            rdoTenDG = new RadioButton();
            rdoMaDG = new RadioButton();
            grpReaderInfo = new GroupBox();
            cbbGioiTinh = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            lblGhiChu = new Label();
            lblSLNhap = new Label();
            lblNamXB = new Label();
            lblGioiTinh = new Label();
            lblLoaiDocGia = new Label();
            lblTacGia = new Label();
            lblTenSach = new Label();
            lblMaSach = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).BeginInit();
            grpDanhSachDocGia.SuspendLayout();
            grpChucNang.SuspendLayout();
            grpSearchReader.SuspendLayout();
            grpInputSearch.SuspendLayout();
            grpSearchBy.SuspendLayout();
            grpReaderInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReaders
            // 
            dgvReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReaders.Location = new Point(6, 29);
            dgvReaders.Name = "dgvReaders";
            dgvReaders.RowHeadersWidth = 62;
            dgvReaders.Size = new Size(1526, 449);
            dgvReaders.TabIndex = 0;
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
            // grpDanhSachDocGia
            // 
            grpDanhSachDocGia.BackColor = SystemColors.Control;
            grpDanhSachDocGia.Controls.Add(dgvReaders);
            grpDanhSachDocGia.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDanhSachDocGia.Location = new Point(38, 608);
            grpDanhSachDocGia.Name = "grpDanhSachDocGia";
            grpDanhSachDocGia.Size = new Size(1543, 474);
            grpDanhSachDocGia.TabIndex = 7;
            grpDanhSachDocGia.TabStop = false;
            grpDanhSachDocGia.Text = "Danh sách độc giả";
            grpDanhSachDocGia.Enter += grpDanhSachDocGia_Enter;
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
            grpChucNang.Location = new Point(255, 494);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(1193, 108);
            grpChucNang.TabIndex = 6;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            // 
            // cbbTheLoai
            // 
            cbbTheLoai.FormattingEnabled = true;
            cbbTheLoai.Location = new Point(272, 247);
            cbbTheLoai.Name = "cbbTheLoai";
            cbbTheLoai.Size = new Size(384, 35);
            cbbTheLoai.TabIndex = 11;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(1052, 247);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(384, 72);
            txtDiaChi.TabIndex = 15;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(1052, 183);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(384, 35);
            txtSoDienThoai.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(1052, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(384, 35);
            txtEmail.TabIndex = 13;
            // 
            // txtTenDG
            // 
            txtTenDG.Location = new Point(272, 110);
            txtTenDG.Name = "txtTenDG";
            txtTenDG.Size = new Size(384, 35);
            txtTenDG.TabIndex = 9;
            // 
            // txtMaDG
            // 
            txtMaDG.Location = new Point(272, 39);
            txtMaDG.Name = "txtMaDG";
            txtMaDG.Size = new Size(384, 35);
            txtMaDG.TabIndex = 8;
            // 
            // grpSearchReader
            // 
            grpSearchReader.BackColor = SystemColors.Control;
            grpSearchReader.Controls.Add(grpInputSearch);
            grpSearchReader.Controls.Add(grpSearchBy);
            grpSearchReader.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpSearchReader.Location = new Point(38, 7);
            grpSearchReader.Name = "grpSearchReader";
            grpSearchReader.Size = new Size(1543, 140);
            grpSearchReader.TabIndex = 4;
            grpSearchReader.TabStop = false;
            grpSearchReader.Text = "Tìm kiếm độc giả";
            // 
            // grpInputSearch
            // 
            grpInputSearch.BackColor = SystemColors.Control;
            grpInputSearch.Controls.Add(txtSearchKeywordtxtSearchKeyword);
            grpInputSearch.Location = new Point(834, 26);
            grpInputSearch.Name = "grpInputSearch";
            grpInputSearch.Size = new Size(698, 90);
            grpInputSearch.TabIndex = 1;
            grpInputSearch.TabStop = false;
            grpInputSearch.Text = "Nhập thông tin cần tìm kiếm";
            // 
            // txtSearchKeywordtxtSearchKeyword
            // 
            txtSearchKeywordtxtSearchKeyword.Location = new Point(157, 34);
            txtSearchKeywordtxtSearchKeyword.Name = "txtSearchKeywordtxtSearchKeyword";
            txtSearchKeywordtxtSearchKeyword.Size = new Size(445, 35);
            txtSearchKeywordtxtSearchKeyword.TabIndex = 0;
            txtSearchKeywordtxtSearchKeyword.TextChanged += txtSearchKeywordtxtSearchKeyword_TextChanged;
            // 
            // grpSearchBy
            // 
            grpSearchBy.BackColor = SystemColors.Control;
            grpSearchBy.Controls.Add(rdoTenDG);
            grpSearchBy.Controls.Add(rdoMaDG);
            grpSearchBy.Location = new Point(93, 26);
            grpSearchBy.Name = "grpSearchBy";
            grpSearchBy.Size = new Size(645, 90);
            grpSearchBy.TabIndex = 0;
            grpSearchBy.TabStop = false;
            grpSearchBy.Text = "Tìm theo";
            // 
            // rdoTenDG
            // 
            rdoTenDG.AutoSize = true;
            rdoTenDG.Location = new Point(366, 34);
            rdoTenDG.Name = "rdoTenDG";
            rdoTenDG.Size = new Size(162, 31);
            rdoTenDG.TabIndex = 1;
            rdoTenDG.TabStop = true;
            rdoTenDG.Text = "Tên độc giả";
            rdoTenDG.UseVisualStyleBackColor = true;
            // 
            // rdoMaDG
            // 
            rdoMaDG.AutoSize = true;
            rdoMaDG.Location = new Point(124, 34);
            rdoMaDG.Name = "rdoMaDG";
            rdoMaDG.Size = new Size(153, 31);
            rdoMaDG.TabIndex = 0;
            rdoMaDG.TabStop = true;
            rdoMaDG.Text = "Mã độc giả";
            rdoMaDG.UseVisualStyleBackColor = true;
            // 
            // grpReaderInfo
            // 
            grpReaderInfo.BackColor = SystemColors.Control;
            grpReaderInfo.Controls.Add(cbbGioiTinh);
            grpReaderInfo.Controls.Add(dtpNgaySinh);
            grpReaderInfo.Controls.Add(cbbTheLoai);
            grpReaderInfo.Controls.Add(txtDiaChi);
            grpReaderInfo.Controls.Add(txtSoDienThoai);
            grpReaderInfo.Controls.Add(txtEmail);
            grpReaderInfo.Controls.Add(txtTenDG);
            grpReaderInfo.Controls.Add(txtMaDG);
            grpReaderInfo.Controls.Add(lblGhiChu);
            grpReaderInfo.Controls.Add(lblSLNhap);
            grpReaderInfo.Controls.Add(lblNamXB);
            grpReaderInfo.Controls.Add(lblGioiTinh);
            grpReaderInfo.Controls.Add(lblLoaiDocGia);
            grpReaderInfo.Controls.Add(lblTacGia);
            grpReaderInfo.Controls.Add(lblTenSach);
            grpReaderInfo.Controls.Add(lblMaSach);
            grpReaderInfo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpReaderInfo.Location = new Point(38, 153);
            grpReaderInfo.Name = "grpReaderInfo";
            grpReaderInfo.Size = new Size(1543, 335);
            grpReaderInfo.TabIndex = 5;
            grpReaderInfo.TabStop = false;
            grpReaderInfo.Text = "Thông tin độc giả";
            // 
            // cbbGioiTinh
            // 
            cbbGioiTinh.FormattingEnabled = true;
            cbbGioiTinh.Location = new Point(1052, 39);
            cbbGioiTinh.Name = "cbbGioiTinh";
            cbbGioiTinh.Size = new Size(384, 35);
            cbbGioiTinh.TabIndex = 12;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(272, 186);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(384, 35);
            dtpNgaySinh.TabIndex = 10;
            dtpNgaySinh.Value = new DateTime(2025, 8, 21, 20, 24, 33, 0);
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(839, 255);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(92, 27);
            lblGhiChu.TabIndex = 7;
            lblGhiChu.Text = "Địa chỉ:";
            // 
            // lblSLNhap
            // 
            lblSLNhap.AutoSize = true;
            lblSLNhap.Location = new Point(839, 183);
            lblSLNhap.Name = "lblSLNhap";
            lblSLNhap.Size = new Size(159, 27);
            lblSLNhap.TabIndex = 6;
            lblSLNhap.Text = "Số điện thoại:";
            // 
            // lblNamXB
            // 
            lblNamXB.AutoSize = true;
            lblNamXB.Location = new Point(839, 118);
            lblNamXB.Name = "lblNamXB";
            lblNamXB.Size = new Size(79, 27);
            lblNamXB.TabIndex = 5;
            lblNamXB.Text = "Email:";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(839, 47);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(105, 27);
            lblGioiTinh.TabIndex = 4;
            lblGioiTinh.Text = "Giới tính";
            // 
            // lblLoaiDocGia
            // 
            lblLoaiDocGia.AutoSize = true;
            lblLoaiDocGia.Location = new Point(103, 255);
            lblLoaiDocGia.Name = "lblLoaiDocGia";
            lblLoaiDocGia.Size = new Size(140, 27);
            lblLoaiDocGia.TabIndex = 3;
            lblLoaiDocGia.Text = "Loại độc giả";
            // 
            // lblTacGia
            // 
            lblTacGia.AutoSize = true;
            lblTacGia.Location = new Point(103, 186);
            lblTacGia.Name = "lblTacGia";
            lblTacGia.Size = new Size(127, 27);
            lblTacGia.TabIndex = 2;
            lblTacGia.Text = "Ngày sinh:";
            // 
            // lblTenSach
            // 
            lblTenSach.AutoSize = true;
            lblTenSach.Location = new Point(103, 118);
            lblTenSach.Name = "lblTenSach";
            lblTenSach.Size = new Size(144, 27);
            lblTenSach.TabIndex = 1;
            lblTenSach.Text = "Tên độc giả:";
            // 
            // lblMaSach
            // 
            lblMaSach.AutoSize = true;
            lblMaSach.Location = new Point(103, 47);
            lblMaSach.Name = "lblMaSach";
            lblMaSach.Size = new Size(135, 27);
            lblMaSach.TabIndex = 0;
            lblMaSach.Text = "Mã độc giả:";
            // 
            // fQuanLiDocGia
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1618, 1081);
            Controls.Add(grpDanhSachDocGia);
            Controls.Add(grpChucNang);
            Controls.Add(grpSearchReader);
            Controls.Add(grpReaderInfo);
            Name = "fQuanLiDocGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lí đọc giả";
            ((System.ComponentModel.ISupportInitialize)dgvReaders).EndInit();
            grpDanhSachDocGia.ResumeLayout(false);
            grpChucNang.ResumeLayout(false);
            grpSearchReader.ResumeLayout(false);
            grpInputSearch.ResumeLayout(false);
            grpInputSearch.PerformLayout();
            grpSearchBy.ResumeLayout(false);
            grpSearchBy.PerformLayout();
            grpReaderInfo.ResumeLayout(false);
            grpReaderInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReaders;
        private Button btnLoad;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox grpDanhSachDocGia;
        private GroupBox grpChucNang;
        private ComboBox cbbTheLoai;
        private TextBox txtDiaChi;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtTenDG;
        private TextBox txtMaDG;
        private GroupBox grpSearchReader;
        private GroupBox grpInputSearch;
        private TextBox txtSearchKeywordtxtSearchKeyword;
        private GroupBox grpSearchBy;
        private RadioButton rdoTenDG;
        private RadioButton rdoMaDG;
        private GroupBox grpReaderInfo;
        private Label lblGhiChu;
        private Label lblSLNhap;
        private Label lblNamXB;
        private Label lblGioiTinh;
        private Label lblLoaiDocGia;
        private Label lblTacGia;
        private Label lblTenSach;
        private Label lblMaSach;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cbbGioiTinh;
    }
}