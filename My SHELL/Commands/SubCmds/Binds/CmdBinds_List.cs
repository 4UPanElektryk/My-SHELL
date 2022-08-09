using MShell.Binds;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;

namespace MShell.Commands.SubCmds
{
    class CmdBinds_List : SubCmd
    {
        public CmdBinds_List(string name) : base(name)
        {
        }
        public override bool Execute(string[] args, string input, User user)
        {
            Log.Write("Listing binds");
            foreach (Bind item in BindManager.Binds)
            {
                Console.WriteLine();
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.Description);
                Console.WriteLine("File Path: " + item.Path);
                Console.WriteLine("Required Arguments: " + item.Args);
            }
            return true;
        }
    }
}
