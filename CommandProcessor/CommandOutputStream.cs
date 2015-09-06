using System;

namespace CommandProcessor
{
	/// <summary>
	/// Summary description for CommandOutputStream.
	/// </summary>
    public interface ICommandOutputStream
    {
        public
            void
            WriteTo(
            object newData );

        public
            ICommandInputStream
            Destination
        {
            get;
            set;
        }
    

	}
}
