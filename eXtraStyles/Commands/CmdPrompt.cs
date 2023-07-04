using MyShell.Commands.Base;
using eXtraStyles.Commands.CmdPromptSub;

namespace eXtraStyles.Commands
{
	public class CmdPrompt : Cmd
	{
		public CmdPrompt(string name) : base(name) 
		{
			Subs.Add(new CmdPrompt_Menu("menu"));
		}
	}
}
