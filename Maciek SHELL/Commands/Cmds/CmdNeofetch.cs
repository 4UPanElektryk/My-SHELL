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
            #region Logo
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
            #endregion
            #region Colors
            for (int i = 0; i < 16; i++)
            {
                Console.BackgroundColor = Dual.IntToColor(i);
                Console.Write("   ");
                if (i == 7)
                {
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            #endregion
            #region Data
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Version: " + Settings.Default["Version"].ToString());
            Console.WriteLine("Build date: " + Dual.GetCompilationDDMMString() + "." + Dual.GetCompilationYYYYString());
            Console.ResetColor();
            #endregion
            return true;
        }
    }
}
