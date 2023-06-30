using System;
using MyShell.Essentials;
using System.IO;
using SimpleLogs4Net;
using MyShell.Modules.Base;

namespace MyShell.Commands.SubCmds.Del
{
    class CmdDel_Dir : SubCmd
    {
        public CmdDel_Dir(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input)
        {
            string path = string.Join(" ",args);
            path = Dual.GetThePath(path);
            if (!Directory.Exists(path))
            {
                Dual.Msg("Directory does not exists", ConsoleColor.Red);
                Log.Write("Attempted deltion of not existant directory: " + path, EType.Informtion);
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
                Log.Write("Deleted directory: " + path, EType.Informtion);
            }
            catch (Exception error)
            {
                Log.Write(error.Message, EType.Error);
            }
            return true;
        }
    }
}
