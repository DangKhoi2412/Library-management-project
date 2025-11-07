using QuanLiThuVien.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.DTO
{
    public class ReturnTicketViewModel
    {
        public string MaPhieuMuon { get; set; } = string.Empty;
        public string MaDocGia { get; set; } = string.Empty;
        public string MaSach { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public BorrowingStatus TrangThai { get; set; }
        public int SoNgayQuaHan { get; set; }
        public decimal TienPhat { get; set; }
        public string GhiChu { get; set; } = string.Empty;

        public string TrangThaiDisplay => Helper.GetEnumDescription(TrangThai);

    }
}
