using MyShell.Essentials;
using MyShell.Properties;
using System;
using System.Threading;
using CoolConsole.Aditonal;
using MyShell.Modules.Base;

namespace MyShell.Commands.SubCmds.Info
{
    public class CmdInfo_Live : SubCmd
    {
        Timer RefreshTimer;
        int x, y;
        public CmdInfo_Live(string name) : base(name)
        {
            _Help = "Shows live status";
        }

        private void Refresh(object state)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.WriteLine("Maciek Shell");
            Console.WriteLine("Version: " + Settings.Default["Version"].ToString());
            Console.WriteLine("Status: Running");
            float CPUUsageProcatage = Program.cpuCounter.NextValue();
            #region CPU Counter
            Console.WriteLine("CPU Usage:");
            ConsoleColor color = ConsoleColor.Green;
            if (CPUUsageProcatage > 50)
            {
                color = ConsoleColor.Yellow;
            }
            if (CPUUsageProcatage > 70)
            {
                color = ConsoleColor.Red;
            }
            ProgressBar.ShowColor((int)CPUUsageProcatage,100, color,50, true);
            #endregion
            #region RAM Counter
            float RAMCurentUsage = (int)Program.currentProc.WorkingSet64 / 1024 / 1024;
            float RAMMaxUsage = (int)Program.currentProc.VirtualMemorySize64 / 1024 / 1024;
            float RAMUsageProcatage = (RAMCurentUsage / RAMMaxUsage) * 100;
            Console.WriteLine("Alocated RAM Usage: " + RAMCurentUsage + "MB" + "/" + RAMMaxUsage + "MB");
            color = ConsoleColor.Green;
            if (RAMUsageProcatage > 50)
            {
                color = ConsoleColor.Yellow;
            }
            if (RAMUsageProcatage > 70)
            {
                color = ConsoleColor.Red;
            }
            ProgressBar.ShowColor((int)RAMUsageProcatage, 100, color, 50, true);
            #endregion
        }

        public override bool Execute(string[] args, string input)
        {
            Console.CursorVisible = false;
            x = Console.CursorLeft;
            y = Console.CursorTop;
            RefreshTimer = new Timer(Refresh, null, 0, 1000);
            Console.CursorTop += 7;
            Dual.AwaitingEnter();
            RefreshTimer.Dispose();
            Console.CursorVisible = true;
            Console.Clear();
            Dual.Watermark();
            return true;
        }
    }
}
