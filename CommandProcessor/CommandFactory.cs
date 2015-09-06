using System;

namespace Shango.CommandProcessor
{
	/// <summary>
	/// Summary description for CommandFactory.
	/// </summary>
	public interface ICommandFactory
	{
        ICommand
            GetCommand( string CommandName, ICommandProcessor CommandProcessor );
	}
}
