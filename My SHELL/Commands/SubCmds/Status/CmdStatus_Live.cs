using MShell.Essentials;
using MShell.Integrations.User_Manager;
using MShell.Properties;
using System;
using System.Threading;

namespace MShell.Commands.SubCmds
{
    public class CmdStatus_Live : SubCmd
    {
        Timer RefreshTimer;
        public CmdStatus_Live(string name) : base(name)
        {
            _Help = "Shows live status";
        }

        private void Refresh(object state)
        {
            Console.Clear();
            Dual.Watermark();
            Console.WriteLine("Maciek Shell");
            Console.WriteLine("Version: " + Settings.Default["Version"].ToString());
            Console.WriteLine("Status: Running");
            float CPUUsageProcatage = Program.cpuCounter.NextValue();
            //Cpu Counter
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
            Dual.ProgressBar(CPUUsageProcatage, color, false);
            //End CPU bar
            //RAM bar
            float RAMCurentUsage = (int)Program.currentProc.WorkingSet64 / 1024 / 1024;
            float RAMMaxUsage = (int)Program.currentProc.VirtualMemorySize64 / 1024 / 1024;
            float RAMUsageProcatage = (RAMCurentUsage / RAMMaxUsage) * 100;
            Console.WriteLine("RAM Usage: " + RAMCurentUsage + "MB" + "/" + RAMMaxUsage + "MB");
            color = ConsoleColor.Green;
            if (RAMUsageProcatage > 50)
            {
                color = ConsoleColor.Yellow;
            }
            if (RAMUsageProcatage > 70)
            {
                color = ConsoleColor.Red;
            }
            Dual.ProgressBar(RAMUsageProcatage, color, false);
            //End of RAM bar
        }

        public override bool Execute(string[] args, string input, User user)
        {
            Console.CursorVisible = false;
            Console.Clear();
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
