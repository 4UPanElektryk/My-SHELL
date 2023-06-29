using System;
using System.Collections.Generic;
using System.Text;

namespace SPMModule
{
	class TestCmd : Cmd
	{
		public TestCmd(string name) : base(name) { }
		public override bool Execute(string[] args, string input)
		{
            Console.WriteLine("Command Executed");
            return true;
		}
	}
}
