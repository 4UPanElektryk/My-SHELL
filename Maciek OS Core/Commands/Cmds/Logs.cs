using MOS_User_Menager_Integration;
using System;
using MOS_Log_Integration;
using Maciek_OS_Core.Essentials;
using System.Threading;
using System.IO;

namespace Maciek_OS_Core.Commands.Cmds
{
    class Logs : Cmd
    {
		public Logs(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
        {
			int nbt = args.Length;
			bool action = false;
			if (nbt > 1)
			{
				if (nbt == 2)
				{
					if (args[1] == "-clear")
					{
						action = true;
						if (user._State == User.Type.SysAdmin)
						{
							Console.Clear();
							Dual.LogWatermark();
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.Write("Do you want to delete logs? Y | N >>");
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                Console.WriteLine();
								foreach (string item in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Config.LogsPath))
								{
									Dual.Msg("Log Deleted: '" + item + "'", ConsoleColor.Red);
								}
								Log.ClearLogs();
							}
                            else
                            {
                                Console.WriteLine();
								Dual.Msg("Deletion of logs has been canceled", ConsoleColor.Green);
							}
							Console.ReadKey();
							Console.Clear();
							Dual.Watermark();
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
					if (args[1] == "-open")
					{
						action = true;
						if (user._State == User.Type.Admin || user._State == User.Type.SysAdmin)
						{
							Console.Clear();
							Dual.LogWatermark();
							Console.WriteLine("File nr: ");
							int path = 0;
							bool no = int.TryParse(Console.ReadLine(), out path);
                            Console.WriteLine("");
                            if (true)
                            {
								string p = AppDomain.CurrentDomain.BaseDirectory + Config.LogsPath + "LOG" + path.ToString() + ".log";
								try
								{
									string[] _file = File.ReadAllLines(@p);
									foreach (string _item in _file)
									{
										string[] w = _item.Split('|');
										Console.Write("[" + w[0] + "]");
										bool nok = false;
										switch (w[1])
										{
											case "{[NORMAL]}":
												nok = false;
												break;
											case "{[INFO]}":
												nok = false;
												Console.ForegroundColor = ConsoleColor.Blue;
												break;
											case "{[WARRNING]}":
												nok = false;
												Console.ForegroundColor = ConsoleColor.Yellow;
												break;
											case "{[ERROR]}":
												nok = false;
												Console.ForegroundColor = ConsoleColor.DarkRed;
												break;
											case "{[CRITICAL_ERROR]}":
												nok = true;
												Console.ForegroundColor = ConsoleColor.Red;
												break;
											default:
												break;
										}
										Console.WriteLine(w[1]);
										if (!nok)
										{
											Console.ForegroundColor = ConsoleColor.White;
										}
										Console.WriteLine("Name of action: \n" + w[2]);
										Console.WriteLine("Action: \n" + w[3]);
										Console.WriteLine("");
										Console.ForegroundColor = ConsoleColor.White;
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
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
					if (args[1] == "-state")
					{
						action = true;
						if (user._State == User.Type.SysAdmin)
						{
							if (Config.LogsEnabled)
							{
								Dual.Msg("Logs are enabled", ConsoleColor.Yellow);
							}
							else
							{
								Dual.Msg("Logs are disabled", ConsoleColor.Yellow);
							}
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
				}
				if (nbt == 3)
				{
					if (args[1] == "-state" && args[2] == "-on")
					{
						action = true;
						if (user._State == User.Type.SysAdmin)
						{
							Config.DeleteConfig();
							Config.CreateNewConfig(true);
							Config.LoadConfig();
							Log.ChangeEnable(Config.LogsEnabled);
							Dual.Msg("Logs are now enabled", ConsoleColor.Yellow);
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
					if (args[1] == "-state" && args[2] == "-off")
					{
						action = true;
						if (user._State == User.Type.SysAdmin)
						{
							Config.DeleteConfig();
							Config.CreateNewConfig(false);
							Config.LoadConfig();
							Log.ChangeEnable(Config.LogsEnabled);
							Dual.Msg("Logs are now disabled", ConsoleColor.Yellow);
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
				}
			}
            else
            {
				action = true;
				string[] f = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Config.LogsPath);
				foreach (string item in f)
				{
					string x = AppDomain.CurrentDomain.BaseDirectory;
					Console.WriteLine(item.TrimStart(x.ToCharArray()));
				}
			}
			return action;
		}
    }
}
