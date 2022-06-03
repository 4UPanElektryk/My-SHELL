using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;
using System;

namespace Maciek_SHELL.Commands.Cmds.SubCmds
{
    public class CmdUsers_Del : SubCmd
    {
        public CmdUsers_Del(string name) : base(name)
        {
        }
        public override bool Execute(string[] args, string input, User user)
        {
            Console.WriteLine("!--{User Delete wizard}--!");
            Console.WriteLine("Id:");
            bool t = int.TryParse(Console.ReadLine(), out int Id);
            if (t)
            {
                Console.WriteLine("Password:");
                Console.ForegroundColor = ConsoleColor.Black;
                string Password = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                User DeleteUser;
                DeleteUser = UserController.FindUserById(Id, Password);
                if (DeleteUser != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Are you sure you want to delete this User? Y | N >>");
                    ConsoleKey Key1 = Console.ReadKey().Key;
                    if (Key1 == ConsoleKey.Y)
                    {
                        UserController.DeleteUser(DeleteUser);
                        Console.WriteLine("");
                        Console.WriteLine("User has been deleted");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("User deletion canceled");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Dual.Msg("sorry but this value should be number", ConsoleColor.Red);
            }
            return true;
        }
    }
}
