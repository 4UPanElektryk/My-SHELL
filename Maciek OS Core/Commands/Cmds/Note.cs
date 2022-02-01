using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using System.Diagnostics;
using System;

namespace Maciek_OS_Core.Commands.Cmds
{
    class Note : Cmd
    {
        public Note(string name) : base(name) { }
        public override bool Execute(string[] args, string input, User user)
        {
            Log.AddLogEvent(new LogEvent("User Action", "Notepad oppening", LogEvent.Type.Normal, DateTime.Now));
            Process.Start("note.exe");
            return true;
        }
    }
}
