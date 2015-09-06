using System;

namespace ConsoleProcessRedirection
{
	/// <summary>
	/// Summary description for Parser.
	/// </summary>
	public interface IParser
	{
        string
            Parse(  
            ITerminal Terminal,
            string    Command,
            ref    string[]  Arguments );
	}
}
