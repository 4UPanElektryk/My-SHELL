using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System;
using System.IO;

namespace Maciek_SHELL.Commands.Cmds
{
	class CmdMKDir : Cmd
	{
		public CmdMKDir(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			bool action = false;
			string path = Dual.TrimStart(input, args[0] + " ");
			if (!Directory.Exists(LoggedProgram.DIR + path))
			{
				Directory.CreateDirectory(LoggedProgram.DIR + path);
				Log.AddEvent(new Event("User action: Directory Created - " + LoggedProgram.DIR + path, Event.Type.Informtion, DateTime.Now));
				action = true;
			}
			else
			{
				Log.AddEvent(new Event("User action: Directory Can not be created ,Rason: Directory already Exist - " + LoggedProgram.DIR + path, Event.Type.Informtion, DateTime.Now));
				Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
				action = true;
			}
			return action;
		}
	}
}
