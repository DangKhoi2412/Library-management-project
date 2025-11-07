using QuanLiThuVien.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    // Đây là lớp chung cho người, sau này có mở rộng thêm lớp như Staff,
    // Các thuộc tính MaDocGia (mã độc giả) và LoaiDocGia (loại độc giả) là đặc thù cho độc giả, nên để ở lớp Reader.

    [Serializable]
    public abstract class Person
    {
        private string _ten = default!;
        private DateTime _ngaySinh;
        private GioiTinh _gioiTinh;
        private string _email = default!;
        private string _soDienThoai = default!;
        private string _diaChi = default!;

        public string Ten
        {
            get { return _ten; }
            set { _ten = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value < DateTime.MinValue.AddYears(1900) ? DateTime.MinValue.AddYears(1900) : value; }
        }

        public GioiTinh GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = (string.IsNullOrWhiteSpace(value) || !value.Contains("@")) ? "UNKNOW" : value.Trim(); }
        }

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        protected Person()
        {
            Ten = string.Empty;
            NgaySinh = DateTime.Now;
            GioiTinh = GioiTinh.Khac;
            Email = string.Empty;
            SoDienThoai = string.Empty;
            DiaChi = string.Empty;
        }

        protected Person(
            string ten, DateTime ngaySinh, GioiTinh gioiTinh, string email, 
            string soDienThoai, string diaChi)
        {
            Ten = ten;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
    }
}
