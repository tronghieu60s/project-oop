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
            return $"\t{_maSB,-25}{_tenSB,-25}{_quocGia,-25}";
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

        public static LinkedList<SanBay> InputList()
        {
            LinkedList<SanBay> List = new LinkedList<SanBay>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("SanBay.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        SanBay p = new SanBay();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("SanBay.txt"))
                    throw;
            }
            return List;
        }

        public static void WriteList(LinkedList<SanBay> List)
        {
            using (StreamWriter sW = new StreamWriter("SanBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<SanBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        public static void PrintList(LinkedList<SanBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t{0,-25}{1,-25}{2,-25}", "Ma San Bay", "Ten San Bay", "Quoc Gia");
            Console.ResetColor();
            for (LinkedListNode<SanBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }

        public SanBay Get(string maSB)
        {
            LinkedList<SanBay> ListSanBay = InputList();
            for (LinkedListNode<SanBay> p = ListSanBay.First; p != null; p = p.Next)
                if (p.Value.MaSB == maSB)
                    return p.Value;
            return null;
        }
    }
}
