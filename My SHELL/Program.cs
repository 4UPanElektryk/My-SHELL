using MyShell.Essentials;
using MyShell.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace MyShell
{
	class Program
	{
		public static bool UseASCII;
		public static bool FoundUpdater;
		public static bool Experimental;
		public static List<string> inputs;
		public static PerformanceCounter cpuCounter;
		public static PerformanceCounter ramCounter;
		public static Process currentProc;
		static void Main(string[] args)
		{
			#region Init
#if DEBUG
			Experimental = true;
#else
			Experimental = false;
#endif
			inputs = new List<string>();
			FoundUpdater = false;
			currentProc = Process.GetCurrentProcess();
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			ramCounter = new PerformanceCounter("Memory", "Available MBytes");
			cpuCounter.NextValue();
			Console.Title = !Experimental ? $"My Shell {Settings.Default["Version"]}" : $"My Shell {Settings.Default["Version"]} Experimental";
			Console.ResetColor();
			if (!RST.RunTest())
			{
				return;
			}
			UseASCII = Config._AppConfig.UseAsciiOnly;
			Console.ResetColor();
			Console.Clear();
			new MakeCrashLog(Config._LogsConfig.Path + "crash.log");
			#endregion
			//try {
				LoggedProgram.LoggedMain();
			/*}
			#region Exception handeling
			catch (Exception ex)
			{
				Log.Write("Aplication Crashed Message: " + ex.Message, EType.Error);
				Console.ForegroundColor = ConsoleColor.Red;
				string[] strings =
				{
					"Error: " + ex.Message,
					ex.Source,
					ex.StackTrace,
					"Something went wrong"
				};
				MakeCrashLog.WriteLog(ex,inputs);
				if (Config._AppConfig.DevMode)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					if (Dual.YesOrNO("Do You want to Continue anyway?"))
					{
						LoggedProgram.LoggedMain();
						Console.WriteLine("");
					}
					else
					{
						Console.WriteLine("");
					}
				}
				Console.ReadKey();
				Console.ResetColor();
			}
			#endregion*/

		}
	}
}
