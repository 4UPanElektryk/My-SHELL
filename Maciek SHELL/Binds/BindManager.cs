using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Integrations.User_Manager;
using MShell.Essentials;
using MShell.Commands;
using Newtonsoft.Json;
using System.IO;

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
			File.WriteAllText(Path, JsonConvert.SerializeObject(Binds,Formatting.Indented));
		}
		public static void AddBind(Bind bind)
		{
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
			if (!File.Exists(bind.Path))
			{
				Dual.Msg("Bind file not found \"" + bind.Path + "\"", ConsoleColor.Red);
				return true;
			}
			if (bind == null)
			{
				Dual.Msg("No Binds Named \"" + name + "\" Found", ConsoleColor.Red);
				return false;
			}
			try
			{
                Dictionary<string, string> argsDict = new Dictionary<string, string>();
                foreach (string item in File.ReadAllLines(bind.Path))
				{
					string command = item;
                    if (bind.Args > 0)
                    {
                        for (int i = 0; i < bind.Args; i++)
                        {
                            command = command.Replace("$%" + i, args[i + 1]);
                        }
                    }
					commandMenager.ExecuteCommandForBind(command, user);
				}
			}
			catch (Exception ex)
			{
				Dual.Msg(ex.Message, ConsoleColor.Red);
				Dual.Msg(ex.Source, ConsoleColor.Red);
			}
			return true;
		}
	}
}
