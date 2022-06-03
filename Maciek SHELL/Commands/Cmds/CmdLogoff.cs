using MOS_User_Menager_Integration;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
    class CmdLogoff : Cmd
    {
        public CmdLogoff(string name) : base(name) { }
        public override bool Execute(string[] args, string input, User user)
        {
            Console.Write("Do You want to Logoff? Y | N >> ");
            ConsoleKey Key = Console.ReadKey().Key;
            if (Key == ConsoleKey.Y)
            {
                Console.WriteLine("");
                LoggedProgram.loop = false;
            }
            else
            {
                Console.WriteLine("");
            }
            return true;
        }
    }
}
