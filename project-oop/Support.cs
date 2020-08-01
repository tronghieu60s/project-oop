using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace project_oop
{
    class Support
    {
        public static void Await(bool status, string alertTrue, string alertFalse)
        {
            Console.Write("\nVui long cho mot chut");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Thread.Sleep(500);
            Console.WriteLine();
            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(alertTrue);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(alertFalse);
                Console.ResetColor();
            }
            Thread.Sleep(800);
        }

        public static string HidePass()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        public static string RandomID(string firstPoint)
        {
            Random rd = new Random();
            int randomID = rd.Next(1, 99999);
            return $"{firstPoint}{randomID}";
        }

        public static void PressKeyToExit()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\nNhan phim Enter de thoat. ");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
