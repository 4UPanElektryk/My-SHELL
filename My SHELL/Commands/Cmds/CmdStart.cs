using MyShell.Essentials;
using SimpleLogs4Net;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MyShell.Modules.Base;

namespace MyShell.Commands.Cmds
{
    class CmdStart : Cmd
    {
        public CmdStart(string name) : base(name) 
        {
            description = "Executes the process written in args";
        }
        public override bool Execute(string[] args, string input)
        {
            string path = input.Substring(_Name.Length+1);
            bool action = false;
            if (path.Contains(':'))
            {
                if (File.Exists(path))
                {
                    action = true;
                    Process.Start(path);
                    Log.AddEvent(new Event("User Action - Start: Action Succesful:" + path, EType.Informtion, DateTime.Now));
                }
                else
                {
                    Dual.Msg("File Not Found", ConsoleColor.Red);
                    Log.AddEvent(new Event("User Action - Start: File Not Found:" + path, EType.Warning, DateTime.Now));
                    action = true;
                }
            }
            else
            {
                if (File.Exists(LoggedProgram.DIR + path))
                {
                    action = true;
                    Process.Start(LoggedProgram.DIR + path);
                    Log.AddEvent(new Event("User Action by - Start: Action Succesful:" + LoggedProgram.DIR + path, EType.Informtion, DateTime.Now));
                }
                else
                {
                    Dual.Msg("File Not Found", ConsoleColor.Red);
                    Log.AddEvent(new Event("User Action by - Start: File Not Found:" + LoggedProgram.DIR + path, EType.Warning, DateTime.Now));
                    action = true;
                }
            }
            return action;
        }
    }
}
