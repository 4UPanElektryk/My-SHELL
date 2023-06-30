using MyShell.Essentials;
using System;
using System.IO;
using MyShell.Modules.Base;

namespace MyShell.Commands.Cmds
{
    class CmdLs : Cmd
    {
        public CmdLs(string name) : base(name)
        {
            description = "Lists Stuff in current directory";
        }
        public override bool Execute(string[] args, string input)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Files In Directory: " + LoggedProgram.DIR);
            Dual.Msg("Directories:", ConsoleColor.Yellow);
            foreach (string item in Directory.GetDirectories(LoggedProgram.DIR))
            {
                string[] text = item.Split("\\".ToCharArray());
                Console.WriteLine(text[text.Length - 1]);
            }
            Dual.Msg("Files:", ConsoleColor.Yellow);
            foreach (string item in Directory.GetFiles(LoggedProgram.DIR))
            {
                string[] text = item.Split("\\".ToCharArray());

                Console.WriteLine(text[text.Length - 1]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }
}
