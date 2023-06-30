using MyShell.Essentials;
using MyShell.Modules.Base;
using System;

namespace MyShell.Commands.Cmds
{
    class CmdExit : Cmd
    {
        public CmdExit(string name) : base(name)
        {
            description = "Closes the program";
        }
        public override bool Execute(string[] args, string input)
        {
            if (Dual.YesOrNO("Do You want to Exit?"))
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
