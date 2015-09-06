using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for ElementCollection.
	/// </summary>
    public abstract class ElementCollection : IElementCollection
    {
        public ElementCollection()
        {
            _elements = new ArrayList();      
        }

        public
            virtual
            IEnumerator
            GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _elements.Count;
            }
        }
    
        public bool IsSynchronized
        {
            get
            {
                return _elements.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return _elements.SyncRoot;
            }
        }

        public
            void 
            CopyTo(
            Array array,
            int   index )
        {
            _elements.CopyTo( array, index );
        }   
      
        public
            virtual
            Element
            FindMatch(
            Element sourceElement )
        {
            return (Element) _searchList[ sourceElement ];          
        }

        public
            virtual
            bool
            Add(
            Element newElement )
        {
            bool added = false;
            
            if ( null == FindMatch( newElement ) )
            {
                _elements.Add( newElement );
                _searchList.Add( newElement, newElement );

                added = true;
            }

            return added;
        }

        public
            virtual
            bool 
            Remove( 
            Element targetElement )
        {
            bool removed = false;
            
            if ( null != FindMatch( targetElement ) )
            {
                _elements.Remove( targetElement );
                _searchList.Remove( targetElement );
            }
            
            return removed;
        }

        protected ArrayList  _elements;
        protected SortedList _searchList;
	}
}
