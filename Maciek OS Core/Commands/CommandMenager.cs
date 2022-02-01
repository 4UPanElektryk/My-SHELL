using System;
using System.Collections.Generic;
using MOS_User_Menager_Integration;
using Maciek_OS_Core.Commands.Cmds;
using Maciek_OS_Core.Commands.Cmds.Nano;
using MOS_Log_Integration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maciek_OS_Core.Commands
{
    class CommandMenager
    {
        public List<Cmd> CmdList;
        public CommandMenager()
        {
            CmdList = new List<Cmd>();
            CmdList.Add(new Users("user"));
            CmdList.Add(new Start("start"));
            CmdList.Add(new MKDir("mkdir"));
            CmdList.Add(new Logs("logs"));
            CmdList.Add(new Dir("dir"));
            CmdList.Add(new DelDir("deldir"));
            CmdList.Add(new CD("cd"));
            CmdList.Add(new NanoCmd("nano"));
            CmdList.Add(new Logoff("logoff"));
            CmdList.Add(new Note("notepad"));
            CmdList.Add(new Clear("clear"));
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
