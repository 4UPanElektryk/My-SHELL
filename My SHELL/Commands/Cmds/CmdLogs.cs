using MyShell.Commands.SubCmds.Logs;
using MyShell.Modules.Base;

namespace MyShell.Commands.Cmds
{
    class CmdLogs : Cmd
    {
        public CmdLogs(string name) : base(name)
        {
            description = "Manipulation of Logs";
            _Subs.Add(new CmdLogs_Open("open"));
            _Subs.Add(new CmdLogs_Clear("clear"));
            _Subs.Add(new CmdLogs_State("state"));
            _Subs.Add(new CmdLogs_Default(null));
        }
    }
}
