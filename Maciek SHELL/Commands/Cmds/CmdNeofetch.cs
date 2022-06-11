using MShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Properties;

namespace MShell.Commands.Cmds
{
    class CmdNeofetch : Cmd
    {
        public CmdNeofetch(string name) : base(name)
        {
            _Help = "Neofetch";
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
            Console.ResetColor();
            return true;
        }
    }
}
