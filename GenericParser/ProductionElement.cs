using System;

namespace GenericParser
{
	/// <summary>
	/// Summary description for ProductionElement.
	/// </summary>
	public abstract class ProductionElement
	{
        protected
        ProductionElement(
            string lexicalExpression )
        {
            _token = null;
        }

        public 
            Token ResolvedToken
        {
            get
            {
                return _token;
            }
        }

        protected
            virtual
            void
            SetToken(
            Token resolvedToken )
        {
            _token = resolvedToken;
        }

        public
            string
            Name
        {
            get
            {
                return GetType().FullName;
            }
        }

        public
            abstract
            bool
            Resolve();

        Token _token;
	}
}
