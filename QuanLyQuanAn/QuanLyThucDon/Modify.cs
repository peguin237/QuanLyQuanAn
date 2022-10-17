using QuanLyQuanAn.Login;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.QuanLyThucDon
{
    internal class Modify
    {
        SqlDataAdapter dataadapter;
        SqlCommand sqlCommand;
        public Modify()
        {

        }
        public DataTable getAllthucdon()
        {
            DataTable dt = new DataTable();
            string query = "select MAMON as [Mã Món], TEN as [Tên Món], MADANHMUC as [Mã Danh Mục], GIATIEN as [Giá Tiền] from MON";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataadapter = new SqlDataAdapter(query, sqlConnection);
                dataadapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public bool insert(ThucDon thucDon)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into MON values (@TEN,@MADANHMUC,@GIATIEN)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = thucDon.Ten;
                sqlCommand.Parameters.Add("@MADANHMUC", SqlDbType.Int).Value = thucDon.Madanhmuc;
                sqlCommand.Parameters.Add("@GIATIEN", SqlDbType.Float).Value = thucDon.Giatien;
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
        public bool update(ThucDon thucDon,string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update MON set TEN = @TEN, MADANHMUC = @MADANHMUC, GIATIEN = @GIATIEN WHERE MAMON = @MAMON";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MAMON", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = thucDon.Ten;
                sqlCommand.Parameters.Add("@MADANHMUC", SqlDbType.Int).Value = thucDon.Madanhmuc;
                sqlCommand.Parameters.Add("@GIATIEN", SqlDbType.Float).Value = thucDon.Giatien;
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
            string query = "delete MON WHERE MAMON = @MAMON";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MAMON", SqlDbType.Int).Value = id;
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
