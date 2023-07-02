using MyShell.Binds;
using SimpleLogs4Net;
using System;
using System.IO;
using MyShell.Essentials.PreStart;
using System.Collections.Generic;
using MyShell.Commands;
using System.Threading;

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
		private static Dictionary<MsgType, EType> _types = new Dictionary<MsgType, EType>();
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
			#region Modules Test
			Directory.CreateDirectory(AppContext.BaseDirectory + "Modules\\");
			if (Directory.GetFiles(AppContext.BaseDirectory + "Modules\\","*.dll").Length != 0)
			{
				TestMsg("Initializing Modules", MsgType.Normal);
				foreach (var item in ModLoader.InitModules(AppContext.BaseDirectory + "Modules\\"))
				{
					TestMsg($" - {item.Key} ",item.Value ? MsgType.OK : MsgType.Error);
					if (!item.Value)
					{
						error_encounterd = true;
					}
				}
			}
			#endregion
			#region Log Initializaion
			try
			{
				TestMsg("Atempting Log initialization", MsgType.Normal);
				new LogConfiguration(Config._LogsConfig.Path, Config._LogsConfig.Enabled ? OutputStream.File : OutputStream.None, Config._LogsConfig.Prefix);
				TestMsg("Log initialization Succeded", MsgType.OK);
			}
			catch (Exception ex)
			{
				TestMsg("Log initialization Failed", MsgType.Error);
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
				return Dual.YesOrNO("Errors has been encountered. \nSome commands may be disabled or not finction correctly.\nAre you sure you want to continue?");
			}
			else
			{
				return true;
			}
			#endregion
		}
		private static void TestMsg(string message, MsgType type)
		{
			if (_types.Count == 0)
			{
				_types.Add(MsgType.OK,EType.Normal);
				_types.Add(MsgType.Normal,EType.Informtion);
				_types.Add(MsgType.Warning,EType.Warning);
				_types.Add(MsgType.Error,EType.Error);
			}
			Log.DebugMsg(message, _types[type]);
		}
	}
}
