using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System;

namespace Maciek_SHELL.Commands.SubCmds
{
	class CmdLogs_State : SubCmd
	{
		public CmdLogs_State(string name) : base(name)
		{

		}
		public override bool Execute(string[] args, string input, User user)
		{
			if (args.Length >= 1)
			{
				if (bool.TryParse(args[0], out bool result))
				{
					Config._LogsConfig.Enabled = result;
					Config.SaveConfig();
					Config.LoadConfig();
					Log.ChangeEnable(Config._LogsConfig.Enabled);
                    if (Config._LogsConfig.Enabled)
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
				if (user._State == User.Type.SysAdmin)
				{
					Log.ChangeEnable(Config._LogsConfig.Enabled);
                    if (Config._LogsConfig.Enabled)
                    {
                        Dual.Msg("Logs are enabled", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Dual.Msg("Logs are disabled", ConsoleColor.Yellow);
                    }
				}
				else
				{
					Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
				}
			}
			return true;
		}
	}
}
