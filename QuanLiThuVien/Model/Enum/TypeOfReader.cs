using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model.Enum
{
    public enum TypeOfReader
    {
        [Description("Học sinh")]
        HocSinh,

        [Description("Giảng viên")]
        GiaoVien,

        [Description("Khác")]
        Khac
    }
}
