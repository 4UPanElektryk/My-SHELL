using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Maciek_OS_Core.Commands;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using Maciek_OS_Core.Commands.UserOnly;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core
{
	class LoggedProgram
	{
		public static string DIR;
		public static void LoggedMain(User user)
		{
			DirCmd dirCmd = new DirCmd();
			UserCmd cmdUser = new UserCmd();
			StartCmd start = new StartCmd();
			LogsCmd log = new LogsCmd();
			NanoCmd nano = new NanoCmd();
			DIR = AppDomain.CurrentDomain.BaseDirectory;
			Console.Clear();
			Dual.Watermark();
			bool loop = true;
			do
			{
				bool action = false;
				Console.Write(DIR + ">");
				string dt = Console.ReadLine();
				string input = dt.ToLower();
				string[] TInput = input.Split(' ');
				int nbt = TInput.Length;
				Log.AddLogEvent(new LogEvent("User Action - Input From User ID:" + user._Id, input, LogEvent.Type.Normal, DateTime.Now));
				switch (TInput[0])
				{
					//cd
					case "cd":
						action = dirCmd.Cd(dt,TInput, user);
						break;
					//mkdir
					case "mkdir":
						action = dirCmd.MKDir(TInput,dt);
						break;
					//deldir
					case "deldir":
						action = dirCmd.DelDir(TInput, dt);
						break;
					//Start
					case "start":
						action = start.Execute(dt, TInput, user);
						break;

					//User
					case "user":
						action = cmdUser.Execute(TInput,user);
						break;
					//User

					case "clear":
						action = true;
						Console.Clear();
						Dual.Watermark();
						break;

					case "dir":
						action = dirCmd.Dir(user);
						break;

					//Logs
					case "log":
						action = log.Execute(TInput, user);
						break;
					case "logs":
						action = true;
						string[] f = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Config.LogsPath);
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

					//Nano
					case "nano":
						action = nano.Execute(TInput, dt);
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
