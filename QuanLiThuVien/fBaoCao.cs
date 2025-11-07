using QuanLiThuVien.Data;
using QuanLiThuVien.DTO; // Thêm DTO mới
using QuanLiThuVien.Model;
using QuanLiThuVien.Model.Enum;
using QuanLiThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class fBaoCao : Form
    {
        private readonly TicketService _ticketService;

        private List<BaoCaoViewModel> _allTickets = new List<BaoCaoViewModel>();

        private readonly BindingList<BaoCaoViewModel> _bindingBaoCao = new BindingList<BaoCaoViewModel>();

        private readonly Dictionary<int, string> _mucQuaHanLevels = new Dictionary<int, string>
        {
            { 1, "Từ 1-7 ngày" },
            { 2, "Từ 8-14 ngày" },
            { 3, "Trên 15 ngày" }
        };

        public fBaoCao()
        {
            InitializeComponent();
            _ticketService = new TicketService(
                DataManager.Instance.BookRepository,
                DataManager.Instance.ReaderRepository,
                DataManager.Instance.BorrowingTicketRepository
            );
            HookEvents();
            InitializeUi();
        }

        private void InitializeUi()
        {
            SetupDataGridViews();
            BindComboBoxes();
            dgvDanhSachSachDangMuon.DataSource = _bindingBaoCao;
        }

        // === VIẾT LẠI HOOKEVENTS KHÔNG DÙNG LAMBDA ===
        private void HookEvents()
        {
            Load += fBaoCao_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;

            // Nối các sự kiện checkbox với các hàm xử lý bên dưới
            ckbTheoNgay.CheckedChanged += ckbTheoNgay_CheckedChanged;
            ckbTenSach.CheckedChanged += ckbTenSach_CheckedChanged;
            ckbLoaiDG.CheckedChanged += ckbLoaiDG_CheckedChanged;
            ckbLoaiSach.CheckedChanged += ckbLoaiSach_CheckedChanged;
            ckbMucDoQuaHan.CheckedChanged += ckbMucDoQuaHan_CheckedChanged;
        }

        #region Các hàm xử lý sự kiện CheckBox (Thay thế cho Lambda)

        // Đây là hàm (đã bỏ comment) mà các hàm dưới đây sẽ gọi
        private void HandleCheckBoxToggle(CheckBox ckb, GroupBox grp, bool toggleComboBox = true)
        {
            foreach (Control c in grp.Controls)
            {
                if (c is ComboBox && toggleComboBox)
                {
                    c.Enabled = ckb.Checked;
                    if (!ckb.Checked) ((ComboBox)c).SelectedIndex = -1;
                }
                if (c is DateTimePicker)
                {
                    c.Enabled = ckb.Checked;
                }
            }
        }

        private void ckbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxToggle(ckbTheoNgay, grpLocBaoCao, false);
        }

        private void ckbTenSach_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxToggle(ckbTenSach, groupBox1);
        }

        private void ckbLoaiDG_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxToggle(ckbLoaiDG, grbTheoLoaiDocGia);
        }

        private void ckbLoaiSach_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxToggle(ckbLoaiSach, grbTheoLoaiSach);
        }

        private void ckbMucDoQuaHan_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxToggle(ckbMucDoQuaHan, grbTheoMucQuaHan);
        }
        #endregion

        // === CÁC HÀM CÀI ĐẶT GIAO DIỆN (Giữ nguyên) ===

        private void SetupDataGridViews()
        {
            SetupDataGridViewColumns(dgvDanhSachSachDangMuon);
        }

        private void SetupDataGridViewColumns(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPhieuMuon", HeaderText = "Mã phiếu mượn" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDocGia", HeaderText = "Tên độc giả" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSach", HeaderText = "Tên sách" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số lượng" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayMuon", HeaderText = "Ngày mượn" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayTraDuKien", HeaderText = "Ngày trả dự kiến" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiDisplay", HeaderText = "Trạng thái", Name = "TrangThai" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoNgayQuaHan", HeaderText = "Số ngày quá hạn", Name = "SoNgayQuaHan" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TienPhat", HeaderText = "Tiền phạt", Name = "TienPhat" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi chú" });

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        private void BindComboBoxes()
        {
            cmbTenSach.DataSource = DataManager.Instance.BookRepository.GetAll();
            cmbTenSach.DisplayMember = "TenSach";
            cmbTenSach.ValueMember = "Id";

            cmbLoaiDocGia.DataSource = Helper.GetEnumList<TypeOfReader>();
            cmbLoaiDocGia.DisplayMember = "Value";
            cmbLoaiDocGia.ValueMember = "Key";

            cmbLoaiSach.DataSource = Helper.GetEnumList<BookCategory>();
            cmbLoaiSach.DisplayMember = "Value";
            cmbLoaiSach.ValueMember = "Key";

            cmbMucQuaHan.DataSource = new BindingSource(_mucQuaHanLevels, null);
            cmbMucQuaHan.DisplayMember = "Value";
            cmbMucQuaHan.ValueMember = "Key";
        }

        private void ClearFilters()
        {
            ckbTheoNgay.Checked = false;
            ckbTenSach.Checked = false;
            ckbLoaiDG.Checked = false;
            ckbLoaiSach.Checked = false;
            ckbMucDoQuaHan.Checked = false;

            // Đồng thời tắt các ComboBox (vì HandleCheckBoxToggle không được gọi)
            cmbTenSach.Enabled = false;
            cmbLoaiDocGia.Enabled = false;
            cmbLoaiSach.Enabled = false;
            cmbMucQuaHan.Enabled = false;
            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            // Xóa lựa chọn
            cmbTenSach.SelectedIndex = -1;
            cmbLoaiDocGia.SelectedIndex = -1;
            cmbLoaiSach.SelectedIndex = -1;
            cmbMucQuaHan.SelectedIndex = -1;
        }

        // === CÁC HÀM TẢI DỮ LIỆU (Giữ nguyên) ===

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                LoadFullData();
                ClearFilters();
                ApplyFilters();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lại dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFullData()
        {
            try
            {
                _allTickets = _ticketService.GetBaoCaoViewModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === VIẾT LẠI UPDATESTATISTICS KHÔNG DÙNG LINQ/LAMBDA ===
        private void UpdateStatistics()
        {
            try
            {
                // 1. Tính Tổng số sách
                int tongSoSach = 0;
                List<Book> allBooks = DataManager.Instance.BookRepository.GetAll();
                foreach (Book b in allBooks)
                {
                    tongSoSach += b.SoLuongNhap;
                }
                lblThongKe_TongSoSach.Text = tongSoSach.ToString();

                // 2. Lấy Tổng số độc giả (List.Count là thuộc tính, không phải LINQ)
                lblThongKe_SoDocGia.Text = DataManager.Instance.ReaderRepository.GetAll().Count.ToString();

                // 3. Lọc danh sách đang mượn
                List<BaoCaoViewModel> dangMuonTickets = new List<BaoCaoViewModel>();
                foreach (BaoCaoViewModel t in _allTickets)
                {
                    if (t.TrangThai == BorrowingStatus.DangMuon)
                    {
                        dangMuonTickets.Add(t);
                    }
                }
                lblThongKe_SachDangMuon.Text = dangMuonTickets.Count.ToString();

                // 4. Đếm số sách quá hạn từ danh sách vừa lọc
                int soSachQuaHan = 0;
                foreach (BaoCaoViewModel t in dangMuonTickets)
                {
                    if (t.SoNgayQuaHan > 0)
                    {
                        soSachQuaHan++;
                    }
                }
                lblThongKe_SachQuaHan.Text = soSachQuaHan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === CÁC HÀM LỌC (VIẾT LẠI KHÔNG DÙNG LINQ/LAMBDA) ===

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            // Danh sách mới để chứa kết quả lọc
            List<BaoCaoViewModel> filteredList = new List<BaoCaoViewModel>();

            // Lấy các giá trị lọc ra ngoài vòng lặp 1 lần
            bool locTheoNgay = ckbTheoNgay.Checked;
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            bool locTheoTenSach = ckbTenSach.Checked && cmbTenSach.SelectedValue != null;
            string maSach = "";
            if (locTheoTenSach)
            {
                maSach = cmbTenSach.SelectedValue.ToString();
            }

            bool locTheoLoaiDG = ckbLoaiDG.Checked && cmbLoaiDocGia.SelectedValue != null;
            TypeOfReader loaiDG = TypeOfReader.Khac; // Giá trị default
            if (locTheoLoaiDG)
            {
                loaiDG = (TypeOfReader)cmbLoaiDocGia.SelectedValue;
            }

            bool locTheoLoaiSach = ckbLoaiSach.Checked && cmbLoaiSach.SelectedValue != null;
            BookCategory loaiSach = BookCategory.Khac; // Giá trị default
            if (locTheoLoaiSach)
            {
                loaiSach = (BookCategory)cmbLoaiSach.SelectedValue;
            }

            bool locTheoMucQuaHan = ckbMucDoQuaHan.Checked && cmbMucQuaHan.SelectedValue != null;
            int level = 0; // Giá trị default
            if (locTheoMucQuaHan)
            {
                level = (int)cmbMucQuaHan.SelectedValue;
            }

            // Bắt đầu 1 vòng lặp duy nhất
            foreach (BaoCaoViewModel ticket in _allTickets)
            {
                // 1. Lọc theo ngày
                if (locTheoNgay)
                {
                    if (ticket.NgayMuon.Date < tuNgay || ticket.NgayMuon.Date > denNgay)
                    {
                        continue; // Bỏ qua ticket này, đi đến ticket tiếp theo
                    }
                }

                // 2. Lọc theo tên sách
                if (locTheoTenSach)
                {
                    if (ticket.MaSach != maSach)
                    {
                        continue; // Bỏ qua
                    }
                }

                // 3. Lọc theo loại độc giả
                if (locTheoLoaiDG)
                {
                    if (ticket.LoaiDocGia != loaiDG)
                    {
                        continue; // Bỏ qua
                    }
                }

                // 4. Lọc theo thể loại sách
                if (locTheoLoaiSach)
                {
                    if (ticket.TheLoaiSach != loaiSach)
                    {
                        continue; // Bỏ qua
                    }
                }

                // 5. Lọc theo mức độ quá hạn
                if (locTheoMucQuaHan)
                {
                    if (!FilterByOverdueLevel(ticket, level)) // Dùng hàm helper
                    {
                        continue; // Bỏ qua
                    }
                }

                // Nếu ticket "sống sót" qua tất cả các bộ lọc, thêm nó vào kết quả
                filteredList.Add(ticket);
            }

            // Cập nhật BindingList
            _bindingBaoCao.Clear();
            foreach (var ticket in filteredList)
            {
                _bindingBaoCao.Add(ticket);
            }
        }

        // Hàm này không dùng LINQ/Lambda nên giữ nguyên
        private bool FilterByOverdueLevel(BaoCaoViewModel ticket, int level)
        {
            int daysOverdue = ticket.SoNgayQuaHan;
            switch (level)
            {
                case 1: // 1-7 ngày
                    return daysOverdue >= 1 && daysOverdue <= 7;
                case 2: // 8-14 ngày
                    return daysOverdue >= 8 && daysOverdue <= 14;
                case 3: // 15+ ngày
                    return daysOverdue >= 15;
                default:
                    return false;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void dgvDanhSachSachDangMuon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabSachDangMuon_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSachDangMuon.CurrentRow == null || dgvDanhSachSachDangMuon.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BaoCaoViewModel selectedTicket = dgvDanhSachSachDangMuon.CurrentRow.DataBoundItem as BaoCaoViewModel;
            if (selectedTicket == null) return;
            fChiTietBaoCao fChiTiet = new fChiTietBaoCao(selectedTicket);
            fChiTiet.ShowDialog();
        }
    }
}