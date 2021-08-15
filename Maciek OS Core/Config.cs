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
		public static string UserPath;
		public static string UserPathOld;
		public static string SettingsPath;
		public static string SettingsPathBackup;
		public static string DebugPath;
		public static bool DebugEnabled;
		public static void LoadConfig()
		{
			string[] file = File.ReadAllLines("config.json");
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
					case "Deug.Path":
						DebugPath = args;
						break;
					case "Deug.Enabled":
						DebugEnabled = bool.Parse(args);
						break;
					default:
						break;
				}
			}
		}
	}
}
