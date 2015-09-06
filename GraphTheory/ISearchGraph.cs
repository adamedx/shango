using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for SearchGraph.
	/// </summary>
	public interface ISearchGraph : IGraph
	{
        Vertex
            FindVertex(
            IComparer key );

        Edge
            FindEdge(
            IComparer sourceKey,
            IComparer sinkKey );
	}
}
