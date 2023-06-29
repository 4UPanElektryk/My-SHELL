using Newtonsoft.Json;
using System;
using System.IO;

namespace MyShell.Essentials
{
    public class OutputAndInput
    {
        public AppConfig Application { get; set; }
        public LogsConfig Logs { get; set; }
    }
    class Config
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";

        public static AppConfig _AppConfig;
        /// <summary>
        /// Stores the data for SimpleLogs4Net
        /// </summary>
        public static LogsConfig _LogsConfig;
        /// <summary>
		/// Loads the Config from the file
		/// </summary>
		/// <exception cref="IOException"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		public static void Load()
        {
            if (File.Exists(path))
            {
                string outputstring = File.ReadAllText(path);
                OutputAndInput re = JsonConvert.DeserializeObject<OutputAndInput>(outputstring);
                if (re != null)
                {
                    _AppConfig = re.Application;
                    _LogsConfig = re.Logs;
                }
                else
                {
                    throw new IOException("Config is empty");
                }
            }
            else
            {
                throw new FileNotFoundException("Config file not found", path);
            }
        }
        /// <summary>
		/// Saves the current configuration
		/// </summary>
		public static void Save()
        {
            OutputAndInput outputAndInput = new OutputAndInput()
            {
                Application = _AppConfig,
                Logs = _LogsConfig
            };
            string file = JsonConvert.SerializeObject(outputAndInput, Formatting.Indented);
            File.Delete(path);
            File.WriteAllText(path, file);
        }
        /// <summary>
		/// Resets Config to Default values
		/// </summary>
        public static void Reset()
        {
            _AppConfig = new AppConfig();
            _LogsConfig = new LogsConfig();
            _AppConfig.Reset();
            _LogsConfig.Reset();
        }
    }
}
