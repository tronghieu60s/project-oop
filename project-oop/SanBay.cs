using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_oop
{
    class SanBay
    {
        // fields
        private string _maSB;
        private string _tenSB;
        private string _quocGia;

        // properties
        public string MaSB { get => _maSB; set => _maSB = value; }
        public string TenSB { get => _tenSB; set => _tenSB = value; }
        public string QuocGia { get => _quocGia; set => _quocGia = value; }

        // constructors
        public SanBay()
        {
            _maSB = "";
            _tenSB = "";
            _quocGia = "";
        }

        public SanBay(string maSB, string tenSB, string quocGia)
        {
            _maSB = maSB;
            _tenSB = tenSB;
            _quocGia = quocGia;
        }

        ~SanBay()
        {
            Console.WriteLine("Ket thuc San Bay!");
        }

        // methods
        public string toString()
        {
            return $"{_maSB,-25}{_tenSB,-25}{_quocGia,-25}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaSB = arr[0];
            TenSB = arr[1];
            QuocGia = arr[2];
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaSB}#{TenSB}#{QuocGia}");
        }
    }
}
