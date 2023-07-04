using System;

namespace MyShell.Essentials
{
	public class Prompt
	{
		public static string PromptTemplate = "*f┏[*b%dir%*f]\n┗>";
		public static void ShowPrompt(string activedir)
		{
			Console.ResetColor();
			if (Program.UseASCII)
			{
				Console.Write("[");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write(activedir);
				Console.ResetColor();
				Console.WriteLine("]");
				Console.Write(">");
			}
			else
			{
				string[] promptpart = Dual.DeleteNullAndEmptyItems(PromptTemplate.Split('*'));
				foreach (string item in promptpart)
				{
					bool inversed = item.StartsWith("!");
					ConsoleColor color = (ConsoleColor)Convert.ToInt32((inversed ? item[1] : item[0]).ToString(), 16);
					string text = item.Substring(inversed ? 2 : 1).Replace("%dir%", activedir).Replace("%time%", DateTime.Now.ToString("HH:mm:ss"));
					if (inversed)
					{
						Console.BackgroundColor = color;
					}
					else
					{
						Console.ForegroundColor = color;
					}
					Console.Write(text);
				}
			}
		}
	}
}
