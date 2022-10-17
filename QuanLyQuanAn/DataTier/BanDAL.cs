using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DataTier.Model
{
    internal class BanDAL
    {
        private Model1 quanlyquanan;
        public BanDAL()
        {
            quanlyquanan = new Model1();
        }
        public IEnumerable<BAN> GetBans()
        {
            return quanlyquanan.BANs.ToList();
        }
    }
}
