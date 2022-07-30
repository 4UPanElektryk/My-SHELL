using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Commands.SubCmds;

namespace MShell.Commands.Cmds
{
    class CmdBinds : Cmd
    {
        public CmdBinds(string name) : base(name)
        {
            description = "allows manipulaion of binds";
            _Subs.Add(new CmdBinds_Add("add"));
            _Subs.Add(new CmdBinds_List("list"));
            _Subs.Add(new Error_SubCmdNotFound("") { _IsDefault = true});
        } 
    }
}
