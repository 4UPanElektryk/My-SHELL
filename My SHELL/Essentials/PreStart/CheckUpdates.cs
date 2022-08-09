using MShell.Properties;
using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Diagnostics;

namespace MShell.Essentials
{
    public class CheckUpdates
    {
        static string UpadaterName = "Updater.exe";
        public static bool CheckConnection(string IPorHostName)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(IPorHostName, timeout, buffer, options);
            return reply.Status == IPStatus.Success;
        }
        public static bool CheckForUpdates()
        {
            if (Config._AppConfig.DevMode)
            {
                return false;
            }
            if (!Program.FoundUpdater || !Config._AppConfig.AutoUpdate)
            {
                return false;
            }
            string args = "-c";
            if (Config._AppConfig.UpdateToBeta)
            {
                args += "b";
            }
            string version = Settings.Default["Version"].ToString().Replace('.', ',');
            args += " " + version + " " + Settings.Default["Build"].ToString();
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = UpadaterName,
                Arguments = args
            };
            Process P = Process.Start(processStartInfo);
            P.WaitForExit();
            int result = P.ExitCode;
            if (result == 1)
            {
                return true;
            }
            else if (result == 3)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        public static void Update()
        {
            if (!CheckForUpdates())
            {
                Dual.Msg("No Updates Found", ConsoleColor.Yellow);
                return;
            }
            else
            {
                if (Config._AppConfig.UpdateToBeta)
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = UpadaterName;
                    processStartInfo.Arguments = "updatebeta";
                    Process P = Process.Start(processStartInfo);
                }
                else
                {
                    Process P = Process.Start(UpadaterName, "update");
                }
                Program.currentProc.Kill();
            }
        }
    }
}
