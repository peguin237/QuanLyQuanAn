using QuanLyQuanAn.DataTier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BusinessTier
{
    internal class BanBUS
    {
        private BanDAL banDAL;
        public BanBUS()
        {
            banDAL = new BanDAL();
        }
        public IEnumerable<BAN> GetBans()
        {
            return banDAL.GetBans();
        }
    }
}
