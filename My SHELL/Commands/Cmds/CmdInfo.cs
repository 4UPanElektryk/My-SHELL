using MyShell.Commands.SubCmds.Status;

namespace MyShell.Commands.Cmds
{
    class CmdInfo : Cmd
    {
        public CmdInfo(string name) : base(name)
        {
            description = "Shows status of current machine";
            _Subs.Add(new CmdInfo_Live("live"));
            _Subs.Add(new CmdInfo_Default(null));
        }
    }
}
