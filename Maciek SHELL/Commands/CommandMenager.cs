using MShell.Commands.Cmds;
using MShell.Commands.Cmds.Nano;
using MShell.Integrations.User_Manager;
using System.Collections.Generic;

namespace MShell.Commands
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
				new CmdLs("ls"),
				new CmdDelDir("deldir"),
				new CmdCD("cd"),
				new NanoCmd("nano"),
				new CmdLogoff("logoff"),
				new CmdNote("notepad"),
				new CmdClear("clear"),
				new CmdStatus("status"),
			};
            if (Program.Experimental)
            {
				CmdList.Add(new CmdNeofetch("neofetch"));
				CmdList.Add(new CmdTest("test"));
            }
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
