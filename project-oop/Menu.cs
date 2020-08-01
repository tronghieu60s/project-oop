using System;
using System.Collections.Generic;
using System.Text;

namespace project_oop
{
    class Menu
    {
        public static int MenuNhanVien()
        {
            int select;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*********************************");
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tMenu Nhan Vien\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t*");
                Console.WriteLine("*********************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t1. Xem - Them May Bay");
                Console.WriteLine("\t2. Xem - Them San Bay");
                Console.WriteLine("\t3. Xem - Them Chuyen Bay");
                Console.WriteLine("\t4. Xem - Them Khach Hang");
                Console.WriteLine("\t5. Xem - Them Ve May Bay");
                Console.WriteLine("\t6. Xoa Ve May Bay");
                Console.WriteLine("\t7. Sua Ve May Bay");
                Console.WriteLine("\t8. -> Dang Xuat");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*********************************");
                select = InputSelect();
            } while (select <= 0 || select > 8);
            return select;
        }

        static int InputSelect()
        {
            int select;
            // select
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ban chon: ");
            Console.ResetColor();
            int.TryParse(Console.ReadLine(), out select);
            return select;
        }
    }
}
