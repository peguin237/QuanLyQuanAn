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
using System.Configuration;
using QuanLyQuanAn.Login;

namespace QuanLyQuanAn.PresentaitionTier
{
    public partial class FormDoanhThu : Form
    {

        public FormDoanhThu()
        {
            InitializeComponent();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string sql = @"
            SELECT	N.MANV as [Mã NV],N.TEN as [Tên NV],SUM(H.TONGTIEN) AS [Tổng Tiền]
            FROM NHANVIEN AS N, HOADON AS H
            WHERE DATEDIFF(DAY, H.NGAY, @TuNgay) <= 0 AND DATEDIFF(DAY, H.NGAY, @DenNgay) >= 0 AND N.MANV = H.MANV
			GROUP BY N.MANV, N.TEN 
            ";
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            command.Parameters.AddWithValue("TuNgay", dtpFrom.Value);
            command.Parameters.AddWithValue("DenNgay", dtpTo.Value);
            command.ExecuteNonQuery();
            SqlDataReader dr = command.ExecuteReader();
            DataTable table = new DataTable(sql);
            table.Load(dr);
            dgvThongKe.DataSource = table;
            sqlConnection.Close();
        }
    }
}
