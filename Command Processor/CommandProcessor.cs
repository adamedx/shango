using System;

namespace Shango
{
	using ConsoleProcessRedirection;
    using System.Threading;
    using System.Text;
  
	/// <summary>
	/// Summary description for CommandProcessor.
	/// </summary>
	public class CommandProcessor
	{
		public CommandProcessor(
			MainWindow Application,
            ITerminal  Terminal,
			int        HistorySize )
		{
            _History = new History( HistorySize );

			_Application = Application;

            _Terminal = Terminal;

            _Parser = new Parser( _Application );

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
                Parser.Commands CommandId = _Parser.Parse( _Terminal, Result, ref Arguments );

                if ( Parser.Commands.External != CommandId )				
                {
                    NewCommand = _Parser.GetCommand( CommandId, _Terminal );
                    Interpretation = CommandInterpretation.Internal;
                }
                else if ( null != Arguments )
                {
                    NewCommand = new ExternalCommand( _Application, _Terminal );
                    Interpretation = CommandInterpretation.External;
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

            if ( ( CommandProcessor.InputMode.Native == _InputMode ) &&
                ! bSuppressEcho )
            {
                // StringBuilder EchoedCommand = new StringBuilder( CommandLine +  ( ( CommandLine.Length > 0 ) ? new string( (char) 10, 1 ) : ""  ) );

                StringBuilder EchoedCommand = new StringBuilder( CommandLine );

                _Terminal.WriteTo( EchoedCommand, OutputType.StandardOutput );
            }

            CommandInterpretation Interpretation = InterpretCommand( CommandLine, ! bExistsInHistory, out InterpretedCommand, ref NewCommand, ref Arguments );

            switch( Interpretation )
            {
                case CommandProcessor.CommandInterpretation.None:
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
                        SetInputMode( CommandProcessor.InputMode.Native );

                        StringBuilder ErrorString = new StringBuilder( (char) 10 + ProcessStartFailure.Message + (char) 10);

                        _Terminal.WriteTo( ErrorString, OutputType.StandardError );
                    }
                }
                    break;
            }

            if ( CommandProcessor.InputMode.Native == _InputMode )
            {
                ShowPrompt();
            }
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

            SetInputMode( CommandProcessor.InputMode.Redirected );
            
            _CommandList.Add( TargetCommand );
            
            try
            {
                CommandStatus = TargetCommand.PerformCommand( Arguments );
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
                SetInputMode( CommandProcessor.InputMode.Native );
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

            SetInputMode( CommandProcessor.InputMode.Native );
            
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

		InputMode         _InputMode;

        History           _History;

		MainWindow        _Application;

        ITerminal         _Terminal;

        Parser            _Parser;

        CommandList       _CommandList;

        Prompt            _Prompt;
	}
}
