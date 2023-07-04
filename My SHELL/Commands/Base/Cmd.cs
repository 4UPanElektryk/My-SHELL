using System.Collections.Generic;

namespace MyShell.Commands.Base
{
	public class Cmd
	{
		public string Name = null;
		public List<SubCmd> Subs;
		public string description = null;
		public string args = null;
		public string CommandSource = "MyShell.exe";

		public Cmd(string name)
		{
			Subs = new List<SubCmd>();
			Name = name;
		}
		public virtual bool Execute(string[] args, string input)
		{
			int nbt = args.Length;
			if (nbt > 1)
			{
				foreach (SubCmd item in Subs)
				{
					if (item.Name == args[1].ToLower())
					{
						string[] new_args = new string[args.Length - 2];
						for (int i = 2; i < args.Length; i++)
						{
							new_args[i - 2] = args[i];
						}
						return item.Execute(new_args, input);
					}
				}
			}
			foreach (SubCmd item in Subs)
			{
				if (item.IsDefault)
				{
					return item.Execute(args, input);
				}
			}
			return false;
		}
	}
}
