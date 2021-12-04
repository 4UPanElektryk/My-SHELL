using System;
using System.Linq;
using System.Text;
using Maciek_OS_Core.Properties;

namespace Maciek_OS_Core.Essentials
{
	public class Dual
	{
		public static void LogWatermark()
		{
			Console.OutputEncoding = Encoding.Unicode;
			if ((bool)Settings.Default["Experimental"])
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			Console.WriteLine("+---------------------------+");
			Console.WriteLine("|  Maciek Log Opener ©" + Settings.Default["Year"].ToString() + "  |");
			Console.WriteLine("|  Ver   " + Settings.Default["Version"].ToString() + "   CL    " + Settings.Default["Compiled"].ToString() + "  |");
			if ((bool)Settings.Default["Experimental"])
			{
				Console.WriteLine("|  Experimental       " + Settings.Default["Build"].ToString() + "  |");
			}
			Console.WriteLine("+---------------------------+");
			Console.ForegroundColor = ConsoleColor.White;
		}
		public static void NanoWatermark()
        {
			Console.OutputEncoding = Encoding.Unicode;
			if ((bool)Settings.Default["Experimental"])
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			Console.WriteLine("+----------------------+");
			Console.WriteLine("|  Nano Editor  ©" + Settings.Default["Year"].ToString() + "  |");
			Console.WriteLine("|  Ver " + Settings.Default["Version"].ToString() + "   CL " + Settings.Default["Compiled"].ToString() + "  |");
			if ((bool)Settings.Default["Experimental"])
			{
				Console.WriteLine("|  Experimental  " + Settings.Default["Build"].ToString() + "  |");
			}
			Console.WriteLine("+----------------------+");
			Console.ForegroundColor = ConsoleColor.White;
		}
		public static void Watermark()
		{
			Console.OutputEncoding = Encoding.Unicode;
			if ((bool)Settings.Default["Experimental"])
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			Console.WriteLine("+----------------------+");
			Console.WriteLine("|  Maciek Basic ©" + Settings.Default["Year"].ToString() + "  |");
			Console.WriteLine("|  Ver " + Settings.Default["Version"].ToString() + "   CL " + Settings.Default["Compiled"].ToString() + "  |");
			if ((bool)Settings.Default["Experimental"])
			{
				Console.WriteLine("|  Experimental  " + Settings.Default["Build"].ToString() + "  |");
			}
			Console.WriteLine("+----------------------+");
			if (!Program.Activated)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("PRODUKT NIE ZOSTAŁ AKTYWOWANY LUB LICENCJA JEST NIE POPRAWNA");
				Console.WriteLine("Skontaktuj się z administratorem lub deweloperem");
				
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		public static void Msg(string text, ConsoleColor Color, ConsoleColor ColorAfter = ConsoleColor.White, ConsoleColor BGColor = ConsoleColor.Black, ConsoleColor BGColorAfter = ConsoleColor.Black)
		{
			Console.BackgroundColor = BGColor;
			Console.ForegroundColor = Color;
			Console.WriteLine(text);
			Console.ForegroundColor = ColorAfter;
			Console.BackgroundColor = BGColorAfter;
		}
		public static string TrimStart(string text, string trimText)
        {
			string p = trimText;
			string path = "";
			int startfrom = p.Length;
			int j = 0;
			foreach (char item in text.ToArray())
			{
				j++;
				if (j > startfrom)
				{
					path = path + item;
				}
			}
			return path;
		}
		public static string TrimEnd(string text, int chars)
		{
			string path = "";
			int startfrom = text.Length - chars;
			int j = 0;
			foreach (char item in text.ToArray())
			{
				j++;
				if (j <= startfrom)
				{
					path = path + item;
				}
			}
			return path;
		}
		public static void showMsg(string[] text, ConsoleColor Color, ConsoleColor BGColor = ConsoleColor.Black)
        {
			Console.ForegroundColor = Color;
			Console.BackgroundColor = BGColor;
			int x = Console.CursorLeft;
			int y = Console.CursorTop;
			int l = 0;
            foreach (string item in text)
            {
                if (l < item.Length)
                {
					l = item.Length;
                }
            }
			int m = (Console.WindowWidth / 2) - ((l + 2) / 2);
			int jl = (Console.WindowHeight / 2) - ((text.Length + 2) / 2);
			int line = jl;
			Console.SetCursorPosition(m, line);
			Console.Write("+");
            for (int i = 0; i < l + 2; i++)
            {
                Console.Write("-");
            }
			Console.WriteLine("+");
			line++;
			Console.SetCursorPosition(m, line);
			foreach (string item in text)
            {
                Console.Write("| " + item);
				for (int i = item.Length; i < l; i++)
				{
					Console.Write(" ");
				}
				Console.WriteLine(" |");
				line++;
				Console.SetCursorPosition(m, line);
			}
			Console.Write("+");
			for (int i = 0; i < l + 2; i++)
			{
				Console.Write("-");
			}
			Console.WriteLine("+");
			line++;
			Console.SetCursorPosition(m, line);
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.SetCursorPosition(x, y);
		}
		public static ConsoleColor IntToColor(int n)
		{
			ConsoleColor color;
			switch (n)
			{
				case 0: color = ConsoleColor.Black; break;
				case 1: color = ConsoleColor.DarkBlue; break;
				case 2: color = ConsoleColor.DarkGreen; break;
				case 3: color = ConsoleColor.DarkCyan; break;
				case 4: color = ConsoleColor.DarkRed; break;
				case 5: color = ConsoleColor.DarkMagenta; break;
				case 6: color = ConsoleColor.DarkYellow; break;
				case 7: color = ConsoleColor.Gray; break;
				case 8: color = ConsoleColor.DarkGray; break;
				case 9: color = ConsoleColor.Blue; break;
				case 10: color = ConsoleColor.Green; break;
				case 11: color = ConsoleColor.Cyan; break;
				case 12: color = ConsoleColor.Red; break;
				case 13: color = ConsoleColor.Magenta; break;
				case 14: color = ConsoleColor.Yellow; break;
				case 15: color = ConsoleColor.White; break;
				default:
					color = ConsoleColor.White;
					break;
			}
			return color;
		}
		public static int ColorToInt(ConsoleColor c)
        {
			int color = 0;
			switch (c)
            {
				case ConsoleColor.Black: color = 0; break;
				case ConsoleColor.DarkBlue: color = 1; break;
				case ConsoleColor.DarkGreen: color = 2; break;
				case ConsoleColor.DarkCyan: color = 3; break;
				case ConsoleColor.DarkRed: color = 4; break;
				case ConsoleColor.DarkMagenta: color = 5; break;
				case ConsoleColor.DarkYellow: color = 6; break;
				case ConsoleColor.Gray: color = 7; break;
				case ConsoleColor.DarkGray: color = 8; break;
				case ConsoleColor.Blue: color = 9; break;
				case ConsoleColor.Green: color = 10; break;
				case ConsoleColor.Cyan: color = 11; break;
				case ConsoleColor.Red: color = 12; break;
				case ConsoleColor.Magenta: color = 13; break;
				case ConsoleColor.Yellow: color = 14; break;
				case ConsoleColor.White: color = 15; break;
            }
			return color;
        }
	}
}
