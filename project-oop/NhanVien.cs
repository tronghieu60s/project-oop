using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_oop
{
    class NhanVien: Nguoi
    {
        // fields
        private string _maNV;
        private int _luongCoBan;
        private string _pass;

        // properties
        public string MaNV { get => _maNV; set => _maNV = value; }
        public int LuongCoBan { get => _luongCoBan; set => _luongCoBan = value; }
        public string Pass { get => _pass; set => _pass = value; }

        // constructors
        public NhanVien(): base()
        {
            _maNV = "";
            _luongCoBan = 0;
            _pass = "";
        }

        public NhanVien(string maNV, int luongCoBan, string pass, string hoTen, int cmnd, string quocTich, DateTime ngaySinh, string gioiTinh, int sdt):base(hoTen, cmnd, quocTich, ngaySinh, gioiTinh, sdt)
        {
            _maNV = maNV;
            _luongCoBan = luongCoBan;
            _pass = pass;
        }

        ~NhanVien()
        {
            Console.WriteLine("Ket thuc Nhan Vien!");
        }
        
        // methods
        public override string toString()
        {
            return $"Ma nhan vien: {_maNV}\n" +
                $"Luong co ban: {_luongCoBan}\n" +
                $"{base.toString()}";
        }

        public void Read(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr = line.Split('#');
            MaNV = arr[0];
            LuongCoBan = int.Parse(arr[1]);
            Pass = arr[2];
            HoTen = arr[3];
            Cmnd = int.Parse(arr[4]);
            QuocTich = arr[5];
            NgaySinh = DateTime.Parse(arr[6]);
            GioiTinh = arr[7];
            Sdt = int.Parse(arr[8]);
        }

        public void Write(StreamWriter sW)
        {
            sW.WriteLine($"{MaNV}#{LuongCoBan}#{Pass}#{HoTen}#{Cmnd}#{QuocTich}#{NgaySinh}#{GioiTinh}#{Sdt}");
        }

        public static LinkedList<NhanVien> InputList()
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

        public static NhanVien Get(string maNV)
        {
            LinkedList<NhanVien> ListNhanVien = InputList();
            for (LinkedListNode<NhanVien> p = ListNhanVien.First; p != null; p = p.Next)
                if (p.Value.MaNV == maNV)
                    return p.Value;
            return null;
        }
    }
}
