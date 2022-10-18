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
using QuanLyQuanAn.PresentaitionTier;


namespace QuanLyQuanAn
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
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
            SqlConnection sqlConnection = Connection.GetConnection();
            try
            {               
                sqlConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN where TENDANGNHAP= '"+txtTaiKhoan.Text+"' and MATKHAU= '"+txtMatKhau.Text+"'", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);
                    FormTong f = new FormTong(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                    f.Show();
                    this.Hide();
                    this.Reset();
                    f.DangXuat += F_DangXuat;
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            finally
            {
                sqlConnection.Close();
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
