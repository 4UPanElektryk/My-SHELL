using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.Diagnostics;

namespace MShell.Commands.Cmds
{
	class CmdNote : Cmd
	{
		public CmdNote(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			Log.AddEvent(new Event("User Action, Notepad oppening", Event.Type.Normal, DateTime.Now));
			Process.Start("note.exe");
			return true;
		}
	}
}
