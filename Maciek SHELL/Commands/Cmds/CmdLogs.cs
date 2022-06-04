using Maciek_SHELL.Commands.SubCmds;
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
