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
            LinkedList<MayBay> ListMayBay = MayBay.InputList();
            LinkedList<SanBay> ListSanBay = SanBay.InputList();
            LinkedList<ChuyenBay> ListChuyenBay = ChuyenBay.InputList();
            LinkedList<KhachHang> ListKhachHang = KhachHang.InputList();
            LinkedList<VeMayBay> ListVeMB = VeMayBay.InputList();

            NhanVien nvDangNhap = DangNhapNhanVien(ListNhanVien);
            if (nvDangNhap != null)
            {
            Menu:
                switch (Menu.MenuNhanVien())
                {
                    case 1:
                        MayBay.PrintList(ListMayBay);
                        if (Support.CheckForInput())
                            ThemMayBay(ListMayBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 2:
                        SanBay.PrintList(ListSanBay);
                        if (Support.CheckForInput())
                            ThemSanBay(ListSanBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 3:
                        ChuyenBay.PrintList(ListChuyenBay);
                        if (Support.CheckForInput())
                            ThemChuyenBay(ListChuyenBay);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 4:
                        KhachHang.PrintList(ListKhachHang);
                        if (Support.CheckForInput())
                            ThemKhachHang(ListKhachHang);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 5:
                        VeMayBay.PrintList(ListVeMB);
                        if (Support.CheckForInput())
                            ThemVeMayBay(ListVeMB, nvDangNhap);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 6:
                        VeMayBay.PrintList(ListVeMB);
                        XoaVeMayBay(ListVeMB);
                        Support.PressKeyToExit();
                        goto Menu;
                    case 7:
                        VeMayBay.PrintList(ListVeMB);
                        SuaVeMayBay(ListVeMB, nvDangNhap);
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Dang Nhap Nhan Vien ---");
            Console.ResetColor();
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
        static void ThemKhachHang(LinkedList<KhachHang> List)
        {
            KhachHang khachHang = new KhachHang();

            Console.WriteLine("\nThem khach hang: ");
            khachHang.MaKH = Support.RandomID("KH");
            Console.Write("\t- Nhap ho ten: ");
            khachHang.HoTen = Console.ReadLine();
            Console.Write("\t- Nhap cmnd: ");
            int cmnd; int.TryParse(Console.ReadLine(), out cmnd);
            khachHang.Cmnd = cmnd;
            Console.Write("\t- Nhap quoc tich: ");
            khachHang.QuocTich = Console.ReadLine();
            Console.Write("\t- Nhap ngay sinh: ");
            DateTime ngaySinh; DateTime.TryParse(Console.ReadLine(), out ngaySinh);
            khachHang.NgaySinh = ngaySinh;
            Console.Write("\t- Nhap gioi tinh: ");
            khachHang.GioiTinh = Console.ReadLine();
            Console.Write("\t- Nhap sdt: ");
            int sdt; int.TryParse(Console.ReadLine(), out sdt);
            khachHang.Sdt = sdt;

            Console.Write("\t- Nhap dia chi: ");
            khachHang.DiaChi = Console.ReadLine();
            Console.Write("\t- Nhap passport: ");
            khachHang.Passport = Console.ReadLine();

            List.AddLast(khachHang);
            KhachHang.WriteList(List);
            Support.Await(true, "Them hanh khach thanh cong!", "");
        }

        // Action VeMayBay
        static void ThemVeMayBay(LinkedList<VeMayBay> List, NhanVien nhanVien)
        {
            VeMayBay veMayBay = new VeMayBay();
            LinkedList<KhachHang> ListKhachHang = KhachHang.InputList();
            LinkedList<ChuyenBay> ListChuyenBay = ChuyenBay.InputList();

            Console.WriteLine("\nThem ve may bay: ");
            veMayBay.MaVe = Support.RandomID("VMB");
            Console.Write("\t- Nhap so luong: ");
            int soLuongVe; int.TryParse(Console.ReadLine(), out soLuongVe);
            veMayBay.SoLuongVe = soLuongVe;
            Console.Write("\t- Nhap gia ve: ");
            int giaVe; int.TryParse(Console.ReadLine(), out giaVe);
            veMayBay.GiaVe = giaVe;
            Console.Write("\t- Nhap loai thanh toan: ");
            veMayBay.ThanhToan = Console.ReadLine();
            veMayBay.NhanVien = nhanVien;

            KhachHang.PrintList(ListKhachHang);
            Console.Write("\t- Nhap ma khach hang: ");
            string maKH = Console.ReadLine();
            for (LinkedListNode<KhachHang> p = ListKhachHang.First; p != null; p = p.Next)
            {
                if (p.Value.MaKH == maKH)
                    veMayBay.KhachHang = p.Value;
            }

            ChuyenBay.PrintList(ListChuyenBay);
            Console.Write("\t- Nhap ma chuyen bay: ");
            string maCB = Console.ReadLine();
            for (LinkedListNode<ChuyenBay> p = ListChuyenBay.First; p != null; p = p.Next)
            {
                if (p.Value.MaCB == maCB)
                    veMayBay.ChuyenBay = p.Value;
            }

            List.AddLast(veMayBay);
            VeMayBay.WriteList(List);
            Support.Await(true, "Them ve may bay thanh cong!", "");
        }

        static void XoaVeMayBay(LinkedList<VeMayBay> List)
        {
            Console.Write("Nhap ma ve can xoa: ");
            string maVe = Console.ReadLine();
            for (LinkedListNode<VeMayBay> p = List.First; p != null; p = p.Next)
            {
                if (p.Value.MaVe == maVe)
                {
                    List.Remove(p.Value);
                    VeMayBay.WriteList(List);
                    Support.Await(true, "Xoa thanh cong!", "");
                    return;
                }
            }
            Support.Await(false, "", "Xoa that bai! Ma ve khong dung!");
        }

        static void SuaVeMayBay(LinkedList<VeMayBay> List, NhanVien nhanVien)
        {
            Console.Write("Nhap ma ve can sua: ");
            string maVe = Console.ReadLine();
            for (LinkedListNode<VeMayBay> p = List.First; p != null; p = p.Next)
            {
                if (p.Value.MaVe == maVe)
                {
                    LinkedList<KhachHang> ListKhachHang = KhachHang.InputList();
                    LinkedList<ChuyenBay> ListChuyenBay = ChuyenBay.InputList();

                    Console.WriteLine("\nSua ve may bay: ");
                    Console.Write("\t- Nhap so luong: ");
                    int soLuongVe; int.TryParse(Console.ReadLine(), out soLuongVe);
                    p.Value.SoLuongVe = soLuongVe;
                    Console.Write("\t- Nhap gia ve: ");
                    int giaVe; int.TryParse(Console.ReadLine(), out giaVe);
                    p.Value.GiaVe = giaVe;
                    Console.Write("\t- Nhap loai thanh toan: ");
                    p.Value.ThanhToan = Console.ReadLine();
                    p.Value.NhanVien = nhanVien;

                    KhachHang.PrintList(ListKhachHang);
                    Console.Write("\t- Nhap ma khach hang: ");
                    string maKH = Console.ReadLine();
                    for (LinkedListNode<KhachHang> q = ListKhachHang.First; q != null; q = q.Next)
                    {
                        if (q.Value.MaKH == maKH)
                            p.Value.KhachHang = q.Value;
                    }

                    ChuyenBay.PrintList(ListChuyenBay);
                    Console.Write("\t- Nhap ma chuyen bay: ");
                    string maCB = Console.ReadLine();
                    for (LinkedListNode<ChuyenBay> q = ListChuyenBay.First; q != null; q = q.Next)
                    {
                        if (q.Value.MaCB == maCB)
                            p.Value.ChuyenBay = q.Value;
                    }

                    VeMayBay.WriteList(List);
                    Support.Await(true, "Sua thanh cong!", "");
                    return;
                }
            }
            Support.Await(false, "", "Sua that bai! Ma ve khong dung!");
        }
    }
}
