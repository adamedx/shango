using System;

namespace Shango
{
    using System.Threading;
    using ConsoleProcessRedirection;
    using System.Text;

    public interface ICommand
    {
        int
            PerformCommand( string[] Arguments );

        bool
            RequiresParentTerminal();

        bool
            Terminate( int Milliseconds );

    }    

    /// <summary>
    /// Summary description for Command.
    /// </summary>
    public abstract class CommandBase : ICommand, ICommandClient
    {
        protected CommandBase(
            MainWindow Application,
            ITerminal  Terminal )
        {
            _Application = Application;

            _Terminal = Terminal;
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
                _Application.GetCommandProcessor().NotifyCommandCompleted( this );
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
            PerformCommand( string[] Arguments );
       
        protected MainWindow         _Application;

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
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {            
        }                
    }

    public abstract class MultiInstanceCommand : CommandBase
    {
        protected
        MultiInstanceCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {            
        }

    }

    public class CommandException : ConsoleProcessException
    {
        
    }

}
