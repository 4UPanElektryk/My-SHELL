using MShell.Essentials;
using MShell.Integrations.User_Manager;
using System;

namespace MShell.Commands.SubCmds
{
	public class CmdUsers_CP : SubCmd
	{
		public CmdUsers_CP(string name) : base(name)
		{

		}

		public override bool Execute(string[] args, string input, User user)
		{
			Console.WriteLine("!-{User Password Change wizard}-!");
			int id = user._Id;
			Guid guid = user._Guid;
			User.Type type = user._State;
			string login = user._Login;
			Console.WriteLine("Password:");
			string s = Console.ReadLine();
			if (UserController.FindUser(login, s) != null)
			{
				Console.WriteLine("New Password:");
				string sl = Console.ReadLine();
				UserController.DeleteUser(user);
				UserController.AddUserOverride(new User(id, guid, type, login, sl));
			}
			else
			{
				Dual.Msg("Incorrect Password", ConsoleColor.Red);
			}
			return true;
		}
	}
}
