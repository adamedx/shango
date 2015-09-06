using System;

namespace Shango.CommandProcessor
{
	/// <summary>
	/// Summary description for ICommandArgument.
	/// </summary>
	
    public interface ICommandArgument
    {
        object
            GetArgument();     
    }

    public class CommandArgument : ICommandArgument
	{
        public
            CommandArgument(
            string textArgument )
        {
            _textArgument = textArgument;
        }

        public
            object
            GetArgument()
        {
            return _textArgument;
        }
        
        string _textArgument;
	}
}
