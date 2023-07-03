using MyShell.Essentials;
using MyShell.Properties;
using MyShell.Commands.Base;
using System;

namespace MyShell.Commands.Cmds
{
	class CmdInfo : Cmd
	{
		private readonly int LogoWidthWithSpacing = 57;
		public CmdInfo(string name) : base(name)
		{
			description = "Shows information abot this application";
		}
		public override bool Execute(string[] args, string input)
		{
			#region Logo
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			int line = Console.CursorTop;
			Console.WriteLine(@" __       __           ______  __                __ __ ");
			Console.WriteLine(@"/  \     /  |         /      \/  |              /  /  |");
			Console.WriteLine(@"$$  \   /$$ |__    __/$$$$$$  $$ |____   ______ $$ $$ |");
			Console.WriteLine(@"$$$  \ /$$$ /  |  /  $$ \__$$/$$      \ /      \$$ $$ |");
			Console.WriteLine(@"$$$$  /$$$$ $$ |  $$ $$      \$$$$$$$  /$$$$$$  $$ $$ |");
			Console.WriteLine(@"$$ $$ $$/$$ $$ |  $$ |$$$$$$  $$ |  $$ $$    $$ $$ $$ |");
			Console.WriteLine(@"$$ |$$$/ $$ $$ \__$$ /  \__$$ $$ |  $$ $$$$$$$$/$$ $$ |");
			Console.WriteLine(@"$$ | $/  $$ $$    $$ $$    $$/$$ |  $$ $$       $$ $$ |");
			Console.WriteLine(@"$$/      $$/ $$$$$$$ |$$$$$$/ $$/   $$/ $$$$$$$/$$/$$/ ");
			Console.WriteLine(@"            /  \__$$ |                                 ");
			Console.WriteLine(@"            $$    $$/                                  ");
			Console.WriteLine(@"             $$$$$$/                                   ");
			#endregion
			#region Data
			Console.ForegroundColor = ConsoleColor.Green;
			Console.CursorTop = line + 1;
			Console.CursorLeft = LogoWidthWithSpacing;
			Console.WriteLine("Version: " + Settings.Default["Version"].ToString());
			Console.CursorLeft = LogoWidthWithSpacing;
			Console.WriteLine("Build date: " + Dual.GetCompilationDDMMString() + "." + Dual.GetCompilationYYYYString());
			Console.ResetColor();
			#endregion
			#region Colors
			Console.CursorTop = line + 6;
			Console.CursorLeft = LogoWidthWithSpacing;
			for (int i = 0; i < 16; i++)
			{
				Console.BackgroundColor = Dual.IntToColor(i);
				Console.Write("   ");
				if (i == 7)
				{
					Console.CursorTop += 1;
					Console.CursorLeft = LogoWidthWithSpacing;
				}
			}
			Console.ResetColor();
			Console.WriteLine();
			#endregion
			Console.CursorTop = line + 12;
			return true;
		}
	}
}
