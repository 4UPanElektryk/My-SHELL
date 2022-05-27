using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_User_Menager_Integration;

namespace Maciek_SHELL.Commands
{
    class SubCmd
    {
        public readonly string _Name = "null";
        public readonly bool _IsDefault = false;
        public SubCmd(string name)
        {
            _Name = name;
        }
        public SubCmd(string name, bool isDefault)
        {
            _Name = name;
            _IsDefault = isDefault;
        }
        public virtual bool Execute(string[] args, string input, User user)
        {
            int nbt = args.Length;
            bool action = false;
            return action;
        }
    }
}
