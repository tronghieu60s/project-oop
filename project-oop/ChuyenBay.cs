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
            return $"\t{_maCB,-25}{_ngayGioBay,-25}{_diemDi.TenSB,-25}{_diemDen.TenSB,-25}{_mayBay.TenMayBay,-25}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            _maCB = arr[0];
            _ngayGioBay = DateTime.Parse(arr[1]);

            _diemDi.MaSB = arr[2];
            _diemDi = _diemDi.Get(_diemDi.MaSB);

            _diemDen.MaSB = arr[3];
            _diemDen = _diemDen.Get(_diemDen.MaSB);
            
            _mayBay.MaMB = arr[4];
            _mayBay = _mayBay.Get(_mayBay.MaMB);
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaCB}#{NgayGioBay}#{DiemDi.MaSB}#{DiemDen.MaSB}#{MayBay.MaMB}");
        }

        public static LinkedList<ChuyenBay> InputList()
        {
            LinkedList<ChuyenBay> List = new LinkedList<ChuyenBay>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("ChuyenBay.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        ChuyenBay p = new ChuyenBay();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("ChuyenBay.txt"))
                    throw;
            }
            return List;
        }

        public static void WriteList(LinkedList<ChuyenBay> List)
        {
            using (StreamWriter sW = new StreamWriter("ChuyenBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<ChuyenBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        public static void PrintList(LinkedList<ChuyenBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t{0,-25}{1,-25}{2,-25}{3,-25}{4,-25}", "Ma Chuyen Bay", "Ngay Gio Bay", "Diem Di", "Diem Den", "May Bay");
            Console.ResetColor();
            for (LinkedListNode<ChuyenBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }
    }
}
