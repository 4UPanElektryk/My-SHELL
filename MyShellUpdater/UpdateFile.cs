using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShell.Updater
{
    public class UpdateFile
    {
        public int BuildNumber { get; set; }
        public double Version { get; set; }
        public List<LinkPath> Files { get; set; }
    }
    public class LinkPath
    {
        public string _Path { get; set; }
        public string _Uri { get; set; }
    }
}
