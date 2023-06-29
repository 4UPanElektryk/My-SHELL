using SimpleLogs4Net;
using System;
using System.IO;
using System.Linq;

namespace MyShell.Commands.Cmds
{
    class CmdCD : Cmd
    {
        public CmdCD(string name) : base(name)
        {
            description = "changes active directory";
        }
        public override bool Execute(string[] args, string input)
        {
            bool action = true;
            string path = input.Substring(_Name.Length+1);
            path = path.Replace("~\\", AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(path);
            if (path != "..")
            {
                if (path.Contains(':'))
                {
                    if (Directory.Exists(path))
                    {
                        LoggedProgram.DIR = path;
                        Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, EType.Informtion, DateTime.Now));
                    }
                    else
                    {
                        action = false;
                    }
                }
                else
                {
                    if (Directory.Exists(LoggedProgram.DIR + path))
                    {
                        string paths = path;
                        foreach (string item in Directory.GetDirectories(LoggedProgram.DIR))
                        {
                            if (item.Substring(LoggedProgram.DIR.Length).ToLower() == path.ToLower())
                            {
                                paths = item.Substring(LoggedProgram.DIR.Length);
                            }
                        }
                        if (Program.IsUnix)
                        {
                            LoggedProgram.DIR = LoggedProgram.DIR + paths + "/";
                        }
                        else
                        {
                            LoggedProgram.DIR = LoggedProgram.DIR + paths + "\\";
                        }
                        Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, EType.Informtion, DateTime.Now));
                    }
                    else
                    {
                        action = false;
                    }
                }

            }
            else
            {
                string[] d;
                if (Program.IsUnix)
                {
                    d = LoggedProgram.DIR.Split('/');
                }
                else
                {
                    d = LoggedProgram.DIR.Split('\\');
                }
                string nd = "";
                int i = 1;
                foreach (string item in d)
                {
                    i++;
                    if (i == d.Length)
                    {

                    }
                    else
                    {
                        if (i == d.Length - 1)
                        {
                            nd = nd + item;
                        }
                        else
                        {
                            if (Program.IsUnix)
                            {
                                nd = nd + item + "/";
                            }
                            else
                            {
                                nd = nd + item + "\\";
                            }
                        }
                    }
                }
                if (Directory.Exists(nd))
                {
                    LoggedProgram.DIR = nd;
                    Log.AddEvent(new Event("User action: Directory Change - " + LoggedProgram.DIR, EType.Informtion, DateTime.Now));
                }
            }
            return action;
        }
    }
}
