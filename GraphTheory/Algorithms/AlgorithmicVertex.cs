using System;

namespace GraphTheory.Algorithms
{
	/// <summary>
	/// Summary description for AlgorithmicVertex.
	/// </summary>
    public class AlgorithmicVertex
    {
        public AlgorithmicVertex()
        {
            _state = null;
        }

        public
            object
            State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        object _state;
	}
}
