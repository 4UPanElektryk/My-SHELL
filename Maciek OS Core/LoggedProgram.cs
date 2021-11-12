using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MOS_User_Menager_Integration;
using Maciek_OS_Core.Properties;
using Maciek_OS_Core;
using MOS_Log_Integration;
using Maciek_OS_Core.Commands;

namespace Maciek_OS_Core
{
	class LoggedProgram
	{
		public static void LoggedMain(User user)
		{
			Console.Clear();
			Dual.Watermark();
			bool loop = true;
			do
			{
				bool action = false;
				Console.Write(">>");
				string input = Console.ReadLine().ToLower();
				string[] TInput = input.Split(' ');
				int nbt = TInput.Length;
				Log.AddLogEvent(new LogEvent("User Action - Input From User ID:" + user._Id, input, LogEvent.Type.Normal, DateTime.Now));
				switch (TInput[0])
				{
					//Start
					case "start":
						StartCmd start = new StartCmd();
						action = start.Execute(TInput, user);
						break;

					//User
					case "user":
						CmdUser cmdUser = new CmdUser();
						action = cmdUser.Execute(TInput,user);
						break;
					//User

					case "clear":
						action = true;
						Console.Clear();
						Dual.Watermark();
						break;

					//Logs
					case "log":
						LogsCmd log = new LogsCmd();
						action = log.Execute(TInput, user);
						break;
					case "logs":
						action = true;
						string[] f = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Config.DebugPath);
						foreach (string item in f)
						{
							string x = AppDomain.CurrentDomain.BaseDirectory;
							Console.WriteLine(item.TrimStart(x.ToCharArray()));
						}
						break;
					case "edit":
					case "note":
					case "notepad":
						action = true;
						Log.AddLogEvent(new LogEvent("User Action", "Notepad oppening", LogEvent.Type.Normal, DateTime.Now));
						Process.Start("note.exe");
						break;

					case "hmmmmm":
						action = true;
						Log.AddLogEvent(new LogEvent("User Action", "Achivement get", LogEvent.Type.Normal, DateTime.Now));
						Console.WriteLine("");
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("+--{Achivment Get}--+");
						Console.WriteLine("How Did We Get Here? ");
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("");
						break;

					//Logoff
					case "logoff":
						action = true;
						Console.Write("Do You want to Logoff? Y | N >> ");
						ConsoleKey Key = Console.ReadKey().Key;
						if (Key == ConsoleKey.Y)
						{
							Console.WriteLine("");
							loop = false;
						}
						else
						{
							Console.WriteLine("");
						}
						break;
					//Koniec Logoff

					//Koniec
					case "":
						action = true;
						break;
					default:
						action = true;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Incorect command '" + TInput[0] + "'");
						Console.WriteLine("Type 'Help' or '?' for help");
						Console.ForegroundColor = ConsoleColor.White;
						break;
				}
				if (!action)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Incorect command '" + input + "'");
					Console.WriteLine("Type 'Help' or '?' for help");
					Console.ForegroundColor = ConsoleColor.White;
				}
			} while (loop);
			Console.Clear();
			Console.WriteLine("You have been logged off");
			Thread.Sleep(3000);
			Console.Clear();
			Dual.Watermark();
		}
	}
}
