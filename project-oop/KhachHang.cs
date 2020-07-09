using System;
using System.Collections.Generic;
using System.Text;

namespace project_oop
{
    class KhachHang: Nguoi
    {
        // fields
        private string _maKH;
        private string _diaChi;
        private string _passport;

        // properties
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Passport { get => _passport; set => _passport = value; }

        // constructors
        public KhachHang(): base(){
            _maKH = "";
            _diaChi = "";
            _passport = "";
        }

        public KhachHang(string maKH, string diaChi, string passport, string hoTen, int cmnd, string quocTich, DateTime ngaySinh, string gioiTinh, int sdt): base(hoTen, cmnd, quocTich, ngaySinh, gioiTinh, sdt)
        {
            _maKH = maKH;
            _diaChi = diaChi;
            _passport = passport;
        }

        // methods
        public override string toString()
        {
            return $"Ma khach hang: {_maKH}\n" +
                $"Dia chi: {_diaChi}\n" +
                $"Passport: {_passport}\n" +
                $"{base.toString()}";
        }
    }
}
