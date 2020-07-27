using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_oop
{
    class VeMayBay
    {
        // fields
        private string _maVe;
        private int _soLuongVe;
        private int _giaVe;
        private string _thanhToan;
        private NhanVien _nhanVien;
        private KhachHang _khachHang;
        private ChuyenBay _chuyenBay;

        // properties
        public string MaVe { get => _maVe; set => _maVe = value; }
        public int SoLuongVe { get => _soLuongVe; set => _soLuongVe = value; }
        public int GiaVe { get => _giaVe; set => _giaVe = value; }
        public string ThanhToan { get => _thanhToan; set => _thanhToan = value; }
        internal NhanVien NhanVien { get => _nhanVien; set => _nhanVien = value; }
        internal KhachHang KhachHang { get => _khachHang; set => _khachHang = value; }
        internal ChuyenBay ChuyenBay { get => _chuyenBay; set => _chuyenBay = value; }

        // constructors
        public VeMayBay()
        {
            _maVe = "";
            _soLuongVe = 0;
            _giaVe = 0;
            _thanhToan = "";
            _nhanVien = new NhanVien();
            _khachHang = new KhachHang();
            _chuyenBay = new ChuyenBay();
        }

        public VeMayBay(string maVe, int soLuongVe, int giaVe, string thanhToan, NhanVien nhanVien, KhachHang khachHang, ChuyenBay chuyenBay)
        {
            _maVe = maVe;
            _soLuongVe = soLuongVe;
            _giaVe = giaVe;
            _thanhToan = thanhToan;
            _nhanVien = nhanVien;
            _khachHang = khachHang;
            _chuyenBay = chuyenBay;
        }

        // methods
        public string toString()
        {
            return $"Ma ve: {_maVe}\n" +
                $"So luong ve: {_soLuongVe}\n" +
                $"Gia ve: {_giaVe}\n" +
                $"Thanh toan: {_thanhToan}\n" +
                $"Nhan vien: {_nhanVien.toString()}\n" +
                $"Khach hang: {_khachHang.toString()}\n" +
                $"Chuyen Bay: {_chuyenBay.toString()}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaVe = arr[0];
            SoLuongVe = int.Parse(arr[1]);
            GiaVe = int.Parse(arr[2]);
            ThanhToan = arr[3];
            NhanVien.MaNV = arr[4];
            KhachHang.MaKH = arr[5];
            ChuyenBay.MaCB = arr[6];
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaVe}#{SoLuongVe}#{GiaVe}#{ThanhToan}#{NhanVien.MaNV}#{KhachHang.MaKH}#{ChuyenBay.MaCB}");
        }
    }
}
