using QuanLyQuanAn.BusinessTier;
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
using System.IO;

namespace QuanLyQuanAn.PresentaitionTier
{
    public delegate void UyQuyenChonMon(MON mon, int maSoBan, int SoLuong);
    public partial class FormChonMon : Form
    {
        public event UyQuyenChonMon UyQuyenChonMon;

        private readonly DanhMucBUS danhMucBUS;
        private readonly MonBUS monBUS;
        System.Globalization.CultureInfo fVND = new System.Globalization.CultureInfo("vi-VN");

        private int maSoBanChon;
        
        public FormChonMon(int maSoBan)
        {
            InitializeComponent();
            this.maSoBanChon = maSoBan;

            this.StartPosition = FormStartPosition.CenterScreen;
            danhMucBUS = new DanhMucBUS();
            monBUS = new MonBUS();
        }
        private void CaiDatDieuKhien()
        {
            cbxDanhMuc.DisplayMember = "Ten";
            cbxDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadDanhMuc()
        {
            cbxDanhMuc.DataSource = danhMucBUS.GetDanhMucs();
        }

        private void FormChonMon_Load(object sender, EventArgs e)
        {
            CaiDatDieuKhien();
            LoadDanhMuc();
        }

        private void cbxDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMonAn.Controls.Clear();
            int maDanhMuc = Convert.ToInt32(cbxDanhMuc.SelectedValue);
            LoadMonAn(maDanhMuc);
        }
        private void LoadMonAn(int maDanhMuc)
        {
            int x = 26;
            int y = 29;
            int count = 0;
            foreach (var mon in monBUS.GetMonTheoDanhMuc(maDanhMuc))
            {
                TaoBan(x, y, mon);
                count++;
                if (count % 5 == 0)
                {
                    y += 110;
                    x = 26;
                    continue;
                }
                x += 110;
            }
        }
        private void TaoBan(int x, int y, MON mon)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = new Size(100, 80);
            btn.Text = mon.TEN + "\n" + String.Format(fVND, "{0:C0}", mon.GIATIEN);
            btn.TextAlign = ContentAlignment.BottomCenter;
            string duongDanHinh = "../.." + mon.HINH;
            if (File.Exists(duongDanHinh))
                btn.Image = Image.FromFile(duongDanHinh);
            else
                btn.Image = Image.FromFile("../../Resources/food_cafe_hot_soup_restaurant_icon_226128.ico");
            btn.ImageAlign = ContentAlignment.TopCenter;

            btn.Tag = mon;

            btn.BackColor = Color.White;

            btn.Click += Btn_Click;

            pnlMonAn.Controls.Add(btn);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MON m = button.Tag as MON;
            int soLuong = Convert.ToInt32(NupSoLuong.Value);
            if (NupSoLuong.Value == 0)
                MessageBox.Show("Phải chọn số lượng món ăn", "Thông báo", MessageBoxButtons.OK);
            else
                UyQuyenChonMon(m, maSoBanChon, soLuong);
        }
    }
}
