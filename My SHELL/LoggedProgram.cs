
using MyShell.Commands;
using MyShell.Essentials;
using SimpleLogs4Net;
using System;
using System.Collections.Generic;
namespace MyShell
{
	class LoggedProgram
	{
		public static string DIR;
		public static bool loop;
		public static void LoggedMain()
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
				string input = Prompt.ShowPropt(ShowDIR);
                Program.inputs.Add(input);
				Log.AddEvent(new Event("User Action - Input: " + input, EType.Normal));
				action = commandMenager.ExecuteCommand(input);
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
