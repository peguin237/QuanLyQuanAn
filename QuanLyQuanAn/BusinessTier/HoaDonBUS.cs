using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BusinessTier
{
    internal class HoaDonBUS
    {
        private HoaDonDAL hoaDonDAL;
        public HoaDonBUS()
        {
            hoaDonDAL = new HoaDonDAL();
        }
        public bool LuuHoaDon(HOADON hoaDon)
        {
            try
            {
                return hoaDonDAL.LuuHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
