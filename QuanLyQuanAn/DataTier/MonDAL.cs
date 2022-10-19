using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.DataTier.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DataTier
{
    internal class MonDAL
    {
        private Model1 quanlyquanan;
        public MonDAL()
        {
            quanlyquanan = new Model1();
        }
        public IEnumerable<MON> GetMonTheoMaDanhMuc(int maDanhMuc)
        {
            return quanlyquanan.MONs.Where(x => x.MADANHMUC == maDanhMuc).ToList();
        }
        public IEnumerable<MonAnViewModel> GetMons()
        {
            //var danhSachMon = 
            return    quanlyquanan.MONs.Select(x => new MonAnViewModel()
                                   {
                                       MaMon = x.MAMON,
                                       Ten = x.TEN,
                                       MaDanhMuc = x.MADANHMUC,
                                       Hinh = x.HINH,
                                       GiaTien = x.GIATIEN                                     
                                   }).ToList();
            //return danhSachMon;
        }
        public bool ThemMonAn(MON m)
        {
            try
            {
                MON mon = quanlyquanan.MONs.Where(x => x.TEN == m.TEN).FirstOrDefault();
                if (mon == null)
                {
                    quanlyquanan.MONs.Add(m);
                    quanlyquanan.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Món đã tồn tại");
                }
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
                MON mon = quanlyquanan.MONs.Where(x => x.MAMON == m.MAMON).FirstOrDefault();
                if (mon == null)
                {
                    throw new Exception("Nhân viên không tồn tại");
                }
                else
                {
                    mon.MAMON = m.MAMON;
                    mon.TEN = m.TEN;
                    mon.MADANHMUC = m.MADANHMUC;
                    mon.GIATIEN = m.GIATIEN;
                    mon.HINH = m.HINH;
                    quanlyquanan.SaveChanges();
                    return true;
                }
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
                var mon = quanlyquanan.MONs.Where(x => x.MAMON == maMon).FirstOrDefault();
                if (mon != null)
                {
                    quanlyquanan.MONs.Remove(mon);
                    quanlyquanan.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
