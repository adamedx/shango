using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for Edge.
	/// </summary>
    public class Edge : Element, IComparable
    { 
        public Edge(
            Vertex source,
            Vertex sink )
        {
            _source = source;
            _sink = sink;
        }

        public Edge(
            object sourceKey,
            object sinkKey )
        {
            _source = new Vertex( sourceKey );
            _sink = new Vertex( sinkKey );
        }

        int Cost
        {
            get
            {
                return _Cost;
            }

            set
            {
                _Cost = value;
            }
        }

        public
            Vertex Source
        {
            get
            {
                return _source;
            }
        }

        public
            Vertex Sink
        {
            get
            {                
                return _sink;
            }
        }

        public
            virtual
            int
            CompareTo(
            object other )
        {
            Comparer comparer = new Comparer( System.Globalization.CultureInfo.CurrentCulture );

            Edge otherEdge = (Edge) other;

            int compareResult = comparer.Compare(
                _source,
                otherEdge._source );

            if ( 0 == compareResult )
            {
                comparer.Compare(
                    _sink,
                    otherEdge._sink );
            }

            return compareResult;
        }

        int _Cost;

        Vertex _source;
        Vertex _sink;
	}
}
