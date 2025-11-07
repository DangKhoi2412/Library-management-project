using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(string id);
        List<T> GetAll();
        T GetById(string id);


        List<T> FindByPropertyContains(string propertyName, string keyword);
        void SaveChanges();
        void LoadFromFile();
    }
}
