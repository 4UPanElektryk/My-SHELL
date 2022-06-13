using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;

namespace MShell.Essentials
{
	/// <summary>
	/// Run Self Test
	/// </summary>
	public class RST
	{
		public enum MsgType
		{
			OK,
			Normal,
			Warning,
			Error,
		}
		public static bool RunTest()
		{
			bool error_encounterd = false;
			#region Config Test
			if (File.Exists(Config.path))
			{
				TestMsg("Found Config File", MsgType.OK);
			}
			else
			{
				TestMsg("Config File is Missing", MsgType.Warning);
				error_encounterd = true;
			}
			try
			{
				TestMsg("Attempting Load of Config file", MsgType.Warning);
				Config.Load();
				TestMsg("Load succesfull", MsgType.OK);
			}
			catch (Exception ex)
			{
				TestMsg("Config Load Filed", MsgType.Error);
				TestMsg(ex.Message, MsgType.Error);
				TestMsg("Reseting Config", MsgType.Warning);
				Config.Reset();
				Config.Save();
				error_encounterd = true;
			}
			#endregion
			#region Dependecies Test
			if (File.Exists("MShellUpdater.exe"))
			{
				TestMsg("MShellUpdater.exe found", MsgType.OK);
				Program.FoundUpdater = true;
			}
			else
			{
				TestMsg("MShellUpdater.exe not found", MsgType.Error);
				error_encounterd = true;
			}
			#endregion
			#region Log Initializaion
			try
			{
				TestMsg("Atempting Log initialization", MsgType.Warning);
				new Log(Config._LogsConfig.Path, Config._LogsConfig.Enabled, Config._LogsConfig.Prefix);
				TestMsg("Log initialization Succeded", MsgType.OK);
			}
			catch (Exception ex)
			{
				TestMsg("Log initialization Failed", MsgType.Error);
				TestMsg(ex.Message, MsgType.Error);
				error_encounterd = true;
			}
			#endregion
			#region User Controller initialization
			if (File.Exists(Config._UserConfig.File))
			{
				TestMsg("Found User File", MsgType.OK);
			}
			else
			{
				TestMsg("User File is Missing", MsgType.Warning);
				if (File.Exists(Config._UserConfig.FileBackup))
				{
					TestMsg("Found Backup User File", MsgType.OK);
					TestMsg("Restoring File From Backup", MsgType.Warning);
					File.Copy(Config._UserConfig.FileBackup, Config._UserConfig.File);
				}
				else
				{
					TestMsg("Backup User File is Missing", MsgType.Warning);
				}
			}
			try
			{
				TestMsg("Atempting User Controller initialization", MsgType.Warning);
				new UserController(Config._UserConfig.File, Config._UserConfig.FileBackup);
				TestMsg("User Controller initialization Succeded", MsgType.OK);
			}
			catch (Exception ex)
			{
				TestMsg("User Controller initialization Failed", MsgType.Error);
				TestMsg("We Recomend to rename the User File and restart the program", MsgType.Warning);
				TestMsg(ex.Message, MsgType.Error);
				error_encounterd = true;
			}
			#endregion
			if (error_encounterd)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				return Dual.YesOrNO("Errors has been encountered. \nAre you sure you want to continue?");
            }
            else
            {
				return true;
            }
		}
		private static void TestMsg(string message,MsgType type)
		{
			Console.ResetColor();
			Console.Write("[");
			if (type == MsgType.OK)
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			else if (type == MsgType.Normal)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
			}
			else if (type == MsgType.Warning)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else if (type == MsgType.Error)
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			Console.Write("*");
			Console.ResetColor();
			Console.WriteLine("] " + message);
		}
	}
}
