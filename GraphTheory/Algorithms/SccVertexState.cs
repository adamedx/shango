using System;

namespace GraphTheory.Algorithms
{
	/// <summary>
	/// Summary description for SccVertex.
	/// </summary>
    internal class SccVertexState
    {
        public SccVertexState()
        {

        }

        public
            AlgorithmicVertex
            Minimum
        {
            get
            {
                return _minimum;
            }

            set
            {
                _minimum = value;
            }
        }

        public
            AlgorithmicVertex
            Root
        {
            get
            {
                return _componentRoot;
            }

            set
            {
                _componentRoot = value;
            }
        }


        AlgorithmicVertex _minimum;   
        AlgorithmicVertex _componentRoot;
	}
}
