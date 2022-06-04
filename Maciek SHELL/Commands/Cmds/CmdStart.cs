using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Maciek_SHELL.Commands.Cmds
{
	class CmdStart : Cmd
	{
		public CmdStart(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			string p = args[0] + " ";
			string path = Dual.TrimStart(input, p);
			bool action = false;
			if (path.Contains(':'))
			{
				if (File.Exists(path))
				{
					action = true;
					Process.Start(path);
					Log.AddEvent(new Event("User Action by " + user._Id + " - Start: Action Succesful:" + path, Event.Type.Informtion, DateTime.Now));
				}
				else
				{
					Dual.Msg("File Not Found", ConsoleColor.Red);
					Log.AddEvent(new Event("User Action by " + user._Id + " - Start: File Not Found:" + path, Event.Type.Warning, DateTime.Now));
					action = true;
				}
			}
			else
			{
				if (File.Exists(LoggedProgram.DIR + path))
				{
					action = true;
					Process.Start(LoggedProgram.DIR + path);
					Log.AddEvent(new Event("User Action by " + user._Id + " - Start: Action Succesful:" + LoggedProgram.DIR + path, Event.Type.Informtion, DateTime.Now));
				}
				else
				{
					Dual.Msg("File Not Found", ConsoleColor.Red);
					Log.AddEvent(new Event("User Action by " + user._Id + " - Start: File Not Found:" + LoggedProgram.DIR + path, Event.Type.Warning, DateTime.Now));
					action = true;
				}
			}
			return action;
		}
	}
}
