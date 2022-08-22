using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using MyShell.Properties;
using SimpleLogs4Net;
using System;

namespace MyShell.Commands.SubCmds
{
    public class CmdStatus_Default : SubCmd
    {
        public CmdStatus_Default(string name) : base(name)
        {
            _IsDefault = true;
        }
        public override bool Execute(string[] args, string input, User user)
        {
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
            Log.Write("Ram Usage: " + RAMUsageProcatage + "% Cpu Usage: " + CPUUsageProcatage + "%");
            return true;
        }
    }
}
