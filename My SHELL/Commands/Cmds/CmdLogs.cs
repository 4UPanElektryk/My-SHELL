using MyShell.Commands.SubCmds.Logs;
using MyShell.Commands.Base;

namespace MyShell.Commands.Cmds
{
    class CmdLogs : Cmd
    {
        public CmdLogs(string name) : base(name)
        {
            description = "Manipulation of Logs";
            Subs.Add(new CmdLogs_Open("open"));
            Subs.Add(new CmdLogs_Clear("clear"));
            Subs.Add(new CmdLogs_State("state"));
            Subs.Add(new CmdLogs_Default(null));
        }
    }
}
