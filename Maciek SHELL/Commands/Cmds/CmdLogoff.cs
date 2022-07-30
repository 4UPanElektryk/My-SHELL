using MShell.Essentials;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;

namespace MShell.Commands.Cmds
{
    class CmdLogoff : Cmd
    {
        public CmdLogoff(string name) : base(name)
        {
            description = "Loggs off currently logged user";
        }
        public override bool Execute(string[] args, string input, User user)
        {
            if (Dual.YesOrNO("Do You want to Logoff?"))
            {
                Console.WriteLine("");
                Log.Write("User logged of ID: " + user._Id);
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
