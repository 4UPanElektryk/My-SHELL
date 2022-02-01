using MOS_User_Menager_Integration;
using System;
using System.IO;
using Maciek_OS_Core.Essentials;
using MOS_Log_Integration;

namespace Maciek_OS_Core.Commands.Cmds
{
    class DelDir : Cmd
    {
		public DelDir(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
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
