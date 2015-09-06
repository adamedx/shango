using System;

namespace Xango
{
    using Shango.CommandProcessor;
    using ConsoleProcessRedirection;
    using Shango.Commands;

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class XangoApp : ICommandEnvironment
	{
        public
            XangoApp()
        {
            _Terminal = new ConsoleTerminal();

            InternalCommandFactory internalFactory = new InternalCommandFactory(
                _Terminal );
            
            _CommandProcessor = new StandardCommandProcessor(
                this,
                internalFactory,
                _Terminal,
                50 );           
        }

        #region ICommandEnvironment Members

        public void CloseEnvironment()
        {
        }

        #endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static int Main(string[] args)
		{
            XangoApp shell = new XangoApp();

            return shell.Execute( args );
		}

        int
            Execute( string[] args )
        {
            string commandLine = "";

            foreach ( string argument in args )
            {
                commandLine += " " + argument;
            }

            _CommandProcessor.ProcessCommand(
                commandLine,
                false,
                false);

            return 0;
        }

        StandardCommandProcessor _CommandProcessor;
        ConsoleTerminal          _Terminal;

    }
}
