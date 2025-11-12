using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien.Model
{
    [Serializable]
    public abstract class TicketBase
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
            set { _ghiChu = value == null ? "UNKNOW" : value.Trim(); }
        }

        protected TicketBase()
        {
            Id = string.Empty;
            GhiChu = string.Empty;
        }

        protected TicketBase(string id, string ghiChu)
        {
            Id = id;
            GhiChu = ghiChu;
        }
    }
}
