using Maciek_SHELL.Properties;
using MOS_User_Menager_Integration;
using System;

namespace Maciek_SHELL.Commands.Cmds
{
    class CmdStatus : Cmd
    {
        public CmdStatus(string name) : base(name) { }

        public override bool Execute(string[] args, string input, User user)
        {
            Console.WriteLine("Maciek Shell");
            Console.WriteLine("Version: " + Settings.Default["Version"].ToString());
            Console.WriteLine("Status: Running");
            float CPUUsageProcatage = Program.cpuCounter.NextValue();
            Console.WriteLine("CPU Usage:");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            if (CPUUsageProcatage > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (CPUUsageProcatage > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            for (int i = 0; i < 20; i++)
            {
                if ((i * 5) < CPUUsageProcatage)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(" ");
                }
                {

                }
            }
            Console.ResetColor();
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Green;
            if (CPUUsageProcatage > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (CPUUsageProcatage > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(Math.Round(CPUUsageProcatage) + "%");
            Console.ResetColor();
            float RAMCurentUsage = (int)Program.currentProc.WorkingSet64 / 1024 / 1024;
            float RAMMaxUsage = (int)Program.currentProc.VirtualMemorySize64 / 1024 / 1024;
            float RAMUsageProcatage = (RAMCurentUsage / RAMMaxUsage) * 100;
            Console.WriteLine("RAM Usage: " + RAMCurentUsage + "MB" + "/" + RAMMaxUsage + "MB");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            if (CPUUsageProcatage > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (CPUUsageProcatage > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            for (int i = 0; i < 20; i++)
            {
                if ((i * 5) < RAMUsageProcatage)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.ResetColor();
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Green;
            if (CPUUsageProcatage > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (CPUUsageProcatage > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(Math.Round(RAMUsageProcatage) + "%");
            Console.ResetColor();
            Console.WriteLine("");
            return true;
        }
    }
}
