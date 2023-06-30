using System;
using System.IO;
using SimpleLogs4Net;
using MyShell.Essentials;
using MyShell.Modules.Base;

namespace MyShell.Commands.SubCmds.Del
{
    class CmdDel_File : SubCmd
    {
        public CmdDel_File(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input)
        {
            string path = string.Join(" ", args);
            path = Dual.GetThePath(path);
            if (!File.Exists(path))
            {
                Dual.Msg("File does not exists", ConsoleColor.Red);
                Log.Write("Attempted deltion of not existant File: " + path, EType.Informtion);
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
                Log.Write("Deleted File: " + path, EType.Informtion);
            }
            catch (Exception error)
            {
                Log.Write(error.Message, EType.Error);
            }
            return true;
        }
    }
}
