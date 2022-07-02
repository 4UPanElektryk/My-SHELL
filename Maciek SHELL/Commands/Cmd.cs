using MShell.Integrations.User_Manager;
using System.Collections.Generic;

namespace MShell.Commands
{
	class Cmd
	{
		public string _Name = null;
		public List<SubCmd> _Subs;
		public string description = null;
		public string args = null;

		public Cmd(string name)
		{
			_Subs = new List<SubCmd>();
			_Name = name;
		}
		public virtual bool Execute(string[] args, string input, User user)
		{
			int nbt = args.Length;
			if (nbt > 1)
			{
				foreach (SubCmd item in _Subs)
				{
					if (item._Name == args[1].ToLower())
					{
						string[] new_args = new string[args.Length - 2];
						for (int i = 2; i < args.Length; i++)
						{
							new_args[i - 2] = args[i];
						}
						return item.Execute(new_args, input, user);
					}
				}
			}
			foreach (SubCmd item in _Subs)
			{
				if (item._IsDefault)
				{
					return item.Execute(args, input, user);
				}
			}
			return false;
		}
	}
}
