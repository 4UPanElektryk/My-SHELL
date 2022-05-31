using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System.Diagnostics;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
    class Note : Cmd
    {
        public Note(string name) : base(name) { }
        public override bool Execute(string[] args, string input, User user)
        {
            Log.AddEvent(new Event("User Action, Notepad oppening", Event.Type.Normal, DateTime.Now));
            Process.Start("note.exe");
            return true;
        }
    }
}
