using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.DataTier.ViewModel;
using QuanLyQuanAn.Login;
using QuanLyQuanAn.QuanLyThucDon;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormTong : Form
    {
        private NhanVienViewModel nhanVienBanHang;
        public FormTong(NhanVienViewModel nv)
        {
            InitializeComponent();
            nhanVienBanHang = nv;
        }
        private void FormTong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThoat)
            {
                if (MessageBox.Show("Bạn muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVienBanHang.Quyen == "Admin")
            { 
            FormQuanLyNhanVien f = new FormQuanLyNhanVien();
            f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện hành động này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            if (nhanVienBanHang.Quyen == "Admin")
            {
                FormDoanhThu f = new FormDoanhThu();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện hành động này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormBaoCao f = new FormBaoCao();
            f.ShowDialog();
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {            
            FormQuanLyThucDon f = new FormQuanLyThucDon();
            f.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FormChinh f = new FormChinh(nhanVienBanHang);
            f.Show();
        }

        private void FormTong_Load(object sender, EventArgs e)
        {
            txtMa.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtTen.Text = nhanVienBanHang.Ten;
            txtMa.Text = nhanVienBanHang.Ma.ToString();
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoTro f = new FormHoTro();
            f.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        public bool isThoat = true;
        private void FormTong_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }
        public event EventHandler DangXuat;

    }
}
