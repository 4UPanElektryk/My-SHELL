using MShell.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MShell.Essentials
{
    public static class Dual
    {
        #region Watermarks
        public static void LogWatermark()
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (Program.Experimental)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ MySH Log Opener ©" + GetCompilationTime().Year + " ┃");
            Console.WriteLine("┃ Ver   " + Settings.Default["Version"].ToString() + "   CL  " + GetCompilationDDMMString() + " ┃");
            if (Program.Experimental)
            {
                Console.WriteLine("┃ Experimental     " + Settings.Default["Build"].ToString() + " ┃");
            }
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void NanoWatermark()
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (Program.Experimental)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|  Nano Editor  ©" + GetCompilationYYYYString() + "  |");
            Console.WriteLine("|  Ver " + Settings.Default["Version"].ToString() + "   CL " + GetCompilationDDMMString() + "  |");
            if (Program.Experimental)
            {
                Console.WriteLine("|  Experimental  " + Settings.Default["Build"].ToString() + "  |");
            }
            Console.WriteLine("+----------------------+");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Watermark()
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (Program.Experimental)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ My SHELL    ©" + GetCompilationYYYYString() + " ┃");
            Console.WriteLine("┃ Ver " + Settings.Default["Version"].ToString() + "  CL " + GetCompilationDDMMString() + " ┃");
            if (Program.Experimental)
            {
                Console.WriteLine("┃ Experimental " + Settings.Default["Build"].ToString() + " ┃");
            }
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━┛ ");
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
        public static void ShowMsg(string[] text, ConsoleColor Color, ConsoleColor BGColor = ConsoleColor.Black)
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
        #endregion
        #region Trim strings
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
        #endregion
        #region colors
        public static ConsoleColor IntToColor(int n)
        {
            ConsoleColor color;
            switch (n)
            {
                //Black
                case 0: color = ConsoleColor.Black; break;
                //Blue
                case 1: color = ConsoleColor.DarkBlue; break;
                //Green
                case 2: color = ConsoleColor.DarkGreen; break;
                //Aqua
                case 3: color = ConsoleColor.DarkCyan; break;
                //Red
                case 4: color = ConsoleColor.DarkRed; break;
                //Purple
                case 5: color = ConsoleColor.DarkMagenta; break;
                //Yellow
                case 6: color = ConsoleColor.DarkYellow; break;
                //White
                case 7: color = ConsoleColor.Gray; break;
                //Gray
                case 8: color = ConsoleColor.DarkGray; break;
                //Light Blue
                case 9: color = ConsoleColor.Blue; break;
                //Light Green
                case 10: color = ConsoleColor.Green; break;
                //Light Aqua
                case 11: color = ConsoleColor.Cyan; break;
                //Light Red
                case 12: color = ConsoleColor.Red; break;
                //Light Purple
                case 13: color = ConsoleColor.Magenta; break;
                //Light Yellow
                case 14: color = ConsoleColor.Yellow; break;
                //Bright White
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
        public static void ProgressBar(float percent, ConsoleColor color, bool normal = true, int width = 50)
        {
            int g = 100 / width;
            int i = (int)Math.Floor(percent / g);
            Console.Write("[");
            string prog = "";
            Console.ForegroundColor = color;
            for (int j = 0; j < width; j++)
            {
                if (normal)
                {
                    if (j < i)
                    {
                        prog = prog + "=";
                    }
                    else if (j == i)
                    {
                        prog = prog + ">";
                    }
                    else
                    {
                        prog = prog + " ";
                    }
                }
                else
                {
                    if (j <= i)
                    {
                        prog = prog + "#";
                    }
                    else
                    {
                        prog = prog + " ";
                    }
                }
            }
            Console.Write(prog);
            Console.ResetColor();
            Console.Write("]");
            Console.ForegroundColor = color;
            Console.Write(Math.Round(percent));
            Console.WriteLine("%");
            Console.ResetColor();
        }
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
            string actualpath = path.Replace("~\\", AppDomain.CurrentDomain.BaseDirectory);
            if (actualpath.Contains(':'))
            {

            }
            else
            {
                actualpath = LoggedProgram.DIR + actualpath;
            }
            return actualpath;
        }
    }
}
