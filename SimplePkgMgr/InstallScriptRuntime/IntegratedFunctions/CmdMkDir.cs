using SimpleLogs4Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePkgMgr.InstallScriptRuntime.IntegratedFunctions
{
    public class CmdMkDir : Cmd
    {
        public CmdMkDir(string name) : base(name) { }
        public override bool Execute(string[] args)
        {
            Log.Write("Making directory " + args[0]);
            try
            {
                Directory.CreateDirectory(args[0]);
            }
            catch
            {
                Log.Write("Making directory Failed " + args[0], EType.Error);
                return false;
            }
            Log.Write("Made directory " + args[0] + " to " + args[1], EType.Informtion);
            return true;
        }
    }
}
