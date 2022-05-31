using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogs4Net;
using MOS_User_Menager_Integration;

namespace Maciek_SHELL.Commands
{
	class Cmd
	{
		public readonly string _Name = "null";
		public readonly List<SubCmd> _Subs;
		public Cmd(string name)
        {
			_Name = name;
        }
		public virtual bool Execute(string[] args, string input, User user)
		{
			int nbt = args.Length;
            if (nbt > 1)
            {
                foreach (SubCmd item in _Subs)
                {
                    if (item._Name == args[1])
                    {
                        string[] new_args = new string[args.Length - 2];
                        int l = 0;
                        foreach (string item2 in args)
                        {
                            if (l > 1)
                            {
                                new_args[l] = item2;
                            }
                            l++;
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
