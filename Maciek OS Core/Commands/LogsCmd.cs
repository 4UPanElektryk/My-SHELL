using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MOS_Log_Integration;
using MOS_User_Menager_Integration;

namespace Maciek_OS_Core.Commands
{
	class LogsCmd
	{
		private User _User;
		public bool Execute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
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
							Log.ClearLogs();
							Console.ReadKey();
							Dual.Watermark();
							Console.Clear();
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
							int path = int.Parse(Console.ReadLine());
							Console.WriteLine("");
							string p = AppDomain.CurrentDomain.BaseDirectory + Config.DebugPath + "LOG" + path.ToString() + ".log";
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
							if (Config.DebugEnabled)
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
							Log.ChangeEnable(Config.DebugEnabled);
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
							Log.ChangeEnable(Config.DebugEnabled);
							Dual.Msg("Logs are now disabled", ConsoleColor.Yellow);
						}
						else
						{
							Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
						}
					}
				}
			}
			return action;
		}
		public bool ScriptExecute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
			bool action = false;
			return action;
		}
	}
}
