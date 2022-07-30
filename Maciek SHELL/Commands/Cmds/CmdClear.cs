using MShell.Essentials;
using MShell.Integrations.User_Manager;
using System;

namespace MShell.Commands.Cmds
{
	class CmdClear : Cmd
	{
		public CmdClear(string name) : base(name) 
		{
			description = "Clears the screen";
		}
		public override bool Execute(string[] args, string input, User user)
		{
			Console.Clear();
			return true;
		}
	}
}
