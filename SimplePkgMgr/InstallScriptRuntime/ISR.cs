using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogs4Net;
using SimplePkgMgr.InstallScriptRuntime.IntegratedFunctions;

namespace SimplePkgMgr.InstallScriptRuntime
{
    public  class ISR
    {
        public static List<Cmd> cmds;
        public ISR() 
        {
            cmds = new List<Cmd> 
            {
                new CmdGet("get"),
            };
        }
        public static void RunInstallScript(string path)
        {
            foreach (string item in File.ReadAllLines(path))
            {
                if (!item.StartsWith("//"))
                {
                    string[] args = item.Split("\"".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (Cmd item2 in cmds)
                    {
                        if (item.ToLower().StartsWith(item2.Name))
                        {
                            if (!item2.Execute())
                            {
                                Log.Write("Instalation Encounterd an Error");
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
