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

        ~VeMayBay()
        {
            Console.WriteLine("Ket thuc Ve May Bay!");
        }

        // methods
        public string toString()
        {
            return $"\t{_maVe,-15}{_soLuongVe,-15}{_giaVe,-15}{_thanhToan,-15}{_nhanVien.HoTen,-15}{_khachHang.HoTen,-15}{_chuyenBay.MaCB,-15}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            _maVe = arr[0];
            _soLuongVe = int.Parse(arr[1]);
            _giaVe = int.Parse(arr[2]);
            _thanhToan = arr[3];

            _nhanVien.MaNV = arr[4];
            _nhanVien = NhanVien.Get(_nhanVien.MaNV);

            _khachHang.MaKH = arr[5];
            _khachHang = KhachHang.Get(_khachHang.MaKH);

            _chuyenBay.MaCB = arr[6];
            _chuyenBay = ChuyenBay.Get(_chuyenBay.MaCB);
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaVe}#{SoLuongVe}#{GiaVe}#{ThanhToan}#{NhanVien.MaNV}#{KhachHang.MaKH}#{ChuyenBay.MaCB}");
        }

        public static LinkedList<VeMayBay> InputList()
        {
            LinkedList<VeMayBay> List = new LinkedList<VeMayBay>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("VeMayBay.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        VeMayBay p = new VeMayBay();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("VeMayBay.txt"))
                    throw;
            }
            return List;
        }

        public static void WriteList(LinkedList<VeMayBay> List)
        {
            using (StreamWriter sW = new StreamWriter("VeMayBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<VeMayBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        public static void PrintList(LinkedList<VeMayBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t{"Ma ve",-15}{"So luong",-15}{"Gia",-15}{"Thanh toan",-15}{"Nhan vien",-15}{"Khach hang",-15}{"Chuyen Bay",-15}");
            Console.ResetColor();
            for (LinkedListNode<VeMayBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }
    }
}
