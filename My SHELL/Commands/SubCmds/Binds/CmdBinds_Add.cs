using MyShell.Binds;
using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.IO;

namespace MyShell.Commands.SubCmds
{
    class CmdBinds_Add : SubCmd
    {
        public CmdBinds_Add(string name) : base(name) { }
        public override bool Execute(string[] args, string input, User user)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Dual.Msg("Name is Empty", ConsoleColor.Red);
                return true;
            }
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Path: ");
            string path = Console.ReadLine();
            if (!path.EndsWith(".bind"))
            {
                Dual.Msg("File Is Not a .bind file", ConsoleColor.Red);
                return true;
            }
            if (!File.Exists(path))
            {
                Dual.Msg("File Not Found", ConsoleColor.Red);
                return true;
            }
            int i = 0;
            Console.WriteLine("Number of Arguments: ");
            int.TryParse(Console.ReadLine(), out i);
            Bind bind = new Bind()
            {
                Name = name,
                Description = description,
                Path = path,
                Args = i
            };
            Log.Write("Added bind by User " + user._Id, Event.Type.Informtion);
            BindManager.AddBind(bind);
            return true;
        }
    }
}
