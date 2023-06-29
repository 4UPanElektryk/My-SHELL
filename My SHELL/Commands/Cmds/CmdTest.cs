using MyShell.Essentials;
using System;
using CoolConsole.Aditonal;

namespace MyShell.Commands.Cmds
{
    class CmdTest : Cmd
    {
        public CmdTest(string name) : base(name)
        {
            description = "Tests Basic Functions of SHELL";
        }
        public override bool Execute(string[] args, string input)
        {
            if (Dual.YesOrNO("Run The TEST?"))
            {
                for (int i = 0; i <= 15; i++)
                {

                    ProgressBar.ShowColor(1,2, Dual.IntToColor(i),50,true);
                    Dual.Msg("Test Message For Color Nr. " + i, Dual.IntToColor(i));
                    Dual.Msg("Test Message For Color Nr. " + i, ConsoleColor.White, Dual.IntToColor(i));
                }
            }
            return true;
        }
    }
}
