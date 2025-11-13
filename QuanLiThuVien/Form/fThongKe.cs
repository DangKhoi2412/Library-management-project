using QuanLiThuVien.Data;
using QuanLiThuVien.DTO;
using QuanLiThuVien.Model.Enum; 
using QuanLiThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLiThuVien
{
    public partial class fThongKe : Form
    {
        private readonly TicketService _ticketService;
        private List<BaoCaoViewModel> _allTickets;


        private class SachMuonInfo
        {
            public string TenSach { get; set; }
            public int SoLuotMuon { get; set; }
        }


        private class DocGiaTreInfo
        {
            public string TenDocGia { get; set; }
            public int SoLanTre { get; set; }
            public int TongSoNgayTre { get; set; }
        }

        private class TheLoaiInfo
        {
            public string TheLoai { get; set; }
            public int SoLuotMuon { get; set; }
        }


        private int CompareSachMuonInfoBySoLuotMuon(SachMuonInfo a, SachMuonInfo b)
        {
            return b.SoLuotMuon.CompareTo(a.SoLuotMuon);
        }

        private int CompareDocGiaTreByTongNgay(DocGiaTreInfo a, DocGiaTreInfo b)
        {
            return b.TongSoNgayTre.CompareTo(a.TongSoNgayTre);
        }


        public fThongKe()
        {
            InitializeComponent();
            _ticketService = new TicketService(
                DataManager.Instance.BookRepository,
                DataManager.Instance.ReaderRepository,
                DataManager.Instance.BorrowingTicketRepository
            );
            HookEvents();
        }

        private void HookEvents()
        {
            this.Load += fThongKe_Load;
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            LoadDataAndRenderCharts();
        }

        private void LoadDataAndRenderCharts()
        {
            try
            {
                _allTickets = _ticketService.GetBaoCaoViewModels();

                LoadChartTop10Sach(_allTickets);
                LoadChartTheoThang(_allTickets);
                LoadChartDocGiaTre(_allTickets);
                LoadChartTheLoai(_allTickets);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChartTop10Sach(List<BaoCaoViewModel> data)
        {
            Dictionary<string, SachMuonInfo> sachCounts = new Dictionary<string, SachMuonInfo>();

            foreach (BaoCaoViewModel ticket in data)
            {
                if (!sachCounts.ContainsKey(ticket.MaSach))
                {
                    sachCounts[ticket.MaSach] = new SachMuonInfo
                    {
                        TenSach = ticket.TenSach,
                        SoLuotMuon = 0
                    };
                }
                sachCounts[ticket.MaSach].SoLuotMuon += ticket.SoLuong;
            }

            List<SachMuonInfo> sortedList = new List<SachMuonInfo>(sachCounts.Values);
            sortedList.Sort(CompareSachMuonInfoBySoLuotMuon);

            List<SachMuonInfo> top10Sach = new List<SachMuonInfo>();
            int count = 0;
            foreach (SachMuonInfo item in sortedList)
            {
                if (count >= 10)
                {
                    break;
                }
                top10Sach.Add(item);
                count++;
            }

            dgvTop10Sach.DataSource = top10Sach;
            dgvTop10Sach.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvTop10Sach.Columns["SoLuotMuon"].HeaderText = "Số Lượng Mượn";

            Series series = chartTop10Sach.Series["Series1"];
            series.ChartType = SeriesChartType.Column;
            series.Points.Clear();

            List<SachMuonInfo> chartData = new List<SachMuonInfo>(top10Sach);
            chartData.Reverse();
            foreach (SachMuonInfo item in chartData)
            {
                series.Points.AddXY(item.TenSach, item.SoLuotMuon);
            }

            series.IsValueShownAsLabel = true;
            chartTop10Sach.ChartAreas[0].AxisX.Interval = 1;
            chartTop10Sach.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chartTop10Sach.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10f);
        }

        private void LoadChartTheoThang(List<BaoCaoViewModel> data)
        {
            Dictionary<int, int> muonTheoThang = new Dictionary<int, int>();

            foreach (BaoCaoViewModel ticket in data)
            {
                int thang = ticket.NgayMuon.Month;
                if (!muonTheoThang.ContainsKey(thang))
                {
                    muonTheoThang[thang] = 0;
                }
                muonTheoThang[thang] += ticket.SoLuong;
            }

            Series series = chartTheoThang.Series["Series1"];
            series.ChartType = SeriesChartType.Line;
            series.Points.Clear();
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.BorderWidth = 3;

            for (int i = 1; i <= 12; i++)
            {
                int soLuot = 0;
                muonTheoThang.TryGetValue(i, out soLuot);
                series.Points.AddXY($"T{i}", soLuot);
            }

            series.IsValueShownAsLabel = true;
        }

        private void LoadChartDocGiaTre(List<BaoCaoViewModel> data)
        {
            Dictionary<string, DocGiaTreInfo> treCounts = new Dictionary<string, DocGiaTreInfo>();

            foreach (BaoCaoViewModel ticket in data)
            {
                if (ticket.SoNgayQuaHan > 0)
                {
                    if (!treCounts.ContainsKey(ticket.TenDocGia))
                    {
                        treCounts[ticket.TenDocGia] = new DocGiaTreInfo
                        {
                            TenDocGia = ticket.TenDocGia,
                            SoLanTre = 0,
                            TongSoNgayTre = 0
                        };
                    }

                    DocGiaTreInfo info = treCounts[ticket.TenDocGia];
                    info.SoLanTre += 1;
                    info.TongSoNgayTre += ticket.SoNgayQuaHan;
                }
            }

            List<DocGiaTreInfo> sortedList = new List<DocGiaTreInfo>(treCounts.Values);
            sortedList.Sort(CompareDocGiaTreByTongNgay);

            List<DocGiaTreInfo> docGiaTre = new List<DocGiaTreInfo>();
            int count = 0;
            foreach (DocGiaTreInfo item in sortedList)
            {
                if (count >= 10) break;
                docGiaTre.Add(item);
                count++;
            }

            dgvDocGiaTre.DataSource = docGiaTre;
            dgvDocGiaTre.Columns["TenDocGia"].HeaderText = "Tên Độc Giả";
            dgvDocGiaTre.Columns["SoLanTre"].HeaderText = "Số Lần Trễ";
            dgvDocGiaTre.Columns["TongSoNgayTre"].HeaderText = "Tổng Ngày Trễ";

            Series series = chartDocGiaTre.Series["Series1"];
            series.ChartType = SeriesChartType.Bar;
            series.Points.Clear();

            List<DocGiaTreInfo> chartData = new List<DocGiaTreInfo>(docGiaTre);
            chartData.Reverse();
            foreach (DocGiaTreInfo item in chartData)
            {
                series.Points.AddXY(item.TenDocGia, item.TongSoNgayTre);
            }
            series.IsValueShownAsLabel = true;
        }

        private void LoadChartTheLoai(List<BaoCaoViewModel> data)
        {
            Dictionary<BookCategory, int> theLoaiCounts = new Dictionary<BookCategory, int>();

            foreach (BaoCaoViewModel ticket in data)
            {
                if (!theLoaiCounts.ContainsKey(ticket.TheLoaiSach))
                {
                    theLoaiCounts[ticket.TheLoaiSach] = 0;
                }
                theLoaiCounts[ticket.TheLoaiSach] += ticket.SoLuong;
            }
            List<TheLoaiInfo> tyLeTheLoai = new List<TheLoaiInfo>();
            foreach (KeyValuePair<BookCategory, int> pair in theLoaiCounts)
            {
                tyLeTheLoai.Add(new TheLoaiInfo
                {
                    TheLoai = Helper.GetEnumDescription(pair.Key),
                    SoLuotMuon = pair.Value
                });
            }
            System.Windows.Forms.DataVisualization.Charting.Series series = chartTheLoai.Series["Series1"];
            series.ChartType = SeriesChartType.Pie;
            series.Points.Clear();

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            series.Font = new Font("Arial", 10f, FontStyle.Bold);

            foreach (TheLoaiInfo item in tyLeTheLoai)
            {
                DataPoint point = new DataPoint(0, item.SoLuotMuon);
                point.Label = $"{item.TheLoai}\n(#PERCENT)";
                point.LegendText = item.TheLoai;

                series.Points.Add(point);
            }

            chartTheLoai.Legends[0].Enabled = true;
            chartTheLoai.Legends[0].Docking = Docking.Bottom;
            chartTheLoai.Legends[0].Font = new Font("Arial", 8f);
        }
    }
}