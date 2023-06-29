using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;
using Newtonsoft.Json;

namespace MyShell.Commands
{
	public class ModLoader
	{
		public ModLoader() { }
		public static List<Cmd> ImportCommands()
		{
			foreach (Assembly assembly in LoadModules("Modules\\"))
			{
				Console.WriteLine("x");
				/*Type type = assembly.GetType("SPMModule.SPMModule");
				object c = Activator.CreateInstance(type);
				type.GetMethod("OnLoad").Invoke(c, new object[] { });
				Console.WriteLine(JsonConvert.SerializeObject(type));*/
			}
			return new List<Cmd>();
		}
		private static List<Assembly> LoadModules(string dir)
		{
			var modules = new List<Assembly>();
			foreach (string item in Directory.GetFiles(dir))
			{
				if (item.EndsWith(".dll"))
				{
					modules.Add(Assembly.LoadFile(item));
				}
			}
			return modules;
		}
	}
}
