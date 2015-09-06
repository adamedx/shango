using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for Vertex.
	/// </summary>
    public class Vertex : Element, IComparable
    {
        public Vertex(
            object key )
        {
            _key = key;
        }

        public
            object Key
        {
            get
            {               
                return _key;
            }
        }

        public
            int
            CompareTo(
            object other )
        {
            Comparer comparer = new Comparer( System.Globalization.CultureInfo.CurrentCulture );

            Vertex otherVertex = (Vertex) other;

            return comparer.Compare(
                _key,
                otherVertex._key );
        }

        protected object _key;
	}
}
