using System;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Maciek_OS_Core.Properties;
using MOS_User_Menager_Integration;
using Maciek_OS_Core;

namespace Maciek_OS_Core
{
	class Program
	{

		static User loggedUser;
		static UserController userController; //nie usuwać
		static void Main(string[] args)
		{
			bool action = false;
			Config.LoadConfig();
			userController = new UserController(Config.UserPath, Config.UserPathOld);
			Console.Title = "Maciek OS Core " + Settings.Default["Version"].ToString();
			try
			{
				if ((bool)Settings.Default["Experimental"])
				{
					Console.Title = Console.Title + " Experimental";
				}
				Dual.Watermark();
				do
				{
					string input = Console.ReadLine().ToLower();
					string[] TInput = input.Split(' ');
					int nbt = TInput.Length;
					switch (TInput[0])
					{

						//Pomoc
						case "help":
						case "?":
							if (nbt > 1)
							{
								if (TInput[1] == "-user")
								{
									action = true;
									Console.WriteLine("User");
									Console.WriteLine("-login for login");
									Console.WriteLine("-list for list all user");
									Console.WriteLine("Use -Login /Id");
								}
							}
							else
							{
								action = true;
								Console.WriteLine("+-----------+{Help Guide}+-----------+");
								Console.WriteLine("User - use Help -User for more info");
								Console.WriteLine("+-{You need to login fore more info}-+");
							}
							break;
						//Koniec Pomocy

							//Użytkownik
						case "user":
							if (nbt > 1)
							{
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
								if ((TInput[1] == "-login") && nbt == 2)
								{
									action = true;
									Console.WriteLine("User");
									Console.WriteLine("Login:");
									string User = Console.ReadLine();
									Console.WriteLine("Password:");
									Console.ForegroundColor = ConsoleColor.Black;
									string Password = Console.ReadLine();
									Console.ForegroundColor = ConsoleColor.White;
									loggedUser = UserController.FindUser(User, Password);
									if (loggedUser != null)
									{
										LoggedProgram.LoggedMain(loggedUser);
									}
									else
									{
										Console.Clear();
										Dual.Watermark();
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("!--{Incorrect User or Password}--!");
										Console.ForegroundColor = ConsoleColor.White;
									}
								}
								if ((TInput[1] == "-login" && nbt == 3) && TInput[2] == "/id")
								{
									action = true;
									Console.WriteLine("User");
									Console.WriteLine("Id:");
									string text = Console.ReadLine();
									int id;
									if (int.TryParse(text,out id))
									{
										Console.WriteLine("Password:");
										Console.ForegroundColor = ConsoleColor.Black;
										string Password = Console.ReadLine();
										Console.ForegroundColor = ConsoleColor.White;
										loggedUser = UserController.FindUserById(id, Password);
										if (loggedUser != null)
										{
											LoggedProgram.LoggedMain(loggedUser);
										}
										else
										{
											Console.Clear();
											Dual.Watermark();
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("!--{Incorrect User or Password}--!");
											Console.ForegroundColor = ConsoleColor.White;
										}
									}
									else
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("sorry but this value should be number");
										Console.ForegroundColor = ConsoleColor.White;
									}
									
								}
							}
							else
							{
								Console.WriteLine("You need to use - subaction");
								Console.WriteLine("Use Help -User for subactions");
							}
							break;
						//Koniec Użytkownika

						case "crash":
							int n = 0;
							int y = 5 / n;
							break;


						case "test":
							if ((bool)Settings.Default["Experimental"])
							{
								action = true;
								UserController.Save();
                            }
                            else
                            {
								goto default;
                            }
							break;
						case "hmmmmm":
							action = true;
							Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("+--{Achivment Get}--+");
                            Console.WriteLine("How Did We Get Here? ");
							Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
							break;
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
				} while (true);
			}
			catch(Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: " + ex.Message);
				Console.WriteLine("Something went wrong");
				if ((bool)Settings.Default["Experimental"])
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Do You want to Continue with code? Y | N >>");
					ConsoleKey Key = Console.ReadKey().Key;
					if (Key == ConsoleKey.Y)
					{
						LoggedProgram.LoggedMain(null);
						Console.WriteLine("");
					}
					else
					{
						Console.WriteLine("");
					}
				}
				Console.ReadKey();
				Console.ForegroundColor = ConsoleColor.White;
			}

		}
	}
}
