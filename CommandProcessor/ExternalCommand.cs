using System;

namespace Shango.Commands
{
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

	/// <summary>
	/// Summary description for ExternalCommand.
	/// </summary>
	public class ExternalCommand : MultiInstanceCommand
	{    
        public
            ExternalCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal        Terminal ) : base ( ParentCommandProcessor, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( ICommandArgument[] Arguments, out ICommandResult CommandResult )
        {
            CommandResult = null;

            string CommandName = (string) Arguments[0].GetArgument();
            string CommandArguments = null;

            if ( Arguments.Length > 1 )
            {
                CommandArguments = (string) Arguments[1].GetArgument();
            }

            for ( int Argument = 2; Argument < Arguments.Length; Argument++ )
            {
                CommandArguments += " " + Arguments[Argument].GetArgument();
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
