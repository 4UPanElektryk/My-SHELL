using MyShell.Binds;
using MyShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.IO;
using MyShell.Essentials;
using MyShell.Essentials.PreStart;

namespace MyShell.Essentials
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
				TestMsg("Attempting Load of Config file", MsgType.Normal);
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
			#region System Test
			SysDetect.Sys info = SysDetect.Check();
			if (info == SysDetect.Sys.NotSupported)
			{
				TestMsg("Unsuported System",MsgType.Error);
				return false;
			}
			Program.IsUnix = info == SysDetect.Sys.Unix;
			if (Program.IsUnix)
			{
                TestMsg("Unix based System", MsgType.OK);
            }
			else
			{
                TestMsg("Windows based System", MsgType.OK);
            }
			#endregion
			#region Connection Test
			TestMsg("Checking Internet Connection", MsgType.Normal);
			string[] PingDestinations =
			{
				"google.com",
				"github.com",
				"stackoverflow.com"
			};
			foreach (string item in PingDestinations)
			{
				if (CheckUpdates.CheckConnection(item))
				{
					TestMsg("Ping Succesful: " + item, MsgType.OK);
				}
				else
				{
					TestMsg("Ping Failed: " + item, MsgType.Warning);
					error_encounterd = true;
				}
			}
			#endregion
			#region Dependecies Test
			if (File.Exists("Updater.exe"))
			{
				TestMsg("Updater.exe found", MsgType.OK);
				Program.FoundUpdater = true;
			}
			else
			{
				TestMsg("Updater.exe not found", MsgType.Error);
				error_encounterd = true;
			}
			#endregion
			#region Log Initializaion
			try
			{
				TestMsg("Atempting Log initialization", MsgType.Normal);
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
				TestMsg("Atempting User Controller initialization", MsgType.Normal);
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
			#region Binds initialization
			bool filemissing = false;
			if (File.Exists(Config._AppConfig.BindFile))
			{
				TestMsg("Found Bind File", MsgType.OK);
			}
			else
			{
				TestMsg("Bind File is Missing", MsgType.Warning);
				filemissing = true;
			}
			try
			{
				TestMsg("Atempting Bind Manager initialization", MsgType.Normal);
				new BindManager(Config._AppConfig.BindFile);
				TestMsg("Bind Manager initialization Succeded", MsgType.OK);
			}
			catch (Exception ex)
			{
				TestMsg("Bind Manager initialization Failed", MsgType.Error);
				TestMsg(ex.Message, MsgType.Error);
				error_encounterd = true;
			}
			if (filemissing && !error_encounterd)
			{
				BindManager.Save();
				BindManager.Load();
			}
			#endregion

			#region End Data
			if (Config._AppConfig.DevMode)
			{
				Config._AppConfig.DevMode = Dual.YesOrNO("Dev Mode is enabled.\nDo you want to continue in Dev Mode");
				Config.Save();
			}
			if (error_encounterd)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				return Dual.YesOrNO("Errors has been encountered. \nAre you sure you want to continue?");
			}
			else
			{
				return true;
			}
			#endregion
		}
		private static void TestMsg(string message, MsgType type)
		{
			Console.ResetColor();
			Console.Write("[");
			ConsoleColor color;
			if (type == MsgType.OK)
			{
                color = ConsoleColor.Green;
			}
			else if (type == MsgType.Normal)
			{
                color = ConsoleColor.Blue;
			}
			else if (type == MsgType.Warning)
			{
                color = ConsoleColor.Yellow;
			}
			else
			{
                color = ConsoleColor.Red;
			}
			Console.ForegroundColor = color;
			Console.Write("*");
			Console.ResetColor();
			Console.WriteLine("] " + message);
		}
	}
}
