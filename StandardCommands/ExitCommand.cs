using System;

namespace Shango.Commands
{
    using System.Threading;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

	/// <summary>
	/// Summary description for ExitCommand.
	/// </summary>
	public class ExitCommand : SingleInstanceCommand
	{
		public ExitCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal  Terminal ) : base ( ParentCommandProcessor, Terminal )
		{
		}

        override
        public
            int
            PerformCommand( ICommandArgument[] Arguments, out ICommandResult CommandResult )
        {
            CommandResult = null;

            _CommandProcessor.Close();

            return 0;
        }
	}
}
