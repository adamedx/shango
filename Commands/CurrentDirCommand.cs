using System;

namespace Shango
{
    using System.IO;
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for CurrentDirCommand.
	/// </summary>
	public class CurrentDirCommand : MultiInstanceCommand
	{
        public
            CurrentDirCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string [] Arguments )
        {
            string Output = Directory.GetCurrentDirectory() + "\n";

            TermUtil.WriteText( _Terminal, Output );

            return 0;
        }            
	}
}
