using System;

namespace Shango.CommandProcessor.Parsing
{
    using System.Text;
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for Parser.
	/// </summary>
	public class DefaultCommandParser : IParser
	{
        public
            string
            Parse(  
                          ITerminal Terminal,
                          string    Command,
                   ref    string[]  Arguments )
        {
            string commandName = null;

            ParsedCommandLine Parsed = new ParsedCommandLine( Command );

            bool bParsed = Parsed.Parse();

            if ( ! bParsed )
            {
                Terminal.WriteTo( new StringBuilder( "Failed to parse\n" ), ConsoleProcessRedirection.OutputType.StandardError );
            }
            else
            {
                Parsed.Print( Terminal );
            }

            Command = Command.TrimStart(' ','\t');
            
            Command = Command.TrimEnd(' ','\t');

            if ( Command.Length > 0 )
            {
                Arguments = Command.Split( new char[] {' ','\t'} );

                if ( Arguments[0].ToLower().StartsWith("cd\\") )
                {
                    string[] NewArguments = new string[ Arguments.Length + 1 ];

                    NewArguments[0] = Arguments[0].Substring( 0, 2 );
                    NewArguments[1] = Arguments[0].Substring( 2, Arguments[0].Length - 2 );
                        
                    if ( Arguments.Length > 1 )
                    {
                        NewArguments[1] += Arguments[1];

                        for ( int Argument = 1; Argument < Arguments.Length; Argument++ )
                        {
                            NewArguments[ Argument + 1 ] = Arguments[ Argument ];
                        }
                    }

                    Arguments = NewArguments;
                }

                commandName = Arguments[0].ToLower();                
            }

            return commandName;
        }
           
    }
}
