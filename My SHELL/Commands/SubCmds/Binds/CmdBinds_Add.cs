using MyShell.Binds;
using MyShell.Essentials;
using SimpleLogs4Net;
using System;
using System.IO;
using MyShell.Commands.Base;

namespace MyShell.Commands.SubCmds.Binds
{
    class CmdBinds_Add : SubCmd
    {
        public CmdBinds_Add(string name) : base(name) { }
        public override bool Execute(string[] args, string input)
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
			Console.WriteLine("Number of Arguments: ");
            if (int.TryParse(Console.ReadLine(), out int i))
            {
				Bind bind = new Bind()
				{
					Name = name,
					Description = description,
					Path = path,
					Args = i
				};
				Log.Write("Added bind: " + name, EType.Informtion);
				BindManager.AddBind(bind);
			}
            else
            {
                Console.WriteLine("Not a number");
            }
            return true;
        }
    }
}
