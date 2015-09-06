using System;

namespace GraphTheory.Algorithms
{
	/// <summary>
	/// Summary description for StronglyConnectedComponentSet.
	/// </summary>
	public class StronglyConnectedComponentSet
	{
		public StronglyConnectedComponentSet(
            IGraph graph )
		{
            _graph = graph;
		}

        public
            void
            Generate(
            Vertex root )
        {

        }

        public
            void
            Generate()
        {
        }
 
        public
        IVertexCollection[] Components
        {
            get
            {
                return null;
            }
        }



        IGraph _graph;
	}
}
