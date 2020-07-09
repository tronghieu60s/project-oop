using System;
using System.Collections.Generic;
using System.Text;

namespace project_oop
{
    class NhanVien: Nguoi
    {
        // fields
        private string _maNV;
        private int _luongCoBan;

        // properties
        public string MaNV { get => _maNV; set => _maNV = value; }
        public int LuongCoBan { get => _luongCoBan; set => _luongCoBan = value; }

        // constructors
        public NhanVien(): base()
        {
            _maNV = "";
            _luongCoBan = 0;
        }

        public NhanVien(string maNV, int luongCoBan, string hoTen, int cmnd, string quocTich, DateTime ngaySinh, string gioiTinh, int sdt):base(hoTen, cmnd, quocTich, ngaySinh, gioiTinh, sdt)
        {
            _maNV = maNV;
            _luongCoBan = luongCoBan;
        }

        // methods
        public override string toString()
        {
            return $"Ma nhan vien: {_maNV}\n" +
                $"Luong co ban: {_luongCoBan}\n" +
                $"{base.toString()}";
        }
    }
}
