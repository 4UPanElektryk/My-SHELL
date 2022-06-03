using MOS_User_Menager_Integration;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
    class CmdHelp : Cmd
    {
        public CmdHelp(string name) : base(name)
        {
            /*description = "Wyświetla listę wszystkich komend";
            args = "";*/
        }

        public override bool Execute(string[] args, string input, User user)
        {
            Console.WriteLine("Command List:");
            foreach (Cmd cmd in CommandMenager.CmdList)
            {
                Console.WriteLine(cmd._Name + " - " + cmd._Help);
            }
            return true;
        }
    }
}
