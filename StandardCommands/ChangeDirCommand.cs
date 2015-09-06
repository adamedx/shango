using System;

namespace Shango.Commands
{
    using System.IO;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

	/// <summary>
	/// Summary description for ChangeDir.
	/// </summary>
	public class ChangeDirCommand : MultiInstanceCommand
	{
        public
            ChangeDirCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal        Terminal ) : base ( ParentCommandProcessor, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( ICommandArgument [] Arguments, out ICommandResult CommandResult )
        {
            CommandResult = null;

            if ( Arguments.Length > 1 )
            {
                Directory.SetCurrentDirectory( (string) Arguments[1].GetArgument() );
            }

            return 0;
        }            	
    }
}
