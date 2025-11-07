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

        private void HookEvents()
        {
            Load += fBaoCao_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

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
            // Tab 1
            ckbTheoNgay.Checked = false;
            ckbTenSach.Checked = false;
            ckbLoaiDG.Checked = false;
            ckbLoaiSach.Checked = false;
            ckbMucDoQuaHan.Checked = false;
        }

        //private void HandleCheckBoxToggle(CheckBox ckb, GroupBox grp, bool toggleComboBox = true)
        //{
        //    foreach (Control c in grp.Controls)
        //    {
        //        if (c is ComboBox && toggleComboBox)
        //        {
        //            c.Enabled = ckb.Checked;
        //            if (!ckb.Checked) ((ComboBox)c).SelectedIndex = -1;
        //        }
        //        if (c is DateTimePicker)
        //        {
        //            c.Enabled = ckb.Checked;
        //        }
        //    }
        //}

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

        private void UpdateStatistics()
        {
            try
            {
                lblThongKe_TongSoSach.Text = DataManager.Instance.BookRepository.GetAll().Sum(b => b.SoLuongNhap).ToString();
                lblThongKe_SoDocGia.Text = DataManager.Instance.ReaderRepository.GetAll().Count.ToString();

                var dangMuonTickets = _allTickets.Where(t => t.TrangThai == BorrowingStatus.DangMuon).ToList();
                lblThongKe_SachDangMuon.Text = dangMuonTickets.Count.ToString();
                lblThongKe_SachQuaHan.Text = dangMuonTickets.Count(t => t.SoNgayQuaHan > 0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<BaoCaoViewModel> filteredList = _allTickets;

            if (ckbTheoNgay.Checked)
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                filteredList = filteredList.Where(t => t.NgayMuon.Date >= tuNgay && t.NgayMuon.Date <= denNgay);
            }

            if (ckbTenSach.Checked && cmbTenSach.SelectedValue != null)
            {
                string maSach = cmbTenSach.SelectedValue.ToString();
                filteredList = filteredList.Where(t => t.MaSach == maSach);
            }

            if (ckbLoaiDG.Checked && cmbLoaiDocGia.SelectedValue != null)
            {
                TypeOfReader loaiDG = (TypeOfReader)cmbLoaiDocGia.SelectedValue;
                filteredList = filteredList.Where(t => t.LoaiDocGia == loaiDG);
            }

            if (ckbLoaiSach.Checked && cmbLoaiSach.SelectedValue != null)
            {
                BookCategory loaiSach = (BookCategory)cmbLoaiSach.SelectedValue;
                filteredList = filteredList.Where(t => t.TheLoaiSach == loaiSach);
            }

            if (ckbMucDoQuaHan.Checked && cmbMucQuaHan.SelectedValue != null)
            {
                int level = (int)cmbMucQuaHan.SelectedValue;
                filteredList = filteredList.Where(t => FilterByOverdueLevel(t, level));
            }

            _bindingBaoCao.Clear();
            foreach (var ticket in filteredList)
            {
                _bindingBaoCao.Add(ticket);
            }
        }

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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachSachDangMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabSachDangMuon_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            
        }

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