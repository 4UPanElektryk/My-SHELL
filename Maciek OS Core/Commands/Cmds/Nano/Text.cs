using System;

namespace Maciek_OS_Core.Commands.Cmds.Nano
{
	public class Text
	{
		public int N;
		public string S;
		public ConsoleColor Color = ConsoleColor.White;
		public ConsoleColor BGColor = ConsoleColor.Black;
		public Text(int n, string s)
		{
			N = n;
			S = s;
		}
	}
}
