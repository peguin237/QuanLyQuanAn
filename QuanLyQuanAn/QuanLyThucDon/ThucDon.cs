using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.QuanLyThucDon
{
    internal class ThucDon
    {
        private string ten;
        private string madanhmuc;
        private string giatien;


        public ThucDon()
        {

        }

        public ThucDon(string ten, string madanhmuc, string giatien)
        {
            Ten = ten;
            Madanhmuc = madanhmuc;
            Giatien = giatien;
        }

        public string Ten { get => ten; set => ten = value; }
        public string Madanhmuc { get => madanhmuc; set => madanhmuc = value; }
        public string Giatien { get => giatien; set => giatien = value; }
    }
}
