using System;
using System.IO;
using Newtonsoft.Json;

namespace Maciek_SHELL.Essentials
{
	public class OutputAndInput
	{
		public AppConfig Aplication { get; set; }
		public UserConfig UserController { get; set; }
		public LogsConfig Logs { get; set; }
	}
	class Config
	{
		private static string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";

		public static AppConfig _AppConfig;
		public static UserConfig _UserConfig;
		public static LogsConfig _LogsConfig;
        /// <summary>
		/// Loads the Config from the file
		/// </summary>
		/// <exception cref="IOException"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		public static void LoadConfig()
		{
			if (File.Exists(path))
			{
				string outputstring = File.ReadAllText(path);
				OutputAndInput re = JsonConvert.DeserializeObject<OutputAndInput>(outputstring);
                if (re != null)
                {
					_AppConfig = re.Aplication;
					_UserConfig = re.UserController;
					_LogsConfig = re.Logs;
                }
                else
                {
					throw new IOException("Config is empty");
                }
			}
            else
            {
				throw new FileNotFoundException("Config file not found",path);
            }
		}
        /// <summary>
		/// Saves the current configuration
		/// </summary>
		public static void SaveConfig()
		{
			OutputAndInput outputAndInput = new OutputAndInput()
			{
				Aplication = _AppConfig,
				UserController = _UserConfig,
				Logs = _LogsConfig
			};
			string file = JsonConvert.SerializeObject(outputAndInput,Formatting.Indented);
			File.Delete(path);
			File.WriteAllText(path, file);
		}
        /// <summary>
		/// Resets Config to Default values
		/// </summary>
        public static void ResetConfig()
        {
            _AppConfig = new AppConfig();
            _UserConfig = new UserConfig();
            _LogsConfig = new LogsConfig();
            _AppConfig.Reset();
			_LogsConfig.Reset();
			_UserConfig.Reset();
        }
	}
}
