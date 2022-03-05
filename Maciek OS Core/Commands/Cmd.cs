using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_Log_Integration;
using MOS_User_Menager_Integration;

namespace Maciek_OS_Core.Commands
{
	class Cmd
	{
		public readonly string _Name = "null";
		public Cmd(string name)
        {
			_Name = name;
        }
		public virtual bool Execute(string[] args, string input, User user)
		{
			int nbt = args.Length;
			bool action = false;
			return action;
		}
	}
}
