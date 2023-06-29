using System;
using MyShell.Essentials;

namespace MyShell.Commands.SubCmds.Config
{
    class CmdConfig_RawEdit : SubCmd
    {
        public CmdConfig_RawEdit(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input)
        {
            try
            {
                string firsthalf = args[0].Split('.')[0];
                string secoundhalf = args[0].Split('.')[1];
                if (firsthalf == "Application")
                {
                    AppConfig localApp = Essentials.Config._AppConfig;
                    switch (secoundhalf)
                    {
                        case "AutoUpdate":
                            localApp.AutoUpdate = bool.Parse(args[1]);
                            break;
                        case "UpdateToBeta":
                            localApp.UpdateToBeta = bool.Parse(args[1]);
                            break;
                        case "DevMode":
                            localApp.DevMode = bool.Parse(args[1]);
                            break;
                        case "UseAsciiOnly":
                            localApp.UseAsciiOnly = bool.Parse(args[1]);
                            break;
                        case "BindFile":
                            localApp.BindFile = args[1];
                            break;
                        default:
                            break;
                    }
                    Essentials.Config._AppConfig = localApp;
                    return true;
                }
                if (firsthalf == "Logs")
                {
                    LogsConfig localLogs = Essentials.Config._LogsConfig;
                    switch (secoundhalf)
                    {
                        case "Prefix":
                            localLogs.Prefix = args[1];
                            break;
                        case "Path":
                            localLogs.Path = args[1];
                            break;
                        case "Enabled":
                            localLogs.Enabled = bool.Parse(args[1]);
                            break;
                        default:
                            Console.WriteLine(secoundhalf + " Not Found in configuration");
                            break;
                    }
                    Essentials.Config._LogsConfig = localLogs;
                }
                Essentials.Config.Save();
            }
            catch { }
            Essentials.Config.Save();
            Console.WriteLine("Invalid info");
            return true;
        }
    }
}
