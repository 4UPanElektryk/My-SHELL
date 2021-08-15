using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maciek_OS_Core.Properties;

namespace Maciek_OS_Core
{
	public class Dual
	{
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
	}
}
