using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using System.IO;
using System;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core.Commands.Cmds
{
    class MKDir : Cmd
    {
		public MKDir(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
        {
			bool action = false;
			string path = Dual.TrimStart(input, args[0] + " ");
			if (!Directory.Exists(LoggedProgram.DIR + path))
			{
				Directory.CreateDirectory(LoggedProgram.DIR + path);
				Log.AddLogEvent(new LogEvent("User action: Directory Created", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
				action = true;
			}
			else
			{
				Log.AddLogEvent(new LogEvent("User action: Directory Can not be created ,Rason: Directory already Exist", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
				Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
				action = true;
			}
			return action;
		}
    }
}
