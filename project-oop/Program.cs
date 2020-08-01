using System.Collections.Generic;
using System;
using System.IO;

namespace project_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<NhanVien> ListNhanVien = InputListNhanVien();
            if (DangNhapNhanVien(ListNhanVien) != null)
            {
                Menu:
                switch (Menu.MenuNhanVien())
                {
                    case 1:
                        LinkedList<MayBay> ListMayBay = InputListMayBay();
                        PrintListMayBay(ListMayBay);
                        ThemMayBay(ListMayBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 2:
                        LinkedList<SanBay> ListSanBay = InputListSanBay();
                        PrintListSanBay(ListSanBay);
                        ThemSanBay(ListSanBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    default:
                        break;
                }
            }
            else
                Console.WriteLine("Dang nhap that bai!");
        }

        // Action NhanVien
        static LinkedList<NhanVien> InputListNhanVien()
        {
            LinkedList<NhanVien> List = new LinkedList<NhanVien>();
            int iN = 0;
            try
            {
                using (StreamReader sR = new StreamReader("NhanVien.txt"))
                {
                    int.TryParse(sR.ReadLine(), out iN);
                    for (int i = 0; i < iN; i++)
                    {
                        NhanVien p = new NhanVien();
                        p.Read(sR);
                        List.AddLast(p);
                    }
                }
            }
            catch (Exception)
            {
                using (StreamWriter sW = new StreamWriter("NhanVien.txt"))
                    throw;
            }
            return List;
        }

        static NhanVien DangNhapNhanVien(LinkedList<NhanVien> List)
        {
            Console.Write("User: ");
            string user = Console.ReadLine();
            Console.Write("Pass: ");
            string pass = Support.HidePass();
            for (LinkedListNode<NhanVien> p = List.First; p != null; p = p.Next)
            {
                if (p.Value.MaNV == user && p.Value.Pass == pass)
                    return p.Value;
            }
            return null;
        }

        // Action MayBay
        static LinkedList<MayBay> InputListMayBay()
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

        static void WriteListMayBay(LinkedList<MayBay> List)
        {
            using (StreamWriter sW = new StreamWriter("MayBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<MayBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        static void PrintListMayBay(LinkedList<MayBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t{0,-25}{1,-25}{2,-25}{3,-25}", "Ma May Bay", "Ten May Bay", "Ten Hang", "So Luong Ghe");
            Console.ResetColor();
            for (LinkedListNode<MayBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }

        static void ThemMayBay(LinkedList<MayBay> List)
        {
            MayBay mayBay = new MayBay();

            Console.WriteLine("\nThem may bay: ");
            mayBay.MaMB = Support.RandomID("MB");
            Console.Write("\t- Ten may bay: ");
            mayBay.TenMayBay = Console.ReadLine();
            Console.Write("\t- Ten hang: ");
            mayBay.TenHangMB = Console.ReadLine();
            Console.Write("\t- So luong ghe: ");
            int soLuongGhe; int.TryParse(Console.ReadLine(), out soLuongGhe);
            mayBay.SoLuongGhe = soLuongGhe;
            List.AddLast(mayBay);
            WriteListMayBay(List);
            Support.Await(true, "Them may bay thanh cong!", "");
        }

        // Action SanBay
        static LinkedList<SanBay> InputListSanBay()
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

        static void WriteListSanBay(LinkedList<SanBay> List)
        {
            using (StreamWriter sW = new StreamWriter("SanBay.txt"))
            {
                sW.WriteLine(List.Count);
                for (LinkedListNode<SanBay> p = List.First; p != null; p = p.Next)
                    p.Value.Write(sW);
            }
        }

        static void PrintListSanBay(LinkedList<SanBay> List)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t{0,-25}{1,-25}{2,-25}", "Ma San Bay", "Ten San Bay", "Quoc Gia");
            Console.ResetColor();
            for (LinkedListNode<SanBay> p = List.First; p != null; p = p.Next)
                Console.WriteLine(p.Value.toString());
        }

        static void ThemSanBay(LinkedList<SanBay> List)
        {
            SanBay sanBay = new SanBay();

            Console.WriteLine("\nThem san bay: ");
            sanBay.MaSB = Support.RandomID("SB");
            Console.Write("\t- Ten san bay: ");
            sanBay.TenSB = Console.ReadLine();
            Console.Write("\t- Quoc gia: ");
            sanBay.QuocGia = Console.ReadLine();
            List.AddLast(sanBay);
            WriteListSanBay(List);
            Support.Await(true, "Them san bay thanh cong!", "");
        }
    }
}
