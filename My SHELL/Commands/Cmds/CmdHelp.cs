using System;
using MyShell.Commands.Base;

namespace MyShell.Commands.Cmds
{
    class CmdHelp : Cmd
    {
        public CmdHelp(string name) : base(name)
        {
            description = "Shows list of all commands";
            args = "<Command Name>";
        }

        public override bool Execute(string[] args, string input)
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
                    Console.WriteLine(cmd.Name + " - " + cmd.description);
                }
                return true;
            }
            if (args.Length == 2)
            {
                foreach (Cmd item in CommandMenager.CmdList)
                {
                    if (item.Name == args[1])
                    {
                        Console.WriteLine($"Listing information about command:");
                        Console.WriteLine($"{item.Name} - {item.description}");
                        Console.WriteLine($"Usage: {item.Name} {item.args}");
                        Console.WriteLine($"Command Source: {item.CommandSource}");
                        foreach (SubCmd item2 in item.Subs)
                        {
                            if (item2.IsDefault)
                            {
                                Console.WriteLine($"!> Default");
                            }
                            if (item2.Name != null)
                            {
                                Console.WriteLine($" > {item2.Name}");
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
