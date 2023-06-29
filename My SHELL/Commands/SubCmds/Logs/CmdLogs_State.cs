using MyShell.Essentials;
using SimpleLogs4Net;
using System;

namespace MyShell.Commands.SubCmds.Logs
{
	class CmdLogs_State : SubCmd
	{
		public CmdLogs_State(string name) : base(name)
		{

		}
		public override bool Execute(string[] args, string input)
		{
			if (args.Length >= 1)
			{
				if (bool.TryParse(args[0], out bool result))
				{
					Essentials.Config._LogsConfig.Enabled = result;
					Essentials.Config.Save();
					Essentials.Config.Load();
					LogConfiguration.ChangeStream(Essentials.Config._LogsConfig.Enabled ? OutputStream.File : OutputStream.None);
					if (Essentials.Config._LogsConfig.Enabled)
					{
						Dual.Msg("Logs are now enabled", ConsoleColor.Yellow);
					}
					else
					{
						Dual.Msg("Logs are now disabled", ConsoleColor.Yellow);
					}
				}
			}
			else
			{
				LogConfiguration.ChangeStream(Essentials.Config._LogsConfig.Enabled ? OutputStream.File : OutputStream.None);
				if (Essentials.Config._LogsConfig.Enabled)
				{
					Dual.Msg("Logs are enabled", ConsoleColor.Yellow);
				}
				else
				{
					Dual.Msg("Logs are disabled", ConsoleColor.Yellow);
				}
			}
			return true;
		}
	}
}
