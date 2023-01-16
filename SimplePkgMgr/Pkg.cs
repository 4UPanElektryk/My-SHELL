using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySettings;

namespace SimplePkgMgr
{
    public class Pkg
    {
        public string PkgsFolder { get; set; }
        public string RepoDB { get; set; }
        public void LoadRepoDB()
        {
            
        }
        public bool AddRepo(Uri uri)
        {
            Settings.path = RepoDB()
        }
    }
}
