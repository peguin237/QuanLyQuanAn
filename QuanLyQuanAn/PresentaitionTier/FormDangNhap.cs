using QuanLyQuanAn.QuanLyNhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyQuanAn.Login;
using QuanLyQuanAn.BusinessTier;
using QuanLyQuanAn.DataTier.ViewModel;
using QuanLyQuanAn.PresentaitionTier;

namespace QuanLyQuanAn
{
    public partial class FormDangNhap : Form
    {
        private NhanVienBUS nhanVienBUS;
        public FormDangNhap()
        {
            InitializeComponent();
            nhanVienBUS = new NhanVienBUS();
        }
        private void Reset()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";         
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            NhanVienViewModel nv;
            if (nhanVienBUS.KiemTraNhanVien(txtTaiKhoan.Text, txtMatKhau.Text, out nv))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);
                FormTong f = new FormTong(nv);
                f.Show();
                this.Hide();
                this.Reset();
                f.DangXuat += F_DangXuat;
            }
        }
        private void F_DangXuat(object sender, EventArgs e)
        {
            (sender as FormTong).isThoat = false;
            (sender as FormTong).Close();
            this.Show();
        }

        private void ckbAnHien_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = (ckbAnHien.Checked) ? '\0' : '*';
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
    }
}
