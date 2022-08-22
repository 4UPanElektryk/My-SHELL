using MyShell.Integrations.User_Manager;

namespace MyShell.Commands
{
    public class SubCmd
    {
        public string _Name = "null";
        public bool _IsDefault = false;
        public string _Help = null;
        public SubCmd(string name)
        {
            _Name = name;
        }
        public SubCmd(string name, bool isDefault)
        {
            _Name = name;
            _IsDefault = isDefault;
        }
        public virtual bool Execute(string[] args, string input, User user)
        {
            int nbt = args.Length;
            bool action = false;
            return action;
        }
    }
}
