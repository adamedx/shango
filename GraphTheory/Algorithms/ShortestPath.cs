using System;
using System.Collections;
using GraphTheory.Representation.AdjacencyList;

namespace GraphTheory.Algorithms
{
	/// <summary>
	/// Summary description for ShortestPath.
	/// </summary>
	public class ShortestPath
	{
		public ShortestPath( 
            ListGraph graph )
		{
            _graph = graph;
		}

        public
        IList
            GetShortestPath(
            Vertex source,
            Vertex sink )
        {
            Queue shortestPath = new Queue();

            return null;
        }

        ListGraph _graph;
	}
}
