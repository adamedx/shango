using System;

namespace ConsoleProcessRedirection
{
    using System.IO;
	/// <summary>
	/// Summary description for ConsoleTerminal.
	/// </summary>
	public class ConsoleTerminal : ITerminal
	{
        
    #region ITerminal Members

        public void WriteTo(System.Text.StringBuilder OutputText, ConsoleProcessRedirection.OutputType OutType)
        {
            TextWriter outStream = null;

            if ( OutputType.StandardError == OutType )
            {
                outStream = Console.Out;
            }
            else
            {
                outStream = Console.Error;
            }

            outStream.Write( OutputText.ToString() );
        }

        void ConsoleProcessRedirection.ITerminal.WriteTo(System.Text.StringBuilder OutputText, System.Drawing.Color OutputColor, ConsoleProcessRedirection.OutputType OutType)
        {
            WriteTo( OutputText, OutType );
        }

    #endregion

    }
}
