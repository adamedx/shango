using System;

namespace Shango.CommandProcessor
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ObjectStream
    {
        void
        WriteTo(
        object NewData )
        {
        }

        public 
        object
        ReadFrom();

        public
        object
        Current
        {
            get;
            set;
        }
	}
/*
    public class ObjectReader : IEnumerable
    {
        protected
        ObjectStream
        Stream
        {
            get;
        }
    }

    public class ObjectWriter
    {
        protected
        ObjectStream
        Stream
         {
            get;
        }
    }*/
}
