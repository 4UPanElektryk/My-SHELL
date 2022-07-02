using MShell.Essentials;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.IO;
using System.Linq;

namespace MShell.Commands.Cmds
{
	class CmdCD : Cmd
	{
		public CmdCD(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			bool action = true;
			string path = Dual.TrimStart(input, args[0] + " ");
			path = path.Replace("~",AppDomain.CurrentDomain.BaseDirectory);
			if (path != "..")
			{
				if (path.Contains(':'))
				{
					if (Directory.Exists(path))
					{
						LoggedProgram.DIR = path;
						Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, Event.Type.Informtion, DateTime.Now));
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
						string paths = path;
                        foreach (string item in Directory.GetDirectories(LoggedProgram.DIR))
                        {
                            Console.WriteLine(item);
                            Console.WriteLine(Dual.TrimStart(item, LoggedProgram.DIR));
                            Console.WriteLine(Dual.TrimStart(item, LoggedProgram.DIR).ToLower() == path.ToLower());
                            if (Dual.TrimStart(item,LoggedProgram.DIR).ToLower() == path.ToLower())
                            {
                                Console.WriteLine("found");
								paths = Dual.TrimStart(item, LoggedProgram.DIR);
                            }
                        }
						LoggedProgram.DIR = LoggedProgram.DIR + paths + "\\";
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
