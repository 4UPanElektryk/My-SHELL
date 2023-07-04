using MyShell.Commands.Base;
using eXtraStyles.Commands;

namespace eXtraStyles
{
	public class Main
	{
		public static bool Load()
		{
			return true;
		}
		public static Cmd[] ExportCommands()
		{
			return new Cmd[]
			{
				new CmdPrompt("prompt"),
			};
		}
	}
}
