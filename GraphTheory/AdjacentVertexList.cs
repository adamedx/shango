using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for AdjacentVertexList.
	/// </summary>
    public class AdjacentVertexList : ArrayList, IComparable
    {
        public AdjacentVertexList( Vertex source )
        {         
            _source = source;         
        }

        public AdjacentVertexList( AdjacentVertexList sourceList ) :
        base( sourceList )
        {        
            _source = sourceList._source;
        }

        public
            Vertex Source
        {
            get
            {                               
                return _source;
            }
        }

        public
        int
            CompareTo(
            object other )
        {
            Vertex otherVertex = (Vertex) other;

            return _source.CompareTo( otherVertex );
        }

        public
            static
            explicit
            operator
            Element(
            AdjacentVertexList vertexList )
        {
            return vertexList.Source;
        }

        Vertex _source;
	}
}
