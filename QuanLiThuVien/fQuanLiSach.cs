using QuanLiThuVien.Data;
using QuanLiThuVien.Model;
using QuanLiThuVien.Model.Enum;
using QuanLiThuVien.Repositories;
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
    public partial class fQuanLiSach : Form
    {
        private enum FormMode
        {
            Viewing,
            Adding,
            Editing
        }

        private FormMode _mode = FormMode.Viewing;

        private readonly IRepository<Book> bookRepository;
        private readonly BindingList<Book> _bindingBooks = new BindingList<Book>();

        private readonly IRepository<TacGia> tacGiaRepository;

        private List<TacGia> _allAuthors = new List<TacGia>();
        private Book _currentBook = null;

        public fQuanLiSach()
        {
            InitializeComponent();
            tacGiaRepository = DataManager.Instance.TacGiaRepository;
            bookRepository = DataManager.Instance.BookRepository;
            HookEvents();
            InitializeUi();
        }
        private void HookEvents()
        {
            Load += fQuanLiSach_Load;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            btnLoad.Click += btnLoad_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnXoa.Click += btnXoa_Click;
            txtSearchKeyword.TextChanged += txtSearchKeyword_TextChanged;
            rdoMaSach.CheckedChanged += SearchOptionChanged;
            rdoTenSach.CheckedChanged += SearchOptionChanged;
            rdoChuDe.CheckedChanged += SearchOptionChanged;
        }

        private void InitializeUi()
        {
            // read-only ban đầu
            SetMode(FormMode.Viewing);
            SetupDataGridView();
        }

        private void fQuanLiSach_Load(object sender, EventArgs e)
        {
            BindEnums();
            BindAuthors();
            LoadBooks();
            SetMode(FormMode.Viewing);
            if (dgvBooks.Rows.Count > 0)
            {
                dgvBooks.Rows[0].Selected = true;
            }
        }

        private void BindAuthors()
        {
            try
            {
                cbbTacGia.DropDownStyle = ComboBoxStyle.DropDown;

                // Bật gợi ý tự động khi gõ
                cbbTacGia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbTacGia.AutoCompleteSource = AutoCompleteSource.ListItems;
                _allAuthors = tacGiaRepository.GetAll();
                cbbTacGia.DataSource = _allAuthors;
                cbbTacGia.DisplayMember = "Name";
                cbbTacGia.ValueMember = "Id";
                cbbTacGia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tác giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupDataGridView()
        {
            // Cài đặt cấu trúc cột
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã sách" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSach", HeaderText = "Tên sách" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TacGiaDisplay", HeaderText = "Tác giả" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TheLoaiDisplay", HeaderText = "Thể loại" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NhaXuatBan", HeaderText = "Nhà XB" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NamXuatBan", HeaderText = "Năm XB" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongNhap", HeaderText = "SL Nhập" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi chú" });

            // Cài đặt các thuộc tính chung
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.ReadOnly = true;
            dgvBooks.AllowUserToAddRows = false;

            // Liên kết DataSource MỘT LẦN DUY NHẤT
            dgvBooks.DataSource = _bindingBooks;
        }

        private void BindEnums()
        {
            cbbTheLoai.DataSource = Helper.GetEnumList<BookCategory>();
            cbbTheLoai.DisplayMember = "Value";
            cbbTheLoai.ValueMember = "Key";
        }

        private void LoadBooks()
        {
            try
            {
                bookRepository.LoadFromFile();
                _bindingBooks.Clear();
                List<Book> list = bookRepository.GetAll();
                foreach (Book b in list)
                {
                    _bindingBooks.Add(b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMode(FormMode mode)
        {
            _mode = mode;
            bool readOnly = mode == FormMode.Viewing;
            txtMaSach.ReadOnly = mode != FormMode.Adding; // chỉ cho sửa mã khi thêm
            txtTenSach.ReadOnly = readOnly;
            cbbTacGia.Enabled = !readOnly;
            txtNXB.ReadOnly = readOnly;
            txtNamXB.ReadOnly = readOnly;
            txtSLNhap.ReadOnly = readOnly;
            txtGhiChu.ReadOnly = readOnly;
            cbbTheLoai.Enabled = !readOnly;

            btnThem.Enabled = mode == FormMode.Viewing;
            btnSua.Enabled = mode == FormMode.Viewing && _currentBook != null;
            btnXoa.Enabled = mode == FormMode.Viewing && _currentBook != null;
            btnLuu.Enabled = mode != FormMode.Viewing;
            btnHuy.Enabled = mode != FormMode.Viewing;
        }

        private void ClearInputs()
        {
            txtMaSach.Text = string.Empty;
            txtTenSach.Text = string.Empty;

            if (cbbTacGia != null)
                cbbTacGia.SelectedIndex = -1;

            txtNXB.Text = string.Empty;
            txtNamXB.Text = string.Empty;
            txtSLNhap.Text = string.Empty;
            txtGhiChu.Text = string.Empty;

            if (cbbTheLoai != null)
                cbbTheLoai.SelectedIndex = -1;
        }

        private void FillInputs(Book book)
        {
            if (book == null) return;
            txtMaSach.Text = book.Id;
            txtTenSach.Text = book.TenSach;

            if (!string.IsNullOrEmpty(book.TacGiaId))
                cbbTacGia.SelectedValue = book.TacGiaId;
            else if (cbbTacGia.Items.Count > 0)
                cbbTacGia.SelectedIndex = 0;

            txtNXB.Text = book.NhaXuatBan;
            txtNamXB.Text = book.NamXuatBan.ToString();
            txtSLNhap.Text = book.SoLuongNhap.ToString();
            txtGhiChu.Text = book.GhiChu;

            bool previousState = cbbTheLoai.Enabled;
            // Tạm thời bật nó lên để đảm bảo giá trị được cập nhật và hiển thị
            cbbTheLoai.Enabled = true;
            // Gán giá trị mới
            cbbTheLoai.SelectedValue = book.TheLoai;
            // Trả nó về trạng thái ban đầu (thường là false khi ở chế độ Viewing)
            cbbTheLoai.Enabled = previousState;
        }

        private bool TryBuildBookFromInputs(out Book book, out string error)
        {
            book = null;
            error = string.Empty;

            string id = txtMaSach.Text.Trim();
            string ten = txtTenSach.Text.Trim();
            string tacGiaId = cbbTacGia.SelectedValue?.ToString() ?? string.Empty;
            string nxb = txtNXB.Text.Trim();
            string namStr = txtNamXB.Text.Trim();
            string slStr = txtSLNhap.Text.Trim();

            if (string.IsNullOrWhiteSpace(id)) { error = "Mã sách không được rỗng."; return false; }
            if (string.IsNullOrWhiteSpace(ten)) { error = "Tên sách không được rỗng."; return false; }
            if (string.IsNullOrWhiteSpace(tacGiaId)) { error = "Tác giả không được rỗng."; return false; }
            if (!int.TryParse(namStr, out int nam) || nam <= 0) { error = "Năm xuất bản không hợp lệ."; return false; }
            if (!int.TryParse(slStr, out int sl) || sl < 0) { error = "Số lượng nhập không hợp lệ."; return false; }

            BookCategory theLoai = (BookCategory)cbbTheLoai.SelectedValue;
            book = new Book(id, ten, tacGiaId, theLoai, nxb, nam, sl, txtGhiChu.Text?.Trim() ?? string.Empty);
            return true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null || dgvBooks.CurrentRow.DataBoundItem == null)
            {
                _currentBook = null;
                ClearInputs();
                SetMode(FormMode.Viewing);
                return;
            }
            _currentBook = (Book)dgvBooks.CurrentRow.DataBoundItem;
            FillInputs(_currentBook);
            if (_mode == FormMode.Viewing)
            {
                SetMode(FormMode.Viewing);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBooks();
            SetMode(FormMode.Viewing);
            if (dgvBooks.Rows.Count > 0)
            {
                dgvBooks.Rows[0].Selected = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _currentBook = null;
            SetMode(FormMode.Adding);
            txtMaSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_currentBook == null) return;
            SetMode(FormMode.Editing);
            txtTenSach.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_currentBook != null)
            {
                FillInputs(_currentBook);
            }
            else
            {
                ClearInputs();
            }
            SetMode(FormMode.Viewing);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!TryBuildBookFromInputs(out Book book, out string error))
            {
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == FormMode.Adding)
            {
                if (bookRepository.GetById(book.Id) != null)
                {
                    MessageBox.Show("Mã sách đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bookRepository.Add(book);
            }
            else if (_mode == FormMode.Editing)
            {
                if (!string.Equals(book.Id, _currentBook.Id, StringComparison.OrdinalIgnoreCase) && bookRepository.GetById(book.Id) != null)
                {
                    MessageBox.Show("Mã sách đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bookRepository.Update(book);
            }
            else
            {
                return;
            }

            DataManager.Instance.SaveAllChanges();
            //LoadBooks();
            //SelectRowById(book.Id);
            ApplySearch(book.Id);
            MessageBox.Show("Đã lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetMode(FormMode.Viewing);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_currentBook == null) return;
                bookRepository.Delete(_currentBook.Id);
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.Instance.SaveAllChanges();
                LoadBooks();
                //ClearInputs();
                _currentBook = null;
                SetMode(FormMode.Viewing);
            }
        }

        private void SelectRowById(string id)
        {
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.DataBoundItem is Book b && string.Equals(b.Id, id, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvBooks.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        // ============ SEARCH ============
        private void txtSearchKeyword_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void SearchOptionChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private string GetSelectedPropertyName()
        {
            if (rdoTenSach.Checked) return nameof(Book.TenSach);
            if (rdoChuDe.Checked) return nameof(Book.TheLoai);
            return nameof(Book.Id); // mặc định Mã sách
        }

        private void ApplySearch(string selectedId = null)
        {
            // BƯỚC 1: "TẮT CÔNG TẮC" - Tạm thời ngắt kết nối sự kiện để tránh "bão sự kiện"
            dgvBooks.SelectionChanged -= dgvBooks_SelectionChanged;

            string keyword = txtSearchKeyword.Text?.Trim() ?? string.Empty;
            var prop = GetSelectedPropertyName();

            List<Book> result;
            if (string.IsNullOrEmpty(keyword))
            {
                result = bookRepository.GetAll();
            }
            else
            {
                result = bookRepository.FindByPropertyContains(prop, keyword);
            }

            _bindingBooks.Clear();
            foreach (var b in result)
            {
                _bindingBooks.Add(b);
            }

            // BƯỚC 2: THỰC HIỆN LOGIC CHỌN DÒNG TRONG "IM LẶNG"
            // Vì sự kiện đã bị tắt, các lệnh .Selected = true sẽ không kích hoạt hàm xử lý của chúng ta.
            if (!string.IsNullOrEmpty(selectedId))
            {
                // Ưu tiên chọn dòng có ID được chỉ định.
                SelectRowById(selectedId);
            }
            else if (_bindingBooks.Count > 0)
            {
                // Nếu không, chọn dòng đầu tiên như mặc định.
                dgvBooks.ClearSelection();
                dgvBooks.Rows[0].Selected = true;
            }

            // BƯỚC 3: "BẬT LẠI CÔNG TẮC" - Kết nối lại sự kiện cho các tương tác sau này của người dùng.
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;

            // BƯỚC 4: KÍCH HOẠT THỦ CÔNG - Bây giờ DataGridView đã ở trạng thái ổn định và chính xác,
            // chúng ta tự gọi hàm xử lý sự kiện MỘT LẦN DUY NHẤT để đồng bộ hóa các TextBox.
            // Điều này đảm bảo các TextBox sẽ hiển thị chính xác thông tin của dòng đang được tô màu xanh.
            dgvBooks_SelectionChanged(this, EventArgs.Empty);

            // Nếu sau khi tìm kiếm không còn dòng nào, đảm bảo các ô nhập liệu được xóa.
            if (dgvBooks.CurrentRow == null)
            {
                ClearInputs();
            }
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fTacGia fTacGia = new fTacGia();
            fTacGia.ShowDialog();
            BindAuthors();
        }

        private void grpSearchBook_Enter(object sender, EventArgs e)
        {

        }
    }
}
