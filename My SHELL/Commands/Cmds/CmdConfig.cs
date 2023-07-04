using MyShell.Commands.SubCmds;
using MyShell.Commands.SubCmds.CConfig;
using MyShell.Commands.Base;

namespace MyShell.Commands.Cmds
{
    class CmdConfig : Cmd
    {
        public CmdConfig(string name) : base(name)
        {
            Subs.Add(new CmdConfig_Menu("menu"));
            Subs.Add(new CmdConfig_RawEdit("setraw"));
            Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
