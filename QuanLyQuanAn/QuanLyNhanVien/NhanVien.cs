using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.QuanLyNhanVien
{
    class NhanVien
    {
        private string _name;
        private string _pass;
        private string _user;
        private string _sex;
        private string _sdt;
        private string _account;

        public NhanVien()
        {

        }

        public NhanVien(string name, string pass, string user, string sex, string sdt, string account)
        {
            Name = name;
            Pass = pass;
            User = user;
            Sex = sex;
            Sdt = sdt;
            Account = account;
        }
        public string Name { get => _name; set => _name = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string User { get => _user; set => _user = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public string Sdt { get => _sdt; set => _sdt = value; }
        public string Account { get => _account; set => _account = value; }
    }
}
