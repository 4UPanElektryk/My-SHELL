using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_Log_Integration;
using MOS_User_Menager_Integration;

namespace Maciek_OS_Core.Commands
{
	class Command
	{
		private User _User;
		public bool Execute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
			bool action = false;
			return action;
		}
		public bool ScriptExecute(string[] args, User user)
		{
			int nbt = args.Length;
			_User = user;
			bool action = false;
			return action;
		}
	}
}
