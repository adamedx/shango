using System;
using System.Collections;

namespace GraphTheory.Representation.AdjacencyList
{
	/// <summary>
	/// Summary description for EdgeCollection.
	/// </summary>
	public class EdgeCollection : ElementCollection, IEdgeCollection
	{
        EdgeCollection(
            VertexCollection vertices )
        {
            _vertices = vertices;
        }

        public
            override
            bool
            Add(
            Element newElement )
        {
            bool added = false;

            Edge newEdge = (Edge) newElement;            

            if ( null != _vertices.FindMatch( newEdge.Source ) ||
                null != _vertices.FindMatch( newEdge.Sink ) )
            {
                added = base.Add( newElement );
            }

            return added;
        }

        public
            override
            IEnumerator
            GetEnumerator()
        {
            return new EdgeEnumerator( _vertices );
        }

        public
            Edge
            GetEdge(
            Vertex source,
            Vertex sink )
        {
            Edge foundEdge = null;

            ListVertex sourceVertex = (ListVertex) _vertices.FindMatch( source );

            if ( null != sourceVertex )
            {
                Vertex sinkVertex = sourceVertex.FindSink( sink );

                if ( null != sinkVertex )
                {
                    foundEdge = new Edge( sourceVertex, sinkVertex );
                }
            }

            return foundEdge;
        }

        VertexCollection _vertices;
	}
}
