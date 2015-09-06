using System;

namespace Shango.CommandProcessor.Parsing
{
	/// <summary>
	/// Summary description for Lexer.
	/// </summary>
	public class Lexer
	{
		public Lexer( string TextStream )
		{
			_TextStream = TextStream;
		}

        public
            bool
            MatchNext( out int iToken )
        {
            iToken = 0;

            return false;
        }
                       

        string _TextStream;
	}
}
