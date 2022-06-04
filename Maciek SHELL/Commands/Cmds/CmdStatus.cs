using Maciek_SHELL.Properties;
using MOS_User_Menager_Integration;
using Maciek_SHELL.Essentials;
using Maciek_SHELL.Commands.SubCmds;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
	class CmdStatus : Cmd
	{
		public CmdStatus(string name) : base(name) 
		{
			_Subs.Add(new CmdStatus_Live("live"));
			_Subs.Add(new CmdStatus_Default(null));
		}
	}
}
