using QuanLiThuVien.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    [Serializable]
    public class Book : LibraryItem
    {
        private string _tenSach = default!;
        private string _tacGiaId = default!;
        private BookCategory _theLoai = default!;
        private string _nhaXuatBan = default!;
        private int _namXuatBan;
        private int _soLuongNhap;

        public string TenSach
        {
            get { return _tenSach; }
            set { _tenSach = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public string TacGiaId
        {
            get { return _tacGiaId; }
            set { _tacGiaId = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value.Trim(); }
        }

        public BookCategory TheLoai
        {
            get { return _theLoai; }
            set { _theLoai = value; }
        }

        public string NhaXuatBan
        {
            get { return _nhaXuatBan; }
            set { _nhaXuatBan = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }

        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set { _namXuatBan = value <= 0 ? 1900 : value; }
        }

        public int SoLuongNhap
        {
            get { return _soLuongNhap; }
            set { _soLuongNhap = value < 0 ? 0 : value; }
        }

        public string TheLoaiDisplay
        {
            get { return Helper.GetEnumDescription(this.TheLoai); }
        }

        public string TacGiaDisplay
        {
            get
            {
                var tg = Data.DataManager.Instance.TacGiaRepository.GetById(TacGiaId);
                return tg?.Name ?? "Không rõ";
            }
        }

        public Book() : base()
        {
            TenSach = string.Empty;
            TacGiaId = string.Empty;
            TheLoai = BookCategory.Khac;
            NhaXuatBan = string.Empty;
            NamXuatBan = 1900;
            SoLuongNhap = 0;
        }

        public Book(string id, string tenSach, string tacGiaId, BookCategory theLoai, string nhaXuatBan,
                    int namXuatBan, int soLuongNhap, string ghiChu)
            : base(id, ghiChu)
        {
            TenSach = tenSach;
            TacGiaId = tacGiaId;
            TheLoai = theLoai;
            NhaXuatBan = nhaXuatBan;
            NamXuatBan = namXuatBan;
            SoLuongNhap = soLuongNhap;
        }
    }
}

