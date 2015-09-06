using System;
using System.Collections;


namespace GenericParser.GrammarAnalysis
{
	/// <summary>
	/// Summary description for FirstSet.
	/// </summary>
	public class FirstSet
	{
		public FirstSet( ProductionElement element )
		{
            _element = element;
            _set = null;
            _hasEmpty = false;
		}

        public
            ProductionElement
            Symbol
        {
            get
            {
                return _element;
            }
        }

        public
            ProductionElement[]
            Symbols
        {
            get
            {
                return (ProductionElement[]) _set.ToArray();
            }
        }

        public
            bool
            HasEmpty
        {
            get
            {
                return _hasEmpty;
            }
        }

        public
        void
            AddSymbol( ProductionElement element )
        {
            _set.Add( element );

            if ( Terminal.Empty == element )
            {
                _hasEmpty = true;
            }
        }                

        ProductionElement   _element;

        ArrayList           _set;

        bool                _hasEmpty;
	}
}
