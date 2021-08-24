using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maciek_OS_Core
{
	class Config
	{
		private static string path = "config.json";
		
		public static string UserPath;
		public static string UserPathOld;
		public static string SettingsPath;
		public static string SettingsPathBackup;
		public static string DebugPath;
		public static bool DebugEnabled;
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
						case "Debug.Path":
							DebugPath = args;
							break;
						case "Debug.Enabled":
							DebugEnabled = bool.Parse(args);
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
								"Settings.Path=Settings.cfg",
								"Settings.OldPath=Settings_backup.cfg",
								"Debug.Path=Logs\\",
								"Debug.Enabled=" + Debug_enabled
							};
			File.WriteAllLines(path, file);
		}
		public static void DeleteConfig()
		{
			File.Delete(path);
		}
	}
}
