using System;

namespace Shango.Commands
{
    using System.IO;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

	/// <summary>
	/// Summary description for CurrentDirCommand.
	/// </summary>
	public class CurrentDirCommand : MultiInstanceCommand
	{
        public
            CurrentDirCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal  Terminal ) : base ( ParentCommandProcessor, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( ICommandArgument[] Arguments, out ICommandResult CommandResult )
        {
            CommandResult = null;

            string Output = Directory.GetCurrentDirectory() + "\n";

            TermUtil.WriteText( _Terminal, Output );

            return 0;
        }            
	}
}
