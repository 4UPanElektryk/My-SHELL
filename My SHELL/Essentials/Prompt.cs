using MyShell.Integrations.User_Manager;
using System;

namespace MyShell.Essentials
{
    class Prompt
    {
        public static string ShowPropt(User user, string activedir)
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
            if (user._State == User.Type.SysAdmin)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (user._State == User.Type.Admin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write(user._Login);
            Console.ResetColor();
            Console.Write("][");
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
