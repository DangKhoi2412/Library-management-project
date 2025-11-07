using QuanLiThuVien.DTO;
using QuanLiThuVien.Model;
using QuanLiThuVien.Model.Enum;
using QuanLiThuVien.Repositories;
using System;
using System.Collections.Generic;

namespace QuanLiThuVien.Services
{
    internal class TicketService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Reader> _readerRepository;
        private readonly IRepository<BorrowingTicket> _borrowingTicketRepository;

        public TicketService(
            IRepository<Book> bookRepository,
            IRepository<Reader> readerRepository,
            IRepository<BorrowingTicket> borrowingTicketRepository)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _borrowingTicketRepository = borrowingTicketRepository;
        }

        public void CreateBorrowingTicket(string id, string maDocGia, string maSach, int soLuong, DateTime ngayMuon, string soDienThoai, string ghiChu)
        {
            BorrowingTicket existingTicket = _borrowingTicketRepository.GetById(id);
            if (existingTicket != null)
            {
                throw new Exception($"Phiếu mượn với mã '{id}' đã tồn tại.");
            }

            Reader reader = _readerRepository.GetById(maDocGia);
            if (reader == null)
            {
                throw new Exception($"Không tìm thấy độc giả với mã: {maDocGia}");
            }

            Book book = _bookRepository.GetById(maSach);
            if (book == null)
            {
                throw new Exception($"Không tìm thấy sách với mã: {maSach}");
            }

            if (book.SoLuongNhap < soLuong)
            {
                throw new Exception($"Không đủ số lượng sách '{book.TenSach}' để cho mượn. Còn lại: {book.SoLuongNhap}");
            }

            BorrowingTicket ticket = new BorrowingTicket(id, maDocGia, maSach, soLuong, ngayMuon, soDienThoai, ghiChu);

            int daysToAdd;
            if (reader.LoaiDocGia == TypeOfReader.HocSinh)
            {
                daysToAdd = 15;
            }
            else if (reader.LoaiDocGia == TypeOfReader.GiaoVien)
            {
                daysToAdd = 30;
            }
            else
            {
                daysToAdd = 10;
            }

            ticket.NgayTraDuKien = ticket.NgayMuon.AddDays(daysToAdd);

            // Cập nhật trạng thái mới
            ticket.TrangThai = BorrowingStatus.DangMuon;

            book.SoLuongNhap -= soLuong;
            _bookRepository.Update(book);
            _borrowingTicketRepository.Add(ticket);
        }

        public decimal ProcessBookReturn(string borrowingTicketId)
        {
            BorrowingTicket borrowingTicket = _borrowingTicketRepository.GetById(borrowingTicketId);
            if (borrowingTicket == null)
            {
                throw new Exception($"Không tìm thấy phiếu mượn với mã: {borrowingTicketId}");
            }

            if (borrowingTicket.TrangThai == BorrowingStatus.DaTra)
            {
                throw new Exception($"Phiếu mượn '{borrowingTicketId}' đã được trả trước đó.");
            }

            Book book = _bookRepository.GetById(borrowingTicket.MaSach);
            if (book == null)
            {
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy sách '{borrowingTicket.MaSach}' của phiếu mượn.");
            }

            Reader reader = _readerRepository.GetById(borrowingTicket.MaDocGia);
            if (reader == null)
            {
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy độc giả '{borrowingTicket.MaDocGia}' của phiếu mượn.");
            }

            DateTime returnDate = DateTime.Now;
            int overdueDays = 0;
            decimal fine = 0;

            if (returnDate > borrowingTicket.NgayTraDuKien)
            {
                TimeSpan timeDiff = returnDate - borrowingTicket.NgayTraDuKien;
                overdueDays = timeDiff.Days;
            }

            if (overdueDays > 0)
            {
                decimal finePerDay;
                if (reader.LoaiDocGia == TypeOfReader.HocSinh)
                {
                    finePerDay = 7000;
                }
                else if (reader.LoaiDocGia == TypeOfReader.GiaoVien)
                {
                    finePerDay = 5000;
                }
                else
                {
                    finePerDay = 3636;
                }
                fine = overdueDays * finePerDay;
            }

            borrowingTicket.NgayTraThucTe = returnDate;
            borrowingTicket.SoNgayQuaHan = overdueDays;
            borrowingTicket.TienPhat = fine;
            borrowingTicket.TrangThai = BorrowingStatus.DaTra;
            borrowingTicket.GhiChu = borrowingTicket.GhiChu + $" | Trả ngày {returnDate:dd/MM/yyyy}";

            book.SoLuongNhap += borrowingTicket.SoLuong;

            _bookRepository.Update(book);
            _borrowingTicketRepository.Update(borrowingTicket);

            return fine;
        }

        public ReturnTicketViewModel GetBorrowingDetails(string borrowingTicketId)
        {
            BorrowingTicket borrowingTicket = _borrowingTicketRepository.GetById(borrowingTicketId);
            if (borrowingTicket == null)
            {
                throw new Exception($"Không tìm thấy phiếu mượn với mã: {borrowingTicketId}");
            }

            Reader reader = _readerRepository.GetById(borrowingTicket.MaDocGia);
            if (reader == null)
            {
                throw new Exception($"Không tìm thấy độc giả {borrowingTicket.MaDocGia}");
            }

            if (borrowingTicket.TrangThai == BorrowingStatus.DaTra)
            {
                return new ReturnTicketViewModel
                {
                    MaPhieuMuon = borrowingTicket.Id,
                    MaDocGia = borrowingTicket.MaDocGia,
                    MaSach = borrowingTicket.MaSach,
                    SoLuong = borrowingTicket.SoLuong,
                    NgayMuon = borrowingTicket.NgayMuon,
                    SoDienThoai = borrowingTicket.SoDienThoai,
                    NgayTraDuKien = borrowingTicket.NgayTraDuKien,
                    SoNgayQuaHan = borrowingTicket.SoNgayQuaHan,
                    TienPhat = borrowingTicket.TienPhat,
                    GhiChu = borrowingTicket.GhiChu,
                    TrangThai = borrowingTicket.TrangThai
                };
            }

            int overdueDays = 0;
            decimal fine = 0;

            if (DateTime.Now > borrowingTicket.NgayTraDuKien)
            {
                TimeSpan timeDiff = DateTime.Now - borrowingTicket.NgayTraDuKien;
                overdueDays = timeDiff.Days;

                decimal finePerDay;
                if (reader.LoaiDocGia == TypeOfReader.HocSinh)
                {
                    finePerDay = 5000;
                }
                else if (reader.LoaiDocGia == TypeOfReader.GiaoVien)
                {
                    finePerDay = 10000;
                }
                else
                {
                    finePerDay = 3600;
                }
                fine = overdueDays * finePerDay;
            }

            return new ReturnTicketViewModel
            {
                MaPhieuMuon = borrowingTicket.Id,
                MaDocGia = borrowingTicket.MaDocGia,
                MaSach = borrowingTicket.MaSach,
                SoLuong = borrowingTicket.SoLuong,
                NgayMuon = borrowingTicket.NgayMuon,
                SoDienThoai = borrowingTicket.SoDienThoai,
                NgayTraDuKien = borrowingTicket.NgayTraDuKien,
                SoNgayQuaHan = overdueDays,
                TienPhat = fine,
                GhiChu = borrowingTicket.GhiChu,
                TrangThai = borrowingTicket.TrangThai
            };
        }
        public List<BaoCaoViewModel> GetBaoCaoViewModels()
        {
            // Lấy tất cả dữ liệu gốc một lần
            var allTickets = _borrowingTicketRepository.GetAll();
            var allReaders = _readerRepository.GetAll().ToDictionary(r => r.MaDocGia, r => r);
            var allBooks = _bookRepository.GetAll().ToDictionary(b => b.Id, b => b);

            List<BaoCaoViewModel> reportViewModels = new List<BaoCaoViewModel>();

            foreach (var ticket in allTickets)
            {
                // Luôn cập nhật trạng thái quá hạn mới nhất
                //UpdateOverdueStatus(ticket);

                // Tra cứu thông tin (dùng TryGetValue để an toàn)
                allReaders.TryGetValue(ticket.MaDocGia, out Reader reader);
                allBooks.TryGetValue(ticket.MaSach, out Book book);

                // Tạo DTO mới
                var vm = new BaoCaoViewModel
                {
                    // Thuộc tính hiển thị
                    MaPhieuMuon = ticket.Id,
                    TenDocGia = reader?.Ten ?? "Không rõ", // Dùng tên nếu có, nếu không thì báo "Không rõ"
                    TenSach = book?.TenSach ?? "Không rõ", // Dùng tên nếu có
                    SoLuong = ticket.SoLuong,
                    NgayMuon = ticket.NgayMuon,
                    NgayTraDuKien = ticket.NgayTraDuKien,
                    SoNgayQuaHan = ticket.SoNgayQuaHan,
                    TienPhat = ticket.TienPhat,
                    GhiChu = ticket.GhiChu,

                    // Thuộc tính ẩn để lọc
                    MaSach = ticket.MaSach,
                    MaDocGia = ticket.MaDocGia,
                    LoaiDocGia = reader?.LoaiDocGia ?? TypeOfReader.Khac, // Dùng enum nếu có
                    TheLoaiSach = book?.TheLoai ?? BookCategory.Khac, // Dùng enum nếu có
                    TrangThai = ticket.TrangThai
                };

                reportViewModels.Add(vm);
            }

            return reportViewModels;
        }
        public List<ReturnTicketViewModel> GetActiveBorrowingDetails()
        {
            List<BorrowingTicket> allTickets = _borrowingTicketRepository.GetAll();
            List<BorrowingTicket> activeTickets = new List<BorrowingTicket>();

            for (int i = 0; i < allTickets.Count; i++)
            {
                if (allTickets[i].TrangThai == BorrowingStatus.DangMuon)
                {
                    activeTickets.Add(allTickets[i]);
                }
            }

            List<ReturnTicketViewModel> results = new List<ReturnTicketViewModel>();

            for (int i = 0; i < activeTickets.Count; i++)
            {
                try
                {
                    ReturnTicketViewModel viewModel = GetBorrowingDetails(activeTickets[i].Id);
                    results.Add(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý phiếu {activeTickets[i].Id}: {ex.Message}");
                }
            }

            return results;
        }

        public List<ReturnTicketViewModel> GetAllBorrowingDetails()
        {
            List<BorrowingTicket> allTickets = _borrowingTicketRepository.GetAll();
            List<ReturnTicketViewModel> results = new List<ReturnTicketViewModel>();

            for (int i = 0; i < allTickets.Count; i++)
            {
                try
                {
                    ReturnTicketViewModel viewModel = GetBorrowingDetails(allTickets[i].Id);
                    results.Add(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý phiếu {allTickets[i].Id}: {ex.Message}");
                }
            }

            return results;
        }

        public List<ReturnTicketViewModel> GetReaderHistory(string maDocGia)
        {
            List<BorrowingTicket> readerTickets = _borrowingTicketRepository.FindByPropertyContains("MaDocGia", maDocGia);
            List<ReturnTicketViewModel> results = new List<ReturnTicketViewModel>();

            for (int i = 0; i < readerTickets.Count; i++)
            {
                try
                {
                    ReturnTicketViewModel viewModel = GetBorrowingDetails(readerTickets[i].Id);
                    results.Add(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý phiếu {readerTickets[i].Id}: {ex.Message}");
                }
            }

            return results;
        }

        public TicketStatistics GetStatistics()
        {
            List<BorrowingTicket> allTickets = _borrowingTicketRepository.GetAll();

            int totalBorrowed = allTickets.Count;
            int active = 0;
            int returned = 0;
            decimal totalFines = 0;

            for (int i = 0; i < allTickets.Count; i++)
            {
                BorrowingTicket ticket = allTickets[i];
                if (ticket.TrangThai == BorrowingStatus.DangMuon)
                {
                    active++;
                }
                else if (ticket.TrangThai == BorrowingStatus.DaTra)
                {
                    returned++;
                    totalFines += ticket.TienPhat;
                }
            }

            return new TicketStatistics
            {
                TotalBorrowed = totalBorrowed,
                Active = active,
                Returned = returned,
                TotalFines = totalFines
            };
        }

        public List<BorrowingTicket> GetOverdueTickets()
        {
            List<BorrowingTicket> allTickets = _borrowingTicketRepository.GetAll();
            List<BorrowingTicket> overdueTickets = new List<BorrowingTicket>();
            DateTime today = DateTime.Now;

            for (int i = 0; i < allTickets.Count; i++)
            {
                BorrowingTicket ticket = allTickets[i];
                if (ticket.TrangThai == BorrowingStatus.DangMuon && today > ticket.NgayTraDuKien)
                {
                    overdueTickets.Add(ticket);
                }
            }

            return overdueTickets;
        }
    }

    // Class helper cho statistics
    public class TicketStatistics
    {
        public int TotalBorrowed { get; set; }
        public int Active { get; set; }
        public int Returned { get; set; }
        public decimal TotalFines { get; set; }
    }
}