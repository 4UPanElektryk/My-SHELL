using System;
using System.IO;

namespace Maciek_SHELL.Essentials
{
	class Config
	{
		private static string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";

		public static bool AppAutoUpdate = false;
		public static string AppLicense = "null";
		public static string LogsPath = "Logs\\";
        public static bool LogsEnabled = true;
        public static string LogsUserPath = "Logs\\User\\";
        public static string LogsPrefix = "LOG";
        public static string NanoExtentions = "NanoExtentions\\";
        public static string UserFile = "Users.dat";
        public static string UserFileOld = "OldUsers.dat";
        public static void LoadConfig()
		{
			if (File.Exists(path))
			{
				string[] file = File.ReadAllLines(path);
				foreach (string item in file)
				{
                    //check if line is comment
                    if (!item.Contains("#"))
					{
						string[] data = item.Split('=');
						string args = data[1];
						switch (data[0])
						{
							case "User.Path":
								UserFile = args;
								break;
							case "User.OldPath":
								UserFileOld = args;
								break;
							case "Aplication.License":
								AppLicense = args;
								break;
							case "Aplication.CheckForUpdates":
                                AppAutoUpdate = Convert.ToBoolean(args);
                                break;
							case "Nano.Extentions":
								break;
							case "Logs.Path":
								LogsPath = args;
								break;
							case "Logs.UserLogsPath":
								LogsUserPath = args;
								break;
							case "Logs.Enabled":
								LogsEnabled = Convert.ToBoolean(args);
								break;
							case "Logs.Prefix":
								LogsPrefix = args;
								break;
							default:
								break;
						}
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
                                "Aplication.CheckForUpdates=false",
                                "Nano.Extentions=NanoExtentions\\",
								"Logs.Path=Logs\\",
								"Logs.UserLogsPath=Logs\\UserLogs\\",
								"Logs.Enabled=" + Debug_enabled,
                                "Logs.Prefix=LOG",
                            };
			File.WriteAllLines(path, file);
		}
		public static void DeleteConfig()
		{
			File.Delete(path);
		}
	}
}
