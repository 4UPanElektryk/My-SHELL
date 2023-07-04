using CoolConsole;
using CoolConsole.MenuItems;
using MyShell.Commands.Base;
using MyShell.Essentials;
using System;
using System.Collections.Generic;

namespace eXtraStyles.Commands.CmdPromptSub
{
	public class CmdPrompt_Menu : SubCmd
	{
		public CmdPrompt_Menu(string name) : base(name) { }
		public override bool Execute(string[] args, string input)
		{
			List<MenuItem> items = new List<MenuItem>
			{
				new MenuItem("~\\>"),
				new MenuItem("┏[~\\]\n  ┗>"),
				new MenuItem("┏[12:00:00][~\\]\n  ┗>"),
				new MenuItem("~\\\n  12:00:00>"),
				new MenuItem("Custom"),
				new MenuItem("Default"),
				new MenuItem("Cancel")
			};
			ReturnCode code = Menu.Show(items);
			switch (code.SelectedMenuItem)
			{
				case 0:
					Prompt.PromptTemplate = "*f%dir%>";
					break;
				case 1:
					Prompt.PromptTemplate = "*f┏[*b%dir%*f]\n┗>";
					break;
				case 2:
					Prompt.PromptTemplate = "*f┏[%time%][%dir%]\n┗>";
					break;
				case 3:
					Prompt.PromptTemplate = "*f%dir%\n%time% >";
					break;
				case 4:
					for (int i = 0; i < 16; i++)
					{
						Console.BackgroundColor = Dual.IntToColor(i);
						Console.Write("   ");
						Console.ResetColor();
						Console.Write(" - *" + i.ToString("X2").Substring(1) + " - ");
						Console.ForegroundColor = Dual.IntToColor(i);
						Console.WriteLine("*!" + i.ToString("X2").Substring(1));
						Console.ResetColor();
					}
                    Console.WriteLine("%dir% for working directory");
                    Console.WriteLine("%time% for time");
                    Prompt.PromptTemplate = Console.ReadLine();
					break;
				case 5:
					Prompt.PromptTemplate = "*f┏[*b%dir%*f]\n┗>";
					break;
				default:
					break;
			}
			return true;
		}
	}
}
