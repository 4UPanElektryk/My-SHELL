using MShell.Integrations.User_Manager;
using System;

namespace MShell.Essentials
{
    class Prompt
    {
        public static string ShowPropt(User user, string activedir)
        {
            Console.ResetColor();
            Console.Write("┏[");
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
            Console.Write("┗❱");
            return Console.ReadLine();
        }
    }
}
