using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyQuanAn.Login;
using System.Windows.Forms;
using QuanLyQuanAn.QuanLyThucDon;
using System.Xml.Linq;

namespace QuanLyQuanAn.QuanLyNhanVien
{
    class Modify
    {
        SqlDataAdapter dataadapter;
        SqlCommand sqlCommand;
        public Modify()
        {

        }
        public DataTable getAllnhanvien()
        {
            DataTable dt = new DataTable();
            string query = "select MANV as [Mã NV], TEN as [Tên NV], GIOITINH as [Giới Tính],SDT as [SĐT],TENDANGNHAP as [Tài Khoản],MATKHAU as [Mật Khẩu],    QUYEN as [Quyền] from NHANVIEN";
            using (SqlConnection sqlConnection = Connection.GetConnection()) 
            {
                sqlConnection.Open();
                dataadapter = new SqlDataAdapter(query, sqlConnection);
                dataadapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public bool insert(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into NHANVIEN values (@TEN,@GIOITINH,@SDT,@MATKHAU,@TENDANGNHAP,@QUYEN)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = nhanVien.Name;
                sqlCommand.Parameters.Add("@TENDANGNHAP", SqlDbType.VarChar).Value = nhanVien.User;
                sqlCommand.Parameters.Add("@MATKHAU", SqlDbType.VarChar).Value = nhanVien.Pass;       
                sqlCommand.Parameters.Add("@SDT", SqlDbType.Int).Value = nhanVien.Sdt;
                sqlCommand.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = nhanVien.Sex;
                sqlCommand.Parameters.Add("@QUYEN", SqlDbType.NVarChar).Value = nhanVien.Account;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool update(NhanVien nhanVien,string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update NHANVIEN set TEN = @TEN, GIOITINH = @GIOITINH, SDT = @SDT, MATKHAU = @MATKHAU, TENDANGNHAP = @TENDANGNHAP, QUYEN = @QUYEN WHERE MANV = @MANV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MANV", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = nhanVien.Name;
                sqlCommand.Parameters.Add("@TENDANGNHAP", SqlDbType.VarChar).Value = nhanVien.User;
                sqlCommand.Parameters.Add("@MATKHAU", SqlDbType.VarChar).Value = nhanVien.Pass;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.Int).Value = nhanVien.Sdt;
                sqlCommand.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = nhanVien.Sex;
                sqlCommand.Parameters.Add("@QUYEN", SqlDbType.NVarChar).Value = nhanVien.Account;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool delete(string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "delete NHANVIEN WHERE MANV = @MANV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MANV", SqlDbType.Int).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }       
    }
}
