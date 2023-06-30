using MyShell.Essentials;
using System;
using System.IO;
using MyShell.Modules.Base;

namespace MyShell.Commands.SubCmds.Logs
{
	class CmdLogs_Open : SubCmd
	{
		public CmdLogs_Open(string name) : base(name)
		{

		}
		public override bool Execute(string[] args, string input)
		{
			Console.Clear();
			Dual.LogWatermark();
			Console.WriteLine("File nr: ");
			bool no = int.TryParse(Console.ReadLine(), out int path);
			Console.WriteLine("");
			string p = AppDomain.CurrentDomain.BaseDirectory + Essentials.Config._LogsConfig.Path + Essentials.Config._LogsConfig.Prefix + path + ".log";
			string[] _file = new string[1];
			try
			{
				_file = File.ReadAllLines(p);
			}
			catch
			{
				Dual.Msg("File Not Found", ConsoleColor.Red);
				return true;
			}
			int increment = 0;
			foreach (string _item in _file)
			{
				Console.ResetColor();
				if (_item.Contains("["))
				{
					string[] w = Dual.DeleteNullAndEmptyItems(_item.Split("][".ToCharArray()));
					Console.Write("[");
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write(w[0].Split('-')[0]);
					Console.ResetColor();
					Console.Write("-");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(w[0].Split('-')[1]);
					Console.ResetColor();
					Console.Write("][");
					switch (w[1])
					{
						default:
						case "NORMAL":
							break;
						case "INFO":
							Console.ForegroundColor = ConsoleColor.Blue;
							break;
						case "WARNING":
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case "ERROR":
							Console.ForegroundColor = ConsoleColor.DarkRed;
							break;
						case "CRITICAL_ERROR":
							Console.ForegroundColor = ConsoleColor.Red;
							break;
					}
					Console.Write(w[1]);
					Console.ResetColor();
					Console.Write("]");
					if (w[2] == "MULTILINE")
					{
						Console.Write("[MULTILINE][");
						Console.Write(int.Parse(w[3]) - 1);
						Console.Write(":");
						Console.Write(int.Parse(w[4]) - 1);
						Console.WriteLine("]");
					}
					else
					{
						Console.WriteLine(w[2]);
					}
					switch (w[1])
					{
						default:
						case "NORMAL":
							break;
						case "INFO":
							Console.ForegroundColor = ConsoleColor.Blue;
							break;
						case "WARNING":
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case "ERROR":
							Console.ForegroundColor = ConsoleColor.DarkRed;
							break;
						case "CRITICAL_ERROR":
							Console.ForegroundColor = ConsoleColor.Red;
							break;
					}
				}
				else if (_item == "{" || _item == "}")
				{
					increment = 0;
					if (_item == "}")
					{
						Console.ResetColor();
						Console.WriteLine("}");
					}
					else
					{
						Console.WriteLine("{");
					}
				}
				else
				{
					Console.WriteLine(increment + "." + _item);
					increment++;
				}
			}
			Console.ReadKey();
			Console.Clear();
			Dual.Watermark();
			return true;
		}
	}
}
