using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        ~KhachHang()
        {
            Console.WriteLine("Ket thuc Khach Hang!");
        }

        // methods
        public override string toString()
        {
            return $"Ma khach hang: {_maKH}\n" +
                $"Dia chi: {_diaChi}\n" +
                $"Passport: {_passport}\n" +
                $"{base.toString()}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaKH = arr[0];
            DiaChi = arr[1];
            Passport = arr[2];
            HoTen = arr[3];
            Cmnd = int.Parse(arr[4]);
            QuocTich = arr[5];
            NgaySinh = DateTime.Parse(arr[6]);
            GioiTinh = arr[7];
            Sdt = int.Parse(arr[8]);
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaKH}#{DiaChi}#{Passport}#{HoTen}#{Cmnd}#{QuocTich}#{NgaySinh}#{GioiTinh}#{Sdt}");
        }
    }
}
