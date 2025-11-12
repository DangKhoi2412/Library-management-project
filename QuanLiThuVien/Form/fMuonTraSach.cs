using QuanLiThuVien.Data;
using QuanLiThuVien.DTO;
using QuanLiThuVien.Model;
using QuanLiThuVien.Model.Enum;
using QuanLiThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class fMuonTraSach : Form
    {
        private enum FormMode
        {
            Viewing,
            Creating
        }
        private FormMode _mode = FormMode.Viewing;
        private readonly TicketService _ticketService;

        private readonly BindingList<ReturnTicketViewModel> _bindingTickets = new BindingList<ReturnTicketViewModel>();
        private readonly BindingList<ReturnTicketViewModel> _bindingActiveTickets = new BindingList<ReturnTicketViewModel>();
        private ReturnTicketViewModel _currentTicket = null;

        public fMuonTraSach()
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
        private void HookEvents()
        {
            Load += fMuonTraSach_Load;
            dgvBorrowList.SelectionChanged += dgvBorrowList_SelectionChanged;
            cbbMaSach.SelectedIndexChanged += cboMaSach_SelectedIndexChanged;
            btnThemPhieuMuon.Click += btnThemPhieuMuon_Click;
            btnChoMuon.Click += btnChoMuon_Click;
            btnHuy.Click += btnHuy_Click;
            btnLoadDanhSach.Click += btnLoadDanhSach_Click;
            btnGiaHan.Click += btnGiaHan_Click;

            //Tab tra sach
            dgvBorrowList_TraSach.SelectionChanged += dgvBorrowList_TraSach_SelectionChanged;
            btnTraSach.Click += btnTraSach_Click;
            btnLoadDanhSach_TraSach.Click += btnLoadDanhSach_TraSach_Click;

            //Search
            txtSearchKeyword.TextChanged += txtSearchKeyword_TextChanged;
            txtTraSach_Search.TextChanged += txtTraSach_Search_TextChanged;

            rdoMaDG.CheckedChanged += SearchOptionChanged_Brow;
            rdoMaSach.CheckedChanged += SearchOptionChanged_Brow;

            rdoTraSach_MaDocGia.CheckedChanged += SearchOptionChanged_Return;
            rdoTraSach_MaPhieuMuon.CheckedChanged += SearchOptionChanged_Return;
        }
        private void InitializeUi()
        {
            SetMode(FormMode.Viewing);
            SetupDataGridViewColumns(dgvBorrowList);



            dgvBorrowList.DataSource = _bindingTickets;

            SetupDataGridViewColumns(dgvBorrowList_TraSach);
            dgvBorrowList_TraSach.DataSource = _bindingActiveTickets;

            dgvBorrowList.Columns["SoNgayQuaHan"].Visible = false;
            dgvBorrowList.Columns["TienPhat"].Visible = false;
            dgvBorrowList_TraSach.Columns["TrangThai"].Visible = false;
        }

        private void SetupDataGridViewColumns(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPhieuMuon", HeaderText = "Mã phiếu mượn" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDocGia", HeaderText = "Mã độc giả" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSach", HeaderText = "Mã sách" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số lượng" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayMuon", HeaderText = "Ngày mượn" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayTraDuKien", HeaderText = "Ngày trả dự kiến" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "Số điện thoại" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiDisplay", HeaderText = "Trạng thái", Name = "TrangThai" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoNgayQuaHan", HeaderText = "Số ngày quá hạn", Name = "SoNgayQuaHan" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TienPhat", HeaderText = "Tiền phạt", Name = "TienPhat" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi chú" });

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }
        private void fMuonTraSach_Load(object? sender, EventArgs e)
        {
            LoadComboBoxs();
            LoadAllDgv();
            if (dgvBorrowList.Rows.Count > 0)
            {
                dgvBorrowList.Rows[0].Selected = true;
            }
        }
        private void LoadAllDgv()
        {
            LoadBorrowListData();
            LoadReturnListData();
        }

        private void LoadBorrowListData()
        {
            try
            {
                List<ReturnTicketViewModel> allTickets = _ticketService.GetAllBorrowingDetails();
                _bindingTickets.Clear();
                foreach (ReturnTicketViewModel ticket in allTickets)
                {
                    _bindingTickets.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReturnListData()
        {
            try
            {
                List<ReturnTicketViewModel> activeTickets = _ticketService.GetActiveBorrowingDetails();
                _bindingActiveTickets.Clear();
                foreach (ReturnTicketViewModel ticket in activeTickets)
                {
                    _bindingActiveTickets.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu đang mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadComboBoxs()
        {
            List<Reader> allReaders = DataManager.Instance.ReaderRepository.GetAll();
            cbbMaDG.DataSource = allReaders;
            cbbMaDG.DisplayMember = "MaDocGia";
            cbbMaDG.ValueMember = "MaDocGia";

            List<Book> allBooks = DataManager.Instance.BookRepository.GetAll();

            Dictionary<string, string> bookDisplayDict = new Dictionary<string, string>();

            foreach (var b in allBooks)
            {
                string displayText = b.Id + " - " + b.TenSach;
                bookDisplayDict.Add(b.Id, displayText);
            }

            cbbMaSach.DataSource = new BindingSource(bookDisplayDict, null);
            cbbMaSach.DisplayMember = "Value";
            cbbMaSach.ValueMember = "Key";


            cboMaSach_TraSach.DataSource = new BindingSource(bookDisplayDict, null);
            cboMaSach_TraSach.DisplayMember = "Value";
            cboMaSach_TraSach.ValueMember = "Key";

            cboMaDG_TraSach.DataSource = allReaders;
            cboMaDG_TraSach.DisplayMember = "MaDocGia";
            cboMaDG_TraSach.ValueMember = "MaDocGia";

            cbbMaDG.SelectedIndex = -1;
            cbbMaSach.SelectedIndex = -1;
            cboMaDG_TraSach.SelectedIndex = -1;
            cboMaSach_TraSach.SelectedIndex = -1;

            cbbMaSach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbMaSach.AutoCompleteSource = AutoCompleteSource.ListItems;
        }



        private void SetMode(FormMode mode)
        {
            _mode = mode;
            bool isViewing = mode == FormMode.Viewing;

            txtMaPhieu.ReadOnly = isViewing;
            cbbMaDG.Enabled = !isViewing;
            cbbMaSach.Enabled = !isViewing;
            txtSLMuon.ReadOnly = isViewing;
            dtpNgayMuon.Enabled = !isViewing;
            txtSoDienThoai.ReadOnly = isViewing;
            txtGhiChu.ReadOnly = isViewing;

            btnThemPhieuMuon.Enabled = isViewing;
            btnChoMuon.Enabled = !isViewing;
            btnGiaHan.Enabled = isViewing && _currentTicket != null;
            btnHuy.Enabled = !isViewing;

            SetReturnControlsReadOnly(true);
        }

        private void SetReturnControlsReadOnly(bool isReadOnly)
        {
            txtMaPhieu_TraSach.ReadOnly = isReadOnly;
            cboMaDG_TraSach.Enabled = !isReadOnly;
            cboMaSach_TraSach.Enabled = !isReadOnly;
            txtSLMuon_TraSach.ReadOnly = isReadOnly;
            dtpNgayMuon_TraSach.Enabled = !isReadOnly;
            dtpNgayTra_TraSach.Enabled = !isReadOnly;
            txtSDT_TraSach.ReadOnly = isReadOnly;
            txtGhiChu_TraSach.ReadOnly = isReadOnly;
        }
        private void ClearInputs()
        {
            txtMaPhieu.Clear();
            cbbMaDG.SelectedIndex = -1;
            cbbMaSach.SelectedIndex = -1;
            txtSLMuon.Clear();
            dtpNgayMuon.Value = DateTime.Now;
            txtSoDienThoai.Clear();
            txtGhiChu.Clear();
            ClearBookInfo();
        }

        private void ClearBookInfo()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void FillInputs(ReturnTicketViewModel ticket)
        {
            if (ticket == null)
            {
                ClearInputs();
                return;
            }

            txtMaPhieu.Text = ticket.MaPhieuMuon;
            cbbMaDG.SelectedValue = ticket.MaDocGia;
            cbbMaSach.SelectedValue = ticket.MaSach;
            txtSLMuon.Text = ticket.SoLuong.ToString();
            dtpNgayMuon.Value = ticket.NgayMuon;
            txtSoDienThoai.Text = ticket.SoDienThoai;
            txtGhiChu.Text = ticket.GhiChu;

            DisplayBookInfo(ticket.MaSach);
        }

        private void DisplayBookInfo(string maSach)
        {
            if (string.IsNullOrEmpty(maSach))
            {
                ClearBookInfo();
                return;
            }
            var book = DataManager.Instance.BookRepository.GetById(maSach);
            if (book != null)
            {
                textBox1.Text = book.Id;
                textBox2.Text = book.TenSach;
                textBox3.Text = book.TacGiaDisplay;
                textBox4.Text = book.TheLoaiDisplay;
                textBox5.Text = book.SoLuongNhap.ToString();
            }
            else
            {
                ClearBookInfo();
            }
        }
        private void btnChoMuon_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhieu.Text)) throw new Exception("Vui lòng nhập mã phiếu!");
                if (cbbMaDG.SelectedItem == null) throw new Exception("Vui lòng chọn độc giả!");
                if (cbbMaSach.SelectedItem == null) throw new Exception("Vui lòng chọn sách!");
                if (!int.TryParse(txtSLMuon.Text, out int soLuong) || soLuong <= 0) throw new Exception("Số lượng mượn phải là số dương!");

                _ticketService.CreateBorrowingTicket(
                    txtMaPhieu.Text.Trim(),
                    cbbMaDG.SelectedValue.ToString(),
                    cbbMaSach.SelectedValue?.ToString(),
                    soLuong,
                    dtpNgayMuon.Value,
                    txtSoDienThoai.Text.Trim(),
                    txtGhiChu.Text.Trim()
                );

                MessageBox.Show("Tạo phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.Instance.SaveAllChanges();
                LoadAllDgv();
                SetMode(FormMode.Viewing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThemPhieuMuon_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            _currentTicket = null;
            SetMode(FormMode.Creating);
            txtMaPhieu.Focus();
        }
        private void btnLoadDanhSach_Click(object? sender, EventArgs e)
        {
            LoadAllDgv();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            FillInputs(_currentTicket);
            SetMode(FormMode.Viewing);
        }
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBorrowList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn cần gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var selectedRow = dgvBorrowList.SelectedRows[0];
                var ticket = selectedRow.DataBoundItem as ReturnTicketViewModel;
                if (ticket != null)
                {
                    // Gia hạn thêm 7 ngày
                    DateTime newReturnDate = ticket.NgayTraDuKien.AddDays(7);
                    // Cập nhật ngày trả dự kiến
                    var borrowingTicket = DataManager.Instance.BorrowingTicketRepository.GetById(ticket.MaPhieuMuon);
                    if (borrowingTicket != null)
                    {
                        borrowingTicket.NgayTraDuKien = newReturnDate;
                        borrowingTicket.GhiChu += $" | Gia hạn đến {newReturnDate:dd/MM/yyyy}";
                        DataManager.Instance.BorrowingTicketRepository.Update(borrowingTicket);
                        MessageBox.Show($"Gia hạn thành công! Ngày trả mới: {newReturnDate:dd/MM/yyyy}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Reload dữ liệu
                        LoadAllDgv();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cboMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.Creating && cbbMaSach.SelectedItem != null)
            {
                DisplayBookInfo(cbbMaSach.SelectedValue?.ToString());
            }
        }
        private void dgvBorrowList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBorrowList.CurrentRow == null || dgvBorrowList.CurrentRow.DataBoundItem == null)
            {
                _currentTicket = null;
                if (_mode == FormMode.Viewing) ClearInputs();
                SetMode(_mode);
                return;
            }
            _currentTicket = dgvBorrowList.CurrentRow.DataBoundItem as ReturnTicketViewModel;

            if (_mode == FormMode.Viewing)
            {
                FillInputs(_currentTicket);
            }
            SetMode(_mode);
        }

        private void btnTraSach_Click(object? sender, EventArgs e)
        {
            if (dgvBorrowList_TraSach.CurrentRow == null || dgvBorrowList_TraSach.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu để trả sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTicket = dgvBorrowList_TraSach.CurrentRow.DataBoundItem as ReturnTicketViewModel;
            var confirmResult = MessageBox.Show($"Bạn có chắc muốn trả sách cho phiếu '{selectedTicket.MaPhieuMuon}'?", "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    decimal fine = _ticketService.ProcessBookReturn(selectedTicket.MaPhieuMuon);
                    string message = "Trả sách thành công!";
                    if (fine > 0)
                    {
                        message += $"\nTiền phạt quá hạn: {fine:N0} VNĐ";
                    }
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataManager.Instance.SaveAllChanges();
                    LoadAllDgv();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBorrowList_TraSach_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBorrowList_TraSach.CurrentRow == null || dgvBorrowList_TraSach.CurrentRow.DataBoundItem == null)
            {
                ClearReturnTicketControls();
                return;
            }
            var selectedTicket = dgvBorrowList_TraSach.CurrentRow.DataBoundItem as ReturnTicketViewModel;
            DisplayReturnTicketInfo(selectedTicket);
        }

        private void DisplayReturnTicketInfo(ReturnTicketViewModel? ticket)
        {
            if (ticket == null)
            {
                ClearReturnTicketControls();
                return;
            }
            txtMaPhieu_TraSach.Text = ticket.MaPhieuMuon;
            cboMaDG_TraSach.Text = ticket.MaDocGia;
            cboMaSach_TraSach.Text = ticket.MaSach;
            txtSLMuon_TraSach.Text = ticket.SoLuong.ToString();
            dtpNgayMuon_TraSach.Value = ticket.NgayMuon;
            dtpNgayTra_TraSach.Value = ticket.NgayTraDuKien;
            txtSDT_TraSach.Text = ticket.SoDienThoai;
            txtGhiChu_TraSach.Text = ticket.GhiChu;
        }

        private void ClearReturnTicketControls()
        {
            txtMaPhieu_TraSach.Clear();
            cboMaDG_TraSach.SelectedIndex = -1;
            cboMaSach_TraSach.SelectedIndex = -1;
            txtSLMuon_TraSach.Clear();
            dtpNgayMuon_TraSach.Value = DateTime.Now;
            dtpNgayTra_TraSach.Value = DateTime.Now;
            txtSDT_TraSach.Clear();
            txtGhiChu_TraSach.Clear();
        }
        private void btnLoadDanhSach_TraSach_Click(object? sender, EventArgs e)
        {
            LoadReturnListData();
        }

        //-----------------SEARCH----------------------//
        private void txtSearchKeyword_TextChanged(object? sender, EventArgs e)
        {
            ApplySearch_Brow();
        }

        private void txtTraSach_Search_TextChanged(object? sender, EventArgs e)
        {
            ApplySearch_Return();
        }

        private void SearchOptionChanged_Brow(object? sender, EventArgs e)
        {
            ApplySearch_Brow();
        }

        private void SearchOptionChanged_Return(object? sender, EventArgs e)
        {
            ApplySearch_Return();
        }

        private void ApplySearch_Brow(string selectedId = null)
        {
            try
            {
                string keyword = txtSearchKeyword.Text.Trim().ToLower();
                var allTickets = _ticketService.GetAllBorrowingDetails();

                IEnumerable<ReturnTicketViewModel> filteredList;

                if (string.IsNullOrEmpty(keyword))
                {
                    filteredList = allTickets;
                }
                else
                {
                    if (rdoMaDG.Checked)
                    {
                        filteredList = allTickets.Where(t => t.MaDocGia.ToLower().Contains(keyword));
                    }
                    else
                    {
                        filteredList = allTickets.Where(t => t.MaSach.ToLower().Contains(keyword));
                    }
                }

                // Cập nhật BindingList
                _bindingTickets.Clear();
                foreach (var ticket in filteredList)
                {
                    _bindingTickets.Add(ticket);
                }

                dgvBorrowList.Refresh(); // làm mới giao diện
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm (Brow): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplySearch_Return(string selectedId = null)
        {
            try
            {
                string keyword = txtTraSach_Search.Text.Trim().ToLower();
                var activeTickets = _ticketService.GetActiveBorrowingDetails();

                IEnumerable<ReturnTicketViewModel> filteredList;

                if (string.IsNullOrEmpty(keyword))
                {
                    filteredList = activeTickets;
                }
                else
                {
                    if (rdoTraSach_MaDocGia.Checked)
                    {
                        filteredList = activeTickets.Where(t => t.MaDocGia.ToLower().Contains(keyword));
                    }
                    else
                    {
                        filteredList = activeTickets.Where(t => t.MaPhieuMuon.ToLower().Contains(keyword));
                    }
                }

                _bindingActiveTickets.Clear();
                foreach (var ticket in filteredList)
                {
                    _bindingActiveTickets.Add(ticket);
                }

                dgvBorrowList_TraSach.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm (Return): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvBorrowList_TraSach.CurrentRow == null || dgvBorrowList_TraSach.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReturnTicketViewModel selectedTicket = dgvBorrowList_TraSach.CurrentRow.DataBoundItem as ReturnTicketViewModel;
            if (selectedTicket == null) return;
            fChiTietPhieuTra fChiTiet = new fChiTietPhieuTra(selectedTicket);
            fChiTiet.ShowDialog();
        }
    }
}
