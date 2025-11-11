using QuanLiThuVien.Model.Enum;
using System;

namespace QuanLiThuVien.DTO
{
    public class BaoCaoViewModel
    {

        public string MaPhieuMuon { get; set; }
        public string TenDocGia { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public string TrangThaiDisplay => Helper.GetEnumDescription(TrangThai);
        public int SoNgayQuaHan { get; set; }
        public decimal TienPhat { get; set; }
        public string GhiChu { get; set; }


        public string MaSach { get; set; }
        public string MaDocGia { get; set; }
        public TypeOfReader LoaiDocGia { get; set; }
        public BookCategory TheLoaiSach { get; set; }
        public BorrowingStatus TrangThai { get; set; }
    }
}