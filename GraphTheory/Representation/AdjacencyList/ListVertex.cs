using System;
using System.Collections;

namespace GraphTheory.Representation.AdjacencyList
{
	/// <summary>
	/// Summary description for ListVertex.
	/// </summary>
	public class ListVertex : Vertex
	{
		public ListVertex( Vertex source ) :
            base( source.Key )
		{
            _sinks = new SortedList();
		}

        public ListVertex( object key ) : 
            base( key )
        {
            _sinks = new SortedList();
        }

        public
            bool
            AddSink(
            Vertex sink )
        {
            bool addedSink = false;

            if ( null == FindSink( sink ) )
            {
                _sinks.Add( sink, sink );
                addedSink = true;
            }

            return addedSink;
        }

        public
            bool
            RemoveSink(
            Vertex sink )
        {
            bool removedSink = false;

            if ( null != FindSink( sink ) )
            {
                _sinks.Remove( sink );
                removedSink = true;
            }

            return removedSink;
        }

        public
            ArrayList
            GetSinks()
        {
            return new ArrayList( _sinks );
        }

        public
            Vertex
            FindSink(
            Vertex sink )
        {
            return (Vertex) _sinks[ sink ];
        }

        SortedList _sinks;
	}
}
