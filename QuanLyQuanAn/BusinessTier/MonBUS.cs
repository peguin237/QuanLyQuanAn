using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BusinessTier
{
    internal class MonBUS
    {
        private MonDAL monDAL;
        public MonBUS()
        {
            monDAL = new MonDAL();
        }
        public IEnumerable<MON> GetMonTheoDanhMuc(int maDanhMuc)
        {
            return monDAL.GetMonTheoMaDanhMuc(maDanhMuc);
        }
    }
}
