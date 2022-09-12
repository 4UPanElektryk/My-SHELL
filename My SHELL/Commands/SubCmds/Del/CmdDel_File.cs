using MyShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpleLogs4Net;
using MyShell.Essentials;
namespace MyShell.Commands.SubCmds.Del
{
    class CmdDel_File : SubCmd
    {
        public CmdDel_File(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input, User user)
        {
            string path = string.Join(" ", args);
            path = Dual.GetThePath(path);
            if (!File.Exists(path))
            {
                Dual.Msg("File does not exists", ConsoleColor.Red);
                Log.Write("User: " + user._Id + " Attempted deltion of not existant File: " + path, Event.Type.Informtion);
                return true;
            }
            if (!Dual.YesOrNO("Are you sure you want to Delete this file"))
            {
                return true;
            }
            try
            {
                File.Delete(path);
                Dual.Msg("File deleted", ConsoleColor.Green);
                Log.Write("User: " + user._Id + " File: " + path, Event.Type.Informtion);
            }
            catch (Exception error)
            {
                Log.Write(error.Message, Event.Type.Error);
            }
            return true;
        }
    }
}
