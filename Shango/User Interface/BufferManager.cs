using System;

namespace Shango
{
	/// <summary>
	/// Summary description for BufferManager.
	/// </summary>
	public class BufferManager
	{
		public BufferManager(
            ICommandPresentation commandPresentation )
		{
            _virtualLinesCount = _defaultVirtualLinesCount;
            _commandPresentation = commandPresentation;
		}

        public
            void
            SetLineCount(
            int lineCount )
        {
            _virtualLinesCount = lineCount;
            AdjustBuffer();
        }       

        public
            void
            AdjustBuffer()
        {
            string[] commandLines = _commandPresentation.GetLines();

            if ( commandLines.Length > ( _virtualLinesCount * 2 ) )
            {
                string newText = "";

                int currentLineStart = commandLines.Length - _virtualLinesCount;

                for ( int currentLineIndex = currentLineStart; currentLineIndex < commandLines.Length; currentLineIndex++ )
                {
                    newText += commandLines[ currentLineIndex ] + "\n";
                }

                _commandPresentation.SetText( newText );
            }
        }

        int                  _virtualLinesCount;
        const int            _defaultVirtualLinesCount = 3000;
        ICommandPresentation _commandPresentation;
	}
}
