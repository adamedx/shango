using System;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for IVertexCollection.
	/// </summary>
	public interface IVertexCollection : IElementCollection
	{
        Vertex
            GetVertex(
            object key );
	}
}
