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