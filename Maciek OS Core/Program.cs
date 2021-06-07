using System;
using Maciek_OS_Core.Properties;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOS_User_Menager_Integration;

namespace Maciek_OS_Core
{
	class Program
	{
		//	static bool logged = false;
		static User loggedUser;
		static void Main(string[] args)
		{
			UserController userController = new UserController();
			Console.Title = "Maciek OS Core " + Settings.Default["Version"].ToString();
			try
			{
				
				if ((bool)Settings.Default["Experimental"])
				{
					Console.Title = Console.Title + " Experimental";
				}
				Watermark();
				do
				{
					string input = Console.ReadLine();
					string[] TInput = input.Split(' ');
					int nbt = TInput.Length;
					switch (TInput[0])
					{

						//Pomoc
						case "Help":
						case "help":
						case "?":
							if (nbt > 1)
							{
								if (TInput[1] == "-User" || TInput[1] == "-user")
								{
									Console.WriteLine("User");
									Console.WriteLine("-login for login");
									Console.WriteLine("-list for list all user");
									Console.WriteLine("Use -Login /Id");
								}
							}
							else
							{
								Console.WriteLine("+-----------+{Help Guide}+-----------+");
								Console.WriteLine("User - use Help -User for more info");
								Console.WriteLine("+-{You need to login fore more info}-+");
							}
							break;
							//Koniec Pomocy

							//Użytkownik
						case "User":
						case "user":
							if (nbt > 1)
							{
								if ((TInput[1] == "-List" || TInput[1] == "-list") && nbt == 2)
								{
									Console.WriteLine("  ID  |  User Type  |  Login");
									List<User> userbase = UserController.ReturnUsers();
									foreach (User item in userbase)
									{
										if (item.Visible)
										{
											Console.WriteLine("  " + item.Id + "  |  " + item.AdminState + "  |  " + item.Login);
										}
									}
								}
								if ((TInput[1] == "-Login" || TInput[1] == "-login") && nbt == 2)
								{
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
										LoggedMain(loggedUser);
									}
									else
									{
										Console.Clear();
										Watermark();
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("!--{Incorrect User or Password}--!");
										Console.ForegroundColor = ConsoleColor.White;
									}
								}
								if (((TInput[1] == "-Login" || TInput[1] == "-login") && nbt == 3) && (TInput[2] == "/Id" || TInput[2] == "/id"))
								{
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
											LoggedMain(loggedUser);
										}
										else
										{
											Console.Clear();
											Watermark();
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("!--{Incorrect User or Password}--!");
											Console.ForegroundColor = ConsoleColor.White;
										}
                                    }
                                    else
                                    {
										Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("sorry but this should be number");
										Console.ForegroundColor = ConsoleColor.White;
									}
									
								}
							}
							else
							{
								Console.WriteLine("You need to use - subaction");
							}
							break;
							//Koniec Użytkownika

							
						case "Test":
						case "test":
                            if ((bool)Settings.Default["Experimental"])
                            {

                            }
							UserController.Save();
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Incorect command '" + TInput[0] + "'");
							Console.WriteLine("Type 'Help' or '?' for help");
							Console.ForegroundColor = ConsoleColor.White;
							break;
					}
				} while (true);
			}
			catch
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Something went wrong");
                if (true)
                {
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Do You want to Continue with code? Y | N >>");
					Console.ReadKey();
					LoggedMain(null);
				}
				Console.ForegroundColor = ConsoleColor.White;
			}

		}
		static void Watermark()
		{
			Console.OutputEncoding = Encoding.Unicode;
			if ((bool)Settings.Default["Experimental"])
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			Console.WriteLine("+----------------------+");
			Console.WriteLine("|  Maciek Basic ©" + Settings.Default["Year"].ToString() + "  |");
			Console.WriteLine("|  Ver " + Settings.Default["Version"].ToString() + "   CL " + Settings.Default["Compiled"].ToString() + "  |");
			if ((bool)Settings.Default["Experimental"])
			{
				Console.WriteLine("|  Experimental  " + Settings.Default["Build"].ToString() + "  |");
			}
			Console.WriteLine("+----------------------+");
			Console.ForegroundColor = ConsoleColor.White;
		}
		static void LoggedMain(User user)
		{
			Console.Clear();
			Watermark();
			bool loop = true;
			do
			{
				Console.Write(">>");
				string input = Console.ReadLine();
				string[] TInput = input.Split(' ');
				int nbt = TInput.Length;
				switch (TInput[0])
				{
					//Logoff
					case "Logoff":
						Console.Write("Do You want to Logoff? Y | N >> ");
						ConsoleKey Key = Console.ReadKey().Key;
                        if (Key == ConsoleKey.Y)
                        {
							Console.WriteLine("");
							loop = false;
                        }
                        else if (Key == ConsoleKey.N)
                        {
							Console.WriteLine("");
						}
						break;
						//Koniec Logoff

					//Koniec
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Incorect command '" + TInput[0] + "'");
						Console.WriteLine("Type 'Help' or '?' for help");
						Console.ForegroundColor = ConsoleColor.White;
						break;
				}

			} while (loop);
			Console.Clear();
            Console.WriteLine("You have been logged off");
		}
	}
}
