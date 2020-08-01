using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_oop
{
    class MayBay
    {
        // fields
        private string _maMB;
        private string _tenMayBay;
        private string _tenHangMB;
        private int _soLuongGhe;

        // properties
        public string MaMB { get => _maMB; set => _maMB = value; }
        public string TenMayBay { get => _tenMayBay; set => _tenMayBay = value; }
        public string TenHangMB { get => _tenHangMB; set => _tenHangMB = value; }
        public int SoLuongGhe { get => _soLuongGhe; set => _soLuongGhe = value; }

        // constructors
        public MayBay()
        {
            _maMB = "";
            _tenMayBay = "";
            _tenHangMB = "";
            _soLuongGhe = 0;
        }

        public MayBay(string maMB, string tenMayBay, string tenHangMB, int soLuongGhe)
        {
            _maMB = maMB;
            _tenMayBay = tenMayBay;
            _tenHangMB = tenHangMB;
            _soLuongGhe = soLuongGhe;
        }

        ~MayBay()
        {
            Console.WriteLine("Ket thuc May Bay!");
        }

        // methods
        public string toString()
        {
            return $"\t{_maMB,-25}{_tenMayBay,-25}{_tenHangMB,-25}{_soLuongGhe,-25}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaMB = arr[0];
            TenMayBay = arr[1];
            TenHangMB = arr[2];
            SoLuongGhe = int.Parse(arr[3]);
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaMB}#{TenMayBay}#{TenHangMB}#{SoLuongGhe}");
        }
    }
}
