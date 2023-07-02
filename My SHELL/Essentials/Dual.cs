using MyShell.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyShell.Essentials
{
	public static class Dual
	{
		#region Watermarks
		public static void LogWatermark()
		{
			if (!Program.UseASCII)
			{
				Console.OutputEncoding = Encoding.UTF8;
			}
			if (Program.Experimental)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			if (Program.UseASCII)
			{
				Console.WriteLine("+-----------------------+");
				Console.WriteLine("| MySH Log Opener ©" + GetCompilationTime().Year + " |");
				Console.WriteLine("| Ver   " + Settings.Default["Version"].ToString() + "   CL  " + GetCompilationDDMMString() + " |");
				if (Program.Experimental)
				{
					Console.WriteLine("| Experimental     " + Settings.Default["Build"].ToString() + " |");
				}
				Console.WriteLine("+-----------------------+");
			}
			else
			{
				Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
				Console.WriteLine("┃ MySH Log Opener ©" + GetCompilationTime().Year + " ┃");
				Console.WriteLine("┃ Ver   " + Settings.Default["Version"].ToString() + "   CL  " + GetCompilationDDMMString() + " ┃");
				if (Program.Experimental)
				{
					Console.WriteLine("┃ Experimental     " + Settings.Default["Build"].ToString() + " ┃");
				}
				Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		public static void NanoWatermark()
		{
			if (!Program.UseASCII)
			{
				Console.OutputEncoding = Encoding.UTF8;
			}
			if (Program.Experimental)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			if (Program.UseASCII)
			{
				Console.WriteLine("+----------------------+");
				Console.WriteLine("|  Nano Editor  ©" + GetCompilationYYYYString() + "  |");
				Console.WriteLine("|  Ver " + Settings.Default["Version"].ToString() + "   CL " + GetCompilationDDMMString() + "  |");
				if (Program.Experimental)
				{
					Console.WriteLine("|  Experimental  " + Settings.Default["Build"].ToString() + "  |");
				}
				Console.WriteLine("+----------------------+");
			}
			else
			{
				Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━┓");
				Console.WriteLine("┃  Nano Editor  ©" + GetCompilationYYYYString() + "  ┃");
				Console.WriteLine("┃  Ver " + Settings.Default["Version"].ToString() + "   CL " + GetCompilationDDMMString() + "  ┃");
				if (Program.Experimental)
				{
					Console.WriteLine("┃  Experimental  " + Settings.Default["Build"].ToString() + "  ┃");
				}
				Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━┛");
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		public static void Watermark()
		{
			if (Program.Experimental)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			if (Program.UseASCII)
			{
				Console.WriteLine("+-------------------+");
				Console.WriteLine("| My SHELL    ©" + GetCompilationYYYYString() + " |");
				Console.WriteLine("| Ver " + Settings.Default["Version"].ToString() + "  CL " + GetCompilationDDMMString() + " |");
				if (Program.Experimental)
				{
					Console.WriteLine("| Experimental " + Settings.Default["Build"].ToString() + " |");
				}
				Console.WriteLine("+-------------------+");
			}
			else
			{
				Console.OutputEncoding = Encoding.UTF8;
				Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━┓");
				Console.WriteLine("┃ My SHELL    ©" + GetCompilationYYYYString() + " ┃");
				Console.WriteLine("┃ Ver " + Settings.Default["Version"].ToString() + "  CL " + GetCompilationDDMMString() + " ┃");
				if (Program.Experimental)
				{
					Console.WriteLine("┃ Experimental " + Settings.Default["Build"].ToString() + " ┃");
				}
				Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━┛");
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		#endregion
		#region Msgs
		public static void Msg(string text, ConsoleColor Color, ConsoleColor BGColor = ConsoleColor.Black)
		{
			ConsoleColor BeforeColor = Console.ForegroundColor;
			ConsoleColor BeforeBgColor = Console.BackgroundColor;
			Console.BackgroundColor = BGColor;
			Console.ForegroundColor = Color;
			Console.WriteLine(text);
			Console.ForegroundColor = BeforeColor;
			Console.BackgroundColor = BeforeBgColor;
		}
		#endregion
		#region Colors
		public static ConsoleColor IntToColor(int n)
		{
			return (ConsoleColor)n;
		}
		public static int ColorToInt(ConsoleColor c)
		{
			return (int)c;
		}
		#endregion
		#region Compilation Time
		public static DateTime GetCompilationTime()
		{
			return File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
		}
		public static string GetCompilationDDMMString()
		{
			return File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("dd.MM");
		}
		public static string GetCompilationYYYYString()
		{
			return File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("yyyy");
		}
		#endregion
		#region User Input
		public static bool YesOrNO(string message)
		{
			Console.WriteLine(message);
			Console.Write("[Y]es or [N]o >>");
			ConsoleKey input = Console.ReadKey().Key;
			Console.WriteLine();
			if (input == ConsoleKey.Y)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static void AwaitingEnter()
		{
			Console.WriteLine("Press Enter to continue...");
			ConsoleKey key = ConsoleKey.NoName;
			while (key != ConsoleKey.Enter)
			{
				key = Console.ReadKey(true).Key;
			}
		}
		#endregion
		public static string[] DeleteNullAndEmptyItems(string[] inputstring)
		{
			List<string> strings = new List<string>();
			foreach (string item in inputstring)
			{
				if (item != null && item != "")
				{
					strings.Add(item);
				}
			}
			return strings.ToArray();
		}
		public static string GetThePath(string path)
		{
			string actualpath = path;
			actualpath = path.Replace("~\\", AppDomain.CurrentDomain.BaseDirectory);
			if (!actualpath.Contains(':'))
			{
				actualpath = LoggedProgram.DIR + actualpath;
			}
			return actualpath;
		}
	}
}
