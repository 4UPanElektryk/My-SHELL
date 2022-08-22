using MyShell.Binds;
using MyShell.Commands.Cmds;
using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
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
                new CmdLogoff("logoff"),
                new CmdLogs("logs"),
                new CmdMKDir("mkdir"),
                new CmdUsers("user"),
                new CmdStart("start"),
                new CmdStatus("status"),
                new CmdBinds("binds"),
                new CmdText("text"),
            };
            if (Config._AppConfig.DevMode)
            {
                CmdList.Add(new CmdNeofetch("neofetch"));
                CmdList.Add(new CmdTest("test"));
            }
        }
        public bool ExecuteCommand(string input, User user)
        {
            string[] args = input.Split(' ');
            foreach (Cmd item in CmdList)
            {
                if (item._Name == args[0].ToLower())
                {
                    return item.Execute(args, input, user);
                }
            }
            if (input == "")
            {
                return true;
            }
            return BindManager.ExecuteBind(input, user);
        }
        public bool ExecuteCommandForBind(string input, User user)
        {
            string[] args = input.Split(' ');
            foreach (Cmd item in CmdList)
            {
                if (item._Name == args[0].ToLower())
                {
                    return item.Execute(args, input, user);
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
