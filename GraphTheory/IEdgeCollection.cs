using System;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for IEdgeCollection.
	/// </summary>
	public interface IEdgeCollection : IElementCollection
	{
        Edge
            GetEdge(
            Vertex source,
            Vertex sink );
	}
}
