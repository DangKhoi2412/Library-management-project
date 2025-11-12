using QuanLiThuVien.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class fmain : Form
    {
        public fmain()
        {
            InitializeComponent();
            DataManager dataManager = DataManager.Instance;
        }

        private void mnuQLS_DanhSachSach_Click(object sender, EventArgs e)
        {
            fQuanLiSach fqs = new fQuanLiSach();
            fqs.ShowDialog();
        }

        private void mnuQLS_ThemSachMoi_Click(object sender, EventArgs e)
        {
            fQuanLiSach fqs = new fQuanLiSach();
            fqs.ShowDialog();

        }


        private void mnuMTS_TaoPhieuMuon_Click(object sender, EventArgs e)
        {
            fMuonTraSach fMuonTraSach = new fMuonTraSach();
            fMuonTraSach.ChonTabPhieuMuon();
            fMuonTraSach.ShowDialog();
        }

        private void mnuMTS_TraSach_Click(object sender, EventArgs e)
        {
            fMuonTraSach fMuonTraSach = new fMuonTraSach();
            fMuonTraSach.ChonTabTraSach();
            fMuonTraSach.ShowDialog();
        }
        private void mnuBC_SachDangMuon_Click(object sender, EventArgs e)
        {
            fBaoCao fBaoCao = new fBaoCao();
            fBaoCao.ChonTabSachDangMuon();
            fBaoCao.ShowDialog();
        }

        private void mnuBC_SachQuaHan_Click(object sender, EventArgs e)
        {
            fBaoCao fBaoCao = new fBaoCao();
            fBaoCao.ChonTabSachQuaHan();
            fBaoCao.ShowDialog();
        }

        private void mnuQuanLiSach_Click(object sender, EventArgs e)
        {
            fQuanLiSach fQuanLiSach = new fQuanLiSach();
            fQuanLiSach.ShowDialog();
        }

        private void mnuQuanLyDocGia_Click(object sender, EventArgs e)
        {
            fQuanLiDocGia fQuanLiDocGia = new fQuanLiDocGia();
            fQuanLiDocGia.ShowDialog();
        }

        private void mnuMuonTraSach_Click(object sender, EventArgs e)
        {

        }

        private void fmain_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void mnuDuLieu_Click(object sender, EventArgs e)
        {
            fThongKe fThongKe = new fThongKe();
            fThongKe.ShowDialog();
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {
            fBaoCao fBaoCao = new fBaoCao();
            fBaoCao.ShowDialog();
        }

        private void mnuTroGiup_Click(object sender, EventArgs e)
        {
            fGioiThieu fGioiThieu = new fGioiThieu();
            fGioiThieu.ShowDialog();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
