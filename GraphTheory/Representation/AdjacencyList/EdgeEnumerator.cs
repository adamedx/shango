using System;
using System.Collections;

namespace GraphTheory.Representation.AdjacencyList
{
	/// <summary>
	/// Summary description for EdgeEnumerator.
	/// </summary>
	public class EdgeEnumerator : IEnumerator
	{
        public EdgeEnumerator(
            IEnumerable vertices )
        {
            _vertices = vertices.GetEnumerator();
            _pastEnd = false;
        }

        public
            object
            Current
        {
            get
            {
                if ( BeforeStart() || PastEnd() )
                {
                    throw new InvalidOperationException();
                }               

                return _currentVertex.Current;
            }
        }

        public
            bool
            MoveNext()
        {
            if ( ! PastEnd() )
            {
                _pastEnd = false;

                while ( BeforeStart() || ! _currentVertex.MoveNext() )
                {           
                    _pastEnd = ! _vertices.MoveNext();

                    if ( ! _pastEnd )
                    {
                        _currentVertex = ( (AdjacentVertexList) (_vertices.Current) ).GetEnumerator();
                    }
                } 
            }

            return ! _pastEnd;
        }

        public
            void
            Reset()
        {
            _currentVertex = null;
            _vertices.Reset();
            _pastEnd = false;
        }

        bool
            BeforeStart()
        {           
            return null == _currentVertex;
        }

        bool
            PastEnd()
        {
            return _pastEnd;
        }            

        IEnumerator   _currentVertex;
        IEnumerator   _vertices;     
        bool          _pastEnd;
	}
}
