using System;

namespace GenericParser
{
    public enum Severity
    {
        Error,
        Warning
    }

	/// <summary>
	/// Summary description for ParseError.
	/// </summary>
	public interface IParseError
	{
        Severity ErrorType
        {
            get;
            set;
        }        
	}
}
