using System;

namespace Shango.CommandProcessor
{
    using System.Text;
	/// <summary>
	/// Summary description for TextCommandResult.
	/// </summary>
    public class TextCommandResult : ICommandResult
    {
        public TextCommandResult( StringBuilder ResultString )
        {
            _resultString = ResultString;
        }   

        #region ICommandArgument Members

        public object GetArgument()
        {
            return _resultString;
        }

        #endregion

        StringBuilder _resultString;
    }
}
