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
using QuanLyQuanAn.Login;
using QuanLyQuanAn.QuanLyThucDon;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormTong : Form
    {
        string MANV = "", TEN = "", MATKHAU = "", TENDANGNHAP = "", GIOITINH = "", SDT = "", QUYEN = "";
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
            if (QUYEN == "Admin")
            {
                FormQuanLyNhanVien f = new FormQuanLyNhanVien();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không quyền làm hành động này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            if (QUYEN == "Admin")
            {
                FormDoanhThu f = new FormDoanhThu();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không quyền làm hành động này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (QUYEN == "Admin")
            {
                FormBaoCao f = new FormBaoCao();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không quyền làm hành động này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            
            FormQuanLyThucDon f = new FormQuanLyThucDon();
            f.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string id = MANV;
            SqlConnection sqlConnection = Connection.GetConnection();
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN where MANV = " + id + "", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            FormChinh f = new FormChinh(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
            f.ShowDialog();
        }

        private void FormTong_Load(object sender, EventArgs e)
        {
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

        public FormTong(string MANV, string TEN, string MATKHAU, string TENDANGNHAP, string GIOITINH, string SDT, string QUYEN)
        {
            InitializeComponent();
            this.MANV = MANV;
            this.TEN = TEN;
            this.MATKHAU = MATKHAU;
            this.TENDANGNHAP = TENDANGNHAP;
            this.GIOITINH = GIOITINH;
            this.SDT = SDT;
            this.QUYEN = QUYEN;           
        }
        public event EventHandler DangXuat;

    }
}
