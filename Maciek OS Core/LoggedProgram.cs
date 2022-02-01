using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Maciek_OS_Core.Commands;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using Maciek_OS_Core.Commands;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core
{
	class LoggedProgram
	{
		public static string DIR;
		public static bool loop;
		public static void LoggedMain(User user)
		{
			DIR = AppDomain.CurrentDomain.BaseDirectory;
			Console.Clear();
			Dual.Watermark();
			CommandMenager commandMenager = new CommandMenager();
			loop = true;
			do
			{
				bool action = false;
				Console.Write(DIR + ">");
				string input = Console.ReadLine();
				Log.AddLogEvent(new LogEvent("User Action - Input From User ID:" + user._Id, input, LogEvent.Type.Normal, DateTime.Now));
				action = commandMenager.ExecuteCommand(input,user);
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
