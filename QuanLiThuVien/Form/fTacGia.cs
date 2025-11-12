using QuanLiThuVien.Data;
using QuanLiThuVien.Interface;
using QuanLiThuVien.Model;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLiThuVien
{
    public partial class fTacGia : Form
    {
        private enum FormMode
        {
            Viewing,
            Adding,
            Editing
        }
        private FormMode _mode = FormMode.Viewing;
        private readonly IRepository<TacGia> _tacGiaReponsitory;
        private readonly BindingList<TacGia> _bindingTacGia = new BindingList<TacGia>();
        private TacGia _currentTacGia;
        public fTacGia()
        {
            InitializeComponent();
            _tacGiaReponsitory = DataManager.Instance.TacGiaRepository;
            HookEvent();
            InitializeUi();
        }

        private void InitializeUi()
        {
            SetMode(FormMode.Viewing);
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvDsTacGia.AutoGenerateColumns = false;
            dgvDsTacGia.Columns.Clear();

            dgvDsTacGia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã tác giả" });
            dgvDsTacGia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên tác giả" });
            dgvDsTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsTacGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDsTacGia.ReadOnly = true;
            dgvDsTacGia.AllowUserToAddRows = false;

            // Liên kết DataSource MỘT LẦN DUY NHẤT
            dgvDsTacGia.DataSource = _bindingTacGia;
        }

        private void SetMode(FormMode mode)
        {
            _mode = mode;
            bool readOnly = mode == FormMode.Viewing;
            txtMaTacGia.ReadOnly = readOnly;
            txtTenTacGia.ReadOnly = readOnly;

            btnThem.Enabled = mode == FormMode.Viewing;
            btnSua.Enabled = mode == FormMode.Viewing && _currentTacGia != null;
            btnXoa.Enabled = mode == FormMode.Viewing && _currentTacGia != null;
            btnLuu.Enabled = mode != FormMode.Viewing;
        }

        private void HookEvent()
        {
            Load += fTacGia_Load;
            dgvDsTacGia.SelectionChanged += dgvDsTacGia_SelectionChanged;
            btnSua.Click += btnSua_Click;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
        }
        private void fTacGia_Load(object? sender, EventArgs e)
        {
            LoadTacGia();
        }

        private void LoadTacGia()
        {
            try
            {
                _tacGiaReponsitory.LoadFromFile();
                _bindingTacGia.Clear();
                List<TacGia> list = _tacGiaReponsitory.GetAll();
                foreach (TacGia tg in list)
                {
                    _bindingTacGia.Add(tg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh tác giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            string error = null;
            string id = txtMaTacGia.Text.Trim();
            string ten = txtTenTacGia.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                error = "Mã tác giả không được để trống";
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(ten))
            {
                error = "Tên tác giả không được để trống";
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TacGia tacGia = new TacGia(id, ten);
            if (_mode == FormMode.Adding)
            {
                if (_tacGiaReponsitory.GetById(tacGia.Id) != null)
                {
                    MessageBox.Show("Mã tác giả đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _tacGiaReponsitory.Add(tacGia);
            }
            else if (_mode == FormMode.Editing)
            {
                if (!string.Equals(tacGia.Id, _currentTacGia.Id, StringComparison.OrdinalIgnoreCase) && _tacGiaReponsitory.GetById(tacGia.Id) != null)
                {
                    MessageBox.Show("Mã tác giả đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _tacGiaReponsitory.Update(tacGia);
            }
            else
            {
                return;
            }
            DataManager.Instance.SaveAllChanges();
            MessageBox.Show("Đã lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTacGia();
            SetMode(FormMode.Viewing);
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_currentTacGia == null) return;
                _tacGiaReponsitory.Delete(_currentTacGia.Id);
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.Instance.SaveAllChanges();
                LoadTacGia();
                _currentTacGia = null;
                SetMode(FormMode.Viewing);
            }
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            _currentTacGia = null;
            SetMode(FormMode.Adding);
            txtMaTacGia.Focus();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (_currentTacGia == null) return;
            SetMode(FormMode.Editing);
            txtTenTacGia.Focus();
        }

        private void dgvDsTacGia_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDsTacGia.CurrentRow == null || dgvDsTacGia.CurrentRow.DataBoundItem == null)
            {
                _currentTacGia = null;
                ClearInputs();
                SetMode(FormMode.Viewing);
                return;
            }
            _currentTacGia = (TacGia)dgvDsTacGia.CurrentRow.DataBoundItem;
            FillInputs(_currentTacGia);
            if (_mode == FormMode.Viewing)
            {
                SetMode(FormMode.Viewing);
            }
        }

        private void FillInputs(TacGia tacGia)
        {
            txtMaTacGia.Text = tacGia.Id;
            txtTenTacGia.Text = tacGia.Name;
        }

        private void ClearInputs()
        {
            txtMaTacGia.Text = string.Empty;
            txtTenTacGia.Text= string.Empty;
        }
    }
}
