using QuanLyQuanAn.DataTier.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DataTier.Model;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanAn.DataTier
{
    internal class NhanVienDAL
    {
        private Model1 quanlyquanan;

        public NhanVienDAL()
        {
            quanlyquanan = new Model1();
        }
        //lay tat ca nhan vien
        public IEnumerable<NhanVienViewModel> GetNhanViens()
        {
            var danhSachNhanVien = quanlyquanan.NHANVIENs
                                   .Select(x => new NhanVienViewModel
                                   {
                                       Ma = x.MANV,
                                       Ten = x.TEN,
                                       GioiTinh = x.GIOITINH,
                                       SDT = x.SDT,
                                       MatKhau = x.MATKHAU,
                                       TenDangNhap = x.TENDANGNHAP,
                                       Quyen = x.QUYEN
                                   }).ToList();

            return danhSachNhanVien;
        }       
        public bool ThemNhanVien(NHANVIEN nv)
        {
            try
            {
                NHANVIEN nhanVien = quanlyquanan.NHANVIENs.Where(x => x.TENDANGNHAP == nv.TENDANGNHAP).FirstOrDefault();
                if (nhanVien == null)
                {
                    quanlyquanan.NHANVIENs.Add(nv);
                    quanlyquanan.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
                }
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
                NHANVIEN nhanVien = quanlyquanan.NHANVIENs.Where(x => x.MANV == nv.MANV).FirstOrDefault();
                if (nhanVien == null)
                {
                    throw new Exception("Nhân viên không tồn tại");
                }
                else
                {
                    nhanVien.MANV = nv.MANV;
                    nhanVien.TEN = nv.TEN;
                    nhanVien.GIOITINH = nv.GIOITINH;
                    nhanVien.SDT = nv.SDT;
                    nhanVien.TENDANGNHAP = nv.TENDANGNHAP;
                    nhanVien.QUYEN = nv.QUYEN; 
                    quanlyquanan.SaveChanges();
                    return true;
                }
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
                var nv = quanlyquanan.NHANVIENs.Where(x => x.MANV == maNhanVien).FirstOrDefault();
                if (nv != null)
                {
                    quanlyquanan.NHANVIENs.Remove(nv);
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

        //lay 1 nhan vien
        
        public IEnumerable<NhanVienViewModel> GetNhanVien(string tenNhanVien)
        {
            var nhanVien = quanlyquanan.NHANVIENs.Where(x => x.TEN == tenNhanVien ).FirstOrDefault();
            var Tim = quanlyquanan.NHANVIENs
                                   .Select(x => new NhanVienViewModel
                                   {
                                       Ma = nhanVien.MANV,
                                       Ten = nhanVien.TEN,
                                       GioiTinh = nhanVien.GIOITINH,
                                       SDT = nhanVien.SDT,
                                       MatKhau = nhanVien.MATKHAU,
                                       TenDangNhap = nhanVien.TENDANGNHAP,
                                       Quyen = nhanVien.QUYEN
                                   }).ToList();
            return Tim;         
        }
        //kiem tra dang nhap
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, out NhanVienViewModel nv)
        {
            var nhanVien = quanlyquanan.NHANVIENs
                .Where(x => x.TENDANGNHAP == tenDangNhap)
                .FirstOrDefault();

            nv = new NhanVienViewModel();

            if (nhanVien == null)
            { 
            MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Thông Báo", MessageBoxButtons.OK);
            return false;
            }
            else
            {
                nv.Ma = nhanVien.MANV;
                nv.Ten = nhanVien.TEN;
                nv.GioiTinh = nhanVien.GIOITINH;
                nv.SDT = nhanVien.SDT;
                nv.TenDangNhap = nhanVien.TENDANGNHAP;
                nv.Quyen = nhanVien.QUYEN;
                return true;
            }
        }
    }
}
