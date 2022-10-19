using QuanLyQuanAn.DataTier.ViewModel;
using QuanLyQuanAn.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DataTier.Model;
using QuanLyQuanAn.QuanLyNhanVien;

namespace QuanLyQuanAn.BusinessTier
{
    internal class NhanVienBUS
    {
        private NhanVienDAL nhanVienDAL;

        public NhanVienBUS()
        {
            nhanVienDAL = new NhanVienDAL();
        }
        public IEnumerable<NhanVienViewModel> GetNhanViens()
        {
            return nhanVienDAL.GetNhanViens();
        }
        public bool ThemNhanVien(NHANVIEN nv)
        {
            try
            {
                return nhanVienDAL.ThemNhanVien(nv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatNhanVien(NHANVIEN nv)
        {
            try
            {
                return nhanVienDAL.CapNhatNhanVien(nv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaNhanVien(int maNhanVien)
        {
            try
            {
                return nhanVienDAL.XoaNhanVien(maNhanVien);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NhanVienViewModel> GetNhanVien(string tenNhanVien)
        {
            try
            {
                return nhanVienDAL.GetNhanVien(tenNhanVien); 
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public bool KiemTraNhanVien(string tenDangNhap, string matKhau, out NhanVienViewModel nv)
        {
            return nhanVienDAL.KiemTraDangNhap(tenDangNhap, matKhau, out nv);
        }
    }
}
