using Maciek_SHELL.Commands.Cmds.SubCmds;
using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using System;
using System.IO;
namespace Maciek_SHELL.Commands.Cmds
{
    class CmdLogs : Cmd
    {
        public CmdLogs(string name) : base(name)
        {
            _Subs.Add(new CmdLogs_Open("open"));
            _Subs.Add(new CmdLogs_Clear("clear"));
            _Subs.Add(new CmdLogs_State("state"));
            _Subs.Add(new CmdLogs_Default(null));
        }
	}
}
