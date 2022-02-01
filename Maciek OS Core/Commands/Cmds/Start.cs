using MOS_User_Menager_Integration;
using System;
using System.IO;
using Maciek_OS_Core.Essentials;
using MOS_Log_Integration;
using System.Diagnostics;
using System.Linq;

namespace Maciek_OS_Core.Commands.Cmds
{
    class Start : Cmd
    {
		public Start(string name) : base(name) { }
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
