using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for Token.
	/// </summary>
	public abstract class Token
	{
        public abstract string Text
        {
            set;
            get;
        }            
	}
}
