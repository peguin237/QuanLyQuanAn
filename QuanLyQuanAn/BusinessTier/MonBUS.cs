using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DataTier.ViewModel;

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
        public IEnumerable<MonAnViewModel> GetMons()
        {
            return monDAL.GetMons();
        }
        public bool ThemMonAn(MON m)
        {
            try
            {
                return monDAL.ThemMonAn(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatMonAn(MON m)
        {
            try
            {
                return monDAL.CapNhatMonAn(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaMonAn(int maMon)
        {
            try
            {
                return monDAL.XoaMonAn(maMon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
