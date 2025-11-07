using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model.Enum
{
    public enum BookCategory
    {
        [Description("Khoa học tự nhiên")]
        KhoaHocTuNhien,

        [Description("Khoa học xã hội")]
        KhoaHocXaHoi,

        [Description("Văn học Việt Nam")]
        VanHocVietNam,

        [Description("Văn học nước ngoài")]
        VanHocNuocNgoai,

        [Description("Lịch sử")]
        LichSu,

        [Description("Địa lý")]
        DiaLy,

        [Description("Toán học")]
        ToanHoc,

        [Description("Công nghệ thông tin")]
        CongNgheThongTin,

        [Description("Kỹ thuật")]
        KyThuat,

        [Description("Kinh tế")]
        KinhTe,

        [Description("Chính trị - Pháp luật")]
        ChinhTriPhapLuat,

        [Description("Y học - Sức khỏe")]
        YHocSucKhoe,

        [Description("Tâm lý - Giáo dục")]
        TamLyGiaoDuc,

        [Description("Nghệ thuật - Âm nhạc")]
        NgheThuatAmNhac,

        [Description("Thiếu nhi")]
        ThieuNhi,

        [Description("Truyện tranh - Manga")]
        TruyenTranhManga,

        [Description("Tiểu thuyết")]
        TieuThuyet,

        [Description("Ngoại ngữ")]
        NgoaiNgu,

        [Description("Tôn giáo - Tín ngưỡng")]
        TonGiaoTinNguong,

        [Description("Khác")]
        Khac

    }
}
