using QuanLyQuanAn.DataTier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DataTier
{
    internal class HoaDonDAL
    {
        private Model1 quanlyquanan;
        public HoaDonDAL()
        {
            quanlyquanan = new Model1();
        }
        public bool LuuHoaDon(HOADON hoaDon)
        {
            try
            {
                quanlyquanan.HOADONs.Add(hoaDon);
                quanlyquanan.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
