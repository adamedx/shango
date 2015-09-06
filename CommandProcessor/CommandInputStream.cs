using System;

namespace CommandProcessor
{
	/// <summary>
	/// Summary description for CommandInputStream.
	/// </summary>
	public interface ICommandInputStream
	{
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

        public
            ICommandOutputStream
            Source
        {
            get;
            set;
        }
	}
}
