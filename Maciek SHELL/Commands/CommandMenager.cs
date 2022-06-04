using Maciek_SHELL.Commands.Cmds;
using Maciek_SHELL.Commands.Cmds.Nano;
using MOS_User_Menager_Integration;
using System.Collections.Generic;

namespace Maciek_SHELL.Commands
{
	class CommandMenager
	{
		public static List<Cmd> CmdList;
		public CommandMenager()
		{
			CmdList = new List<Cmd>
			{
				new CmdUsers("user"),
				new CmdStart("start"),
				new CmdMKDir("mkdir"),
				new CmdLogs("logs"),
				new CmdDir("dir"),
				new CmdDelDir("deldir"),
				new CmdCD("cd"),
				new NanoCmd("nano"),
				new CmdLogoff("logoff"),
				new CmdNote("notepad"),
				new CmdClear("clear"),
				new CmdStatus("status"),
				new CmdTest("test")
			};
		}
		public bool ExecuteCommand(string input, User user)
		{
			string[] args = input.ToLower().Split(' ');
			foreach (Cmd item in CmdList)
			{
				if (item._Name == args[0])
				{
					return item.Execute(args, input, user);
				}
			}
			if (input == "")
			{
				return true;
			}
			return false;
		}
	}
}
