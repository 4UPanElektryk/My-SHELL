using System;
using System.Collections.Generic;

namespace SPMModule
{
	public class SPMModule
	{
		public static void OnLoad()
		{
            Console.WriteLine("Loaded Succesfully");
            Console.WriteLine(AppContext.BaseDirectory);
        }
		public static List<Cmd> ExportCommands()
		{
			return new List<Cmd>
			{
				new TestCmd("f")
			};
		}
	}
}
