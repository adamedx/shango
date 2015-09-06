using System;

namespace Shango.CommandProcessor
{
    using System.Threading;
    using ConsoleProcessRedirection;
    using System.Text;

    public interface ICommand
    {
        int
        PerformCommand(
            ICommandArgument[] Arguments,
            out ICommandResult CommandResult );

        bool
            RequiresParentTerminal();

        bool
            Terminate( int Milliseconds );

        string
            GetSimpleHelp();

    }    

    /// <summary>
    /// Summary description for Command.
    /// </summary>
    public abstract class CommandBase : ICommand, ICommandClient
    {
        protected CommandBase(
            ICommandProcessor ParentCommandProcessor,
            ITerminal  Terminal )
        {
            _CommandProcessor = ParentCommandProcessor;

            _Terminal = Terminal;
        }

        public
            string
            GetSimpleHelp()
        {
            return "Help not implemented";
        }

        public
            bool
            RequiresParentTerminal()
        {
            if ( ! _Process.IsRunning() )
            {
                return false;
            }

            if ( _Process.IsDetachedProcess() )
            {
                return false;
            }

            return true;
        }

        public
            void
            NotifyServerStatus( ConsoleProcessRedirection.ServerStatus Status )
        {
            if ( ConsoleProcessRedirection.ServerStatus.Terminated == Status )
            {
                _CommandProcessor.NotifyCommandCompleted( this );
            }
        }

        virtual
        public
        bool
            Terminate( int Milliseconds )
        {
            return false;
        }

        public
            abstract
            int
            PerformCommand( ICommandArgument[] Arguments, out ICommandResult CommandResult );
       
        protected ICommandProcessor   _CommandProcessor;

        protected RedirectedProcess  _Process;

        protected ITerminal          _Terminal;
   }

    public interface ISingleInstanceCommand : ICommand
    {      
    }

    public abstract class SingleInstanceCommand : CommandBase, ISingleInstanceCommand
    {
        protected
            SingleInstanceCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal        Terminal ) : base ( ParentCommandProcessor, Terminal )
        {            
        }                
    }

    public abstract class MultiInstanceCommand : CommandBase
    {
        protected
        MultiInstanceCommand(
            ICommandProcessor ParentCommandProcessor,
            ITerminal        Terminal ) : base ( ParentCommandProcessor, Terminal )
        {            
        }

    }

    public class CommandException : ConsoleProcessException
    {
        
    }

}
