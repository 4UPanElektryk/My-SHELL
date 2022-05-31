using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_User_Menager_Integration;

namespace Maciek_SHELL.Essentials
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
