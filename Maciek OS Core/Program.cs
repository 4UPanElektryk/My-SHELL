using System;
using System.Diagnostics;
using System.Collections.Generic;
using Maciek_OS_Core.Properties;
using MOS_User_Menager_Integration;
using MOS_Log_Integration;
using Maciek_OS_Core.Essentials;

namespace Maciek_OS_Core
{
	class Program
	{
		static User loggedUser;
		static UserController userController; //nie usuwać | Do not delete this line
		static Log log; //nie usuwać | Do not delete this line
		public static bool Activated;
		static void Main(string[] args)
		{
			
			try
			{
				Config.LoadConfig();
			}
			catch
			{
				Config.DeleteConfig();
				Config.CreateNewConfig(true);
				Config.LoadConfig();
			}
			try
			{
				log = new Log(AppDomain.CurrentDomain.BaseDirectory, Config.LogsPath, Config.LogsEnabled);
				Activated = Activation.CheckLicense();
				userController = new UserController(Config.UserPath, Config.UserPathOld);
			}
			catch(Exception ex)
			{
				string[] msg = { 
									"Startup Failed:",
									ex.Message,
									ex.Data.ToString()
								};
				Dual.ShowMsg(msg,Dual.IntToColor(15), Dual.IntToColor(4));
				Console.ReadKey();
			}
			Console.Clear();
			Console.Title = "Maciek OS Core " + Settings.Default["Version"].ToString();
			try
			{
				if ((bool)Settings.Default["Experimental"])
				{
					Console.Title = Console.Title + " Experimental";
				}
                if (!Activated)
                {
					Console.Title = Console.Title + " | PRODUKT NIE ZOSTAŁ AKTYWOWANY LUB LICENCJA JEST NIE POPRAWNA";
				}
				Dual.Watermark();
				do
				{
					bool action = false;
					string input = Console.ReadLine().ToLower();
					string[] TInput = input.Split(' ');
					int nbt = TInput.Length;
					Log.AddLogEvent(new LogEvent("User Action - Input", input,LogEvent.Type.Normal, DateTime.Now));
					switch (TInput[0])
					{

						//Pomoc
						case "help":
						case "?":
							if (nbt > 1)
							{
								if (TInput[1] == "-user")
								{
									Log.AddLogEvent(new LogEvent("User Action - Help Opened", "Help Sub -user", LogEvent.Type.Normal, DateTime.Now));
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

						case "edit":
						case "note":
						case "notepad":
							action = true;
							Log.AddLogEvent(new LogEvent("User Action", "Notepad oppening", LogEvent.Type.Normal, DateTime.Now));
							Process.Start("note.exe");
							break;

							//Użytkownik
						case "user":
							if (nbt > 1)
							{
								if (nbt == 2)
								{
									if (TInput[1] == "-list")
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
									if (TInput[1] == "-login")
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
								}
								if (nbt == 3)
								{
									if (TInput[1] == "-login" && TInput[2] == "-id")
									{
										action = true;
										Console.WriteLine("User");
										Console.WriteLine("Id:");
										string text = Console.ReadLine();
										if (int.TryParse(text, out int id))
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
							}
							else
							{
								Console.WriteLine("You need to use - subaction");
								Console.WriteLine("Use Help -User for subactions");
							}
							break;
						//Koniec Użytkownika

						case "crash":
							if ((bool)Settings.Default["Experimental"])
							{
								int n = 0;
								int y = 5 / n;
							}
							else
							{
								goto default;
							}
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
				Log.AddLogEvent(new LogEvent("Aplication Crashed", ex.Message, LogEvent.Type.Critical_Error, DateTime.Now));
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
						User tempusr = new User(0, Guid.Empty, User.Type.User, "", "");
						tempusr._Visible = false;
						LoggedProgram.LoggedMain(tempusr);
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
