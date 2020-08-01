using System.Collections.Generic;
using System;
using System.IO;

namespace project_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<NhanVien> ListNhanVien = NhanVien.InputList();
            if (DangNhapNhanVien(ListNhanVien) != null)
            {
            Menu:
                switch (Menu.MenuNhanVien())
                {
                    case 1:
                        LinkedList<MayBay> ListMayBay = MayBay.InputList();
                        MayBay.PrintList(ListMayBay);
                        if (Support.CheckForInput())
                            ThemMayBay(ListMayBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 2:
                        LinkedList<SanBay> ListSanBay = SanBay.InputList();
                        SanBay.PrintList(ListSanBay);
                        if (Support.CheckForInput())
                            ThemSanBay(ListSanBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 3:
                        LinkedList<ChuyenBay> ListChuyenBay = ChuyenBay.InputList();
                        ChuyenBay.PrintList(ListChuyenBay);
                        if (Support.CheckForInput())
                            ThemChuyenBay(ListChuyenBay);
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
            MayBay.WriteList(List);
            Support.Await(true, "Them may bay thanh cong!", "");
        }

        // Action SanBay
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
            SanBay.WriteList(List);
            Support.Await(true, "Them san bay thanh cong!", "");
        }

        // Action ChuyenBay
        static void ThemChuyenBay(LinkedList<ChuyenBay> List)
        {
            ChuyenBay chuyenBay = new ChuyenBay();
            LinkedList<SanBay> ListSanBay = SanBay.InputList();
            LinkedList<MayBay> ListMayBay = MayBay.InputList();

            Console.WriteLine("\nThem chuyen bay: ");
            chuyenBay.MaCB = Support.RandomID("CB");
            Console.Write("\t- Ngay gio bay: ");
            DateTime ngayGioBay; DateTime.TryParse(Console.ReadLine(), out ngayGioBay);
            chuyenBay.NgayGioBay = ngayGioBay;

            SanBay.PrintList(ListSanBay);
            Console.Write("\t- Nhap ma diem di: ");
            string maDiemDi = Console.ReadLine();
            Console.Write("\t- Nhap ma diem den: ");
            string maDiemDen = Console.ReadLine();
            for (LinkedListNode<SanBay> p = ListSanBay.First; p != null; p = p.Next)
            {
                if (p.Value.MaSB == maDiemDi)
                    chuyenBay.DiemDi = p.Value;
                if (p.Value.MaSB == maDiemDen)
                    chuyenBay.DiemDen = p.Value;
            }

            MayBay.PrintList(ListMayBay);
            Console.Write("\t- Nhap ma may bay: ");
            string maMayBay = Console.ReadLine();
            for (LinkedListNode<MayBay> p = ListMayBay.First; p != null; p = p.Next)
            {
                if (p.Value.MaMB == maMayBay)
                    chuyenBay.MayBay = p.Value;
            }

            List.AddLast(chuyenBay);
            ChuyenBay.WriteList(List);
            Support.Await(true, "Them chuyen bay thanh cong!", "");
        }

        // Action KhachHang
        static void ThemKhachHang(LinkedList<ChuyenBay> List)
        {
            ChuyenBay chuyenBay = new ChuyenBay();
            LinkedList<SanBay> ListSanBay = SanBay.InputList();
            LinkedList<MayBay> ListMayBay = MayBay.InputList();

            Console.WriteLine("\nThem chuyen bay: ");
            chuyenBay.MaCB = Support.RandomID("CB");
            Console.Write("\t- Ngay gio bay: ");
            DateTime ngayGioBay; DateTime.TryParse(Console.ReadLine(), out ngayGioBay);
            chuyenBay.NgayGioBay = ngayGioBay;

            SanBay.PrintList(ListSanBay);
            Console.Write("\t- Nhap ma diem di: ");
            string maDiemDi = Console.ReadLine();
            Console.Write("\t- Nhap ma diem den: ");
            string maDiemDen = Console.ReadLine();
            for (LinkedListNode<SanBay> p = ListSanBay.First; p != null; p = p.Next)
            {
                if (p.Value.MaSB == maDiemDi)
                    chuyenBay.DiemDi = p.Value;
                if (p.Value.MaSB == maDiemDen)
                    chuyenBay.DiemDen = p.Value;
            }

            MayBay.PrintList(ListMayBay);
            Console.Write("\t- Nhap ma may bay: ");
            string maMayBay = Console.ReadLine();
            for (LinkedListNode<MayBay> p = ListMayBay.First; p != null; p = p.Next)
            {
                if (p.Value.MaMB == maMayBay)
                    chuyenBay.MayBay = p.Value;
            }

            List.AddLast(chuyenBay);
            ChuyenBay.WriteList(List);
            Support.Await(true, "Them chuyen bay thanh cong!", "");
        }
    }
}
