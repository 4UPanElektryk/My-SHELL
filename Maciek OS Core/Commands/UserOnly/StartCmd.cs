using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;

namespace Maciek_OS_Core.Commands
{
	public class StartCmd
	{
		private User _User;
		public bool Execute(string input,string[] args, User user)
		{
			string p = args[0] + " ";
			string path = input.TrimStart(p.ToCharArray());
			_User = user;
			bool action = false;
			if (path.Contains(':'))
			{
				if (File.Exists(path))
				{
					action = true;
					Process.Start(path);
					Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: Action Succesful:" + path, LogEvent.Type.Informtion, DateTime.Now));
				}
				else
				{
					Dual.Msg("File Not Found", ConsoleColor.Red);
					Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: File Not Found:" + path, LogEvent.Type.Warrning, DateTime.Now));
					action = true;
				}
			}
			else
			{
				if (File.Exists(LoggedProgram.DIR + path))
				{
					action = true;
					Process.Start(LoggedProgram.DIR + path);
					Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: Action Succesful:" + LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
				}
				else
				{
					Dual.Msg("File Not Found", ConsoleColor.Red);
					Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: File Not Found:" + LoggedProgram.DIR + path, LogEvent.Type.Warrning, DateTime.Now));
					action = true;
				}
			}
			return action;
		}
	}
}
