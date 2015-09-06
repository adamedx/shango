using System;
using System.Collections;

namespace GraphTheory.Representation.AdjacencyList
{
	/// <summary>
	/// Summary description for ListGraph.
	/// </summary>
	public class ListGraph : DefaultGraph
	{
		public ListGraph() : base ( null )
		{
            
		}

        public ListGraph( IGraph sourceGraph ) : base( sourceGraph )
        {
        }

        public
            override
            IVertexCollection
            Vertices
        {
            get
            {
                return _vertices;
            }
        }

        public
            override
            IEdgeCollection
            Edges
        {
            get
            {
                return _edges;
            }
        }

        public 
            override
            Vertex
            AddVertex(
            object key )
        {
            ListVertex newVertex = new ListVertex( key );

            bool addSuccessful = _vertices.Add( newVertex );

            if ( ! addSuccessful )
            {
                newVertex = null;
            }

            return newVertex;
        }

        public
            override
            Edge
            AddEdge(
            Vertex source,
            Vertex sink )
        {
            ListVertex sourceVertex = (ListVertex) _vertices.FindMatch( source );

            if ( null == sourceVertex )
            {
                sourceVertex = (ListVertex) AddVertex( source.Key );
            }

            if ( null == _vertices.FindMatch( sink ) )
            {
                AddVertex( sink );
            }

            Edge newEdge = null;

            bool addSuccessful = sourceVertex.AddSink( sink );

            newEdge = new Edge( source, sink );

            return newEdge;
        }

        public
            override
            bool
            RemoveVertex(
            Vertex targetVertex )
        {
            bool removedVertex = false;

            ListVertex sourceVertex = (ListVertex) _vertices.FindMatch( targetVertex );

            if ( null != sourceVertex )
            {
                foreach ( ListVertex source in _vertices )
                {
                    bool hasTargetAsSink = null != source.FindSink( targetVertex );

                    if ( hasTargetAsSink )
                    {
                        source.RemoveSink( targetVertex );
                    }
                }

                removedVertex = _vertices.Remove( targetVertex );
            }

            return removedVertex;
        }


        public
            override
            bool
            RemoveEdge(
            Edge targetEdge )
        {
            bool removeSuccessful = false;

            ListVertex sourceEdge = (ListVertex) _vertices.FindMatch( targetEdge.Source );

            if ( null != sourceEdge )
            {
                removeSuccessful = sourceEdge.RemoveSink( targetEdge.Sink );
            }

            return removeSuccessful;   
        }

        VertexCollection    _vertices;
        EdgeCollection      _edges;
	}
}
