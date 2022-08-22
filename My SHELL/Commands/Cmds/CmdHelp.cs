using MyShell.Integrations.User_Manager;
using System;

namespace MyShell.Commands.Cmds
{
    class CmdHelp : Cmd
    {
        public CmdHelp(string name) : base(name)
        {
            description = "Shows list of all commands";
            args = "<Command Name>";
        }

        public override bool Execute(string[] args, string input, User user)
        {
            if (args.Length > 2)
            {
                Console.WriteLine("this command takes only 1 argument");
                return true;
            }
            if (args.Length == 1)
            {
                Console.WriteLine("Command List:");
                foreach (Cmd cmd in CommandMenager.CmdList)
                {
                    Console.WriteLine(cmd._Name + " - " + cmd.description);
                }
                return true;
            }
            if (args.Length == 2)
            {
                foreach (Cmd item in CommandMenager.CmdList)
                {
                    if (item._Name == args[1])
                    {
                        Console.WriteLine("Listing information about command:");
                        Console.WriteLine(item._Name + " - " + item.description);
                        foreach (SubCmd item2 in item._Subs)
                        {
                            if (item2._IsDefault)
                            {
                                Console.WriteLine("!> " + "Default");
                            }
                            if (item2._Name != null)
                            {
                                Console.WriteLine(" > " + item2._Name);
                            }
                        }
                    }
                }
                return true;
            }
            return true;
        }
    }
}
