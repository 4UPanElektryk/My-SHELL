using MShell.Essentials;
using MShell.Integrations.User_Manager;
using System;
using System.Linq;

namespace MShell.Commands.SubCmds
{
    public class CmdUsers_Add : SubCmd
    {
        public CmdUsers_Add(string name) : base(name) { }
        public override bool Execute(string[] args, string input, User user)
        {
            Console.WriteLine("!--{User creator wizard}--!");
            Console.WriteLine("Login: (If you want tu exit leave the inout blank and press enter)");
            string login = Console.ReadLine();
            if (login != "")
            {
                if (UserController.IsItFree(login))
                {
                    Console.WriteLine("Password:(can't contain '|')");
                    string password = Console.ReadLine();
                    if (!password.Contains('|'))
                    {
                        Console.WriteLine("User Type: 0 - System Admin, 1 - Admin, 2 - User");
                        if (int.TryParse(Console.ReadLine(), out int type))
                        {
                            User.Type Utype = User.Type.User;
                            if (type == 0)
                            {
                                Utype = User.Type.SysAdmin;
                            }
                            else if (type == 1)
                            {
                                Utype = User.Type.Admin;
                            }
                            User user1 = new User(0, Guid.Empty, Utype, login, password);
                            UserController.AddUser(user1);
                        }
                        else
                        {
                            Dual.Msg("sorry but this value should be number", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        Dual.Msg("password can't contain '|'", ConsoleColor.Red);
                    }
                }
                else
                {
                    Dual.Msg("This Username is alredy taken", ConsoleColor.Red);
                }
            }
            return true;
        }
    }
}