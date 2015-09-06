using System;

namespace Shango.Commands
{
    using System.IO;
    using Shango.CommandProcessor;
	/// <summary>
	/// Summary description for FileArgument.
	/// </summary>
	public class FileInputArgument : ICommandArgument
	{
		public 
            FileInputArgument( string FileName )
		{
            _fileObject = (object) new FileStream(
                FileName,
                FileMode.Open,
                FileAccess.Read );
		}

        public
            FileInputArgument( Stream sourceStream )
        {
            _fileObject = (object) sourceStream;
        }

        public
            object
            GetArgument()
        {
            return _fileObject;
        }

        object _fileObject;
	}
}
