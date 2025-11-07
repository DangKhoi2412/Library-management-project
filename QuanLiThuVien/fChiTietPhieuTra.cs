using QuanLiThuVien.Data;
using QuanLiThuVien.DTO;
using QuanLiThuVien.Model;
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
    public partial class fChiTietPhieuTra : Form
    {
        private readonly ReturnTicketViewModel _chiTietPhieu;
        private readonly Book book;
        private readonly Reader reader; 
        public fChiTietPhieuTra(ReturnTicketViewModel chiTietPhieu)
        {
            InitializeComponent();
            _chiTietPhieu = chiTietPhieu;
            book = DataManager.Instance.BookRepository.GetById(_chiTietPhieu.MaSach);
            reader = DataManager.Instance.ReaderRepository.GetById(_chiTietPhieu.MaDocGia);
            Load += fChiTietPhieuTra_Load;
        }
        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            // Lặp qua tất cả các control trên form
            foreach (Control ctrl in this.Controls)
            {
                // Kiểm tra xem control có phải là TextBox không
                if (ctrl is TextBox)
                {
                    // Ép kiểu control thành TextBox và thiết lập thuộc tính ReadOnly
                    ((TextBox)ctrl).ReadOnly = isReadOnly;
                }
                // Nếu bạn có các control nằm trong GroupBox hoặc Panel, bạn cần lặp qua chúng nữa
                else if (ctrl is GroupBox || ctrl is Panel)
                {
                    foreach (Control innerCtrl in ctrl.Controls)
                    {
                        if (innerCtrl is TextBox)
                        {
                            ((TextBox)innerCtrl).ReadOnly = isReadOnly;
                        }
                    }
                }
            }
        }

        private void fChiTietPhieuTra_Load(object sender, EventArgs e)
        {
            if (_chiTietPhieu != null)
            {
                txtMaDG.Text = reader.MaDocGia;
                txtTenDG.Text = reader.Ten;
                txtLoaiDG.Text = reader.LoaiDGDisplay;
                txtNgaySinh.Text = reader.NgaySinh.ToString();
                txtSDT.Text = reader.SoDienThoai;

                txtMaSach.Text = book.Id;
                txtTenSach.Text = book.TenSach;
                txtTheLoai.Text = book.TheLoaiDisplay;
                txtTacGia.Text = book.TacGiaDisplay;
                txtNamXB.Text = book.NamXuatBan.ToString();

                txtMaPM.Text = _chiTietPhieu.MaPhieuMuon;
                txtSL.Text = _chiTietPhieu.SoLuong.ToString();
                txtNgayMuon.Text = _chiTietPhieu.NgayMuon.ToString();
                txtNgayTra.Text = _chiTietPhieu.NgayTraDuKien.ToString();
                txtGhiChu.Text = _chiTietPhieu.GhiChu.ToString();

                SetTextBoxesReadOnly(true);
            }
        }

    }
}
