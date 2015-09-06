using System;

namespace Shango.Commands
{
    using ConsoleProcessRedirection;
    using Shango.CommandProcessor;

	/// <summary>
	/// Summary description for InternalCommandFactory.
	/// </summary>
	public class InternalCommandFactory : ICommandFactory
	{
		public InternalCommandFactory( ITerminal Terminal )
		{
            _Terminal = Terminal;
		}

        public
        ICommand
            GetCommand( string CommandName, ICommandProcessor CommandProcessor )
        {
            ICommand NewCommand = null;

            switch( CommandName )
            {
                case "cd":
                    NewCommand = new ChangeDirCommand( CommandProcessor, _Terminal );
                    break;
                case "cwd":
                    NewCommand = new CurrentDirCommand( CommandProcessor, _Terminal );
                    break;
                case "exit":
                    NewCommand = new ExitCommand( CommandProcessor, _Terminal );
                    break;
                case "prompt":
                    NewCommand = new PromptCommand( CommandProcessor, _Terminal );
                    break;
                case "set":
                    NewCommand = new SetCommand( CommandProcessor, _Terminal );
                    break;
                case "ver":
                    NewCommand = new VersionCommand( CommandProcessor, _Terminal );
                    break;
                case "msn":
                    NewCommand = new MsnCommand( CommandProcessor, _Terminal );
                    break;
                case "page":
                    NewCommand = new PageCommand( CommandProcessor, _Terminal );
                    break;
                case "showpage":
                    NewCommand = new ShowpageCommand( CommandProcessor, _Terminal );
                    break;
                case "textpage":
                    NewCommand = new TextpageCommand( CommandProcessor, _Terminal );
                    break;
            }

            return NewCommand;
        }

        ITerminal _Terminal;
	}
}
