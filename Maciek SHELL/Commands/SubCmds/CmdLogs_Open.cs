using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using System;
using System.IO;

namespace Maciek_SHELL.Commands.SubCmds
{
	class CmdLogs_Open : SubCmd
	{
		public CmdLogs_Open(string name) : base(name)
		{

		}
		public override bool Execute(string[] args, string input, User user)
		{
			if (user._State == User.Type.Admin || user._State == User.Type.SysAdmin)
			{
				Console.Clear();
				Dual.LogWatermark();
				Console.WriteLine("File nr: ");
				int path = 0;
				bool no = int.TryParse(Console.ReadLine(), out path);
				Console.WriteLine("");
				string p = AppDomain.CurrentDomain.BaseDirectory + Config._LogsConfig.Path + Config._LogsConfig.Prefix + path.ToString() + ".log";
				try
				{
					string[] _file = File.ReadAllLines(@p);
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
				}
				catch
				{
					Dual.Msg("File Not Found", ConsoleColor.Red);
				}
			}
			else
			{
				Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
			}
			return true;
		}
	}
}
