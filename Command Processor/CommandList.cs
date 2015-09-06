using System;



namespace Shango
{
    using System.Collections;

    internal class InternalCommandList : SortedList
    {
    }

	/// <summary>
	/// Summary description for TaskList.
	/// </summary>
	public class CommandList : SortedList
	{
        public
            CommandList()
        {
        }

        public
        void
            Add( 
            ICommand NewCommand )
        {
            Add( NewCommand, NewCommand );

            _ActiveCommand = NewCommand;
        }

        public
        void Remove(
            ICommand TargetCommand )
        {
            base.Remove( TargetCommand );

            ResetActiveCommand();
        }

        public
            ICommand
            GetCurrentCommand()
        {
            return _ActiveCommand;
        }

        public
            void
            ResetActiveCommand()
        {
            _ActiveCommand = null;
        }

        ICommand _ActiveCommand;
	}
}
