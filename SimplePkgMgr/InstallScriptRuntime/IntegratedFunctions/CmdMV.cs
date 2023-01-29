using SimpleLogs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimplePkgMgr.InstallScriptRuntime.IntegratedFunctions
{
    public class CmdMV : Cmd
    {
        public CmdMV(string name) : base(name) { }
        public override bool Execute(string[] args)
        {
            Log.Write("Moving " + args[0] + " to " + args[1]);
            try
            {
                File.Copy(args[0], args[1]);
                File.Delete(args[0]);
            }
            catch
            {
                Log.Write("Moving Failed " + args[0] + " to " + args[1], EType.Error);
                return false;
            }
            Log.Write("Moved " + args[0] + " to " + args[1], EType.Informtion);
            return true;
        }
    }
}
