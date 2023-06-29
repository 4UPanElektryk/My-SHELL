using MyShell.Essentials;
using MyShell.Properties;
using SimpleLogs4Net;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace MyShell
{
    class Program
    {
        public static bool IsUnix;
        public static bool UseASCII;
		public static bool FoundUpdater;
		public static bool Experimental;
		public static List<string> inputs;
        public static PerformanceCounter cpuCounter;
		public static PerformanceCounter ramCounter;
		public static Process currentProc;
		static void Main(string[] args)
		{
            Experimental = true;
			FoundUpdater = false;
			currentProc = Process.GetCurrentProcess();
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			ramCounter = new PerformanceCounter("Memory", "Available MBytes");
			cpuCounter.NextValue();
			Console.Title = "My Shell " + Settings.Default["Version"].ToString();
            if (Experimental)
            {
                Console.Title += " Experimental";
            }
            bool testpassed = RST.RunTest();
            Console.ResetColor();
            if (!testpassed)
            {
                return;
            }
            UseASCII = Config._AppConfig.UseAsciiOnly;
			Console.ResetColor();
			Console.Clear();
			new MakeCrashLog(Config._LogsConfig.Path + "crash.log");
            try
            {
				LoggedProgram.LoggedMain();
			}
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
				MakeCrashLog.WriteLog(ex.Message,ex.Source,ex.StackTrace,inputs);
                if (Config._AppConfig.DevMode)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					if (Dual.YesOrNO("Do You want to Continue with code?"))
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
				Console.ForegroundColor = ConsoleColor.White;
			}

        }
    }
}
