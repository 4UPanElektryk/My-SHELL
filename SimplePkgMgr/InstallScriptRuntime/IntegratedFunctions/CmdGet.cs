using SimpleLogs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePkgMgr.InstallScriptRuntime.IntegratedFunctions
{
    public class CmdGet : Cmd
    {
        public CmdGet(string name) : base(name) { }
        public override bool Execute(string[] args)
        {
            Log.Write("Downloading " + args[0] + " to " + args[1]);
            try
            {
                new WebClient().DownloadFile(args[0], args[1]);
            }
            catch
            {
                Log.Write("Download Failed " + args[0] + " to " + args[1], EType.Error);
                return false;
            }
            Log.Write("Downloaded " + args[0] + " to " + args[1], EType.Informtion);
            return true;
        }
    }
}
