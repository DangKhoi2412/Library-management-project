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
    public partial class fQuanLiDocGia : Form
    {
        private enum FormMode
        {
            Viewing,
            Adding,
            Editing
        }

        private FormMode _mode = FormMode.Viewing;
        private readonly IRepository<Reader> _readerRepository;
        private readonly BindingList<Reader> _bindingReaders = new BindingList<Reader>();
        private Reader _currentReader = null;
        public fQuanLiDocGia()
        {
            InitializeComponent();
            _readerRepository = DataManager.Instance.ReaderRepository;
            HookEvents();
            InitializeUi();
        }

        private void InitializeUi()
        {
            SetMode(FormMode.Viewing);
            SetupDataGridView();
        }

        private void HookEvents()
        {
            Load += fQuanLiDocGia_Load;
            dgvReaders.SelectionChanged += dgvReaders_SelectionChanged;
            btnLoad.Click += btnLoad_Click;
            btnHuy.Click += btnHuy_Click;
            btnLuu.Click += btnLuu_Click;
            btnSua.Click += btnSua_Click;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            txtSearchKeywordtxtSearchKeyword.TextChanged += txtSearchKeywordtxtSearchKeyword_TextChanged;
            rdoMaDG.CheckedChanged += SearchOptionChanged;
            rdoTenDG.CheckedChanged += SearchOptionChanged;
        }
        private void fQuanLiDocGia_Load(object? sender, EventArgs e)
        {
            BindEnums();
            LoadReaders();
            SetMode(FormMode.Viewing);

            if (dgvReaders.Rows.Count > 0)
            {
                dgvReaders.Rows[0].Selected = true;
            }
        }
        private void SetupDataGridView()
        {
            dgvReaders.AutoGenerateColumns = false;
            dgvReaders.Columns.Clear();

            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDocGia", HeaderText = "Mã độc giả" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ten", HeaderText = "Tên độc giả" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioiTinhDisplay", HeaderText = "Giới tính" }); // Sửa lại chính tả "Giới tính"
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiDGDisplay", HeaderText = "Loại độc giả" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "Số điện thoại" });
            dgvReaders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiaChi", HeaderText = "Địa chỉ" });

            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReaders.ReadOnly = true;
            dgvReaders.AllowUserToAddRows = false;

            // Liên kết DataSource MỘT LẦN DUY NHẤT
            dgvReaders.DataSource = _bindingReaders;
        }
        private void LoadReaders()
        {
            try
            {
                _bindingReaders.Clear();
                List<Reader> readers = _readerRepository.GetAll();
                foreach (Reader reader in readers)
                {
                    _bindingReaders.Add(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách độc giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMode(FormMode mode)
        {
            _mode = mode;
            bool readOnly = mode == FormMode.Viewing;
            txtMaDG.ReadOnly = mode != FormMode.Adding;
            txtTenDG.ReadOnly = readOnly;
            txtSoDienThoai.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtDiaChi.ReadOnly = readOnly;
            cbbTheLoai.Enabled = !readOnly;
            cbbGioiTinh.Enabled = !readOnly;

            btnThem.Enabled = mode == FormMode.Viewing;
            btnSua.Enabled = mode == FormMode.Viewing && _currentReader != null;
            btnXoa.Enabled = mode == FormMode.Viewing && _currentReader != null;
            btnLuu.Enabled = mode != FormMode.Viewing;
            btnHuy.Enabled = mode != FormMode.Viewing;
        }

        private void BindEnums()
        {
            cbbGioiTinh.DataSource = Helper.GetEnumList<GioiTinh>();
            cbbGioiTinh.DisplayMember = "Value";
            cbbGioiTinh.ValueMember = "Key";

            cbbTheLoai.DataSource = Helper.GetEnumList<TypeOfReader>();
            cbbTheLoai.DisplayMember = "Value";
            cbbTheLoai.ValueMember = "Key";
        }
        private void ClearInputs()
        {
            txtMaDG.Text = string.Empty;
            txtTenDG.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Now;
            txtSoDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            if (cbbTheLoai.Items.Count > 0) cbbTheLoai.SelectedIndex = -1;
            if (cbbGioiTinh.Items.Count > 0) cbbGioiTinh.SelectedIndex = -1;
        }

        private void FillInputs(Reader reader)
        {
            if (reader == null) return;
            txtMaDG.Text = reader.MaDocGia;
            txtTenDG.Text = reader.Ten;
            dtpNgaySinh.Value = reader.NgaySinh;
            txtSoDienThoai.Text = reader.SoDienThoai;
            txtDiaChi.Text = reader.DiaChi;
            txtEmail.Text = reader.Email;

            bool previousState = cbbTheLoai.Enabled;
            cbbTheLoai.Enabled = true;
            cbbTheLoai.SelectedValue = reader.LoaiDocGia;
            cbbTheLoai.Enabled = previousState;
        }
        private bool TryBuildBookFromInputs(out Reader reader, out string error)
        {
            reader = null;
            error = string.Empty;

            string maDocGia = txtMaDG.Text.Trim();
            string ten = txtTenDG.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(maDocGia))
            {
                error = "Mã độc giả không được để trống.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(ten))
            {
                error = "Tên độc giả không được để trống.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                error = "Địa chỉ không được để trống.";
                return false;
            }


            if (cbbTheLoai.SelectedValue == null)
            {
                error = "Vui lòng chọn loại độc giả.";
                return false;
            }

            if (cbbGioiTinh.SelectedValue == null)
            {
                error = "Vui lòng chọn giới tính.";
                return false;
            }

            DateTime ngaySinh = DateTime.MinValue;
            if (dtpNgaySinh.Checked)
            {
                if (dtpNgaySinh.Value.Date > DateTime.Today)
                {
                    error = "Ngày sinh không hợp lệ (không thể là ngày trong tương lai).";
                    return false;
                }
                ngaySinh = dtpNgaySinh.Value;
            }

            if (!string.IsNullOrEmpty(soDienThoai) && !System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9,10}$"))
            {
                error = "Định dạng số điện thoại không hợp lệ.";
                return false;
            }
            if (!string.IsNullOrEmpty(email))
            {
                try { new System.Net.Mail.MailAddress(email); }
                catch { error = "Định dạng email không hợp lệ."; return false; }
            }

            try
            {
                TypeOfReader loaiDocGia = (TypeOfReader)cbbTheLoai.SelectedValue;
                GioiTinh gioiTinh = (GioiTinh)cbbGioiTinh.SelectedValue;

                reader = new Reader
                {
                    MaDocGia = maDocGia,
                    Ten = ten,
                    NgaySinh = ngaySinh,
                    SoDienThoai = soDienThoai,
                    DiaChi = diaChi,
                    Email = email,
                    LoaiDocGia = loaiDocGia,
                    GioiTinh = gioiTinh
                };

                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi khi tạo đối tượng độc giả: " + ex.Message;
                return false;
            }
        }
        private void dgvReaders_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvReaders.CurrentRow == null || dgvReaders.CurrentRow.DataBoundItem == null)
            {
                _currentReader = null;
                ClearInputs();
                SetMode(FormMode.Viewing);
                return;
            }
            _currentReader = (Reader)dgvReaders.CurrentRow.DataBoundItem;
            FillInputs(_currentReader);
            if (_mode == FormMode.Viewing)
            {
                SetMode(FormMode.Viewing);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_currentReader == null) return;
                dgvReaders.Focus();
                _readerRepository.Delete(_currentReader.MaDocGia);
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.Instance.SaveAllChanges();
                LoadReaders();
                _currentReader = null;
                SetMode(FormMode.Viewing);
            }
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            _currentReader = null;
            SetMode(FormMode.Adding);
            txtMaDG.Focus();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (_currentReader == null) return;
            SetMode(FormMode.Editing);
            txtTenDG.Focus();
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!TryBuildBookFromInputs(out Reader reader, out string error))
            {
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == FormMode.Adding)
            {
                if (_readerRepository.GetById(reader.MaDocGia) != null)
                {
                    MessageBox.Show("Mã độc giả đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _readerRepository.Add(reader);
            }
            else if (_mode == FormMode.Editing)
            {
                if (!string.Equals(reader.MaDocGia, _currentReader.MaDocGia, StringComparison.OrdinalIgnoreCase) && _readerRepository.GetById(reader.MaDocGia) != null)
                {
                    MessageBox.Show("Mã độc giả đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _readerRepository.Update(reader);
            }
            else
            {
                return;
            }

            DataManager.Instance.SaveAllChanges();
            ApplySearch(reader.MaDocGia);
            MessageBox.Show("Đã lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetMode(FormMode.Viewing);
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            if (_currentReader != null)
            {
                FillInputs(_currentReader);
            }
            else
            {
                ClearInputs();
            }
            SetMode(FormMode.Viewing);
        }

        private void btnLoad_Click(object? sender, EventArgs e)
        {
            LoadReaders();
            SetMode(FormMode.Viewing);
            if (dgvReaders.Rows.Count > 0)
            {
                dgvReaders.Rows[0].Selected = true;
            }
        }

        private void SelectRowById(string id)
        {
            foreach (DataGridViewRow row in dgvReaders.Rows)
            {
                if (row.DataBoundItem is Reader r && string.Equals(r.MaDocGia, id, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvReaders.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        private void txtSearchKeywordtxtSearchKeyword_TextChanged(object? sender, EventArgs e)
        {
            ApplySearch();
        }
        private void SearchOptionChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private string GetSelectedPropertyName()
        {
            if (rdoMaDG.Checked) return nameof(Reader.MaDocGia);
            if (rdoTenDG.Checked) return nameof(Reader.Ten);
            return nameof(Reader.MaDocGia);
        }


        private void ApplySearch(string selectedId = null)
        {
            dgvReaders.SelectionChanged -= dgvReaders_SelectionChanged;

            string keyword = txtSearchKeywordtxtSearchKeyword.Text?.Trim() ?? string.Empty;
            var prop = GetSelectedPropertyName();

            List<Reader> result;
            if (string.IsNullOrEmpty(keyword))
            {
                result = _readerRepository.GetAll();
            }
            else
            {
                result = _readerRepository.FindByPropertyContains(prop, keyword);
            }

            _bindingReaders.Clear();
            foreach (var b in result)
            {
                _bindingReaders.Add(b);
            }

            // BƯỚC 2: THỰC HIỆN LOGIC CHỌN DÒNG TRONG "IM LẶNG"
            // Vì sự kiện đã bị tắt, các lệnh .Selected = true sẽ không kích hoạt hàm xử lý của chúng ta.
            if (!string.IsNullOrEmpty(selectedId))
            {
                // Ưu tiên chọn dòng có ID được chỉ định.
                SelectRowById(selectedId);
            }
            else if (_bindingReaders.Count > 0)
            {
                // Nếu không, chọn dòng đầu tiên như mặc định.
                dgvReaders.ClearSelection();
                dgvReaders.Rows[0].Selected = true;
            }

            // BƯỚC 3: "BẬT LẠI CÔNG TẮC" - Kết nối lại sự kiện cho các tương tác sau này của người dùng.
            dgvReaders.SelectionChanged += dgvReaders_SelectionChanged;

            // BƯỚC 4: KÍCH HOẠT THỦ CÔNG - Bây giờ DataGridView đã ở trạng thái ổn định và chính xác,
            // chúng ta tự gọi hàm xử lý sự kiện MỘT LẦN DUY NHẤT để đồng bộ hóa các TextBox.
            // Điều này đảm bảo các TextBox sẽ hiển thị chính xác thông tin của dòng đang được tô màu xanh.
            dgvReaders_SelectionChanged(this, EventArgs.Empty);

            // Nếu sau khi tìm kiếm không còn dòng nào, đảm bảo các ô nhập liệu được xóa.
            if (dgvReaders.CurrentRow == null)
            {
                ClearInputs();
            }
        }

        private void grpDanhSachDocGia_Enter(object sender, EventArgs e)
        {

        }

        private void grpReaderInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
