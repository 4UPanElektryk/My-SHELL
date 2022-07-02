using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShell.Binds
{
    public class Bind
    {
        public int Args { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public Bind()
        {
            
        }
    }
}
