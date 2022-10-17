using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BusinessTier
{
    internal class DanhMucBUS
    {
        private DanhMucDAL danhMucDAL;
        public DanhMucBUS()
        {
            danhMucDAL = new DanhMucDAL();
        }
        public IEnumerable<DANHMUC> GetDanhMucs()
        {
            return danhMucDAL.GetDanhMucs();
        }
    }
}
