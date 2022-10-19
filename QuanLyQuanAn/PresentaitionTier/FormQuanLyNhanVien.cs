using QuanLyQuanAn.DataTier.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.DataTier.Model;
using System.Data.SqlClient;
using QuanLyQuanAn.Login;
using QuanLyQuanAn.BusinessTier;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormQuanLyNhanVien : Form
    {
        private readonly NhanVienBUS nhanVienBUS;
        private int maNhanVien = -1;
        public FormQuanLyNhanVien()
        {
            InitializeComponent();
            nhanVienBUS = new NhanVienBUS();
        }     

        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            dgvNhanVien.DataSource = nhanVienBUS.GetNhanViens();
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[1].Width = 170;
            dgvNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvNhanVien.Columns[3].HeaderText = "SĐT";
            dgvNhanVien.Columns[4].HeaderText = "Mật Khẩu";
            dgvNhanVien.Columns[5].HeaderText = "Tài Khoản";
            dgvNhanVien.Columns[6].HeaderText = "Quyền";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string thongBao = "";
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                thongBao += "\nPhải nhập họ tên";
            }
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                thongBao += "\nPhải nhập tài khoản";
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                thongBao += "\nPhải nhập mật khẩu";
            }
            if (string.IsNullOrWhiteSpace(cbxGioiTinh.Text))
            {
                thongBao += "\nPhải chọn giới tính";
            }
            if (string.IsNullOrWhiteSpace(cbxQuyen.Text))
            {
                thongBao += "\nPhải chọn quyền hạn";
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                thongBao += "\nPhải nhập SĐT";
            }
            if (thongBao != "")
            {
                MessageBox.Show(thongBao);
                return;
            }
            NHANVIEN nv = new NHANVIEN();
            nv.TEN = txtTen.Text;
            nv.TENDANGNHAP = txtTaiKhoan.Text;
            nv.GIOITINH = cbxGioiTinh.Text;
            nv.QUYEN = cbxQuyen.Text;
            nv.SDT = txtSDT.Text;
            nv.MATKHAU = txtMatKhau.Text;
            try
            {
                nhanVienBUS.ThemNhanVien(nv);
                LoadNhanVien();
                txtTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = cbxGioiTinh.Text = cbxQuyen.Text = txtSDT.Text = txtMatKhau.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();            
            nv.TEN = txtTen.Text;
            nv.TENDANGNHAP = txtTaiKhoan.Text;
            nv.GIOITINH = cbxGioiTinh.Text;
            nv.QUYEN = cbxQuyen.Text;
            nv.SDT = txtSDT.Text;
            nv.MATKHAU = txtMatKhau.Text;
            nv.MANV = maNhanVien;
            try
            {
                nhanVienBUS.CapNhatNhanVien(nv);
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = maNhanVien;
            try
            {
                nhanVienBUS.XoaNhanVien(maNhanVien);
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongChon = e.RowIndex;
            maNhanVien = Convert.ToInt32(dgvNhanVien.Rows[dongChon].Cells[0].Value.ToString());
            txtTen.Text = dgvNhanVien.Rows[dongChon].Cells[1].Value.ToString();
            txtTaiKhoan.Text = dgvNhanVien.Rows[dongChon].Cells[5].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[dongChon].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[dongChon].Cells[3].Value.ToString();
            cbxGioiTinh.Text = dgvNhanVien.Rows[dongChon].Cells[2].Value.ToString();
            cbxQuyen.Text = dgvNhanVien.Rows[dongChon].Cells[6].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            maNhanVien = -1;
            txtTaiKhoan.Text = txtTen.Text = txtMatKhau.Text = txtSDT.Text = cbxQuyen.Text = cbxGioiTinh.Text = "";
            LoadNhanVien();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtTim.Text;
            try
            {
                dgvNhanVien.DataSource = nhanVienBUS.GetNhanVien(tenNhanVien);
                dgvNhanVien.Rows[0].Selected = true;
            }
            catch
            {
                MessageBox.Show("Không tồn tại nhân viên này", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }   
}
