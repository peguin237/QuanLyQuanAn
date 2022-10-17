using QuanLyQuanAn.DataTier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DataTier
{
    internal class MonDAL
    {
        private Model1 quanlyquannan;
        public MonDAL()
        {
            quanlyquannan = new Model1();
        }
        public IEnumerable<MON> GetMonTheoMaDanhMuc(int maDanhMuc)
        {
            return quanlyquannan.MONs.Where(x => x.MADANHMUC == maDanhMuc).ToList();
        }
    }
}
