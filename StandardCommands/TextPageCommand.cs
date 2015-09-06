using System;

namespace Shango.Commands
{
    using System.IO;
    using System.Net;
    using System.Text;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;
    using System.Text.RegularExpressions;

	/// <summary>
	/// Summary description for Page.
	/// </summary>
	public class TextpageCommand : MultiInstanceCommand
	{
        public TextpageCommand(
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

            WebRequest searchRequest = WebRequest.Create(
                targetUri );

            WebResponse searchResult = searchRequest.GetResponse();
          
            Stream searchStream = searchResult.GetResponseStream();

            ICommandArgument[] showArguments = new ICommandArgument[2];

            showArguments[0] = Arguments[0];
            showArguments[1] = new FileInputArgument( searchStream );

            ShowpageCommand showCommand = new ShowpageCommand( _CommandProcessor, new NullTerminal() );

            showCommand.PerformCommand( showArguments, out CommandResult );

            string resultString = ( (StringBuilder) CommandResult.GetArgument() ).ToString();

            string finalString = GetBody( resultString);
            
            _Terminal.WriteTo(
                new StringBuilder( finalString ),
                ConsoleProcessRedirection.OutputType.StandardOutput );

            return 0;
        }

        string
            GetBody( string HtmlString )
        {
            _Terminal.WriteTo(
                new StringBuilder( "Page Body\n" ),
                ConsoleProcessRedirection.OutputType.StandardOutput );
            //
            // Save this backup :)
            //
            

            Regex bodyExpression = new Regex(
                //".*<html>.*<body\\w?.*>(?<bodytext>.*)</body>.*</html>.*",                
                //".*<html>(?<bodytext>.*)</html>.*",                
                //".*<html>.*(?<bodystart><body\\w?[^>]*>)(?<bodytext>.*).*(?<bodyend></body>).*</html>.*",                
                ".+(?<bodystart><body\\w?[^>]*>)(?<bodytext>.*).*(?<bodyend></body>).+",
                
                RegexOptions.IgnoreCase | RegexOptions.Singleline );

            Match foundBody = bodyExpression.Match( HtmlString );

            string results = null;

            if ( foundBody.Success )
            {
                GroupCollection foundItems = foundBody.Groups;

                results = foundItems[ "bodystart" ].Value;
                results += foundItems[ "bodytext" ].Value;
                results += foundItems[ "bodyend" ].Value;
            }

            StringBuilder textResults = new StringBuilder( 49152 );

            if ( null != results )
            {
                Regex textExpression = new Regex( 
                    "[^>]*>(?<bodytext>[^<]*)<",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline );

                Match foundText = textExpression.Match( results );

                while ( foundText.Success )
                {

                    GroupCollection foundItems = foundText.Groups;

                    string foundBodyText = foundItems[ "bodytext" ].Value;

                    foreach (char currentChar in foundBodyText )
                    {
                        textResults.Append( currentChar );
                    }

                  foundText = foundText.NextMatch();
                }
            }

            _Terminal.WriteTo(
                new StringBuilder( "End page Body\n" ),
                ConsoleProcessRedirection.OutputType.StandardOutput );

            return textResults.ToString();
        }

    }

}








