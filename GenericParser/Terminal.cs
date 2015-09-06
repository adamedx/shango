using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for Terminal.
	/// </summary>
	public class Terminal : ProductionElement
	{
        static
            Terminal()
        {
            _empty = new Terminal( null );
        }

        public
        Terminal(
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

        public
            static
            Terminal
            Empty
        {
            get
            {
                return _empty;
            }
        }

        static Terminal _empty;
	}
}
