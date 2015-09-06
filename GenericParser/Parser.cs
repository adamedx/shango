using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for Parser.
	/// </summary>
    interface  IParser
    {
        Grammar _grammar
        {
            set;
            get;
        }

        bool HasParsableGrammar
        {
            get;
        }
            
        bool
            Parse(
            object        semanticContext,
            IParseResults results);        
    }
}
