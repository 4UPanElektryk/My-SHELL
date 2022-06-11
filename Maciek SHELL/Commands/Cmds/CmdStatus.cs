using MShell.Properties;
using MShell.Integrations.User_Manager;
using MShell.Essentials;
using MShell.Commands.SubCmds;
using System;

namespace MShell.Commands.Cmds
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
