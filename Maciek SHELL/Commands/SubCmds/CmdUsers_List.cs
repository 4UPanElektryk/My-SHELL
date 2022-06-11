using MShell.Integrations.User_Manager;
using System;
using System.Collections.Generic;

namespace MShell.Commands.SubCmds
{
	public class CmdUsers_List : SubCmd
	{
		public CmdUsers_List(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
		{
			Console.WriteLine("   ID   |  User Type  |  Login");
			List<User> userbase = UserController.ReturnUsers();
			foreach (User item in userbase)
			{
				if (item._Visible)
				{
					string id = item._Id.ToString();
					for (int i = id.Length; i < 6; i++)
					{
						id = " " + id;
					}
					Console.Write(" " + id + " |  ");
					if (item._State == User.Type.SysAdmin)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("SysAdmin");
					}
					else if (item._State == User.Type.Admin)
					{
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write("Admin   ");
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.Write("User    ");
					}
					Console.ResetColor();
					Console.WriteLine("   | " + item._Login);
				}
			}
			return true;
		}

	}
}
