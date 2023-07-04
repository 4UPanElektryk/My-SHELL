using MyShell.Commands.SubCmds.Binds;
using MyShell.Commands.SubCmds;
using MyShell.Commands.Base;

namespace MyShell.Commands.Cmds
{
    class CmdBinds : Cmd
    {
        public CmdBinds(string name) : base(name)
        {
            description = "allows manipulaion of binds";
            Subs.Add(new CmdBinds_Add("add"));
            Subs.Add(new CmdBinds_List("list"));
            Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
