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
	public class PageCommand : MultiInstanceCommand
	{
        public PageCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal  Terminal ) : base ( ParentCommandProcessor, Terminal )

        {
        }

        public
            override
            int
            PerformCommand( ICommandArgument[] Arguments, out ICommandResult CommandResult )
        {
            if ( Arguments.Length < 2 )
            {
                throw new CommandException();
            }

            System.Uri targetUri = new System.Uri( (string) Arguments[1].GetArgument() );

            _Terminal.WriteTo( new StringBuilder( "Creating request\n" ),
                OutputType.StandardOutput );

            WebRequest searchRequest = WebRequest.Create(
                targetUri );

            _Terminal.WriteTo( new StringBuilder( "Getting request\n" ),
                OutputType.StandardOutput );

            WebResponse searchResult = searchRequest.GetResponse();
     
            
            Stream searchStream = searchResult.GetResponseStream();

            ICommandArgument[] showArguments = new ICommandArgument[2];

            showArguments[0] = Arguments[0];
            showArguments[1] = new FileInputArgument( searchStream );

            ShowpageCommand showCommand = new ShowpageCommand( _CommandProcessor, _Terminal );

            return showCommand.PerformCommand( showArguments, out CommandResult );
        }
    }

}








