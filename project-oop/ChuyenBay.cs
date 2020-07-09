using System;
using System.Collections.Generic;
using System.Text;

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

        // methods
        public string toString()
        {
            return $"Ma chuyen bay: {_maCB}\n" +
                $"Ngay gio bay: {_ngayGioBay}\n" +
                $"Diem di: {_diemDi.toString()}\n" +
                $"Diem den: {_diemDen.toString()}\n" +
                $"May bay: {_mayBay.toString()}";
        }
    }
}
