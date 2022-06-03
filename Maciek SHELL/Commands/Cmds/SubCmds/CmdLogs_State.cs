using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using SimpleLogs4Net;
using System;

namespace Maciek_SHELL.Commands.Cmds.SubCmds
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
                    Config.LogsEnabled = result;
                    Config.SaveConfig();
                    Config.LoadConfig();
                    Log.ChangeEnable(result);
                }
            }
            else
            {
                if (user._State == User.Type.SysAdmin)
                {
                    Config.DeleteConfig();
                    Config.CreateNewConfig(true);
                    Config.LoadConfig();
                    Log.ChangeEnable(Config.LogsEnabled);
                    Dual.Msg("Logs are now enabled", ConsoleColor.Yellow);
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
