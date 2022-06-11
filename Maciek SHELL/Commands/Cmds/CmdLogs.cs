using MShell.Commands.SubCmds;
namespace MShell.Commands.Cmds
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
