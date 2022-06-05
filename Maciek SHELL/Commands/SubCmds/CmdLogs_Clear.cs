using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System;
using System.IO;

namespace Maciek_SHELL.Commands.SubCmds
{
	public class CmdLogs_Clear : SubCmd
	{
		public CmdLogs_Clear(string name) : base(name)
		{
			_Help = "Deletes the logs";
		}

		public override bool Execute(string[] args, string input, User user)
		{
			if (user._State == User.Type.SysAdmin)
			{
				Console.Clear();
				Dual.LogWatermark();
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (Dual.YesOrNO("Do you want to delete logs?"))
				{
					Console.WriteLine();
					foreach (string item in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Config._LogsConfig.Path))
					{
						if (item.EndsWith(".log"))
						{
							Dual.Msg("Log File Deleted: '" + item + "'", ConsoleColor.Red);
						}
						else
						{
							Dual.Msg("File Skipped: '" + item + "'", ConsoleColor.Yellow);
						}
					}
					Log.ClearLogs();
				}
				else
				{
					Console.WriteLine();
					Dual.Msg("Deletion of logs has been canceled", ConsoleColor.Green);
				}
				Console.ReadKey(true);
				Console.Clear();
				Dual.Watermark();
			}
			else
			{
				Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
			}
			return true;
		}
	}
}
