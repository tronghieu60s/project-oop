using System;
using System.Collections.Generic;
using System.Text;

namespace project_oop
{
    class Nguoi
    {
        // fields
        private string _hoTen;
        private int _cmnd;
        private string _quocTich;
        private DateTime _ngaySinh;
        private string _gioiTinh;
        private int _sdt;

        // properties
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public int Cmnd { get => _cmnd; set => _cmnd = value; }
        public string QuocTich { get => _quocTich; set => _quocTich = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public int Sdt { get => _sdt; set => _sdt = value; }

        // constructors
        public Nguoi()
        {
            _hoTen = "";
            _cmnd = 0;
            _quocTich = "";
            _ngaySinh = new DateTime();
            _gioiTinh = "";
            _sdt = 0;
        }

        public Nguoi(string hoTen, int cmnd, string quocTich, DateTime ngaySinh, string gioiTinh, int sdt)
        {
            _hoTen = hoTen;
            _cmnd = cmnd;
            _quocTich = quocTich;
            _ngaySinh = ngaySinh;
            _gioiTinh = gioiTinh;
            _sdt = sdt;
        }

        ~Nguoi()
        {
            Console.WriteLine("Ket thuc Nguoi!");
        }

        // methods
        public virtual string toString()
        {
            return $"{HoTen,-15}{Cmnd,-10}{QuocTich,-10}{$"{NgaySinh.Day}/{NgaySinh.Month}/{NgaySinh.Year}",-15}{GioiTinh,-10}{Sdt,-10}";
        }
    }
}
