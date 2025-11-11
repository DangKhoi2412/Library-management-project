using QuanLiThuVien.Model;
using QuanLiThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QuanLiThuVien.Data
{
    internal class DataManager
    {
        private static readonly Lazy<DataManager> _instance = new(() => new DataManager());
        public static DataManager Instance => _instance.Value;

        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Reader> _readerRepository;
        private readonly IRepository<BorrowingTicket> _borrowingTicketRepository;
        private readonly IRepository<TacGia> _tacGiaRepository;

        private readonly string _basePath;
        private readonly string _initialDataPath;

        private DataManager()
        {
            _basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            _initialDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InitialData");

            Directory.CreateDirectory(_basePath);
            Directory.CreateDirectory(_initialDataPath);

            _tacGiaRepository = new Repository<TacGia>(Path.Combine(_basePath, "TacGia.json"));
            _bookRepository = new Repository<Book>(Path.Combine(_basePath, "Books.json"));
            _readerRepository = new Repository<Reader>(Path.Combine(_basePath, "Readers.json"));
            _borrowingTicketRepository = new Repository<BorrowingTicket>(Path.Combine(_basePath, "BorrowingTickets.json"));
            
            InitializeData();
        }
        public IRepository<TacGia> TacGiaRepository => _tacGiaRepository;
        public IRepository<Book> BookRepository => _bookRepository;
        public IRepository<Reader> ReaderRepository => _readerRepository;
        public IRepository<BorrowingTicket> BorrowingTicketRepository => _borrowingTicketRepository;
        
        public void SaveAllChanges()
        {
            try
            {
                TacGiaRepository.SaveChanges();
                BookRepository.SaveChanges();
                ReaderRepository.SaveChanges();
                BorrowingTicketRepository.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu dữ liệu: {ex.Message}");
            }
        }

        private void InitializeData()
        {
            try
            {
                if (IsDirectoryEmpty(_basePath))
                {
                    LoadInitialData();
                }
                else
                {
                    TacGiaRepository.LoadFromFile();
                    BookRepository.LoadFromFile();
                    ReaderRepository.LoadFromFile();
                    BorrowingTicketRepository.LoadFromFile();

                    bool noAuthors = TacGiaRepository.GetAll().Count == 0;
                    bool noBooks = BookRepository.GetAll().Count == 0;
                    bool noReaders = ReaderRepository.GetAll().Count == 0;
                    bool noTickets = BorrowingTicketRepository.GetAll().Count == 0;
                    

                    if (noBooks && noReaders && noTickets && noAuthors)
                    {
                        LoadInitialData();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi khởi tạo dữ liệu: {ex.Message}");
            }
        }

        private bool IsDirectoryEmpty(string path)
        {
            if (!Directory.Exists(path))
                return true;

            string[] files = Directory.GetFiles(path);
            if (files.Length == 0) return true;

            foreach (var f in files)
            {
                try
                {
                    string content = File.ReadAllText(f, Encoding.UTF8).Trim();
                    if (!string.IsNullOrEmpty(content) && content != "[]")
                    {
                        return false;
                    }
                }
                catch { }
            }
            return true;
        }

        private void LoadInitialData()
        {
            try
            {
                LoadInitialEntities(TacGiaRepository, "TacGia.json");
                LoadInitialEntities(BookRepository, "Books.json");
                LoadInitialEntities(ReaderRepository, "Readers.json");
                LoadInitialEntities(BorrowingTicketRepository, "BorrowingTickets.json");
                

                SaveAllChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải dữ liệu mẫu: {ex.Message}");
            }
        }

        private void LoadInitialEntities<T>(IRepository<T> repository, string fileName) where T : class
        {
            string filePath = Path.Combine(_initialDataPath, fileName);
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
                List<T>? initialData = JsonSerializer.Deserialize<List<T>>(jsonString);
                if (initialData != null)
                {
                    foreach (T item in initialData)
                    {
                        repository.Add(item);
                    }
                }
            }
        }
    }
}
