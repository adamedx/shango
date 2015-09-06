using System;

namespace Shango
{
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for Parser.
	/// </summary>
	public class Parser
	{
		public Parser( MainWindow Application )
		{
            _Application = Application;
		}

        public
            Commands
            Parse(  
                          ITerminal Terminal,
                          string    Command,
                   ref    string[]  Arguments )
        {
            ParsedCommandLine Parsed = new ParsedCommandLine( Command );

            bool bParsed = Parsed.Parse();

            if ( ! bParsed )
            {
                _Application.AddText( "Failed to parse\n", true );
            }
            else
            {
                Parsed.Print( Terminal );
            }

            Commands CommandId = Commands.External;

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

                string CommandName = Arguments[0].ToLower();

                switch ( CommandName )
                {
                    case "cd":
                        CommandId = Commands.Cd;
                        break;
                    
                    case "cwd":
                        CommandId = Commands.Cwd;
                        break;

                    case "exit":
                        CommandId = Commands.Exit;
                        break;

                    case "set":
                        CommandId = Commands.Set;
                        break;

                    case "prompt":
                        CommandId = Commands.Prompt;
                        break;

                    case "ver":
                        CommandId = Commands.Ver;
                        break;
                }
            }

            return CommandId;
        }

        public
            ICommand
            GetCommand( Commands CommandType, ITerminal Terminal )
        {
            ICommand NewCommand = null;

            switch( CommandType )
            {
                case Commands.Cd:
                    NewCommand = new ChangeDirCommand( _Application, Terminal );
                    break;
                case Commands.Cwd:
                    NewCommand = new CurrentDirCommand( _Application, Terminal );
                    break;
                case Commands.Exit:
                    NewCommand = new ExitCommand( _Application, Terminal );
                    break;
                case Commands.Prompt:
                    NewCommand = new PromptCommand( _Application, Terminal );
                    break;
                case Commands.Set:
                    NewCommand = new SetCommand( _Application, Terminal );
                    break;
                case Commands.Ver:
                    NewCommand = new VersionCommand( _Application, Terminal );
                    break;
            }

            return NewCommand;
        }

        public
        enum Commands
        {
            External,
            Cd,
            Cwd,
            Exit,
            Prompt,
            Set,
            Ver
        };

        MainWindow _Application;
    }
}
