using System;

namespace GraphTheory.Representation.AdjacencyList
{
	/// <summary>
	/// Summary description for VertexCollection.
	/// </summary>
	public class VertexCollection : ElementCollection, IVertexCollection
	{
        public
        Vertex
            GetVertex(
            object key )
        {
            return (Vertex) _searchList[ key ];
        }
	}
}
