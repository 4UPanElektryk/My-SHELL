using MShell.Essentials;
using MShell.Properties;
using MShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MShell
{
	class Program
	{
        /*
		 *     __       __                      __            __         ______   __                  __  __ 
		 *    /  \     /  |                    /  |          /  |       /      \ /  |                /  |/  |
		 *    $$  \   /$$ |  ______    _______ $$/   ______  $$ |   __ /$$$$$$  |$$ |____    ______  $$ |$$ |
		 *    $$$  \ /$$$ | /      \  /       |/  | /      \ $$ |  /  |$$ \__$$/ $$      \  /      \ $$ |$$ |
		 *    $$$$  /$$$$ | $$$$$$  |/$$$$$$$/ $$ |/$$$$$$  |$$ |_/$$/ $$      \ $$$$$$$  |/$$$$$$  |$$ |$$ |
		 *    $$ $$ $$/$$ | /    $$ |$$ |      $$ |$$    $$ |$$   $$<   $$$$$$  |$$ |  $$ |$$    $$ |$$ |$$ |
		 *    $$ |$$$/ $$ |/$$$$$$$ |$$ \_____ $$ |$$$$$$$$/ $$$$$$  \ /  \__$$ |$$ |  $$ |$$$$$$$$/ $$ |$$ |
		 *    $$ | $/  $$ |$$    $$ |$$       |$$ |$$       |$$ | $$  |$$    $$/ $$ |  $$ |$$       |$$ |$$ |
		 *    $$/      $$/  $$$$$$$/  $$$$$$$/ $$/  $$$$$$$/ $$/   $$/  $$$$$$/  $$/   $$/  $$$$$$$/ $$/ $$/ 
		 *                                                                                                   
		 *                                                                                                                                                                                                     
		*/
        static User loggedUser;
		public static bool Activated;
		public static bool Experimental;
		public static PerformanceCounter cpuCounter;
		public static PerformanceCounter ramCounter;
		public static Process currentProc;
		static void Main(string[] args)
		{
			Experimental = true;
			currentProc = Process.GetCurrentProcess();
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			ramCounter = new PerformanceCounter("Memory", "Available MBytes");
			cpuCounter.NextValue();
			try
			{
				Config.Load();
			}
			catch
			{
				Config.Reset();
				Config.Save();
				Config.Load();
			}
			try
			{
				new Log(Config._LogsConfig.Path, Config._LogsConfig.Enabled, Config._LogsConfig.Prefix);
				Activated = Activation.CheckLicense(Config._AppConfig.License);
				new UserController(Config._UserConfig.File, Config._UserConfig.FileBackup);
			}
			catch (Exception ex)
			{
				string[] msg = {
									"Startup Failed:",
									ex.Message,
									ex.Data.ToString(),
									ex.Source.ToString(),
									"Application will be restarted"
								};
				Dual.ShowMsg(msg, Dual.IntToColor(15), Dual.IntToColor(4));
				Console.ReadKey();
			}
			//Console.Clear();
			Console.Title = "Maciek Shell " + Settings.Default["Version"].ToString();
            if (Experimental)
            {
                Console.Title += " Experimental";
            }
            try
			{	
				Dual.Watermark();
				do
				{
					bool action = false;
					string input = Console.ReadLine().ToLower();
					string[] TInput = input.Split(' ');
					int nbt = TInput.Length;
					Log.AddEvent(new Event("User Action - Input: " + input, Event.Type.Normal, DateTime.Now));
					switch (TInput[0])
					{

						//Pomoc
						case "help":
						case "?":
							if (nbt > 1)
							{
								if (TInput[1] == "-user")
								{
									Log.AddEvent(new Event("User Action - Help Opened: Help Sub -user", Event.Type.Normal, DateTime.Now));
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
							Log.AddEvent(new Event("User Action: Notepad oppening", Event.Type.Normal, DateTime.Now));
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
							if (Program.Experimental)
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
							if (Program.Experimental)
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
			catch (Exception ex)
			{
				Log.AddEvent(new Event("Aplication Crashed Message: " + ex.Message, Event.Type.Critical_Error, DateTime.Now));
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: " + ex.Message);
				Console.WriteLine("Something went wrong");
				if (Debugger.IsAttached)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					if (Dual.YesOrNO("Do You want to Continue with code?"))
					{
						User tempusr = new User(0, Guid.Empty, User.Type.User, "Temporary User", "");
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
