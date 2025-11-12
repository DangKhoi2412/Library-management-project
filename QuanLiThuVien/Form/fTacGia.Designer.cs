namespace QuanLiThuVien
{
    partial class fTacGia
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
            grpThongTin = new GroupBox();
            txtTenTacGia = new TextBox();
            txtMaTacGia = new TextBox();
            lblTenTacGia = new Label();
            lblMaTacGia = new Label();
            grpChucNang = new GroupBox();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox3 = new GroupBox();
            dgvDsTacGia = new DataGridView();
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsTacGia).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtTenTacGia);
            grpThongTin.Controls.Add(txtMaTacGia);
            grpThongTin.Controls.Add(lblTenTacGia);
            grpThongTin.Controls.Add(lblMaTacGia);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(626, 182);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin";
            // 
            // txtTenTacGia
            // 
            txtTenTacGia.Location = new Point(256, 107);
            txtTenTacGia.Name = "txtTenTacGia";
            txtTenTacGia.Size = new Size(343, 35);
            txtTenTacGia.TabIndex = 3;
            // 
            // txtMaTacGia
            // 
            txtMaTacGia.Location = new Point(256, 44);
            txtMaTacGia.Name = "txtMaTacGia";
            txtMaTacGia.Size = new Size(343, 35);
            txtMaTacGia.TabIndex = 2;
            // 
            // lblTenTacGia
            // 
            lblTenTacGia.AutoSize = true;
            lblTenTacGia.Location = new Point(51, 115);
            lblTenTacGia.Name = "lblTenTacGia";
            lblTenTacGia.Size = new Size(145, 27);
            lblTenTacGia.TabIndex = 1;
            lblTenTacGia.Text = "Tên tác giả: ";
            // 
            // lblMaTacGia
            // 
            lblMaTacGia.AutoSize = true;
            lblMaTacGia.Location = new Point(51, 47);
            lblMaTacGia.Name = "lblMaTacGia";
            lblMaTacGia.Size = new Size(136, 27);
            lblMaTacGia.TabIndex = 0;
            lblMaTacGia.Text = "Mã tác giả: ";
            // 
            // grpChucNang
            // 
            grpChucNang.Controls.Add(btnLuu);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Location = new Point(12, 216);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(626, 101);
            grpChucNang.TabIndex = 1;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(487, 44);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(339, 44);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(187, 44);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(33, 44);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvDsTacGia);
            groupBox3.Location = new Point(12, 349);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(626, 418);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách tác giả";
            // 
            // dgvDsTacGia
            // 
            dgvDsTacGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDsTacGia.Location = new Point(33, 34);
            dgvDsTacGia.Name = "dgvDsTacGia";
            dgvDsTacGia.RowHeadersWidth = 62;
            dgvDsTacGia.Size = new Size(566, 378);
            dgvDsTacGia.TabIndex = 0;
            // 
            // fTacGia
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 779);
            Controls.Add(groupBox3);
            Controls.Add(grpChucNang);
            Controls.Add(grpThongTin);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fTacGia";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm tác giả";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDsTacGia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private TextBox txtTenTacGia;
        private TextBox txtMaTacGia;
        private Label lblTenTacGia;
        private Label lblMaTacGia;
        private GroupBox grpChucNang;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox groupBox3;
        private DataGridView dgvDsTacGia;
        private Button btnLuu;
    }
}