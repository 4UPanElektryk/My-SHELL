using MyShell.Commands;
using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.Collections.Generic;
namespace MyShell
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
			Program.inputs = new List<string>();
			do
			{
				string ShowDIR = DIR.Replace(AppDomain.CurrentDomain.BaseDirectory, "~\\");
				bool action = false;
				string input = Prompt.ShowPropt(user, ShowDIR);
                Program.inputs.Add(input);
				Log.AddEvent(new Event("User Action - Input From User ID:" + user._Id + " Input: " + input, EType.Normal));
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
