using System;
using System.Collections.Generic;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core.Commands
{
	public class CmdUser
	{
		private User _User;
		public bool Execute(string[] args, User user)
		{
			bool action = false;
			int nbt = args.Length;
			_User = user;
			if (nbt > 1)
			{
				if (((args[1] == "-cp") || (args[1] == "-changepassword")) && nbt == 2)
                {
					action = true;
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
						UserController.AddUser(new User(id,guid,type,login,sl));
					}
                    else
                    {
						Dual.Msg("Incorrect Password", ConsoleColor.Red);
					}
                }
				if ((args[1] == "-add") && nbt == 2)
				{
					action = true;
					Console.WriteLine("!--{User creator wizard}--!");
					Console.WriteLine("Login: Write '!Exit!' to Exit");
					string login = Console.ReadLine();
					if (login != "!Exit!")
					{
						if (UserController.IsItFree(login))
						{
							Console.WriteLine("Password:(can't contain '|')");
							bool x = true;
							string password = Console.ReadLine();
							foreach (char item in password)
							{
								if (item == '|')
								{
									x = false;
								}
							}
                            if (x)
                            {
								Console.WriteLine("User Type: 0 - System Admin, 1 - Admin, 2 - User");
								bool l = int.TryParse(Console.ReadLine(), out int type);
								if (l)
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
									else
									{
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
								Dual.Msg("password can't contain ' | '", ConsoleColor.Red);

							}
						}
						else
						{
							Dual.Msg("This Username is alredy taken", ConsoleColor.Red);
						}
					}
				}
				if ((args[1] == "-list") && nbt == 2)
				{
					action = true;
					Console.WriteLine("  ID  |  User Type  |  Login");
					List<User> userbase = UserController.ReturnUsers();
					foreach (User item in userbase)
					{
						if (item._Visible)
						{
							Console.WriteLine("  " + item._Id + "  |  " + item._State + "  |  " + item._Login);
						}
					}
				}
				if ((args[1] == "-delete" || args[1] == "-del") && nbt == 2)
				{
					action = true;
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
				}
				if (args[1] == "-info")
				{
					if (nbt == 2)
					{
						action = true;
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
					if (nbt == 3)
					{
						if (args[2] == "-full")
						{
							action = true;
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
						if (args[2] == "-id")
						{
							action = true;
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
					if (nbt == 4)
					{
						if ((args[2] == "-id") && (args[3] == "-full"))
						{
							action = true;
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
				}


			}
			else
			{
				Console.WriteLine("You need to use -subaction");
				Console.WriteLine("Use Help -User for subactions");
			}
			return action;
		}
		public bool ScriptExecute(string[] args, User user)
		{
			bool action = false;
			int nbt = args.Length;
			_User = user;

			return action;
		}
	}
}
