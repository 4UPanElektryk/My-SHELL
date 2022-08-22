using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShell.Commands.SubCmds;

namespace MyShell.Commands.Cmds
{
    class CmdDel : Cmd
    {
        public CmdDel(string name) : base(name)
        {
            description = "Used to delete files and dirs";
            args = " <File|Dir> Path";
            _Subs.Add(new CmdDel_Dir("dir"));
            _Subs.Add(new CmdDel_File("file"));
            _Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
