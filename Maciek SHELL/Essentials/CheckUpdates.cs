using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MShell.Properties;

namespace MShell.Essentials
{
    public class CheckUpdates
    {
        static string UpadaterName = "Updater.exe";
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
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = UpadaterName;
            processStartInfo.Arguments = args;
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
