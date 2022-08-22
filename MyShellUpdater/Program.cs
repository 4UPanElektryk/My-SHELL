using System;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace MyShell.Updater
{
    class Program
    {
        public static string Url = "https://raw.githubusercontent.com/4UPanElektryk/Maciek-SHELL/main/Update.json";
        public static string BetaUrl = "https://raw.githubusercontent.com/4UPanElektryk/Maciek-SHELL/main/BetaUpdate.json";
        static int Main(string[] args)
        {
            WebClient web = new WebClient();
            Console.OutputEncoding = Encoding.Unicode;
            if (args.Length == 3)
            {
                if (args[0].StartsWith("-c"))
                {
                    if (double.TryParse(args[1], out double version) && int.TryParse(args[2], out int build))
                    {
                        string jsonfile;
                        if (args[0] == "-cb")
                        {
                            jsonfile = web.DownloadString(BetaUrl);
                        }
                        else
                        {
                            jsonfile = web.DownloadString(Url);
                        }
                        UpdateFile updateFile = JsonConvert.DeserializeObject<UpdateFile>(jsonfile);
                        if (updateFile.Version > version || (updateFile.Version == version && updateFile.BuildNumber > build))
                        {
                            Console.WriteLine("Your Version: " + version + "." + build);
                            Console.WriteLine("Server Version: " + updateFile.Version + "." + updateFile.BuildNumber);
                            Console.WriteLine("Found Newer Version");
                            return 1;
                        }
                        else
                        {
                            Console.WriteLine("Not Found Newer Version");
                            return 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to Parse Data");
                        return 2;
                    }
                }
            }
            else if (args.Length == 1)
            {
                if (args[0] == "help")
                {
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃ My Shell Updater ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━┛");
                    Console.WriteLine("Use: ");
                    Console.WriteLine("Updater.exe -c <Version> <Build>");
                    Console.WriteLine("Updater.exe -cb <Version> <Build>");
                    Console.WriteLine("Updater.exe -update");
                    Console.WriteLine("Updater.exe -updatebeta");
                }
                Process[] process;
                if (args[0].StartsWith("update"))
                {
                    Thread.Sleep(500);
                    process = Process.GetProcessesByName("MShell.exe");
                    foreach (Process item in process)
                    {
                        item.Kill();
                    }
                }
                if (args[0] == "update")
                {
                    string jsonfile = web.DownloadString(Url);
                    UpdateFile updateFile = JsonConvert.DeserializeObject<UpdateFile>(jsonfile);
                    foreach (LinkPath item in updateFile.Files)
                    {
                        if (File.Exists(item._Path))
                        {
                            File.Delete(item._Path);
                        }
                        web.DownloadFile(item._Uri,item._Path);
                    }
                }
                if (args[0] == "updatebeta")
                {
                    string jsonfile = web.DownloadString(BetaUrl);
                    UpdateFile updateFile = JsonConvert.DeserializeObject<UpdateFile>(jsonfile);
                    foreach (LinkPath item in updateFile.Files)
                    {
                        if (File.Exists(item._Path))
                        {
                            File.Delete(item._Path);
                        }
                        web.DownloadFile(item._Uri, item._Path);
                    }
                }
            }
            return 0;
        }
    }
}

