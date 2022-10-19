using QuanLyQuanAn.DataTier.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.BusinessTier;
using QuanLyQuanAn.DataTier;
using QuanLyQuanAn.Properties;
using QuanLyQuanAn.PresentaitionTier;
using QuanLyQuanAn.QuanLyNhanVien;
using QuanLyQuanAn.DataTier.ViewModel;

namespace QuanLyQuanAn
{
    public partial class FormChinh : Form
    {
        private const int W = 60;
        private const int H = 60;
        private const int DISTANCE = 100;
        private const int COL = 5;
        private double tongTien = 0;
        private Button banChon = null;
        private List<ThongTinDatBan> Danhsach = new List<ThongTinDatBan>();

        private DanhMucBUS danhMucBUS;
        private MonBUS monBUS;
        private BanBUS banBUS;
        private HoaDonBUS hoaDonBUS;
        public bool isThoat = true;
        System.Globalization.CultureInfo fVND = new System.Globalization.CultureInfo("vi-VN");
        NhanVienViewModel nhanVienBanHang;
        public FormChinh(NhanVienViewModel nv)
        {
            InitializeComponent();
            nupGiamGia.TextChanged += NupGiamGia_TextChanged;
            monBUS = new MonBUS();
            danhMucBUS = new DanhMucBUS();
            banBUS = new BanBUS();
            hoaDonBUS = new HoaDonBUS();
            nhanVienBanHang = nv;
            CaiDatDieuKhien();
        }
        private void FormChinh_Load(object sender, EventArgs e)
        {
            KhoiTaoSoLuongBan();
            LoadDanhMuc();
            LoadDanhSachBan();
            WindowState = FormWindowState.Maximized;
        }
        private void KhoiTaoSoLuongBan()
        {
            int x = 27, y = 29, i = 0;
            foreach (BAN ban in banBUS.GetBans())
            {
                TaoBan(x, y, ban);
                i++;
                if (i % COL == 0)
                {
                    y += DISTANCE;
                    x = 27;
                    continue;
                }
                x += DISTANCE;
            }
        }
        private void TaoBan(int x, int y, BAN ban)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Text = ban.TEN;
            btn.Tag = ban.MABAN;
            btn.Size = new Size(W, H);
            btn.BackColor = Color.White;
            btn.Click += Btn_Click;
            pnlBan.Controls.Add(btn);
        }
        private void LoadDanhMuc()
        {
            cbxDanhMuc.DataSource = danhMucBUS.GetDanhMucs();
        }
        private void CaiDatDieuKhien()
        {
            cbxDanhMuc.DisplayMember = "Ten";
            cbxDanhMuc.ValueMember = "MaDanhMuc";
            cbxMon.DisplayMember = "Ten";
            cbxMon.ValueMember = "MaMon";
            cbxBan.DisplayMember = "Ten";
            cbxBan.ValueMember = "MaBan";
        }
        private void NupGiamGia_TextChanged(object sender, EventArgs e)
        {
            double soTienGiam = (double)(nupGiamGia.Value / 100) * tongTien;
            txtTongTien.Text = String.Format(fVND, "{0:C0}", (tongTien - soTienGiam));
        }
        private void LoadDanhSachBan()
        {
            cbxBan.DataSource = banBUS.GetBans();
        }
        private void cbxDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            int maDanhMuc = int.Parse(cbx.SelectedValue.ToString());
            cbxMon.DataSource = monBUS.GetMonTheoDanhMuc(maDanhMuc);
        }
        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int maSoBanChuyen, maSoBanDich;
            Button bandich = null;
            if (banChon == null)
            {
                MessageBox.Show("Mời chọn bàn cần chuyển!!");
                return;
            }
            maSoBanChuyen = int.Parse(banChon.Tag.ToString());
            ThongTinDatBan thongTinDatBanChuyen = Danhsach.Where(x => x.MaBan == maSoBanChuyen).FirstOrDefault();
            if (thongTinDatBanChuyen == null)
            {
                MessageBox.Show("Không thể chuyển bàn trống!!");
                return;
            }
            maSoBanDich = int.Parse(cbxBan.SelectedValue.ToString());
            if (maSoBanChuyen == maSoBanDich)
            {
                MessageBox.Show("Bàn chuyển và bàn đích phải khác nhau!!");
                return;
            }
            bandich = pnlBan.Controls.OfType<Button>().Where(x => x.Tag.ToString() == maSoBanDich.ToString()).FirstOrDefault();
            bandich.Image = Image.FromFile("../../Resources/table_icon_131703.ico");
            ThongTinDatBan thongTinDatBanDich = Danhsach.Where(x => x.MaBan == maSoBanDich).FirstOrDefault();
            if (thongTinDatBanDich == null)
            {
                thongTinDatBanChuyen.MaBan = maSoBanDich;
                pnlBan.Controls.OfType<Button>().Where(x => x.Tag.ToString() == maSoBanDich.ToString()).FirstOrDefault().Image = Image.FromFile("../../Resources/table_icon_131703.ico");
            }
            else
            {
                foreach (MonDat item in thongTinDatBanChuyen.DanhSachMon)
                {
                    thongTinDatBanDich.CapNhatMon(item);
                }
                HienThiDanhSachMon(thongTinDatBanDich.DanhSachMon);
                Danhsach.Remove(thongTinDatBanChuyen);
            }
            banChon.Image = null;
            banChon.BackColor = Color.White;
            banChon = bandich;
            banChon.BackColor = Color.LightCoral;
        }
        public void HienThiDanhSachMon(List<MonDat> danhSach)
        {
            dgvDanhSachMon.Rows.Clear();
            foreach (MonDat mon in danhSach)
            {
                int rows = dgvDanhSachMon.Rows.Add(mon);
                dgvDanhSachMon.Rows[rows].Cells[0].Value = mon.TenMon;
                dgvDanhSachMon.Rows[rows].Cells[1].Value = mon.SoLuong;
                dgvDanhSachMon.Rows[rows].Cells[2].Value = mon.DonGia;
                dgvDanhSachMon.Rows[rows].Cells[3].Value = mon.ThanhTien;
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (banChon == null)
            {
                MessageBox.Show("Vui long chon ban");
                return;
            }

            if (nupSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui long chon so luong");
                return;
            }
            //Kiem tra ban da co trong danh sach dat ban chua
            int MaSoBan = int.Parse(banChon.Tag.ToString());
            ThongTinDatBan thongTin = Danhsach.Where(x => x.MaBan == MaSoBan).FirstOrDefault();
            if (thongTin == null)
            {
                thongTin = new ThongTinDatBan();
                thongTin.MaBan = MaSoBan;
                banChon.Image = Image.FromFile("../../Resources/food_cafe_hot_soup_restaurant_icon_226128.ico");
                Danhsach.Add(thongTin);
            }
            MonDat mon = new MonDat();
            MON m = (MON)cbxMon.SelectedItem;
            mon.SoLuong = int.Parse(nupSoLuong.Value.ToString());
            mon.TenMon = cbxMon.Text;
            mon.DonGia = (double)m.GIATIEN;
            mon.MaMon = m.MAMON;          
            thongTin.CapNhatMon(mon);
            HienThiDanhSachMon(thongTin.DanhSachMon);
            tongTien = thongTin.DanhSachMon.Sum(x => x.ThanhTien);
            txtTongTien.Text = String.Format(fVND, "{0:C0}", (tongTien));
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (banChon == null)
            {
                banChon = btn;
                banChon.BackColor = Color.LightCoral;               
            }
            else if (banChon == btn)
            {

                banChon.BackColor = Color.White;
                banChon = null;
                dgvDanhSachMon.Rows.Clear();
                tongTien = 0;
                txtTongTien.Clear();
                return;
            }
            else
            {
                banChon.BackColor = Color.White;
                banChon = btn;
                banChon.BackColor = Color.LightCoral;
            }
            int maSoBanChon = int.Parse(banChon.Tag.ToString());
            //Kiem tra xem BAN CO TRONG DS HAY CHUA 
            ThongTinDatBan thongTin = Danhsach.Where(x => x.MaBan == maSoBanChon).FirstOrDefault();
            if (thongTin != null)
            {
                HienThiDanhSachMon(thongTin.DanhSachMon);
                tongTien = thongTin.DanhSachMon.Sum(x => x.ThanhTien);
                txtTongTien.Text = String.Format(fVND, "{0:C0}", (tongTien));
            }
            else
            {
                dgvDanhSachMon.Rows.Clear();
                tongTien = 0;
                txtTongTien.Clear();
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (banChon == null)
            {
                MessageBox.Show("vui long chon ban");
                return;
            }
            int maSoBanChon = Convert.ToInt32(banChon.Tag);
            ThongTinDatBan thongTinDatBan = Danhsach.Where(x => x.MaBan == maSoBanChon).FirstOrDefault();
            if (thongTinDatBan == null)
            {
                MessageBox.Show("BÀN CHƯA ĐƯỢC ĐẶT MÓN NÀO");
                return;
            }
            HOADON hoaDon = new HOADON();
            hoaDon.TONGTIEN = tongTien;
            hoaDon.MABAN = int.Parse(banChon.Tag.ToString());
            hoaDon.GIAMGIA = (double)nupGiamGia.Value;
            hoaDon.NGAY = DateTime.Now;
            hoaDon.MANV = nhanVienBanHang.Ma;
            CHITIETHOADON chiTiet;
            foreach (var item in thongTinDatBan.DanhSachMon)
            {
                chiTiet = new CHITIETHOADON();
                chiTiet.SOLUONG = item.SoLuong;
                txtTongTien.Clear();
                chiTiet.MAMON = item.MaMon;
                hoaDon.CHITIETHOADONs.Add(chiTiet);
            }
            try
            {
                hoaDonBUS.LuuHoaDon(hoaDon);
                banChon.Image = null;
                dgvDanhSachMon.Rows.Clear();
                txtTongTien.Text = "";
                nupGiamGia.ResetText();
                Danhsach.Remove(thongTinDatBan);
                MessageBox.Show("LƯU HÓA ĐƠN THÀNH CÔNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemMonGiaoDien_Click(object sender, EventArgs e)
        {
            if (banChon == null)
            {
                MessageBox.Show("vui long chon ban");
                return;
            }
            int maSoBan = Convert.ToInt32(banChon.Tag);
            FormChonMon f = new FormChonMon(maSoBan);
            f.UyQuyenChonMon += Frm_UyQuyenChonMon;
            f.ShowDialog();
        }
        private void Frm_UyQuyenChonMon(MON mon, int maSoban, int soLuong)
        {
            //mon 
            ThongTinDatBan thongTinDatBan = Danhsach
                .Where(x => x.MaBan == maSoban)
                .FirstOrDefault();

            // TRƯỜNG HỢP BÀN CHƯA ĐẶT
            if (thongTinDatBan == null)
            {
                thongTinDatBan = new ThongTinDatBan();
                thongTinDatBan.MaBan = maSoban;
                Danhsach.Add(thongTinDatBan);
                // thay hình button 
                banChon.Image =Image.FromFile("../../Resources/food_cafe_hot_soup_restaurant_icon_226128.ico");
            }
            // Thêm món vào bàn
            MON monChon = mon;
            MonDat monMoi = new MonDat()
            {
                MaMon = monChon.MAMON,
                TenMon = monChon.TEN,
                DonGia = (double)monChon.GIATIEN,
                SoLuong = soLuong
            };
            thongTinDatBan.CapNhatMon(monMoi);

            tongTien = thongTinDatBan.DanhSachMon.Sum(x => x.ThanhTien);
            txtTongTien.Text = String.Format(fVND, "{0:C0}", tongTien);

            HienThiDanhSachMon(thongTinDatBan.DanhSachMon);
        }
    }
}
