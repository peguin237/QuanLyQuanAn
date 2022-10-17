using QuanLyQuanAn.DataTier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DataTier
{
    internal class DanhMucDAL
    {
        private Model1 quanlyquanan;
        public DanhMucDAL()
        {
            quanlyquanan = new Model1();
        }
        public IEnumerable<DANHMUC> GetDanhMucs()
        {
            return quanlyquanan.DANHMUCs.ToList();
        }
    }
}
