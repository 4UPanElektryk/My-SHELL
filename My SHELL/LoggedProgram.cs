using MyShell.Commands;
using MyShell.Essentials;
using SimpleLogs4Net;
using System;

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
			while (loop)
			{
				string ShowDIR = DIR.Replace(AppDomain.CurrentDomain.BaseDirectory, "~\\");
				Prompt.ShowPrompt(ShowDIR);
				string input = Console.ReadLine();
				Program.inputs.Add(input);
				Log.Write("User Action - Input: " + input, EType.Normal);
				if (!commandMenager.ExecuteCommand(input))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Incorect command '" + input + "'");
					Console.WriteLine("Type 'Help' or '?' for help");
					Console.ForegroundColor = ConsoleColor.White;
				}
			}
			Console.Clear();
		}
	}
}
