using System;
using System.Collections.Generic;
using MOS_User_Menager_Integration;
using Maciek_SHELL.Commands.Cmds;
using Maciek_SHELL.Commands.Cmds.Nano;
using SimpleLogs4Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maciek_SHELL.Commands
{
    class CommandMenager
    {
        public List<Cmd> CmdList;
        public CommandMenager()
        {
            CmdList = new List<Cmd>
            {
                new Users("user"),
                new Start("start"),
                new MKDir("mkdir"),
                new Logs("logs"),
                new Dir("dir"),
                new DelDir("deldir"),
                new CD("cd"),
                new NanoCmd("nano"),
                new Logoff("logoff"),
                new Note("notepad"),
                new Clear("clear")
            };
        }
        public bool ExecuteCommand(string dt, User user)
        {
            string input = dt.ToLower();
            string[] args = input.Split(' ');
            int nbt = args.Length;
            foreach (Cmd item in CmdList)
            {
                if (item._Name == args[0])
                {
                    return item.Execute(args, dt, user);
                }
            }
            if (dt == "")
            {
                return true;
            }
            return false;
        }
    }
}
