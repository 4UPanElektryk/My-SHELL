using MShell.Commands;
using MShell.Essentials;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.Threading;
namespace MShell
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
				string ShowDIR = DIR.ToLower().Replace(AppDomain.CurrentDomain.BaseDirectory.ToLower(), "~\\");
				bool action = false;
				string input = Prompt.ShowPropt(user, ShowDIR);
				Log.AddEvent(new Event("User Action - Input From User ID:" + user._Id + " Input: " + input, Event.Type.Normal, DateTime.Now));
				action = commandMenager.ExecuteCommand(input, user);
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
			Dual.AwaitingEnter();
			Console.Clear();
			Dual.Watermark();
		}
	}
}
