using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;
using MyShell.Commands.Base;

namespace MyShell.Commands
{
	public static class ModuleLoader
	{
		public static Type[] types;
		public static Dictionary<string,bool> InitModules(string directory) 
		{ 
			Dictionary<string,bool> InitLog = new Dictionary<string,bool>();
			List<Type> mains = new List<Type>();
			foreach (Assembly assembly in LoadModules(directory))
			{
				foreach (Type type in assembly.GetTypes())
				{
					if (type.FullName.EndsWith(".Main"))
					{
						object c = Activator.CreateInstance(type);
						bool ok;
						try
						{
							ok = (bool)type.GetMethod("Load").Invoke(c, null);
						}
						catch
						{
							ok = false;
						}
                        if (ok)
						{
							mains.Add(type);
						}
						InitLog.Add(assembly.GetName().Name, ok);
					}
				}
			}
			types = mains.ToArray();
			return InitLog;
		} 
		public static Cmd[] ImportCommands()
		{
			List<Cmd> cmds = new List<Cmd>();
			if (types != null)
			{
				foreach (Type type in types)
				{
					object c = Activator.CreateInstance(type);
					foreach (Cmd item in (Cmd[])type.GetMethod("ExportCommands").Invoke(c, null))
					{
						Cmd f = item;
						f.CommandSource = type.Assembly.FullName;
						cmds.Add(f);
					}
				}
			}
			return cmds.ToArray();
		}
		private static Assembly[] LoadModules(string dir)
		{
			//return new List<Assembly> { Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Modules\\SPMModule.dll") };
			var modules = new List<Assembly>();
			foreach (string item in Directory.GetFiles(dir))
			{
				if (item.EndsWith(".dll"))
				{
					modules.Add(Assembly.LoadFile(item));
				}
			}
			return modules.ToArray();
		}
	}
}
