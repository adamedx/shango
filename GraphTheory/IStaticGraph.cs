using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for BasicGraph.
	/// </summary>
	public interface IStaticGraph
	{
        IVertexCollection
            Vertices
        {            
            get;
        }

        IEdgeCollection 
            Edges
        {
            get;
        }

        ArrayList
            GetEdgesFrom(
            Vertex source );
        
        ArrayList
            GetEdgesTo(
            Vertex sink );

        Vertex[][]
            ToAdjacencyMatrix();
        
        ArrayList
            ToAdjacencyList();
	}
}
