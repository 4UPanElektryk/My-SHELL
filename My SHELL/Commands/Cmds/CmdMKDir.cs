using MyShell.Essentials;
using SimpleLogs4Net;
using System;
using System.IO;

namespace MyShell.Commands.Cmds
{
    class CmdMKDir : Cmd
    {
        public CmdMKDir(string name) : base(name)
        {
            description = "Creates directory";
        }
        public override bool Execute(string[] args, string input)
        {
            bool action = false;
            string path = input.Substring(_Name.Length+1);
            if (!Directory.Exists(LoggedProgram.DIR + path))
            {
                Directory.CreateDirectory(LoggedProgram.DIR + path);
                Log.AddEvent(new Event("User action: Directory Created - " + LoggedProgram.DIR + path, EType.Informtion));
                action = true;
            }
            else
            {
                Log.AddEvent(new Event("User action: Directory Can not be created ,Rason: Directory already Exist - " + LoggedProgram.DIR + path, EType.Informtion));
                Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
                action = true;
            }
            return action;
        }
    }
}
