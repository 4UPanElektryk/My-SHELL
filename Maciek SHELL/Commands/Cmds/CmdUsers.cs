using Maciek_SHELL.Commands.Cmds.SubCmds;

namespace Maciek_SHELL.Commands.Cmds
{
    class CmdUsers : Cmd
    {
        public CmdUsers(string name) : base(name)
        {
            _Subs.Add(new CmdUsers_Add("add"));
            _Subs.Add(new CmdUsers_List("list"));
            _Subs.Add(new CmdUsers_Info("info"));
            _Subs.Add(new CmdUsers_CP("cp"));
            _Subs.Add(new CmdUsers_CP("changepass"));
            _Subs.Add(new CmdUsers_Del("del"));
            _Subs.Add(new CmdUsers_Del("delete"));
            _Subs.Add(new Error_SubCmdNotFound(null));
        }
    }
}
