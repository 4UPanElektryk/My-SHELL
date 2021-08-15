using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MOS_User_Menager_Integration;
using Maciek_OS_Core.Properties;
using Maciek_OS_Core;

namespace Maciek_OS_Core
{
    class LoggedProgram
    {
		public static void LoggedMain(User user)
		{
			Console.Clear();
			Dual.Watermark();
			bool loop = true;
			do
			{
				bool action = false;
				Console.Write(">>");
				string input = Console.ReadLine().ToLower();
				string[] TInput = input.Split(' ');
				int nbt = TInput.Length;
				switch (TInput[0])
				{
					//User
					case "user":
						if (nbt > 1)
						{
							if ((TInput[1] == "-add") && nbt == 2)
							{
								action = true;
								Console.WriteLine("!--{User creator wizard}--!");
								Console.WriteLine("Login: Write '!Exit!' to Exit");
								string login = Console.ReadLine();
								if (login != "!Exit!")
								{
									if (UserController.IsItFree(login))
									{
										Console.WriteLine("Password:");
										string password = Console.ReadLine();
										Console.WriteLine("User Type: 0 - System Admin, 1 - Admin, 2 - User");
										int type;
										bool l = int.TryParse(Console.ReadLine(), out type);
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
										Dual.Msg("This Username is alredy taken", ConsoleColor.Red);
									}
								}
							}
							if ((TInput[1] == "-list") && nbt == 2)
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
							if ((TInput[1] == "-delete" || TInput[1] == "-del") && nbt == 2)
							{
								action = true;
								Console.WriteLine("!--{User Delete wizard}--!");
								Console.WriteLine("Id:");
								int Id;
								bool t = int.TryParse(Console.ReadLine(), out Id);
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
							if (TInput[1] == "-info")
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
                                    if (TInput[2] == "/full")
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
									if (TInput[2] == "/id")
									{
										action = true;
										Console.WriteLine("Id:");
										int Id;
										bool t = int.TryParse(Console.ReadLine(), out Id);
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
									if ((TInput[2] == "/id") && (TInput[3] == "/full"))
									{
										action = true;
										if (user._State == User.Type.SysAdmin)
										{
											Console.WriteLine("Id:");
											int Id;
											bool t = int.TryParse(Console.ReadLine(), out Id);
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
						break;
					//User


					case "hmmmmm":
						action = true;
						Console.WriteLine("");
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("+--{Achivment Get}--+");
						Console.WriteLine("How Did We Get Here? ");
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("");
						break;

					//Logoff
					case "logoff":
						action = true;
						Console.Write("Do You want to Logoff? Y | N >> ");
						ConsoleKey Key = Console.ReadKey().Key;
						if (Key == ConsoleKey.Y)
						{
							Console.WriteLine("");
							loop = false;
						}
						else
						{
							Console.WriteLine("");
						}
						break;
					//Koniec Logoff

					//Koniec
					case "":
						action = true;
						break;
					default:
						action = true;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Incorect command '" + TInput[0] + "'");
						Console.WriteLine("Type 'Help' or '?' for help");
						Console.ForegroundColor = ConsoleColor.White;
						break;
				}
				if (!action)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Incorect command '" + input + "'");
					Console.WriteLine("Type 'Help' or '?' for help");
					Console.ForegroundColor = ConsoleColor.White;
				}
			} while (loop);
			Console.Clear();
			Console.WriteLine("You have been logged off");
			Thread.Sleep(3000);
			Console.Clear();
			Dual.Watermark();
		}
	}
}
