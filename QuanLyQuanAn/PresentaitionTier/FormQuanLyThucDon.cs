using QuanLyQuanAn.Login;
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
using QuanLyQuanAn.BusinessTier;
using QuanLyQuanAn.DataTier.Model;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormQuanLyThucDon : Form
    {
        private readonly DanhMucBUS danhMucBUS;
        private readonly MonBUS monBUS;
        private int maMon = -1;
        public FormQuanLyThucDon()
        {
            InitializeComponent();
            danhMucBUS = new DanhMucBUS();
            monBUS = new MonBUS();
            this.Load += FormQuanLyThucDon_Load;
        }
        private void FormQuanLyThucDon_Load(object sender, EventArgs e)
        {
            LoadMonAn();
            CaiDatDieuKhien();
            LoadDanhMuc();
        }
        private void LoadDanhMuc()
        {
            cbxMaDanhMuc.DataSource = danhMucBUS.GetDanhMucs();

        }
        private void CaiDatDieuKhien()
        {
            cbxMaDanhMuc.DisplayMember = "MaDanhMuc";
            cbxMaDanhMuc.ValueMember = "MaDanhMuc";
        }
        private void LoadMonAn()
        {          
            int rowAdd;
            foreach (var item in monBUS.GetMons())
            {
                rowAdd = dgvMonAn.Rows.Add();
                dgvMonAn.Rows[rowAdd].Cells[0].Value = item.MaMon;
                dgvMonAn.Rows[rowAdd].Cells[1].Value = item.Ten;
                dgvMonAn.Rows[rowAdd].Cells[2].Value = item.GiaTien;
                dgvMonAn.Rows[rowAdd].Cells[3].Value = item.MaDanhMuc;
                string duongDanHinh = @"../.." + item.Hinh;
                Image img;
                if (File.Exists(duongDanHinh))
                    img = Image.FromFile(duongDanHinh);
                else
                    img = Image.FromFile(@"../../Hinh/7up.jpg");
                dgvMonAn.Rows[rowAdd].Cells[4].Value = img;
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thongBao = "";
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                thongBao += "\nPhải nhập tên món";
            }
            if (string.IsNullOrWhiteSpace(cbxMaDanhMuc.Text))
            {
                thongBao += "\nPhải chọn mã danh mục";
            }
            if (string.IsNullOrWhiteSpace(txtGiaTien.Text))
            {
                thongBao += "\nPhải nhập giá tiền";
            }

            if (thongBao != "")
            {
                MessageBox.Show(thongBao);
                return;
            }
            MON m = new MON();
            m.TEN = txtTenMon.Text;
            m.GIATIEN = Convert.ToDouble(txtGiaTien.Text);
            m.MADANHMUC = Convert.ToInt32(cbxMaDanhMuc.Text);

            int pos = txtFilePath.Text.LastIndexOf("\\") + 1;
            string tenHinh = txtFilePath.Text.Substring(pos, txtFilePath.Text.Length - pos);
            try
            {
                LuuHinhAnh(txtFilePath.Text, tenHinh);
                m.HINH = "//Hinh//" + tenHinh;
                monBUS.ThemMonAn(m);
                LoadMonAn();
                txtTenMon.Text = cbxMaDanhMuc.Text = txtGiaTien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MON m = new MON();
            m.TEN = txtTenMon.Text;
            m.MADANHMUC = Convert.ToInt32(cbxMaDanhMuc.Text);
            m.GIATIEN = Convert.ToDouble(txtGiaTien.Text); 
            m.MAMON = maMon;
            try
            {
                monBUS.CapNhatMonAn(m);
                LoadMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MON m = new MON();
            m.MAMON = maMon;
            try
            {
                monBUS.XoaMonAn(maMon);
                LoadMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongChon = e.RowIndex;
            maMon = Convert.ToInt32(dgvMonAn.Rows[dongChon].Cells[0].Value.ToString());
            txtTenMon.Text = dgvMonAn.Rows[dongChon].Cells[1].Value.ToString();           
            cbxMaDanhMuc.Text = dgvMonAn.Rows[dongChon].Cells[3].Value.ToString();
            txtGiaTien.Text = dgvMonAn.Rows[dongChon].Cells[2].Value.ToString();
            txtFilePath.Text = dgvMonAn.Rows[dongChon].Cells[4].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            maMon = -1;
            txtTenMon.Text = txtGiaTien.Text = cbxMaDanhMuc.Text = "";
            LoadMonAn();
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

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "JPG",
                Filter = "Image files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }
        private bool LuuHinhAnh(string duongDanHinh, string tenHinh)
        {
            try
            {
                Bitmap b = new Bitmap(duongDanHinh);
                if (File.Exists("../../Hinh/" + tenHinh))
                {
                    var randIndex = new Random();

                    tenHinh = randIndex.Next(0, 1000) + tenHinh;
                }
                b.Save("../../Hinh/" + tenHinh);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
