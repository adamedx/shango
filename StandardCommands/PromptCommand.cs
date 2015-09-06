using System;

namespace Shango.Commands
{
    using ConsoleProcessRedirection;
    using SystemInterface;
    using Shango.CommandProcessor;

    /// <summary>
    /// Summary description for PromptCommand
    /// </summary>
    public class PromptCommand : MultiInstanceCommand
    {
        public
            PromptCommand(
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

            if ( Arguments.Length > 1 )
            {
                SystemInterfaceLayer.Environment.SetSystemEnvironmentVariable(
                    "prompt",
                    (string) Arguments[1].GetArgument());
            }

            return 0;
        }            	
    }
}
