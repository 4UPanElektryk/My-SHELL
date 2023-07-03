using System;
using MyShell.Commands.Base;

namespace SPMModule
{
	public class Main
	{
		public static bool Load()
		{
            return false;
        }
		public static Cmd[] ExportCommands()
		{
			return new Cmd[]
			{
				new TestCmd("f")
			};
		}
	}
}
