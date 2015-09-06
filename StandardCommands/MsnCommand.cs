using System;

namespace Shango.Commands
{
    using System.IO;
    using System.Net;
    using System.Text;
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;
    using System.Text.RegularExpressions;
    using System.Collections;

	/// <summary>
	/// Summary description for Msn.
	/// </summary>
	public class MsnCommand : MultiInstanceCommand
	{
		public MsnCommand(
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

            System.UriBuilder searchBinding = new System.UriBuilder();

            searchBinding.Scheme = "http";
            searchBinding.Host = searchServer;
            searchBinding.Path = searchRoot;
            
            string searchQuery = searchQueryPrefix;

            for ( int currentArgument = 1; currentArgument < Arguments.Length; currentArgument++ )
            {
                if ( currentArgument > 1 ) 
                {
                    searchQuery += "%20";
                }

                searchQuery += Arguments[currentArgument].GetArgument();
            }

            searchBinding.Query = searchQuery;

            _Terminal.WriteTo(
                new StringBuilder( searchBinding.ToString() + "\n\n" ),
                ConsoleProcessRedirection.OutputType.StandardOutput );

            PageCommand pageRetriever = new PageCommand(
                _CommandProcessor,
                new NullTerminal() );

            ICommandArgument[] showArguments = new ICommandArgument[2];

            showArguments[0] = Arguments[0];
            showArguments[1] = new CommandArgument( searchBinding.ToString() );

            pageRetriever.PerformCommand(
                showArguments,
                out CommandResult );

            string resultString = ( (StringBuilder) CommandResult.GetArgument() ).ToString();

            string[] links = FindLinks( resultString );

            foreach ( string link in links )
            {            
                _Terminal.WriteTo(
                    new StringBuilder( link + "\n\n" ),
                    ConsoleProcessRedirection.OutputType.StandardOutput );
            }

            return 0;
        }

        string[]
            FindLinks( string HtmlString )
        {
            //
            // Save this backup :)
            //
            // "<a\\s+href\\s*=\\s*\"(?<linkurl>http://([^\"]*))\"([^>]*)>(?<linkdisplay>.*?(?=</a>))</a>",
            //
            // "<\s*a\s[^>]*\bhref\s*=\s*('(?<url>[^']*)'|""(?<url>[^""]*)""|(?<url>\S*))[^>]*>(?<body>(.|\s)*?)<\s*/a\s*>"
            //
 

            Regex linkExpression = new Regex(
                "<a\\s+href\\s*=\\s*\"(?<linkurl>http://([^\"]*))\"([^>]*)>(?<linkdisplay>.*?(?=</a>))</a>",
                //"<\\s*a\\s[^>]*\\bhref\\s*=\\s*('(?<linkurl>[^']*)'|\"\"(?<linkurl>[^\"\"]*)\"\"|(?<linkurl>\\S*))[^>]*>(?<linkdisplay>(.|\\s)*?)<\\s*/a\\s*>",
                RegexOptions.IgnoreCase);

            ArrayList resultList = new ArrayList();

            Match foundLink = linkExpression.Match( HtmlString );

            while ( foundLink.Success )
            {
                GroupCollection foundItems = foundLink.Groups;

                if ( foundItems.Count > 0 )
                {
                    string itemValue = foundItems[ "linkdisplay" ] + "\n" + foundItems[ "linkurl" ].Value;
                    resultList.Add( itemValue );
                }

                foundLink = foundLink.NextMatch();
            }            

            string[] results = new string[ resultList.Count ];

            for ( int currentResult = 0; currentResult < resultList.Count; currentResult++ )
            {
                results[ currentResult ] = (string) resultList[ currentResult ];
            }

            return results;
        }

        const string searchServer = "search.msn.com";
        const string searchRoot = "results.aspx";
        const string searchQueryPrefix = "FORM=SRCHWB&q=";        
	}
}
