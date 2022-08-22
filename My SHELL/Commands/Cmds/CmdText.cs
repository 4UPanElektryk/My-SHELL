using ConsoleDraw;
using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using MyShell.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;

namespace MyShell.Commands.Cmds
{
    class CmdText : Cmd
    {
        public CmdText(string name) : base(name)
        {
        }
        public override bool Execute(string[] args, string input, User user)
        {
            WindowManager.UpdateWindow(100, 40);
            WindowManager.UpdateWindow(100, 40);
            WindowManager.SetWindowTitle("TEXT");
            //Start Program
            new MainWindow();
            Console.ResetColor();
            Console.Clear();
            Dual.Watermark();
            Console.Title = "My Shell " + Settings.Default["Version"].ToString();
            if (Program.Experimental)
            {
                Console.Title += " Experimental";
            }
            return true;
        }
    }
}
