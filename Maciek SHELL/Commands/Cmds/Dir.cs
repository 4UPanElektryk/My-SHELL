using MOS_User_Menager_Integration;
using System.IO;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
    class Dir : Cmd
    {
		public Dir(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
        {
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Files In Directory: " + LoggedProgram.DIR);
			foreach (string item in Directory.GetDirectories(LoggedProgram.DIR))
			{
				string[] text = item.Split("\\".ToCharArray());
				Console.Write("Directory: " + text[text.Length - 1]);
				for (int i = text[text.Length - 1].Length; i < 86; i++)
				{
					Console.Write(" ");
				}
				Console.WriteLine("DIR");
			}
			foreach (string item in Directory.GetFiles(LoggedProgram.DIR))
			{
				string[] text = item.Split("\\".ToCharArray());
				string[] extention = text[text.Length - 1].Split('.');

				Console.Write("File: " + text[text.Length - 1]);
				for (int i = text[text.Length - 1].Length; i < 90; i++)
				{
					Console.Write(" ");
				}
				int l = 0;
				foreach (string itm in extention)
				{
					if (l == 0)
					{

					}
					else
					{
						Console.Write("." + itm.ToUpper());
					}
					l++;
				}
				Console.WriteLine();
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			return true;
		}
    }
}
