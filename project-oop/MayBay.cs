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

        public static LinkedList<MayBay> InputList()
        {
            LinkedList<MayBay> List = new LinkedList<MayBay>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("MayBay.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        MayBay p = new MayBay();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("MayBay.txt"))
                    throw;
            }
            return List;
        }

        public static void WriteList(LinkedList<MayBay> List)
        {
            using (StreamWriter sW = new StreamWriter("MayBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<MayBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        public static void PrintList(LinkedList<MayBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t{0,-25}{1,-25}{2,-25}{3,-25}", "Ma May Bay", "Ten May Bay", "Ten Hang", "So Luong Ghe");
            Console.ResetColor();
            for (LinkedListNode<MayBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }

        public static MayBay Get(string maMB)
        {
            LinkedList<MayBay> ListMayBay = InputList();
            for (LinkedListNode<MayBay> p = ListMayBay.First; p != null; p = p.Next)
                if (p.Value.MaMB == maMB)
                    return p.Value;
            return null;
        }
    }
}
