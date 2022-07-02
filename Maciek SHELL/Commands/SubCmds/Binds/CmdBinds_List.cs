using MShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Binds;

namespace MShell.Commands.SubCmds
{
    class CmdBinds_List : SubCmd
    {
        public CmdBinds_List(string name) : base(name)
        {
        }
        public override bool Execute(string[] args, string input, User user)
        {
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
