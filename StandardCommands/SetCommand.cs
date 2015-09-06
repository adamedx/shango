using System;

namespace Shango.Commands
{
    using ConsoleProcessRedirection;
    using System.Collections;
    using Shango.CommandProcessor;

    /// <summary>
    /// Summary description for PromptCommand
    /// </summary>
    public class SetCommand : MultiInstanceCommand
    {
        public
            SetCommand(
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

            string      VariableStart = "";

            if ( Arguments.Length > 1 )
            {
                VariableStart = ( (string) Arguments[1].GetArgument() ).ToLower();
            }

            IDictionary EnvironmentVariables = Environment.GetEnvironmentVariables();
            
            SortedList AlphaList = new SortedList( EnvironmentVariables );

            foreach ( DictionaryEntry Entry in AlphaList )
            {
                string VariableName = (string) Entry.Key;

                VariableName = VariableName.ToLower();

                if ( VariableName.StartsWith( VariableStart ) )
                {
                    string VariableValue = (string) Entry.Value;

                    TermUtil.WriteText( _Terminal, VariableName + "=" + VariableValue + Environment.NewLine );
                }
            }

            return 0;
        }            	
    }
}
