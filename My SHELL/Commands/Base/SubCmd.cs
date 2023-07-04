namespace MyShell.Commands.Base
{
	public class SubCmd
	{
		public string Name = "null";
		public bool IsDefault = false;
		public string Help = null;
		public SubCmd(string name)
		{
			Name = name;
		}
		public SubCmd(string name, bool isDefault)
		{
			Name = name;
			IsDefault = isDefault;
		}
		public virtual bool Execute(string[] args, string input)
		{
			bool action = false;
			return action;
		}
	}
}
