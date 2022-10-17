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

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormQuanLyNhanVien : Form
    {
        public FormQuanLyNhanVien()
        {
            InitializeComponent();
        }
        Modify modify;
        NhanVien nhanVien;       

        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dgvNhanVien.DataSource = modify.getAllnhanvien();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = this.txtTen.Text;
            string pass = this.txtMatKhau.Text;
            string user = this.txtTaiKhoan.Text;
            string sdt = this.txtSDT.Text;
            string sex = this.cbxGioiTinh.Text;
            string account = this.cbxQuyen.Text;
            nhanVien = new NhanVien(name, pass, user, sex, sdt, account);
            if (modify.insert(nhanVien))
            {
                dgvNhanVien.DataSource = modify.getAllnhanvien();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            string name = this.txtTen.Text;
            string pass = this.txtMatKhau.Text;
            string user = this.txtTaiKhoan.Text;
            string sdt = this.txtSDT.Text;
            string sex = this.cbxGioiTinh.Text;
            string account = this.cbxQuyen.Text;
            nhanVien = new NhanVien(name, pass, user, sex, sdt, account);
            if (modify.update(nhanVien, id))
            {
                dgvNhanVien.DataSource = modify.getAllnhanvien();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            if(modify.delete(id))
            {
                dgvNhanVien.DataSource = modify.getAllnhanvien();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongChon = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[dongChon].Cells[0].Value.ToString();
            txtTen.Text = dgvNhanVien.Rows[dongChon].Cells[1].Value.ToString();
            txtTaiKhoan.Text = dgvNhanVien.Rows[dongChon].Cells[4].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[dongChon].Cells[5].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[dongChon].Cells[3].Value.ToString();
            cbxGioiTinh.Text = dgvNhanVien.Rows[dongChon].Cells[2].Value.ToString();
            cbxQuyen.Text = dgvNhanVien.Rows[dongChon].Cells[6].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = txtMaNV.Text = "";
            cbxQuyen.Text = cbxGioiTinh.Text = "";
            txtSDT.Text = "";
            dgvNhanVien.DataSource = modify.getAllnhanvien();
            txtTen.Enabled = txtTaiKhoan.Enabled = txtMatKhau.Enabled = cbxGioiTinh.Enabled = cbxQuyen.Enabled = txtSDT.Enabled = true;
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            String sqlTimKiem = "Select * From NHANVIEN Where TEN LIKE N'%' + @TEN + '%'";
            SqlCommand command = new SqlCommand(sqlTimKiem, sqlConnection);
            sqlConnection.Open();
            command.Parameters.AddWithValue("TEN", txtTim.Text);
            command.ExecuteNonQuery();
            SqlDataReader dr = command.ExecuteReader();
            DataTable table = new DataTable(sqlTimKiem);
            table.Load(dr);
            dgvNhanVien.DataSource = table;
            sqlConnection.Close();
            if (table.Rows.Count > 0)
            {
                dgvNhanVien.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("Không có nhân viên tên này");
            }
        }
    }   
}
