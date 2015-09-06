using System;

namespace Shango
{
    using System.IO;
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for ChangeDir.
	/// </summary>
	public class ChangeDirCommand : MultiInstanceCommand
	{
        public
            ChangeDirCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string [] Arguments )
        {
            if ( Arguments.Length > 1 )
            {
                Directory.SetCurrentDirectory( Arguments[1] );
            }

            return 0;
        }            	
    }
}
