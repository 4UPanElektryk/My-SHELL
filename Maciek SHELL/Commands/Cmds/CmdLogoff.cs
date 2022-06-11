using MShell.Integrations.User_Manager;
using MShell.Essentials;
using System;

namespace MShell.Commands.Cmds
{
	class CmdLogoff : Cmd
	{
		public CmdLogoff(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			if (Dual.YesOrNO("Do You want to Logoff?"))
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
