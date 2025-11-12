using QuanLiThuVien.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    [Serializable]
    public class Reader : Person
    {
        private string _maDocGia = default!;
        private TypeOfReader _loaiDocGia;

        [KeyId]
        public string MaDocGia
        {
            get { return _maDocGia; }
            set { _maDocGia = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }
        public TypeOfReader LoaiDocGia
        {
            get { return _loaiDocGia; }
            set { _loaiDocGia = value; }
        }
        public string LoaiDGDisplay
        {
            get { return Helper.GetEnumDescription(this.LoaiDocGia); }
        }
        public string GioiTinhDisplay
        {
            get { return Helper.GetEnumDescription(this.GioiTinh); }
        }
        public Reader() : base()
        {
            MaDocGia = string.Empty;
            LoaiDocGia = TypeOfReader.Khac;
        }

        public Reader(string maDocGia, string ten, DateTime ngaySinh, TypeOfReader loaiDocGia, GioiTinh gioiTinh,
            string email, string soDienThoai, string diaChi)
            : base(ten, ngaySinh, gioiTinh, email, soDienThoai, diaChi)
        {
            MaDocGia = maDocGia;
            LoaiDocGia = loaiDocGia;
        }
    }
}
 