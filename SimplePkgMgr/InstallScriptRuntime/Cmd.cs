using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePkgMgr.InstallScriptRuntime
{
    public class Cmd
    {
        public string Name;
        public Cmd(string name)
        {
            Name = name;
        }
        public virtual bool Execute(string[] args)
        {
            return true;
        }
    }
}
