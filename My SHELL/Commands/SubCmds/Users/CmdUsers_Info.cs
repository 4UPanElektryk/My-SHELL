using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using System;

namespace MyShell.Commands.SubCmds.Users
{
    class CmdUsers_Info : SubCmd
    {
        public CmdUsers_Info(string name) : base(name)
        {

        }

        public override bool Execute(string[] args, string input, User user)
        {
            int nbt = args.Length;
            if (nbt == 0)
            {
                if (user != null)
                {
                    Console.WriteLine("User.Id -    " + user._Id);
                    Console.WriteLine("User.Login - " + user._Login);
                    Console.WriteLine("User.State - " + user._State);
                }
                else
                {
                    Dual.Msg("Cannot show info if user is null", ConsoleColor.Red);
                }
            }
            else if (nbt == 1)
            {
                if (args[0] == "full")
                {
                    if (user != null)
                    {
                        Console.WriteLine("User.Id      - " + user._Id);
                        Console.WriteLine("User.Login   - " + user._Login);
                        Console.WriteLine("User.State   - " + user._State);
                        Console.WriteLine("User.Visible - " + user._Visible);
                        Console.WriteLine("User.Guid    - " + user._Guid);

                    }
                    else
                    {
                        Dual.Msg("Cannot show info if user is null", ConsoleColor.Red);
                    }
                }
                if (args[0] == "id")
                {
                    Console.WriteLine("Id:");
                    bool t = int.TryParse(Console.ReadLine(), out int Id);
                    if (t)
                    {
                        if (UserController.FindUserByIdNoPass(Id) != null)
                        {
                            User localuser = UserController.FindUserByIdNoPass(Id);
                            Console.WriteLine("User.Id -    " + localuser._Id);
                            Console.WriteLine("User.Login - " + localuser._Login);
                            Console.WriteLine("User.State - " + localuser._State);

                        }
                        else
                        {
                            Dual.Msg("Id must be incorrect", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        Dual.Msg("sorry but this value should be number", ConsoleColor.Red);
                    }
                }
            }
            else if (nbt == 2)
            {
                if ((args[0] == "id") && (args[1] == "full"))
                {
                    if (user._State == User.Type.SysAdmin)
                    {
                        Console.WriteLine("Id:");
                        bool t = int.TryParse(Console.ReadLine(), out int Id);
                        if (t)
                        {
                            if (UserController.FindUserByIdNoPass(Id) != null)
                            {
                                User localuser = UserController.FindUserByIdNoPass(Id);

                                Console.WriteLine("--{User Info}--");
                                Console.WriteLine("User.Id      - " + localuser._Id);
                                Console.WriteLine("User.Login   - " + localuser._Login);
                                Console.WriteLine("User.State   - " + localuser._State);
                                Console.WriteLine("User.Visible - " + localuser._Visible);
                                Console.WriteLine("User.Guid    - " + localuser._Guid);
                            }
                            else
                            {
                                Dual.Msg("Id must be incorrect", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            Dual.Msg("sorry but this value should be number", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
                    }
                }
            }
            return true;
        }
    }
}
