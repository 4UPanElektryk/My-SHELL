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
		public bool Execute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
			bool action = false;
			string c = Console.ReadLine();
            if (File.Exists(c))
            {
				action = true;
				Process.Start(c);
				Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: Action Succesful:" + c, LogEvent.Type.Informtion, DateTime.Now));
			}
            else
            {
				Dual.Msg("File Not Found", ConsoleColor.Red);
				Log.AddLogEvent(new LogEvent("User Action by " + user._Id, "Start: File Not Found:" + c,LogEvent.Type.Warrning, DateTime.Now));
				action = true;
            }
			return action;
		}
		public bool ScriptExecute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
			bool action = false;
			return action;
		}
	}
}
