using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for NonTerminal.
	/// </summary>
	public abstract class NonTerminal : ProductionElement
	{
        public
        NonTerminal(
            string lexicalDefinition ) :
            base ( lexicalDefinition )
        {
        }

        public
            override
            bool
            Resolve()
        {
            return false;
        }
	}
}
