using System;
using System.IO;

namespace Maciek_OS_Core.Essentials
{
	class Config
	{
		private static string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";
		
		public static string UserPath;
		public static string UserPathOld;
		public static string SettingsPath;
		public static string SettingsPathBackup;
		public static string AppLicense;
		public static string LogsPath;
		public static string LogsUserPath;
		public static bool LogsEnabled;
		public static void LoadConfig()
		{
			if (File.Exists(path))
			{
				string[] file = File.ReadAllLines(path);
				foreach (string item in file)
				{
					string[] data = item.Split('=');
					string args = data[1];
					switch (data[0])
					{
						case "User.Path":
							UserPath = args;
							break;
						case "User.OldPath":
							UserPathOld = args;
							break;
						case "Settings.Path":
							SettingsPath = args;
							break;
						case "Settings.OldPath":
							SettingsPathBackup = args;
							break;
						case "Aplication.License":
							AppLicense = args;
							break;
						case "Logs.Path":
							LogsPath = args;
                            break;
                        case "Logs.UserLogsPath=Logs\\UserLogs\\":
							LogsUserPath = args;
                            break;
						case "Logs.Enabled":
							LogsEnabled = bool.Parse(args);
							break;
						default:
							break;
					}
				}
			}
			else
			{
				throw new FileNotFoundException("Can not find configuration file");
			}
		}
		public static void CreateNewConfig(bool Debug_enabled)
		{
			string[] file = {
								"User.Path=Users.dat",
								"User.OldPath=UsersOld.dat",
								"Aplication.License=null",
								"Logs.Path=Logs\\",
								"Logs.UserLogsPath=Logs\\UserLogs\\",
								"Logs.Enabled=" + Debug_enabled
							};
			File.WriteAllLines(path, file);
		}
		public static void DeleteConfig()
		{
			File.Delete(path);
		}
	}
}
