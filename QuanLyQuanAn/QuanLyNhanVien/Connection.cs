using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyQuanAn.Login
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-KF9F4CD\SQL;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
   
}
