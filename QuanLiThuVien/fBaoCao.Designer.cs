namespace QuanLiThuVien
{
    partial class fBaoCao
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
            tbcBaoCao = new TabControl();
            tabSachDangMuon = new TabPage();
            btnTaiLai = new Button();
            btnChiTiet = new Button();
            btnLoc = new Button();
            grbTheoMucQuaHan = new GroupBox();
            ckbMucDoQuaHan = new CheckBox();
            cmbMucQuaHan = new ComboBox();
            textBox3 = new TextBox();
            grbTheoLoaiSach = new GroupBox();
            ckbLoaiSach = new CheckBox();
            cmbLoaiSach = new ComboBox();
            textBox2 = new TextBox();
            grbTheoLoaiDocGia = new GroupBox();
            ckbLoaiDG = new CheckBox();
            cmbLoaiDocGia = new ComboBox();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            ckbTenSach = new CheckBox();
            cmbTenSach = new ComboBox();
            textBox4 = new TextBox();
            groupBox2 = new GroupBox();
            dgvDanhSachSachDangMuon = new DataGridView();
            grpLocBaoCao = new GroupBox();
            ckbTheoNgay = new CheckBox();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            tabSachQuaHan = new TabPage();
            groupBox4 = new GroupBox();
            dgvDSQuaHan = new DataGridView();
            groupBox3 = new GroupBox();
            btnLocDSQuaHan = new Button();
            cmbMucDoQuaHan = new ComboBox();
            label12 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lblThongKe_TongSoSach = new Label();
            lblThongKe_SoDocGia = new Label();
            lblThongKe_SachDangMuon = new Label();
            lblThongKe_SachQuaHan = new Label();
            tbcBaoCao.SuspendLayout();
            tabSachDangMuon.SuspendLayout();
            grbTheoMucQuaHan.SuspendLayout();
            grbTheoLoaiSach.SuspendLayout();
            grbTheoLoaiDocGia.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSachDangMuon).BeginInit();
            grpLocBaoCao.SuspendLayout();
            tabSachQuaHan.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSQuaHan).BeginInit();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbcBaoCao
            // 
            tbcBaoCao.Controls.Add(tabSachDangMuon);
            tbcBaoCao.Controls.Add(tabSachQuaHan);
            tbcBaoCao.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbcBaoCao.Location = new Point(3, 186);
            tbcBaoCao.Name = "tbcBaoCao";
            tbcBaoCao.SelectedIndex = 0;
            tbcBaoCao.Size = new Size(1717, 832);
            tbcBaoCao.TabIndex = 0;
            // 
            // tabSachDangMuon
            // 
            tabSachDangMuon.Controls.Add(btnTaiLai);
            tabSachDangMuon.Controls.Add(btnChiTiet);
            tabSachDangMuon.Controls.Add(btnLoc);
            tabSachDangMuon.Controls.Add(grbTheoMucQuaHan);
            tabSachDangMuon.Controls.Add(grbTheoLoaiSach);
            tabSachDangMuon.Controls.Add(grbTheoLoaiDocGia);
            tabSachDangMuon.Controls.Add(groupBox1);
            tabSachDangMuon.Controls.Add(groupBox2);
            tabSachDangMuon.Controls.Add(grpLocBaoCao);
            tabSachDangMuon.Location = new Point(4, 36);
            tabSachDangMuon.Name = "tabSachDangMuon";
            tabSachDangMuon.Padding = new Padding(3);
            tabSachDangMuon.Size = new Size(1709, 792);
            tabSachDangMuon.TabIndex = 0;
            tabSachDangMuon.Text = "Sách đang mượn";
            tabSachDangMuon.UseVisualStyleBackColor = true;
            tabSachDangMuon.Click += tabSachDangMuon_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(1550, 163);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(148, 65);
            btnTaiLai.TabIndex = 14;
            btnTaiLai.Text = "Load";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click_1;
            // 
            // btnChiTiet
            // 
            btnChiTiet.Location = new Point(1550, 92);
            btnChiTiet.Name = "btnChiTiet";
            btnChiTiet.Size = new Size(148, 65);
            btnChiTiet.TabIndex = 13;
            btnChiTiet.Text = "Chi tiết";
            btnChiTiet.UseVisualStyleBackColor = true;
            btnChiTiet.Click += btnChiTiet_Click;
            // 
            // btnLoc
            // 
            btnLoc.Location = new Point(1550, 21);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(148, 65);
            btnLoc.TabIndex = 12;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = true;
            // 
            // grbTheoMucQuaHan
            // 
            grbTheoMucQuaHan.BackColor = Color.LightGray;
            grbTheoMucQuaHan.Controls.Add(ckbMucDoQuaHan);
            grbTheoMucQuaHan.Controls.Add(cmbMucQuaHan);
            grbTheoMucQuaHan.Controls.Add(textBox3);
            grbTheoMucQuaHan.Location = new Point(1261, 21);
            grbTheoMucQuaHan.Name = "grbTheoMucQuaHan";
            grbTheoMucQuaHan.Size = new Size(266, 211);
            grbTheoMucQuaHan.TabIndex = 11;
            grbTheoMucQuaHan.TabStop = false;
            grbTheoMucQuaHan.Text = "Theo mức quá hạn";
            // 
            // ckbMucDoQuaHan
            // 
            ckbMucDoQuaHan.AutoSize = true;
            ckbMucDoQuaHan.Location = new Point(170, 174);
            ckbMucDoQuaHan.Name = "ckbMucDoQuaHan";
            ckbMucDoQuaHan.Size = new Size(96, 31);
            ckbMucDoQuaHan.TabIndex = 2;
            ckbMucDoQuaHan.Text = "Chọn";
            ckbMucDoQuaHan.UseVisualStyleBackColor = true;
            // 
            // cmbMucQuaHan
            // 
            cmbMucQuaHan.FormattingEnabled = true;
            cmbMucQuaHan.Location = new Point(22, 123);
            cmbMucQuaHan.Name = "cmbMucQuaHan";
            cmbMucQuaHan.Size = new Size(223, 35);
            cmbMucQuaHan.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(22, 50);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(204, 35);
            textBox3.TabIndex = 0;
            textBox3.Text = "Mức độ quá hạn:";
            // 
            // grbTheoLoaiSach
            // 
            grbTheoLoaiSach.BackColor = Color.LightGray;
            grbTheoLoaiSach.Controls.Add(ckbLoaiSach);
            grbTheoLoaiSach.Controls.Add(cmbLoaiSach);
            grbTheoLoaiSach.Controls.Add(textBox2);
            grbTheoLoaiSach.Location = new Point(934, 21);
            grbTheoLoaiSach.Name = "grbTheoLoaiSach";
            grbTheoLoaiSach.Size = new Size(321, 211);
            grbTheoLoaiSach.TabIndex = 10;
            grbTheoLoaiSach.TabStop = false;
            grbTheoLoaiSach.Text = "Theo loại sách";
            // 
            // ckbLoaiSach
            // 
            ckbLoaiSach.AutoSize = true;
            ckbLoaiSach.Location = new Point(225, 180);
            ckbLoaiSach.Name = "ckbLoaiSach";
            ckbLoaiSach.Size = new Size(96, 31);
            ckbLoaiSach.TabIndex = 2;
            ckbLoaiSach.Text = "Chọn";
            ckbLoaiSach.UseVisualStyleBackColor = true;
            // 
            // cmbLoaiSach
            // 
            cmbLoaiSach.FormattingEnabled = true;
            cmbLoaiSach.Location = new Point(6, 123);
            cmbLoaiSach.Name = "cmbLoaiSach";
            cmbLoaiSach.Size = new Size(296, 35);
            cmbLoaiSach.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(36, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 35);
            textBox2.TabIndex = 0;
            textBox2.Text = "Thể loại sách:";
            // 
            // grbTheoLoaiDocGia
            // 
            grbTheoLoaiDocGia.BackColor = Color.LightGray;
            grbTheoLoaiDocGia.Controls.Add(ckbLoaiDG);
            grbTheoLoaiDocGia.Controls.Add(cmbLoaiDocGia);
            grbTheoLoaiDocGia.Controls.Add(textBox1);
            grbTheoLoaiDocGia.Location = new Point(661, 21);
            grbTheoLoaiDocGia.Name = "grbTheoLoaiDocGia";
            grbTheoLoaiDocGia.Size = new Size(267, 211);
            grbTheoLoaiDocGia.TabIndex = 9;
            grbTheoLoaiDocGia.TabStop = false;
            grbTheoLoaiDocGia.Text = "Theo loại độc giả";
            // 
            // ckbLoaiDG
            // 
            ckbLoaiDG.AutoSize = true;
            ckbLoaiDG.Location = new Point(147, 180);
            ckbLoaiDG.Name = "ckbLoaiDG";
            ckbLoaiDG.Size = new Size(96, 31);
            ckbLoaiDG.TabIndex = 2;
            ckbLoaiDG.Text = "Chọn";
            ckbLoaiDG.UseVisualStyleBackColor = true;
            // 
            // cmbLoaiDocGia
            // 
            cmbLoaiDocGia.FormattingEnabled = true;
            cmbLoaiDocGia.Location = new Point(36, 123);
            cmbLoaiDocGia.Name = "cmbLoaiDocGia";
            cmbLoaiDocGia.Size = new Size(202, 35);
            cmbLoaiDocGia.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 35);
            textBox1.TabIndex = 0;
            textBox1.Text = "Loại độc giả:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(ckbTenSach);
            groupBox1.Controls.Add(cmbTenSach);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Location = new Point(375, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 211);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Theo tên sách";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // ckbTenSach
            // 
            ckbTenSach.AutoSize = true;
            ckbTenSach.Location = new Point(189, 176);
            ckbTenSach.Name = "ckbTenSach";
            ckbTenSach.Size = new Size(91, 31);
            ckbTenSach.TabIndex = 2;
            ckbTenSach.Text = "chọn";
            ckbTenSach.UseVisualStyleBackColor = true;
            // 
            // cmbTenSach
            // 
            cmbTenSach.FormattingEnabled = true;
            cmbTenSach.Location = new Point(6, 123);
            cmbTenSach.Name = "cmbTenSach";
            cmbTenSach.Size = new Size(274, 35);
            cmbTenSach.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(27, 48);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(201, 35);
            textBox4.TabIndex = 0;
            textBox4.Text = "Tên sách";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDanhSachSachDangMuon);
            groupBox2.Location = new Point(13, 286);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1685, 500);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
            // 
            // dgvDanhSachSachDangMuon
            // 
            dgvDanhSachSachDangMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSachDangMuon.Location = new Point(11, 34);
            dgvDanhSachSachDangMuon.Name = "dgvDanhSachSachDangMuon";
            dgvDanhSachSachDangMuon.RowHeadersWidth = 62;
            dgvDanhSachSachDangMuon.Size = new Size(1663, 460);
            dgvDanhSachSachDangMuon.TabIndex = 0;
            dgvDanhSachSachDangMuon.CellContentClick += dgvDanhSachSachDangMuon_CellContentClick;
            // 
            // grpLocBaoCao
            // 
            grpLocBaoCao.BackColor = Color.LightGray;
            grpLocBaoCao.Controls.Add(ckbTheoNgay);
            grpLocBaoCao.Controls.Add(dtpDenNgay);
            grpLocBaoCao.Controls.Add(dtpTuNgay);
            grpLocBaoCao.Controls.Add(label10);
            grpLocBaoCao.Controls.Add(label9);
            grpLocBaoCao.Location = new Point(13, 21);
            grpLocBaoCao.Name = "grpLocBaoCao";
            grpLocBaoCao.Size = new Size(356, 259);
            grpLocBaoCao.TabIndex = 0;
            grpLocBaoCao.TabStop = false;
            grpLocBaoCao.Text = "Lọc báo cáo sách đang mượn";
            // 
            // ckbTheoNgay
            // 
            ckbTheoNgay.AutoSize = true;
            ckbTheoNgay.Location = new Point(260, 228);
            ckbTheoNgay.Name = "ckbTheoNgay";
            ckbTheoNgay.Size = new Size(96, 31);
            ckbTheoNgay.TabIndex = 4;
            ckbTheoNgay.Text = "Chọn";
            ckbTheoNgay.UseVisualStyleBackColor = true;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(11, 176);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(300, 35);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(11, 77);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(300, 35);
            dtpTuNgay.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Location = new Point(186, 129);
            label10.Name = "label10";
            label10.Size = new Size(125, 29);
            label10.TabIndex = 1;
            label10.Text = "Đến ngày:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Location = new Point(11, 31);
            label9.Name = "label9";
            label9.Size = new Size(111, 29);
            label9.TabIndex = 0;
            label9.Text = "Từ ngày:";
            // 
            // tabSachQuaHan
            // 
            tabSachQuaHan.Controls.Add(groupBox4);
            tabSachQuaHan.Controls.Add(groupBox3);
            tabSachQuaHan.Location = new Point(4, 36);
            tabSachQuaHan.Name = "tabSachQuaHan";
            tabSachQuaHan.Padding = new Padding(3);
            tabSachQuaHan.Size = new Size(1709, 792);
            tabSachQuaHan.TabIndex = 1;
            tabSachQuaHan.Text = "Sách quá hạn";
            tabSachQuaHan.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvDSQuaHan);
            groupBox4.Location = new Point(18, 232);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1685, 463);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách";
            // 
            // dgvDSQuaHan
            // 
            dgvDSQuaHan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSQuaHan.Location = new Point(11, 34);
            dgvDSQuaHan.Name = "dgvDSQuaHan";
            dgvDSQuaHan.RowHeadersWidth = 62;
            dgvDSQuaHan.Size = new Size(1663, 423);
            dgvDSQuaHan.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLocDSQuaHan);
            groupBox3.Controls.Add(cmbMucDoQuaHan);
            groupBox3.Controls.Add(label12);
            groupBox3.Location = new Point(25, 46);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1662, 180);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Báo cáo sách quá hạn";
            // 
            // btnLocDSQuaHan
            // 
            btnLocDSQuaHan.Location = new Point(1364, 77);
            btnLocDSQuaHan.Name = "btnLocDSQuaHan";
            btnLocDSQuaHan.Size = new Size(268, 73);
            btnLocDSQuaHan.TabIndex = 2;
            btnLocDSQuaHan.Text = "Lọc danh sách quá hạn";
            btnLocDSQuaHan.UseVisualStyleBackColor = true;
            // 
            // cmbMucDoQuaHan
            // 
            cmbMucDoQuaHan.FormattingEnabled = true;
            cmbMucDoQuaHan.Location = new Point(100, 101);
            cmbMucDoQuaHan.Name = "cmbMucDoQuaHan";
            cmbMucDoQuaHan.Size = new Size(1191, 35);
            cmbMucDoQuaHan.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(100, 58);
            label12.Name = "label12";
            label12.Size = new Size(195, 27);
            label12.TabIndex = 0;
            label12.Text = "Mức độ quá hạn:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label8, 3, 1);
            tableLayoutPanel1.Controls.Add(label7, 2, 1);
            tableLayoutPanel1.Controls.Add(label6, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(lblThongKe_TongSoSach, 0, 0);
            tableLayoutPanel1.Controls.Add(lblThongKe_SoDocGia, 1, 0);
            tableLayoutPanel1.Controls.Add(lblThongKe_SachDangMuon, 2, 0);
            tableLayoutPanel1.Controls.Add(lblThongKe_SachQuaHan, 3, 0);
            tableLayoutPanel1.Location = new Point(97, 26);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(1539, 140);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(1155, 98);
            label8.Name = "label8";
            label8.Size = new Size(381, 38);
            label8.TabIndex = 3;
            label8.Text = "Số sách quá hạn";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(771, 98);
            label7.Name = "label7";
            label7.Size = new Size(378, 38);
            label7.TabIndex = 2;
            label7.Text = "Số sách đang mượn";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(387, 98);
            label6.Name = "label6";
            label6.Size = new Size(378, 38);
            label6.TabIndex = 1;
            label6.Text = "Tống số độc giả";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(3, 98);
            label5.Name = "label5";
            label5.Size = new Size(378, 38);
            label5.TabIndex = 0;
            label5.Text = "Tổng số sách";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongKe_TongSoSach
            // 
            lblThongKe_TongSoSach.BorderStyle = BorderStyle.Fixed3D;
            lblThongKe_TongSoSach.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblThongKe_TongSoSach.ForeColor = Color.MediumOrchid;
            lblThongKe_TongSoSach.Location = new Point(3, 0);
            lblThongKe_TongSoSach.Name = "lblThongKe_TongSoSach";
            lblThongKe_TongSoSach.Size = new Size(378, 98);
            lblThongKe_TongSoSach.TabIndex = 0;
            lblThongKe_TongSoSach.Text = "1233";
            lblThongKe_TongSoSach.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongKe_SoDocGia
            // 
            lblThongKe_SoDocGia.BorderStyle = BorderStyle.Fixed3D;
            lblThongKe_SoDocGia.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblThongKe_SoDocGia.ForeColor = Color.MediumOrchid;
            lblThongKe_SoDocGia.Location = new Point(387, 0);
            lblThongKe_SoDocGia.Name = "lblThongKe_SoDocGia";
            lblThongKe_SoDocGia.Size = new Size(378, 98);
            lblThongKe_SoDocGia.TabIndex = 1;
            lblThongKe_SoDocGia.Text = "3636";
            lblThongKe_SoDocGia.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongKe_SachDangMuon
            // 
            lblThongKe_SachDangMuon.BorderStyle = BorderStyle.Fixed3D;
            lblThongKe_SachDangMuon.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblThongKe_SachDangMuon.ForeColor = Color.MediumOrchid;
            lblThongKe_SachDangMuon.Location = new Point(771, 0);
            lblThongKe_SachDangMuon.Name = "lblThongKe_SachDangMuon";
            lblThongKe_SachDangMuon.Size = new Size(378, 98);
            lblThongKe_SachDangMuon.TabIndex = 2;
            lblThongKe_SachDangMuon.Text = "1155";
            lblThongKe_SachDangMuon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongKe_SachQuaHan
            // 
            lblThongKe_SachQuaHan.BorderStyle = BorderStyle.Fixed3D;
            lblThongKe_SachQuaHan.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblThongKe_SachQuaHan.ForeColor = Color.MediumOrchid;
            lblThongKe_SachQuaHan.Location = new Point(1155, 0);
            lblThongKe_SachQuaHan.Name = "lblThongKe_SachQuaHan";
            lblThongKe_SachQuaHan.Size = new Size(381, 98);
            lblThongKe_SachQuaHan.TabIndex = 3;
            lblThongKe_SachQuaHan.Text = "24";
            lblThongKe_SachQuaHan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fBaoCao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1722, 1030);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tbcBaoCao);
            Name = "fBaoCao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo và thống kê";
            tbcBaoCao.ResumeLayout(false);
            tabSachDangMuon.ResumeLayout(false);
            grbTheoMucQuaHan.ResumeLayout(false);
            grbTheoMucQuaHan.PerformLayout();
            grbTheoLoaiSach.ResumeLayout(false);
            grbTheoLoaiSach.PerformLayout();
            grbTheoLoaiDocGia.ResumeLayout(false);
            grbTheoLoaiDocGia.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSachDangMuon).EndInit();
            grpLocBaoCao.ResumeLayout(false);
            grpLocBaoCao.PerformLayout();
            tabSachQuaHan.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSQuaHan).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcBaoCao;
        private TabPage tabSachDangMuon;
        private TabPage tabSachQuaHan;


        public void ChonTabSachDangMuon()
        {
            tbcBaoCao.SelectedTab = tabSachDangMuon;
        }

        public void ChonTabSachQuaHan()
        {
            tbcBaoCao.SelectedTab = tabSachQuaHan;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblThongKe_TongSoSach;
        private Label lblThongKe_SachQuaHan;
        private Label lblThongKe_SachDangMuon;
        private Label lblThongKe_SoDocGia;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private GroupBox grpLocBaoCao;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label10;
        private Label label9;
        private GroupBox groupBox2;
        private DataGridView dgvDanhSachSachDangMuon;
        private GroupBox groupBox3;
        private Label label12;
        private GroupBox groupBox4;
        private DataGridView dgvDSQuaHan;
        private Button btnLocDSQuaHan;
        private ComboBox cmbMucDoQuaHan;
        private GroupBox groupBox1;
        private CheckBox ckbTenSach;
        private ComboBox cmbTenSach;
        private TextBox textBox4;
        private GroupBox grbTheoLoaiDocGia;
        private CheckBox ckbLoaiDG;
        private ComboBox cmbLoaiDocGia;
        private TextBox textBox1;
        private Button btnChiTiet;
        private Button btnLoc;
        private GroupBox grbTheoMucQuaHan;
        private CheckBox ckbMucDoQuaHan;
        private ComboBox cmbMucQuaHan;
        private TextBox textBox3;
        private GroupBox grbTheoLoaiSach;
        private CheckBox ckbLoaiSach;
        private ComboBox cmbLoaiSach;
        private TextBox textBox2;
        private CheckBox ckbTheoNgay;
        private Button btnTaiLai;
    }
}