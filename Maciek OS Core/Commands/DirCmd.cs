using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core.Commands
{
	class DirCmd
	{
		private User _User;
		public bool Cd(string input, string[] args, User user)
		{
			bool action = true;
			string path = Dual.TrimStart(input, args[0] + " ");
			if (path != "..")
            {
				if (path.Contains(':'))
				{
					if (Directory.Exists(path))
					{
						LoggedProgram.DIR = path;
						Log.AddLogEvent(new LogEvent("User action: Directory Change", LoggedProgram.DIR, LogEvent.Type.Informtion, DateTime.Now));
					}
					else
					{
						action = false;
					}
				}
				else
				{
					if (Directory.Exists(LoggedProgram.DIR + path))
					{
						LoggedProgram.DIR = LoggedProgram.DIR + path + "\\";
						Log.AddLogEvent(new LogEvent("User action: Directory Change", LoggedProgram.DIR, LogEvent.Type.Informtion, DateTime.Now));
					}
					else
					{
						action = false;
					}
				}
				
			}
            else
            {
				string[] d = LoggedProgram.DIR.Split('\\');
				string nd = "";
				int i = 1;
                foreach (string item in d)
                {
					i++;
                    if (i == d.Length)
                    {

                    }
                    else
                    {
                        if (i == d.Length - 1 )
                        {
							nd = nd + item;
						}
                        else
                        {
							nd = nd + item + "\\";
						}
                    }
                }
                if (Directory.Exists(nd))
                {
					LoggedProgram.DIR = nd;
					Log.AddLogEvent(new LogEvent("User action: Directory Change", LoggedProgram.DIR, LogEvent.Type.Informtion, DateTime.Now));
				}
			}
			_User = user;
			return action;
		}
		public bool Dir(User user)
        {
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Files In Directory: " + LoggedProgram.DIR);
			foreach (string item in Directory.GetDirectories(LoggedProgram.DIR))
            {
				string[] text = item.Split("\\".ToCharArray());
                Console.Write("Directory: " + text[text.Length - 1]);
				for (int i = text[text.Length - 1].Length; i < 86; i++)
				{
					Console.Write(" ");
                }
                Console.WriteLine("DIR");
			}
			foreach (string item in Directory.GetFiles(LoggedProgram.DIR))
			{
				string[] text = item.Split("\\".ToCharArray());
				string[] extention = text[text.Length - 1].Split('.');

				Console.Write("File: " + text[text.Length - 1]);
				for (int i = text[text.Length - 1].Length; i < 90; i++)
				{
					Console.Write(" ");
				}
				int l = 0;
                foreach (string itm in extention)
                {
					if (l == 0)
                    {
						
					}
                    else
                    {
						Console.Write("." + itm.ToUpper());
					}
					l++;
				}
				Console.WriteLine();
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			return true;
        }
		public bool MKDir(string[] args, string input)
        {
			bool action = false;
			string path = Dual.TrimStart(input, args[0] + " ");
			if (!Directory.Exists(LoggedProgram.DIR + path))
			{;
				Directory.CreateDirectory(LoggedProgram.DIR + path);
				Log.AddLogEvent(new LogEvent("User action: Directory Created", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
				action = true;
			}
            else
            {
				Log.AddLogEvent(new LogEvent("User action: Directory Can not be created ,Rason: Directory already Exist", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
				Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
				action = true;
			}
			return action;
        }
		public bool DelDir(string[] args, string input)
		{
			bool action = false;
			string path = Dual.TrimStart(input, args[0] + " ");
			Console.Write("Do You want to Delete " + path + " ? Y | N >> ");
			ConsoleKey Key = Console.ReadKey().Key;
            Console.WriteLine();
			if (Key == ConsoleKey.Y)
			{
				if (Directory.Exists(LoggedProgram.DIR + path))
				{
					Directory.Delete(LoggedProgram.DIR + path);
					Log.AddLogEvent(new LogEvent("User action: Directory Delete", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
					action = true;
				}
				else
				{
					Log.AddLogEvent(new LogEvent("User action: Directory Can not be Deleted ,Rason: Directory not Exist", LoggedProgram.DIR + path, LogEvent.Type.Informtion, DateTime.Now));
					Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
					action = true;
				}
			}
			else
			{
				Console.WriteLine("");
			}
			return action;
		}
	}
}
