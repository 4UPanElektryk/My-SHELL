using System;

namespace MyShell.Commands.Cmds
{
    class CmdClear : Cmd
    {
        public CmdClear(string name) : base(name)
        {
            description = "Clears the screen";
        }
        public override bool Execute(string[] args, string input)
        {
            Console.Clear();
            return true;
        }
    }
}
