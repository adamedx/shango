using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for ParseResults.
	/// </summary>
	public interface IParseResults
	{
        IParseError[] Errors
        {
            get;
            set;
        }

        IParseError[] Warnings
        {
            get;
            set;
        }
	}
}
