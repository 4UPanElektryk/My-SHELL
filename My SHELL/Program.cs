using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using MyShell.Properties;
using SimpleLogs4Net;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace MyShell
{
    class Program
    {
        static User loggedUser;
        public static bool IsUnix;
        public static bool UseASCII;
		public static bool FoundUpdater;
		public static bool Experimental;
		public static List<string> inputs;
        public static PerformanceCounter cpuCounter;
		public static PerformanceCounter ramCounter;
		public static Process currentProc;
		static void Main(string[] args)
		{
            Experimental = true;
			FoundUpdater = false;
			currentProc = Process.GetCurrentProcess();
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			ramCounter = new PerformanceCounter("Memory", "Available MBytes");
			cpuCounter.NextValue();
			Console.Title = "My Shell " + Settings.Default["Version"].ToString();
            if (Experimental)
            {
                Console.Title += " Experimental";
            }
            bool testpassed = RST.RunTest();
            Console.ResetColor();
            if (!testpassed)
            {
                return;
            }
            UseASCII = Config._AppConfig.UseAsciiOnly;
			Console.ResetColor();
			Console.Clear();
			new MakeCrashLog(Config._LogsConfig.Path + "crash.log");
            try
            {
                Dual.Watermark();
                if (CheckUpdates.CheckForUpdates())
                {
                    Dual.Msg("Newer version has been found!", ConsoleColor.Cyan);
                    Dual.Msg("If you want to update Type \"update\"", ConsoleColor.Cyan);
                }
                do
                {
                    bool action = false;
                    string input = Console.ReadLine().ToLower();
                    string[] TInput = input.Split(' ');
                    int nbt = TInput.Length;
                    Log.AddEvent(new Event("User Action - Input: " + input, EType.Normal, DateTime.Now));
                    switch (TInput[0])
                    {
                        case "update":
                            CheckUpdates.Update();
                            break;

                        case "exit":
                            return;

                        //Pomoc
                        case "help":
                        case "?":
                            if (nbt > 1)
                            {
                                if (TInput[1] == "-user")
                                {
                                    Log.AddEvent(new Event("User Action - Help Opened: Help Sub -user", EType.Normal, DateTime.Now));
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
                            Log.AddEvent(new Event("User Action: Notepad oppening", EType.Normal, DateTime.Now));
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
                            if (Config._AppConfig.DevMode)
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
                Log.AddEvent(new Event("Aplication Crashed Message: " + ex.Message, EType.Critical_Error, DateTime.Now));
                Console.ForegroundColor = ConsoleColor.Red;
                string[] strings =
                {
                    "Error: " + ex.Message,
                    ex.Source,
                    ex.StackTrace,
                    "Something went wrong"
                };
                Dual.ShowMsg(strings, ConsoleColor.White, ConsoleColor.Red);
				MakeCrashLog.WriteLog(ex.Message,ex.Source,ex.StackTrace,inputs);
                if (Config._AppConfig.DevMode)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					if (Dual.YesOrNO("Do You want to Continue with code?"))
					{
						User tempusr = new User(0, Guid.Empty, User.Type.SysAdmin, "Temporary User", "");
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
