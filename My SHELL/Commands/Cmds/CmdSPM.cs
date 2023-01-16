using MyShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShell.Commands.Cmds
{
    class CmdSPM : Cmd
    {
        public CmdSPM(string name) : base(name) 
        {
        
        }
        public override bool Execute(string[] args, string input, User user)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "SPM.exe"))
                return false;
            return base.Execute(args, input, user);
        }
    }
}
