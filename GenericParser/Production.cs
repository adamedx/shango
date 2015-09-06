using System;
using System.Collections;
using System.Reflection;

namespace GenericParser
{
	/// <summary>
	/// Summary description for Production.
	/// </summary>
    public class Production
    {
        Production(
            string left,
            params string[] right )
        {
            Type leftType = Type.GetType( left );

            _right = new ArrayList();

            foreach( string typeName in right )
            {                
                ProductionElement vocabularyElement = (ProductionElement) CreateInstance(
                    typeName,
                    null );

                _right.Add( vocabularyElement );
            }

            _left = (NonTerminal) CreateInstance(
                left,
                _right.ToArray() );
        }

        Production(
            NonTerminal left,
            params ProductionElement[] right )
        {
            _left = Left;
            _right = new ArrayList( right );
        }

        static
            public
            string
            VocabularyNamespace
        {
            set
            {
                _customVocabularyNamespace = value;
            }
        }

        public
            NonTerminal Left
        {
            get
            {
                return _left;
            }
        }

        public
            ArrayList Right
        {
            get
            {
                return _right;
            }
        }

        public
        virtual
            void
            Recognize()
        {
        }

        object
            CreateInstance(
            string   typeName,
            object[] parameters )
        {
            BindingFlags flags = BindingFlags.CreateInstance | 
                BindingFlags.Public |
                BindingFlags.Instance;

            Type instanceType = Type.GetType( typeName );

            object newInstance = instanceType.InvokeMember(
                null,
                flags,
                null,
                null,
                parameters);

            return newInstance;           
        }

        string
            GetVocabularyNamespace()
        {
            if ( null == _customVocabularyNamespace )
            {
                return GetDefaultVocabularyNamespace();
            }

            return _customVocabularyNamespace;
        }

        string
            GetDefaultVocabularyNamespace()
        {
            return GetType().Namespace;
        }

        NonTerminal   _left;
        ArrayList     _right;

        static string _customVocabularyNamespace;
	}
}
