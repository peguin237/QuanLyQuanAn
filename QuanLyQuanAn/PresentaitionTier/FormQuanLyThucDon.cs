using QuanLyQuanAn.Login;
using QuanLyQuanAn.QuanLyThucDon;
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
using System.IO;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormQuanLyThucDon : Form
    {
        public FormQuanLyThucDon()
        {
            InitializeComponent();
        }
        Modify modify;
        ThucDon thucDon;

        private void FormQuanLyThucDon_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dgvMonAn.DataSource = modify.getAllthucdon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {          
            string tenmon = this.txtTenMon.Text;
            string madanhmuc = this.cbxMaDanhMuc.Text;
            string giatien = this.txtGiaTien.Text;
            thucDon = new ThucDon(tenmon, madanhmuc, giatien);
            if (modify.insert(thucDon))
            {                
                dgvMonAn.DataSource = modify.getAllthucdon();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mamon = dgvMonAn.SelectedRows[0].Cells[0].Value.ToString();
            string tenmon = this.txtTenMon.Text;
            string madanhmuc = this.cbxMaDanhMuc.Text;
            string giatien = this.txtGiaTien.Text;
            thucDon = new ThucDon(tenmon, madanhmuc, giatien);
            if (modify.update(thucDon, mamon))
            {
                dgvMonAn.DataSource = modify.getAllthucdon();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mamon = dgvMonAn.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.delete(mamon))
            {
                dgvMonAn.DataSource = modify.getAllthucdon();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongChon = e.RowIndex;
            txtMaMon.Text = dgvMonAn.Rows[dongChon].Cells[0].Value.ToString();
            txtTenMon.Text = dgvMonAn.Rows[dongChon].Cells[1].Value.ToString();           
            cbxMaDanhMuc.Text = dgvMonAn.Rows[dongChon].Cells[2].Value.ToString();
            txtGiaTien.Text = dgvMonAn.Rows[dongChon].Cells[3].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenMon.Text = txtMaMon.Text = txtGiaTien.Text = "";
            cbxMaDanhMuc.Text = "";
            dgvMonAn.DataSource = modify.getAllthucdon();
            txtTenMon.Enabled = txtMaMon.Enabled = txtGiaTien.Enabled = cbxMaDanhMuc.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            String sqlTimKiem = "Select * From MON Where TEN LIKE N'%' + @TEN + '%'";
            SqlCommand command = new SqlCommand(sqlTimKiem, sqlConnection);
            sqlConnection.Open();
            command.Parameters.AddWithValue("TEN", txtTim.Text);
            command.ExecuteNonQuery();
            SqlDataReader dr = command.ExecuteReader();
            DataTable table = new DataTable(sqlTimKiem);
            table.Load(dr);
            dgvMonAn.DataSource = table;
            sqlConnection.Close();
            if (table.Rows.Count > 0)
            {
                dgvMonAn.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("Không có món tên này");
            }
        }
    }
}
