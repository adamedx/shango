using System;

namespace Shango
{
    using System.Threading;
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for ExitCommand.
	/// </summary>
	public class ExitCommand : SingleInstanceCommand
	{
		public ExitCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
		{
		}

        override
        public
            int
            PerformCommand( string[] Arguments )
        {
            _Application.Close();

            return 0;
        }
	}
}
