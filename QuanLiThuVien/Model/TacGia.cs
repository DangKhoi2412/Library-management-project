using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    [Serializable]
    internal class TacGia
    {
        [KeyId]
        public string Id { get; set; } 
        public string Name { get; set; }

        public TacGia(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
