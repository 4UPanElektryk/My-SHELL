using MyShell.Commands.SubCmds;
using MyShell.Commands.SubCmds.CConfig;
using MyShell.Commands.Base;

namespace MyShell.Commands.Cmds
{
    class CmdConfig : Cmd
    {
        public CmdConfig(string name) : base(name)
        {
            _Subs.Add(new CmdConfig_Menu("menu"));
            _Subs.Add(new CmdConfig_RawEdit("setraw"));
            _Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
