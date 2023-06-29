using System;

namespace MyShell.Essentials
{
    class Prompt
    {
        public static string ShowPropt(string activedir)
        {
            Console.ResetColor();
            if (Program.UseASCII)
            {
                Console.Write("[");
            }
            else
            {
                Console.Write("┏[");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(activedir);
            Console.ResetColor();
            Console.WriteLine("]");
            if (Program.UseASCII)
            {
                Console.Write(">");
            }
            else
            {
                Console.Write("┗❱");
            }
            return Console.ReadLine();
        }
    }
}
