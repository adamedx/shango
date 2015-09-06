using System;

namespace Shango
{
    using ConsoleProcessRedirection;
    using System.Collections;

    /// <summary>
    /// Summary description for PromptCommand
    /// </summary>
    public class SetCommand : MultiInstanceCommand
    {
        public
            SetCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string [] Arguments )
        {
            string      VariableStart = "";

            if ( Arguments.Length > 1 )
            {
                VariableStart = Arguments[1].ToLower();
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
