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
        public static bool CheckForUpdates()
        {
            if (!Program.FoundUpdater)
            {
                return false;
            }
            bool NewerVersion = false;
            string args = "-c";
            if (Config._AppConfig.UpdateToBeta)
            {
                args += "b";
            }
            args += " " + Settings.Default["Version"].ToString() + " " + Settings.Default["Build"].ToString();
            Process P = Process.Start("MShellUpdater.exe", args);
            P.WaitForExit();
            int result = P.ExitCode;
            if (result == 1)
            {
                return false;
            }
            else if (result == 3)
            {
                return true;
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
                    Process P = Process.Start("MShellUpdater.exe", "updatebeta");
                }
                else
                {
                    Process P = Process.Start("MShellUpdater.exe", "update");
                }
                Program.currentProc.Close();
            }
        }
    }
}
