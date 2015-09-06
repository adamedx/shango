using System;

namespace Shango
{
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for ExternalCommand.
	/// </summary>
	public class ExternalCommand : MultiInstanceCommand
	{    
        public
            ExternalCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string[] Arguments )
        {
            string CommandName = Arguments[0];
            string CommandArguments = null;

            if ( Arguments.Length > 1 )
            {
                CommandArguments = Arguments[1];
            }

            for ( int Argument = 2; Argument < Arguments.Length; Argument++ )
            {
                CommandArguments += " " + Arguments[Argument];
            }

            _Process = new RedirectedProcess( _Terminal, this );               
            
            _Process.Start( CommandName, CommandArguments );   
            
            return 0;             
        }

        public
            override
            bool
            Terminate( int Milliseconds )
        {
            bool bExited = _Process.WaitForTermination( Milliseconds );

            if ( ! bExited )
            {
                _Process.Terminate();
            }

            return true;
        }

        public
            void
            ProcessInput( string NewInput )
        {
            _Process.SendInput( NewInput );
        }

        public
            void
            Disconnect()
        {
            _Process.Disconnect();
            _Process = null;
        }
	}
}
