using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
	class CmdClear : Cmd
	{
		public CmdClear(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			Console.Clear();
			Dual.Watermark();
			return true;
		}
	}
}
