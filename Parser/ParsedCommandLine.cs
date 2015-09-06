using System;
using System.Drawing;
using ConsoleProcessRedirection;
using System.Text.RegularExpressions;
using System.Text;

namespace Shango
{
	/// <summary>
	/// Summary description for ParsedCommand.
	/// </summary>
	public class ParsedCommandLine
	{
		public ParsedCommandLine( string CommandLine )
		{
			_CommandLine = CommandLine;

            //_ParseExpression = new Regex( "?<StartSymbol>(?<CmdLine>(?<CommandInput>\".*\"|\\s*)<?(?<CmdList>(?<Cmd>\".+\"|\\s+(?<ArgList>(?<Arg>\".*\")+|.*)*)+)>?(?<CommandOutput>\".*\"|\\s*))");
//(?<CommandInput>(?<InputFile>\".*\"|\\s*)>)
            //(?<Cmd>\".+\"|\\s+)  |(?<Empty>\\s*)(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\S+)
            //(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\S+))

            //_ParseExpression = new Regex( "(?<StartSymbol>(?<NonEmpty>(?<CmdLine>(?<CommandInput>(?<InputFile>(?<QuotedInputFile>\".*\")|(?<UnquotedInputFile>\\S+))?<)(?<CmdList>(?<Cmd>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+)(?<ArgList>(?<Arg>\".*\")*|S*)*)*)(?<CommandOutput>>fun)?)))", RegexOptions.Singleline );        
            //_ParseExpression = new Regex( "(?<StartSymbol>(?<NonEmpty>(?<CmdLine>(?<CommandInput>(?<InputFile>(?<QuotedInputFile>\".*\")|(?<UnquotedInputFile>\\S+))?<)(?<CmdList>fun)((?<CommandOutput>>(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\S+)))))))", RegexOptions.Singleline );        
            //(?<CmdList>(?<Cmd>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+)(?<ArgList>(?<Arg>\".*\")*|S*)*)*)
            //_ParseExpression = new Regex( "(?<StartSymbol>(?<NonEmpty>(?<CmdLine>(?<CommandInput>(?<InputFile>(?<QuotedInputFile>\".*\")|(?<UnquotedInputFile>\\S+))<)?(?<CmdList>(?<Cmd>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+)(?<ArgList>(?<Arg>\".*\")*|S*)*)*)(?<CommandOutput>>(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\S+))?))))", RegexOptions.Singleline );        

            //(?<CmdList>(?<Cmd>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+)(?<ArgList>(?<Arg>\".*\")*|S*)*))
            //(?<CmdList>(?<Cmd>(?<CommandName>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+))))
            //  (?<CommandInput>(?<InputFile> (?<QuotedInputFile> \".*\")|(?<UnquotedInputFile> \\S+))<)
            //(?<CommandOutput>>(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\S+)))
            //(?<Cmd>(?<CommandName>(?<QuotedCommand>\".+\")|(?<UnquotedCommand>\\S+)))
            //_ParseExpression = new Regex( "(?<StartSymbol>(?<NonEmpty>(?<CmdLine>(?<OptionalInput>(?<CommandInput>(?<InputFile>(?<QuotedInputFile>\".*\")|(?<UnquotedInputFile>\\w+))<)?)(?<CmdList>(?<cmd>(?<CommandName>(?<QuotedCommand>\".\")|(?<UnquotedCommand>\\w+))(?<ArgList>(?<Arg>\\s(?<QuotedArg>\".\")|(?<UnquotedArg>\\w+))+)?))(?<OptionalOutput>(?<CommandOutput>>(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\w+)))?))))", RegexOptions.Singleline );        
            //_ParseExpression = new Regex(
            //    "(?<StartSymbol>(?<NonEmpty>\\s*(?<CmdLine>(?<OptionalInput>(?<CommandInput>(?<InputFile>(?<QuotedInputFile>\".*\")|(?<UnquotedInputFile>\\w+))\\s*<\\s*)?)(?<CmdList>(?<cmd>(?<CommandName>(?<QuotedCommand>\".\")|(?<UnquotedCommand>\\w+))(?<ArgList>(?<Arg>\\s*(?<QuotedArg>\".\")|(?<UnquotedArg>\\w+))+)?))(?<OptionalOutput>(?<CommandOutput>\\s*>\\s*(?<OutputFile>(?<QuotedOutputFile>\".*\")|(?<UnquotedOutputFile>\\w+)))?))\n)|(?<Empty>\\s*\n))#bye", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace );        
                                                                                                                                                                         // "(?<CmdList>(?<cmd>(?<CommandName>(?<QuotedCommand>\".\")|(?<UnquotedCommand>\\w+))(?<ArgList>(?<Arg>\\s*(?<QuotedArg>\".\")|(?<UnquotedArg>\\w+))+)?))"

            
            _ParseExpression = new Regex(
                "(?<StartSymbol>" +
                    "(?<NonEmpty>" +
                        "\\s*" +
                        "(?<CmdLine>" +
                            "(?<OptionalInput>" +
                                "(?<CommandInput>" +
                                    "(?<InputFile>" + 
                                        "(?<QuotedInputFile>" + 
                                            "\".+\"" +
                                        ")(?#<QuotedInputFile>)" + 
                                        "|" + 
                                        "(?<UnquotedInputFile>" +
                                            "\\w+" + 
                                        ")(?#<UnquotedInputFile>)" +
                                    ")(?#<InputFile>)" +
                                    "\\s*<\\s*" + 
                                ")?(?#<CommandInput>)" +
                            ")(?#<OptionalInput>)" + 
                                "(?<CmdList>" + 
                                    "(?<cmd>" + 
                                        "(?<CommandName>" + 
                                            "(?<QuotedCommand>" + 
                                                "\".+\"" + 
                                            ")(?#QuotedCommand>)" + 
                                            "|"+
                                            "(?<UnquotedCommand>"+
                                                "\\w+"+
                                            ")(?#<UnquotedCommand>)" +
                                        ")(?#<CommandName>)"+
                                        "(?<ArgList>" +
                                            "(?<Arg>" +
                                                "\\s+" + 
                                                "(?<QuotedArg>" + 
                                                    "\".*\"" +
                                                ")(?#<QuotedArg>)" + 
                                                "|" + 
                                                "(?<UnquotedArg>" +
                                                    "\\w+" +
                                                ")(?#<UnquotedArg>)" +
                                            ")+(?#<Arg>)" +                                        
                                        ")?(?#ArgList>)" + 
                                    ")(?#<cmd>)" +
                                ")(?#<CmdList>)" +                             
                            "(?<OptionalOutput>" + 
                                "(?<CommandOutput>" + 
                                    "\\s*>\\s*" +
                                    "(?<OutputFile>" + 
                                        "(?<QuotedOutputFile>" + 
                                            "\".+\"" + 
                                        ")(?#<QuotedOutputFile>)" + 
                                        "|" + 
                                        "(?<UnquotedOutputFile>" + 
                                            "\\w+"+ 
                                        ")(?#<UnquotedOutputFile>)" + 
                                    ")(?#<OutputFile>)" + 
                                ")?(?#<CommandOutput>)" +
                            ")(?#<OptionalOutput>)" + 
                        ")(?#<CmdLine>)" + 
                        "\\s*\\n" + 
                    ")(?#<NonEmpty>)" + 
                    "|" + 
                    "(?<Empty>" + 
                        "\\s*\\n" + 
                    ")(?#<Empty>)" + 
                ")(?#<StartSymbol>)"
                , RegexOptions.Singleline );        
		}

        public
            bool
            Parse()
        {
            bool bParsed = false;
            
            _InputFile = null;
            _OutputFile = null;
            _CommandList = null;

            if ( Tokenize() )
            {
                _bEmptyLine = false;

                try
                {
                    _InputFile = _MatchedExpression.Groups["InputFile"].Captures[0].Value;
                }
                catch
                {
                    _InputFile = "";

                }

                try
                {
                    _bEmptyLine = _MatchedExpression.Groups["Empty"].Captures.Count != 0;
                }
                catch
                {
                }

                try
                {
                    _CommandList = _MatchedExpression.Groups["CmdList"].Captures[0].Value;
                }
                catch
                {
                }

                try
                {
                    _OutputFile = _MatchedExpression.Groups["OutputFile"].Captures[0].Value;
                }
                catch
                {
                    _OutputFile = "";
                }

                try
                {
                    _ParsedCommand = _MatchedExpression.Groups["StartSymbol"].Captures[0].Value;
                }
                catch
                {
                    _ParsedCommand = "";
                }


                bParsed = true;
            }

            return bParsed;
        }

        bool
            Tokenize()
        {
            bool  bMatched = false;

            _MatchedExpression = _ParseExpression.Match( _CommandLine + "\n" );

            if ( _MatchedExpression.Success )
            {
                bMatched = true;
            }

            return bMatched;
        }

        public
            void
            Print( ITerminal Terminal )
        {
            lock( this )
            {
                Terminal.WriteTo( new StringBuilder("\n"), OutputType.StandardOutput );

                if ( _bEmptyLine )
                {
                    Terminal.WriteTo( new StringBuilder("<emptyline>\n"), Color.Blue, OutputType.StandardOutput );
                    return;
                }

                if ( null != _InputFile )
                {
                    StringBuilder InputFile = new StringBuilder( _InputFile );
                    
                    Terminal.WriteTo( InputFile, Color.Magenta, OutputType.StandardOutput );
                    Terminal.WriteTo( new StringBuilder(" < "), OutputType.StandardOutput );
                }

                if ( null != _CommandList )
                {
                    StringBuilder CommandList = new StringBuilder( _CommandList );

                    Terminal.WriteTo( CommandList, Color.Blue, OutputType.StandardOutput );
                }

                if ( null != _OutputFile )
                {
                    StringBuilder OutputFile = new StringBuilder( _OutputFile );

                    Terminal.WriteTo( new StringBuilder(" > "), OutputType.StandardOutput );
                    Terminal.WriteTo( OutputFile, Color.Magenta, OutputType.StandardOutput );
                }

                if ( null != _ParsedCommand )
                {
                    Terminal.WriteTo( new StringBuilder("\n"), OutputType.StandardOutput );

                    StringBuilder ParsedCommand = new StringBuilder( _ParsedCommand );

                    Terminal.WriteTo( ParsedCommand, Color.Green, OutputType.StandardOutput );
                }

                Terminal.WriteTo( new StringBuilder("\n"), OutputType.StandardOutput );
            }

        }

        Regex   _ParseExpression = null;
        Match   _MatchedExpression = null;

        string _CommandLine = null;    
  
        string _ParsedCommand = null;

        string _InputFile = null;

        string _OutputFile = null;

        string _CommandList = null;

        bool   _bEmptyLine = false;
	}
}
