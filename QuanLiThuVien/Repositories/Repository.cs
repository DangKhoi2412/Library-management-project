using QuanLiThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLiThuVien.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private List<T> _items;
        private string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public Repository(string filePath)
        {
            _items = new List<T>();
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        public T GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                string currentId = GetIdFromItem(_items[i]);
                if (currentId == id)
                {
                    return _items[i];
                }
            }
            return null;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                return;
            }
            _items.Add(item);
        }

        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            for (int i = _items.Count - 1; i >= 0; i--)
            {
                string currentId = GetIdFromItem(_items[i]);
                if (currentId == id)
                {
                    _items.RemoveAt(i);
                    break;
                }
            }
        }

        public void Update(T item)
        {
            if (item == null)
            {
                return;
            }

            string itemId = GetIdFromItem(item);
            if (string.IsNullOrEmpty(itemId))
            {
                return;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                string currentId = GetIdFromItem(_items[i]);
                if (currentId == itemId)
                {
                    _items[i] = item;
                    break;
                }
            }
        }

        public List<T> FindByPropertyContains(string propertyName, string keyword)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName không hợp lệ.", nameof(propertyName));
            }

            string query = keyword == null ? string.Empty : keyword.Trim();
            List<T> result = new List<T>();

            PropertyInfo prop = typeof(T).GetProperty(propertyName);
            if (prop == null)
            {
                return result;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                T item = _items[i];
                object val = prop.GetValue(item);
                if (val != null)
                {
                    string text = val.ToString();
                    if (text != null && text.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(_filePath, Encoding.UTF8);
                    List<T> loadedItems = JsonSerializer.Deserialize<List<T>>(jsonString, _jsonOptions);
                    if (loadedItems != null)
                    {
                        _items = new List<T>(loadedItems);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Có lỗi khi Load danh sách!");
                    _items = new List<T>();
                }
            }
        }

        public void SaveChanges()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(_items, _jsonOptions);
                File.WriteAllText(_filePath, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi khi lưu dữ liệu: {ex}");
            }
        }

        private string GetIdFromItem(T item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (Attribute.IsDefined(prop, typeof(KeyIdAttribute)))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        return (string)prop.GetValue(item);
                    }
                }
            }

            return string.Empty;
        }
    }
}