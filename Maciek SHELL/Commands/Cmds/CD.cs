using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using Maciek_SHELL.Essentials;
using System;
using System.IO;
using System.Linq;

namespace Maciek_SHELL.Commands.Cmds
{
    class CD : Cmd
    {
		public CD(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
        {
			bool action = true;
			string path = Dual.TrimStart(input, args[0] + " ");
			if (path != "..")
			{
				if (path.Contains(':'))
				{
					if (Directory.Exists(path))
					{
						LoggedProgram.DIR = path;
						Log.AddEvent(new Event("User action: Directory Change - " +  LoggedProgram.DIR, Event.Type.Informtion, DateTime.Now));
					}
					else
					{
						action = false;
					}
				}
				else
				{
					if (Directory.Exists(LoggedProgram.DIR + path))
					{
						LoggedProgram.DIR = LoggedProgram.DIR + path + "\\";
						Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, Event.Type.Informtion, DateTime.Now));
					}
					else
					{
						action = false;
					}
				}

			}
			else
			{
				string[] d = LoggedProgram.DIR.Split('\\');
				string nd = "";
				int i = 1;
				foreach (string item in d)
				{
					i++;
					if (i == d.Length)
					{

					}
					else
					{
						if (i == d.Length - 1)
						{
							nd = nd + item;
						}
						else
						{
							nd = nd + item + "\\";
						}
					}
				}
				if (Directory.Exists(nd))
				{
					LoggedProgram.DIR = nd;
					Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, Event.Type.Informtion, DateTime.Now));
				}
			}
			return action;
		}
    }
}
