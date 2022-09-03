using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
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
        public override bool Execute(string[] args, string input, User user)
        {
            if (Dual.YesOrNO("Run The TEST?"))
            {
                for (int i = 0; i <= 15; i++)
                {

                    ProgressBar.show(50, Dual.IntToColor(i));
                    Dual.ProgressBar(50, Dual.IntToColor(i), false);
                    Dual.Msg("Test Message For Color Nr. " + i, Dual.IntToColor(i));
                    Dual.Msg("Test Message For Color Nr. " + i, ConsoleColor.White, Dual.IntToColor(i));
                }
            }
            return true;
        }
    }
}
