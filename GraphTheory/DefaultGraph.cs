using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for Graph.
	/// </summary>
    public abstract class DefaultGraph : IGraph
    {   
        public
        DefaultGraph( IGraph sourceGraph )
        {
            foreach ( Vertex currentVertex in sourceGraph.Vertices )
            {
                AddVertex( currentVertex.Key );
            }

            foreach ( Edge currentEdge in sourceGraph.Edges )
            {
                AddEdge( currentEdge.Source, currentEdge.Sink );
            }
        }

        public
            abstract
            IEdgeCollection
            Edges
        {
            get;
        }

        public
            abstract
            IVertexCollection
            Vertices
        {
            get;
        }

        public
            virtual
            Vertex
            GetVertex(
            object key )
        {
            Vertex targetVertex = new Vertex( key );

            return (Vertex) Vertices.FindMatch( targetVertex );
        }

        public
            virtual
            Edge
            GetEdge(
            Vertex source,
            Vertex sink )
        {
            Edge targetEdge = new Edge( source, sink );

            return (Edge) Edges.FindMatch( targetEdge );
        }

        public
           virtual
            ArrayList
            GetEdgesFrom(
            Vertex source )
        {
            ArrayList edgesFrom = new ArrayList();

            foreach ( Edge currentEdge in Edges )
            {
                if ( currentEdge.Source == source )
                {
                    edgesFrom.Add( currentEdge );
                }
            }
            
            return edgesFrom;
        }

        public
            virtual
            ArrayList
            GetEdgesTo(
            Vertex sink )
        {
            ArrayList edgesTo = new ArrayList();

            foreach ( Edge currentEdge in Edges )
            {
                if ( currentEdge.Sink == sink )
                {
                    edgesTo.Add( currentEdge );
                }
            }
            
            return edgesTo;
        }

        public
            abstract
            Vertex
            AddVertex(
            object key );

        public
            abstract
            Edge
            AddEdge(
            Vertex source,
            Vertex sink );

        public
            abstract
            bool
            RemoveVertex(
            Vertex targetVertex );

        public
            abstract
            bool
            RemoveEdge(
            Edge targetEdge );
                
        public
            virtual
            Vertex[][]
            ToAdjacencyMatrix()
        {
            return null;
        }

        public
            virtual
            ArrayList
            ToAdjacencyList()
        {
            return null;
        }
            
	}
}
