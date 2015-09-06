using System;
using System.Collections;

namespace GenericParser
{
	/// <summary>
	/// Summary description for Grammar.
	/// </summary>
    public class Grammar
    {
        public Grammar(
            Production   startProduction,
            Production[] productionList,
            Token[]      tokenList )
        {
            _startProduction = startProduction;
            _productionList = productionList;
            _tokenList = tokenList;
        }

        public
        Production Start
        {
            get
            {
                return _startProduction;
            }
        }

        public
        Production[] Rules
        {
            get
            {
                return _productionList;
            }
        }

        public
        Token[] Tokens
        {
            get
            {
                return _tokenList;
            }
        }                

        Production   _startProduction;
        Production[] _productionList;
        Token[]      _tokenList;
	}
}
