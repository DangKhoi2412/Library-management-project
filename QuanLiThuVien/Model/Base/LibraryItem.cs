using QuanLiThuVien.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    //Đây là lớp chung của các item trong thư viện,
    //Id và ghi chú là thuộc tính chung, có thể áp dụng cho các loại item khác ngoài sách (tạp chí, báo, tài liệu khác)
    //Các thuộc tính còn lại như tên sách, tác giả, thể loại, nhà xuất bản, năm xuất bản, số lượng nhập
    //mang tính đặc thù của sách, nên sẽ để ở lớp kế thừa.

    [Serializable]
    public abstract class LibraryItem
    {
        private string _id = default!;
        private string _ghiChu = default!;

        [KeyId]
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrWhiteSpace(value) ? "UNKNOW" : value.Trim(); }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value == null ? string.Empty : value.Trim(); }
        }
        protected LibraryItem()
        {
            Id = string.Empty;
            GhiChu = string.Empty;
        }

        protected LibraryItem(string id, string ghiChu)
        {
            Id = id;
            GhiChu = ghiChu;
        }
    }
}
