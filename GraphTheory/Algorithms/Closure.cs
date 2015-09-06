using System;
using System.Collections;

namespace GraphTheory.Algorithms
{
	/// <summary>
	/// Summary description for Closure.
	/// </summary>
	public class Closure
	{
		public Closure(
            IGraph graph )
		{         
            _graph = graph;
		}

        public
        void
            ReflexiveTransitive()
        {
            StronglyConnectedComponentSet sccFinder = new StronglyConnectedComponentSet( _graph );

            sccFinder.Generate();

            IVertexCollection[] components = sccFinder.Components;

            foreach ( IVertexCollection component in components )
            {
                AddEdgesFromStronglyConnectedComponent( component );
            }
        }

        void
            AddEdgesFromStronglyConnectedComponent( IVertexCollection component )
        {
            int sourceVertexCount = (int) System.Math.Ceiling( System.Math.Sqrt( component.Count ) );

            IEnumerator componentEnumerator = component.GetEnumerator();

            for ( int currentVertexIndex = 0; currentVertexIndex < sourceVertexCount; currentVertexIndex++ )
            {
                componentEnumerator.MoveNext();

                foreach( Vertex sinkVertex in component )
                {
                    _graph.AddEdge(
                        (Vertex) componentEnumerator.Current,
                        sinkVertex);
                }
            }
        }

        IGraph _graph;
	}
}
