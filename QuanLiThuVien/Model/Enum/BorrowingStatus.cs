using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model.Enum
{
    public enum BorrowingStatus
    {
        [Description("Đang mượn")]
        DangMuon = 0,

        [Description("Đã trả")]
        DaTra = 1       
    }
}
