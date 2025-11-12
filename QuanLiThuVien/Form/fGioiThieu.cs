using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class fGioiThieu : Form
    {
        public fGioiThieu()
        {
            InitializeComponent();
            HookEvents();
            LoadInfo();
            CustomizeAppearance();
        }

        private void HookEvents()
        {
            // Nối sự kiện click cho các control
            this.btnOK.Click += btnOK_Click;
            this.lnkEmail.LinkClicked += lnkEmail_LinkClicked;
        }

        private void CustomizeAppearance()
        {
            // Tùy chỉnh giao diện cho đẹp hơn
            this.lblAppName.ForeColor = Color.FromArgb(0, 102, 204); // Màu xanh dương đậm

            // Tùy chỉnh textbox mô tả
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;

            // Tùy chỉnh nút OK
            this.btnOK.BackColor = Color.FromArgb(0, 122, 204);
            this.btnOK.ForeColor = Color.White;
            this.btnOK.FlatStyle = FlatStyle.Flat;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Cursor = Cursors.Hand;

            // Tùy chỉnh link
            this.lnkEmail.LinkColor = Color.FromArgb(0, 102, 204);
            this.lnkEmail.ActiveLinkColor = Color.FromArgb(204, 0, 0);
            this.lnkEmail.VisitedLinkColor = Color.FromArgb(128, 0, 128);
        }

        private void LoadInfo()
        {
            try
            {
                // 1. Tải Logo (nếu có trong Resources)
                this.pictureBoxLogo.Image = Properties.Resources.Logo_phu__bo_nen_trang_;
            }
            catch (Exception)
            {
                // Nếu không tải được logo, hiển thị icon mặc định hoặc ẩn
                this.pictureBoxLogo.Visible = false;
            }

            // 2. Tải thông tin phiên bản (tự động lấy từ Assembly)
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = $"Phiên bản {version.Major}.{version.Minor}.{version.Build}";

            // 3. Thông tin bản quyền
            this.lblCopyright.Text = $"Copyright © {DateTime.Now.Year}. Phát triển bởi Khôi - Tiến - Duy";

            // 4. Thông tin liên hệ hỗ trợ
            this.lnkEmail.Text = "Liên hệ hỗ trợ: phamdangkhoi241206@gmail.com";

            // 5. Mô tả chi tiết về phần mềm
            string moTa = @"PHẦN MỀM QUẢN LÝ THƯ VIỆN

Phần mềm được thiết kế để hỗ trợ quản lý toàn diện các hoạt động của thư viện, từ quản lý sách, độc giả đến theo dõi mượn trả.

═══════════════════════════════════════════

TÍNH NĂNG CHÍNH:

Quản lý Sách và Tài liệu
   • Thêm, sửa, xóa thông tin sách
   • Quản lý thông tin tác giả, nhà xuất bản
   • Phân loại sách theo thể loại, tìm kiếm sách theo nhiều tiêu chí

Quản lý Độc giả
   • Thêm, sửa, xóa thông tin độc giả
   • Cập nhật thông tin độc giả
   • Phân loại, tìm kiếm độc giả

Quản lý Mượn - Trả sách
   • Xử lý phiếu mượn sách
   • Theo dõi hạn trả
   • Tính phí phạt tự động
   • Gia hạn phiếu mượn

Báo cáo và Thống kê
   • Lọc phiếu muợn theo ngày, độc giả, thể loại sách, số ngày quá hạn
   • Thống kê sách được mượn nhiều nhất, lược mượn theo tháng, tỷ lệ mượn theo thể loại
   • Thống kê có biểu đồ trực quan

═══════════════════════════════════════════

CÔNG NGHỆ:
• Nền tảng: .NET Framework / .NET 9
• Ngôn ngữ: C# (WinForms)
• Dữ liệu lưu trữ ra file (sử dụng kĩ thuật serialization và deserialization)
• Giao diện: Windows Forms Application

═══════════════════════════════════════════

Phần mềm được phát triển nhằm mục đích học tập và ứng dụng thực tế trong việc quản lý thư viện một cách hiện đại, hiệu quả.";

            this.txtDescription.Text = moTa;
        }

        // Đóng form khi nhấn nút OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Mở email client khi click vào link
        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Đánh dấu link đã được click
                lnkEmail.LinkVisited = true;

                // Mở trình email mặc định
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "mailto:support@thuvien.com?subject=Hỗ trợ phần mềm Quản lý Thư viện",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở trình gửi email.\n\n" +
                    "Vui lòng sao chép địa chỉ email: support@thuvien.com\n\n" +
                    $"Chi tiết lỗi: {ex.Message}",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Override ProcessCmdKey để đóng form khi nhấn ESC
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}