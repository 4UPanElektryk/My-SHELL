using MShell.Integrations.User_Manager;
using System;

namespace MShell.Commands.SubCmds
{
	public class Error_SubCmdNotFound : SubCmd
	{
		public Error_SubCmdNotFound(string name) : base(name)
		{
			_IsDefault = true;
		}
		public override bool Execute(string[] args, string input, User user)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			if (args.Length > 1)
			{
				Console.WriteLine("Sub Command \"" + args[1] + "\" was Not Found for");
				Console.WriteLine("Command \"" + args[0] + "\"");
				Console.WriteLine("Or is not accesible for that privilage level");
			}
			else
			{
				Console.WriteLine("This Command(" + args[0] + ") require sub commands");
			}
			Console.ResetColor();
			return true;
		}
	}
}
