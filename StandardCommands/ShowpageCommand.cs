using System;

namespace Shango.Commands
{
    using System.IO;
    using System.Net;
    using System.Text;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

    /// <summary>
    /// Summary description for Page.
    /// </summary>
    public class ShowpageCommand : MultiInstanceCommand
    {
        public ShowpageCommand(
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

            if ( Arguments.Length < 2 )
            {
                throw new CommandException();
            }

            Stream sourceStream = null;

            if ( Arguments[1].GetArgument() is string )
            {
                sourceStream = (Stream) new FileStream( (string) Arguments[1].GetArgument(), FileMode.Open, FileAccess.Read );
            }
            else
            {
                sourceStream = (Stream) Arguments[1].GetArgument();
            }

            string resultString = GetHtml( sourceStream );

            _Terminal.WriteTo(
                new StringBuilder( resultString ),
                ConsoleProcessRedirection.OutputType.StandardOutput );

            TextCommandResult result = new TextCommandResult( new StringBuilder( resultString ) );

            CommandResult = result;
            
            return 0;
        }        

        string
            GetHtml( Stream sourceStream )
        {
            StringBuilder resultBuilder = new StringBuilder( 49152 );

            byte[] inBuffer = new byte[8192];

            int currentResultLength = 0;

            _Terminal.WriteTo( new StringBuilder( "Creating html\n" ),
                OutputType.StandardOutput );

            for ( ;; )
            {                
                int bytesRead = sourceStream.Read(
                    inBuffer,
                    0,
                    inBuffer.Length);

                if ( 0 == bytesRead )
                {
                    break;
                }

                //resultBuilder.Insert( currentResultLength, inBuffer, 0, bytesRead );
                
                //currentResultLength += bytesRead;

                
                
                for ( int currentChar = 0; currentChar < bytesRead; currentChar++ )
                {
                    resultBuilder.Insert( currentResultLength++, (char) inBuffer[ currentChar ] );
                }
            }

            _Terminal.WriteTo( new StringBuilder( "Finished html\n" ),
                OutputType.StandardOutput );

            return resultBuilder.ToString();
        }        
    }
}








