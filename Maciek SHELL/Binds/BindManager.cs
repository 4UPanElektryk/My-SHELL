using MShell.Commands;
using MShell.Essentials;
using MShell.Integrations.User_Manager;
using Newtonsoft.Json;
using SimpleLogs4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MShell.Binds
{
    public class BindManager
    {
        public static List<Bind> Binds { get; set; }
        public static string Path { get; set; }
        public BindManager(string path)
        {
            Binds = new List<Bind>();
            Path = path;
            Load();
        }
        public static void Load()
        {
            if (File.Exists(Path))
            {
                string file = File.ReadAllText(Path);
                try
                {
                    Binds = JsonConvert.DeserializeObject<List<Bind>>(file);
                }
                catch
                {
                    Binds = new List<Bind>();
                }
            }
        }
        public static void Save()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(Binds, Formatting.Indented));
        }
        public static void AddBind(Bind bind)
        {
            Log.Write("Added bind: " + bind.Name);
            Binds.Add(bind);
            Save();
        }
        public static void RemoveBind(Bind bind)
        {
            Binds.Remove(bind);
            Save();
        }
        public static Bind GetBind(string name)
        {
            foreach (Bind item in Binds)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public static bool ExecuteBind(string input, User user)
        {
            CommandMenager commandMenager = new CommandMenager();
            string[] args = input.Split(' ');
            string name = args[0];
            Bind bind = GetBind(name);
            if (bind == null)
            {
                Dual.Msg("No Binds Named \"" + name + "\" Found", ConsoleColor.Red);
                return false;
            }
            if (!File.Exists(bind.Path))
            {
                Dual.Msg("Bind file not found \"" + bind.Path + "\"", ConsoleColor.Red);
                return true;
            }
            int lastline = 0;
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Dictionary<string, string> argsDict = new Dictionary<string, string>();
                if (bind.Args != (args.Length - 1))
                {
                    Dual.Msg("Bind Takes " + bind.Args + " not " + args.Length, ConsoleColor.Red);
                    return true;
                }
                if (bind.Args > 0)
                {
                    for (int i = 0; i < bind.Args; i++)
                    {
                        argsDict.Add("$%" + i, args[i + 1]);
                    }
                }
                foreach (string item in File.ReadAllLines(bind.Path))
                {
                    string command = item;
                    command = argsDict.Aggregate(command, (result, s) => result.Replace(s.Key, s.Value));
                    commandMenager.ExecuteCommandForBind(command, user);
                    lastline++;
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Dual.Msg(ex.Message, ConsoleColor.Red);
                Dual.Msg(ex.Source, ConsoleColor.Red);
                Log.Write("Exeption Encountered while executing bind: At line: " + lastline + " Message: \"" + ex.Message, Event.Type.Error);
            }
            return true;
        }
    }
}
