using System;

namespace Shango.CommandProcessor
{
	using ConsoleProcessRedirection;
    using System.Threading;
    using System.Text;
    using Shango.CommandProcessor;
    using Shango.CommandProcessor.Parsing;
    using Shango.Commands;

    public interface ICommandProcessor
    {
        void
            ProcessCommand( string CommandLine, bool bExistsInHistory, bool bSuppressEcho );
        
        void
            Close();

        void
            NotifyCommandCompleted( ICommand Command );
        
        History
            GetHistory();

        void
            TerminateCommand( int Milliseconds );        
    }

	/// <summary>
	/// Summary description for CommandProcessor.
	/// </summary>
	public class StandardCommandProcessor : Shango.CommandProcessor.ICommandProcessor
	{
		public StandardCommandProcessor(
			ICommandEnvironment CommandEnvironment,
            ICommandFactory CommandFactory,
            ITerminal  Terminal,
			int        HistorySize )
		{
            _History = new History( HistorySize );

			_CommandEnvironment = CommandEnvironment;

            _Terminal = Terminal;

            _InternalCommandFactory = CommandFactory;

            _Parser = new DefaultCommandParser();

            _CommandList = new CommandList();

            _Prompt = new Prompt( _Terminal, "$p$g" );
		}

        CommandInterpretation
            InterpretCommand( 
                string   InputCommand,
                bool     bAddToHistory,
            out string   Result,
            ref ICommand NewCommand,
            ref string[] Arguments )
        {
            CommandInterpretation Interpretation = CommandInterpretation.None;

            Result = InputCommand;

			if ( InputMode.Native == _InputMode )
			{
                string commandName = _Parser.Parse( _Terminal, Result, ref Arguments );

                if ( null != commandName )				
                {
                    ICommand parsedCommand = null;
                    
                    parsedCommand = _InternalCommandFactory.GetCommand( commandName, this );

                    if ( null != parsedCommand )
                    {
                        NewCommand = parsedCommand;
                        Interpretation = CommandInterpretation.Internal;
                    }
                    else if ( null != Arguments )
                    {
                        NewCommand = new ExternalCommand( (ICommandProcessor) this, _Terminal );
                        Interpretation = CommandInterpretation.External;
                    }
                }
			}

            if ( ( InputMode.Redirected == _InputMode ) ||
                ( null != NewCommand ) )
            {
                _History.Add( Result );
            }

            return Interpretation;
        }

        public
            void
            ProcessCommand( string CommandLine, bool bExistsInHistory, bool bSuppressEcho )
        {
            string   InterpretedCommand;
            ICommand NewCommand = null;
            string[] Arguments = null;

            if ( ( InputMode.Native == _InputMode ) &&
                ! bSuppressEcho )
            {
                StringBuilder EchoedCommand = new StringBuilder( CommandLine );

                _Terminal.WriteTo( EchoedCommand, OutputType.StandardOutput );
            }

            CommandInterpretation Interpretation = InterpretCommand( CommandLine, ! bExistsInHistory, out InterpretedCommand, ref NewCommand, ref Arguments );

            switch( Interpretation )
            {
                case CommandInterpretation.None:
                {                  
                    ICommand CurrentCommand;

                    CurrentCommand = _CommandList.GetCurrentCommand();

                    if ( null == CurrentCommand )
                    {
                        if ( null != Arguments )
                        {
                            _Terminal.WriteTo( new StringBuilder( "\n\'" + Arguments[0] + "\' is not recognized as an internal command, application, or script.\n" ), OutputType.StandardError );
                        }
                    }

                    if ( CurrentCommand is ExternalCommand )
                    {
                        ( (ExternalCommand) CurrentCommand).ProcessInput( InterpretedCommand + (char)13 + (char)10 );
                    }
                }
                    break;

                default:
                {
                    if ( ! bSuppressEcho )
                    {
                        TermUtil.WriteText( _Terminal, "\n" );
                    }

                    try
                    {
                        ExecuteCommand( NewCommand, Arguments, true );
                    }
                    catch ( Exception ProcessStartFailure )
                    {
                        SetInputMode( InputMode.Native );

                        StringBuilder ErrorString = new StringBuilder( (char) 10 + ProcessStartFailure.Message + (char) 10);

                        _Terminal.WriteTo( ErrorString, OutputType.StandardError );
                    }
                }
                    break;
            }

            if ( InputMode.Native == _InputMode )
            {
                ShowPrompt();
            }
        }

        public
            void
            Close()
        {
            _CommandEnvironment.CloseEnvironment();
        }

        private
            CommandArgument[]
            GenerateArguments(
            string[] arguments )
        {
            CommandArgument[] resultArguments = new CommandArgument[ arguments.Length ];

            int currentArgument = 0;

            foreach ( string argument in arguments )
            {
                resultArguments[ currentArgument++ ] = new CommandArgument( argument );
            }

            return resultArguments;
        }

        private
            int
            ExecuteCommand( 
            ICommand  TargetCommand,
            string[]  Arguments,
            bool      bWaitIfNeeded )
        {          
            if ( TargetCommand is ISingleInstanceCommand )
            {
                bool bAllowExecute = Monitor.TryEnter( TargetCommand.GetType(), bWaitIfNeeded ? Timeout.Infinite : 0 );

                if ( ! bAllowExecute )
                {
                    CommandException ExecutionError = new CommandException();                

                    throw ExecutionError;
                }
            }
    
            int              CommandStatus;
            System.Exception ProcessError = null; 

            SetInputMode( InputMode.Redirected );
            
            _CommandList.Add( TargetCommand );
            
            CommandArgument[] commandArguments = GenerateArguments( Arguments );

            try
            {
                ICommandResult commandResult;

                CommandStatus = TargetCommand.PerformCommand( commandArguments, out commandResult );
            }
            catch ( System.Exception ProcessException)
            {
                CommandStatus = 0;
                ProcessError = ProcessException;
            }      

            bool bRequiresParent = false;
            bool bExternal = false;

            try
            {
                bRequiresParent = TargetCommand.RequiresParentTerminal();
            }
            catch 
            {               
            }

            if ( TargetCommand is ExternalCommand )
            {
                bExternal = true;

                if ( ! bRequiresParent )
                {
                    ( (ExternalCommand) TargetCommand ).Disconnect();
                }
            }

            if ( ! bExternal ||
                ! bRequiresParent )
            {
                _CommandList.Remove( TargetCommand );
            }

            if ( ! bRequiresParent )
            {
                SetInputMode( InputMode.Native );
            }

            if ( TargetCommand is ISingleInstanceCommand )
            {
                Monitor.Exit( TargetCommand.GetType() );
            } 

            if ( null != ProcessError )
            {
                throw ProcessError;
            }
            
            return CommandStatus;
        }   


        public
            void
            NotifyCommandCompleted( ICommand Command )
        {
            bool bActiveCommand = ( Command == _CommandList.GetCurrentCommand() );

            _CommandList.Remove( Command );

            SetInputMode( InputMode.Native );
            
            if ( bActiveCommand )
            {
                ShowPrompt();                
            }
        }

        private
            void
            ShowPrompt()
        {
            _Prompt.ShowPrompt();
        }		

        public
            History
            GetHistory()
        {
            return _History;
        }

    	void
			SetInputMode(
			InputMode NewMode
			)
		{
			_InputMode = NewMode;
		}

        public
            void
            TerminateCommand( int Milliseconds )
        {
            ICommand CurrentCommand;

            CurrentCommand = _CommandList.GetCurrentCommand();

            if ( null != CurrentCommand )
            {
                CurrentCommand.Terminate( Milliseconds );
            }
        }

		public
			enum InputMode
		{
			Native,
			Redirected
		};

		public
			enum CommandInterpretation
		{
			None,
			Internal,
			External
		};

		InputMode           _InputMode;

        History             _History;

		ICommandEnvironment _CommandEnvironment;

        ITerminal           _Terminal;

        IParser             _Parser;

        ICommandFactory     _InternalCommandFactory;

        CommandList         _CommandList;

        Prompt              _Prompt;
	}
}
