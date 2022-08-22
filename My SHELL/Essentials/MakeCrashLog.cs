using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpleLogs4Net;
using Newtonsoft.Json;

namespace MyShell.Essentials
{
	public class MakeCrashLog
	{
		public static string Path;
		public MakeCrashLog(string path)
		{
			Path = path;
		}
		public static void WriteLog(string exeption, string sender, string trace,List<string> commands)
		{
			if (File.Exists(Path))
			{
				File.Delete(Path);
			}
			CrasshLog log = new CrasshLog()
			{
				UTCDateAndTime = DateTime.UtcNow,
				Exeption = exeption,
				Sender = sender,
				Trace = trace,
				CommandsLeadingToCrash = commands,

			};
			if (Config._LogsConfig.Enabled)
			{
				int i = 0;
				foreach (var item in Directory.GetFiles(Config._LogsConfig.Path))
				{
					string fin = Dual.TrimStart(item, Config._LogsConfig.Path+Config._LogsConfig.Prefix);
					fin = Dual.TrimEnd(fin, 4);
					int g = int.Parse(fin);
					if (g > i)
					{
						i = g;
					}
				}
				string gg = Config._LogsConfig.Path + Config._LogsConfig.Prefix + i + ".log";
				log.LatestLogPath = gg;
				log.LatestLog = File.ReadAllLines(gg).ToList();
			}
			else
			{
				log.LatestLog = new List<string>();
				log.LatestLogPath = "Logs Disabled";
			}
			File.WriteAllText(Path, JsonConvert.SerializeObject(log,Formatting.Indented));
		}
	}
	public class CrasshLog
	{
		public DateTime UTCDateAndTime { get; set; }
		public string Exeption { get; set; }
		public string Sender { get; set; }
		public string Trace { get ; set; }
		public List<string> CommandsLeadingToCrash { get; set; }
		public string LatestLogPath { get; set; }
		public List<string> LatestLog { get; set; }
	}
}
