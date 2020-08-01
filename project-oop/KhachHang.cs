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
            return $"\t{MaKH,-10}{base.toString()}{DiaChi,-10}{Passport,-10}";
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

        public static LinkedList<KhachHang> InputList()
        {
            LinkedList<KhachHang> List = new LinkedList<KhachHang>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("KhachHang.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        KhachHang p = new KhachHang();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("KhachHang.txt"))
                    throw;
            }
            return List;
        }

        public static void WriteList(LinkedList<KhachHang> List)
        {
            using (StreamWriter sW = new StreamWriter("KhachHang.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<KhachHang> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        public static void PrintList(LinkedList<KhachHang> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t{"Ma KH",-10}{"Ho Ten",-15}{"CMND",-10}{"Quoc Tich",-10}{"Ngay Sinh",-15}{"Gioi Tinh",-10}{"SDT",-10}{"Dia Chi",-10}{"Passport",-10}");
            Console.ResetColor();
            for (LinkedListNode<KhachHang> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }

        public static KhachHang Get(string maKH)
        {
            LinkedList<KhachHang> ListKhachHang = InputList();
            for (LinkedListNode<KhachHang> p = ListKhachHang.First; p != null; p = p.Next)
                if (p.Value.MaKH == maKH)
                    return p.Value;
            return null;
        }
    }
}
