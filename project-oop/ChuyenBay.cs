using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_oop
{
    class ChuyenBay
    {
        // fields
        private string _maCB;
        private DateTime _ngayGioBay;
        private SanBay _diemDi;
        private SanBay _diemDen;
        private MayBay _mayBay;

        // properties
        public string MaCB { get => _maCB; set => _maCB = value; }
        public DateTime NgayGioBay { get => _ngayGioBay; set => _ngayGioBay = value; }
        internal SanBay DiemDi { get => _diemDi; set => _diemDi = value; }
        internal SanBay DiemDen { get => _diemDen; set => _diemDen = value; }
        internal MayBay MayBay { get => _mayBay; set => _mayBay = value; }

        // constructors
        public ChuyenBay()
        {
            _maCB = "";
            _ngayGioBay = new DateTime();
            _diemDi = new SanBay();
            _diemDen = new SanBay();
            _mayBay = new MayBay();
        }

        public ChuyenBay(string maCB, DateTime ngayGioBay, SanBay diemDi, SanBay diemDen, MayBay mayBay)
        {
            _maCB = maCB;
            _ngayGioBay = ngayGioBay;
            _diemDi = diemDi;
            _diemDen = diemDen;
            _mayBay = mayBay;
        }

        ~ChuyenBay()
        {
            Console.WriteLine("Ket thuc Chuyen Bay!");
        }

        // methods
        public string toString()
        {
            return $"\t{_maCB,-25}{_ngayGioBay,-25}{_diemDi.MaSB,-25}{_diemDen.MaSB,-25}{_mayBay.MaMB,-25}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaCB = arr[0];
            NgayGioBay = DateTime.Parse(arr[1]);
            DiemDi.MaSB = arr[2];
            DiemDen.MaSB = arr[3];
            MayBay.MaMB = arr[4];
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaCB}#{NgayGioBay}#{DiemDi.MaSB}#{DiemDen.MaSB}#{MayBay.MaMB}");
        }
    }
}
