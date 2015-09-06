using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for IGraph.
	/// </summary>
	public interface IGraph : IStaticGraph
	{        
        Vertex
            AddVertex(
            object key );

        Edge
            AddEdge(
            Vertex source,
            Vertex sink );

        bool
            RemoveVertex(
            Vertex targetVertex );

        bool
            RemoveEdge(
            Edge targetEdge );
	}
}
