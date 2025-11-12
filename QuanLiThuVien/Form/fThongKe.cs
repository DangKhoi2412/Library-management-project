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
            var top10Sach = data
                .GroupBy(t => new { t.MaSach, t.TenSach })
                .Select(g => new
                {
                    TenSach = g.Key.TenSach,
                    SoLuotMuon = g.Sum(t => t.SoLuong) 
                })
                .OrderByDescending(s => s.SoLuotMuon)
                .Take(10)
                .ToList();

            dgvTop10Sach.DataSource = top10Sach;
            dgvTop10Sach.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvTop10Sach.Columns["SoLuotMuon"].HeaderText = "Số Lượng Mượn";

            var series = chartTop10Sach.Series["Series1"];
            series.ChartType = SeriesChartType.Column;
            series.Points.Clear();

            foreach (var item in top10Sach.AsEnumerable().Reverse())
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

            var luotMuonTheoThang = data
                .GroupBy(t => t.NgayMuon.Month)
                .Select(g => new
                {
                    Thang = g.Key,
                    SoLuotMuon = g.Sum(t => t.SoLuong)
                })
                .OrderBy(x => x.Thang)
                .ToList();


            var series = chartTheoThang.Series["Series1"];
            series.ChartType = SeriesChartType.Line;
            series.Points.Clear();
            series.MarkerStyle = MarkerStyle.Circle; 
            series.MarkerSize = 8;
            series.BorderWidth = 3;


            for (int i = 1; i <= 12; i++)
            {
                var dataPoint = luotMuonTheoThang.FirstOrDefault(x => x.Thang == i);
                int soLuot = dataPoint?.SoLuotMuon ?? 0;
                series.Points.AddXY($"T{i}", soLuot);
            }

            series.IsValueShownAsLabel = true;
        }


        private void LoadChartDocGiaTre(List<BaoCaoViewModel> data)
        {
            var docGiaTre = data
                .Where(t => t.SoNgayQuaHan > 0)
                .GroupBy(t => t.TenDocGia)
                .Select(g => new
                {
                    TenDocGia = g.Key,
                    SoLanTre = g.Count(), 
                    TongSoNgayTre = g.Sum(t => t.SoNgayQuaHan) 
                })
                .OrderByDescending(x => x.TongSoNgayTre)
                .Take(10) 
                .ToList();


            dgvDocGiaTre.DataSource = docGiaTre;
            dgvDocGiaTre.Columns["TenDocGia"].HeaderText = "Tên Độc Giả";
            dgvDocGiaTre.Columns["SoLanTre"].HeaderText = "Số Lần Trễ";
            dgvDocGiaTre.Columns["TongSoNgayTre"].HeaderText = "Tổng Ngày Trễ";


            var series = chartDocGiaTre.Series["Series1"];
            series.ChartType = SeriesChartType.Bar; 
            series.Points.Clear();

 
            foreach (var item in docGiaTre.AsEnumerable().Reverse())
            {
                series.Points.AddXY(item.TenDocGia, item.TongSoNgayTre);
            }
            series.IsValueShownAsLabel = true;
        }


        private void LoadChartTheLoai(List<BaoCaoViewModel> data)
        {
            var tyLeTheLoai = data
                .GroupBy(t => t.TheLoaiSach)
                .Select(g => new
                {
                    TheLoai = Helper.GetEnumDescription(g.Key),
                    SoLuotMuon = g.Sum(t => t.SoLuong)
                })
                .ToList();

            var series = chartTheLoai.Series["Series1"];
            series.ChartType = SeriesChartType.Pie;
            series.Points.Clear();

            series["PieLabelStyle"] = "Outside"; 
            series["PieLineColor"] = "Black"; 
            series.Font = new Font("Arial", 10f, FontStyle.Bold);

            foreach (var item in tyLeTheLoai)
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