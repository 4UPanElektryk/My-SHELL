using MyShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShell.Essentials;
using System.IO;
using SimpleLogs4Net;

namespace MyShell.Commands.SubCmds.Del
{
    class CmdDel_Dir : SubCmd
    {
        public CmdDel_Dir(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input, User user)
        {
            string path = string.Join(" ",args);
            path = Dual.GetThePath(path);
            if (!Directory.Exists(path))
            {
                Dual.Msg("Directory does not exists", ConsoleColor.Red);
                Log.Write("User: " + user._Id + " Attempted deltion of not existant directory: " + path, EType.Informtion);
                return true;
            }
            if (!Dual.YesOrNO("Are you sure you want to Delete this directory"))
            {
                return true;
            }
            try
            {
                Directory.Delete(path);
                Dual.Msg("Directory deleted", ConsoleColor.Green);
                Log.Write("User: " + user._Id + " Deleted directory: " + path, EType.Informtion);
            }
            catch (Exception error)
            {
                Log.Write(error.Message, EType.Error);
            }
            return true;
        }
    }
}
