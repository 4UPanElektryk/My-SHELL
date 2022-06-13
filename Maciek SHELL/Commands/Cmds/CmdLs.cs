using MShell.Integrations.User_Manager;
using MShell.Essentials;
using System;
using System.IO;

namespace MShell.Commands.Cmds
{
	class CmdLs : Cmd
	{
		public CmdLs(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
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
