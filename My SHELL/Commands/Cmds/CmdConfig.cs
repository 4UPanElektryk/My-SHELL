using System;
using MyShell.Commands.SubCmds;
using MyShell.Integrations.User_Manager;
namespace MyShell.Commands.Cmds
{
    class CmdConfig : Cmd
    {
        public CmdConfig(string name) : base(name)
        {
            _Subs.Add(new CmdConfig_Menu("menu"));
            _Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
