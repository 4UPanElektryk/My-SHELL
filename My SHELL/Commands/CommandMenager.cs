using MyShell.Binds;
using MyShell.Commands.Cmds;
using MyShell.Essentials;
using System.Collections.Generic;

namespace MyShell.Commands
{
    class CommandMenager
    {
        public static List<Cmd> CmdList;
        public CommandMenager()
        {
            CmdList = new List<Cmd>
            {
                new CmdCD("cd"),
                new CmdClear("clear"),
                new CmdDel("del"),
                new CmdHelp("help"),
                new CmdLs("ls"),
                new CmdExit("exit"),
                new CmdLogs("logs"),
                new CmdMKDir("mkdir"),
                new CmdStart("start"),
                new CmdInfo("info"),
                new CmdBinds("binds"),
                new CmdNeofetch("neofetch"),
                new CmdConfig("config"),
            };
            if (Config._AppConfig.DevMode)
            {
                CmdList.Add(new CmdTest("test"));
            }
        }
        public bool ExecuteCommand(string input)
        {
            string[] args = input.Split(' ');
            args = Dual.DeleteNullAndEmptyItems(args);
            foreach (Cmd item in CmdList)
            {
                if (item._Name == args[0].ToLower())
                {
                    return item.Execute(args, input);
                }
            }
            if (input == "")
            {
                return true;
            }
            return BindManager.ExecuteBind(input);
        }
        public bool ExecuteCommandForBind(string input)
        {
            string[] args = input.Split(' ');
            foreach (Cmd item in CmdList)
            {
                if (item._Name == args[0].ToLower())
                {
                    return item.Execute(args, input);
                }
            }
            if (input == "")
            {
                return true;
            }
            return false;
        }
    }
}
