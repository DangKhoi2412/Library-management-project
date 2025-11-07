using QuanLiThuVien.Data;
using QuanLiThuVien.Model.Enum;
using System;

namespace QuanLiThuVien.Model
{
    [Serializable]
    public class BorrowingTicket : TicketBase
    {
        private string _maDocGia = default!;
        private string _maSach = default!;
        private int _soLuong;
        private DateTime _ngayMuon;
        private DateTime _ngayTraDuKien;
        private DateTime? _ngayTraThucTe;
        private string _soDienThoai = default!;
        private BorrowingStatus _trangThai;
        private int _soNgayQuaHan;
        private decimal _tienPhat;

        public string MaDocGia
        {
            get { return _maDocGia; }
            set { _maDocGia = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public string MaSach
        {
            get { return _maSach; }
            set { _maSach = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value < 1 ? 1 : value; }
        }

        public DateTime NgayMuon
        {
            get { return _ngayMuon; }
            set { _ngayMuon = value; }
        }

        public DateTime NgayTraDuKien
        {
            get { return _ngayTraDuKien; }
            set { _ngayTraDuKien = value; }
        }

        // Null nếu chưa trả
        public DateTime? NgayTraThucTe
        {
            get { return _ngayTraThucTe; }
            set { _ngayTraThucTe = value; }
        }

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public BorrowingStatus TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

        public int SoNgayQuaHan
        {
            get { return _soNgayQuaHan; }
            set { _soNgayQuaHan = value < 0 ? 0 : value; }
        }

        public decimal TienPhat
        {
            get { return _tienPhat; }
            set { _tienPhat = value < 0 ? 0 : value; }
        }

        public BorrowingTicket() : base()
        {
            MaDocGia = string.Empty;
            MaSach = string.Empty;
            SoLuong = 1;
            NgayMuon = DateTime.Now;
            NgayTraDuKien = DateTime.Now;
            NgayTraThucTe = null;
            SoDienThoai = string.Empty;
            TrangThai = BorrowingStatus.DangMuon;
            SoNgayQuaHan = 0;
            TienPhat = 0;
        }

        public BorrowingTicket(string id, string maDocGia, string maSach,
                               int soLuong, DateTime ngayMuon, string soDienThoai, string ghiChu)
            : base(id, ghiChu)
        {
            MaDocGia = maDocGia;
            MaSach = maSach;
            SoLuong = soLuong;
            NgayMuon = ngayMuon;
            SoDienThoai = soDienThoai;
            // NgayTraDuKien thường sẽ được service set sau khi biết loại độc giả

            NgayTraDuKien = ngayMuon;
            NgayTraThucTe = null;
            TrangThai = BorrowingStatus.DangMuon;
            SoNgayQuaHan = 0;
            TienPhat = 0;
        }
    }
}
