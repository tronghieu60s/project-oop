using System;
using System.Collections.Generic;
using System.Text;

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

        // methods
        public string toString()
        {
            return $"Ma san bay: {_maSB}\n" +
                $"Ten san bay: {_tenSB}\n" +
                $"Quoc gia: {_quocGia}";
        }
    }
}
