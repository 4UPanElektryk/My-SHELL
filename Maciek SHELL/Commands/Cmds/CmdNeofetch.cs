using MShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Properties;
using MShell.Essentials;

namespace MShell.Commands.Cmds
{
    class CmdNeofetch : Cmd
    {
        public CmdNeofetch(string name) : base(name)
        {
            description = "Neofetch";
        }
        public override bool Execute(string[] args, string input, User user)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@" __       __           ______  __                __ __ ");
            Console.WriteLine(@"/  \     /  |         /      \/  |              /  /  |");
            Console.WriteLine(@"$$  \   /$$ |__    __/$$$$$$  $$ |____   ______ $$ $$ |");
            Console.WriteLine(@"$$$  \ /$$$ /  |  /  $$ \__$$/$$      \ /      \$$ $$ |");
            Console.WriteLine(@"$$$$  /$$$$ $$ |  $$ $$      \$$$$$$$  /$$$$$$  $$ $$ |");
            Console.WriteLine(@"$$ $$ $$/$$ $$ |  $$ |$$$$$$  $$ |  $$ $$    $$ $$ $$ |");
            Console.WriteLine(@"$$ |$$$/ $$ $$ \__$$ /  \__$$ $$ |  $$ $$$$$$$$/$$ $$ |");
            Console.WriteLine(@"$$ | $/  $$ $$    $$ $$    $$/$$ |  $$ $$       $$ $$ |");
            Console.WriteLine(@"$$/      $$/ $$$$$$$ |$$$$$$/ $$/   $$/ $$$$$$$/$$/$$/ ");
            Console.WriteLine(@"            /  \__$$ |                                 ");
            Console.WriteLine(@"            $$    $$/                                  ");
            Console.WriteLine(@"             $$$$$$/                                   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ver: " + Settings.Default["Version"].ToString());
            for (int i = 0; i <= 15; i++)
            {
                Console.BackgroundColor = Dual.IntToColor(i);
                Console.Write("   ");
                Console.ResetColor();
                if (i == 7)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.ResetColor();
            return true;
        }
    }
}
