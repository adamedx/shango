using System;

namespace Shango.CommandProcessor
{
    using ConsoleProcessRedirection;
    using System.IO;

	/// <summary>
	/// Summary description for Prompt.
	/// </summary>
	public class Prompt
	{
		public Prompt(
            ITerminal Terminal,
            string    DefaultPrompt
            )
		{
            _Terminal = Terminal;

            if ( null != DefaultPrompt )
            {
                _DefaultPrompt = DefaultPrompt;
            }
		}

        public
            void
            ShowPrompt()
        {
            string NewPrompt = null;

            NewPrompt = Environment.GetEnvironmentVariable( "prompt" );

            if ( null == NewPrompt )
            {
                NewPrompt = _DefaultPrompt;
            }

            NewPrompt = ParsePrompt( NewPrompt );

            TermUtil.WriteText( _Terminal, (char) 10 + NewPrompt );            
        }

        string
            ParsePrompt( string RawPrompt )
        {
            string NewPrompt = "";

            try
            {
                for ( int iCurrent = 0; iCurrent < RawPrompt.Length; iCurrent++ )
                {
                    bool bReplaced = false;

                    if ( '$' == RawPrompt[iCurrent] )
                    {
                        switch ( RawPrompt.ToLower()[iCurrent + 1] )
                        {
                            case '$':
                                NewPrompt += '$';
                                bReplaced = true;
                                break;
                            case 'p':
                                NewPrompt += Directory.GetCurrentDirectory();
                                bReplaced = true;
                                break;
                            case 'g':
                                NewPrompt += '>';
                                bReplaced = true;
                                break;
                            default:
                                break;
                        }
                    }

                    if ( bReplaced )
                    {
                        iCurrent++;
                    }
                    else
                    {
                        NewPrompt += RawPrompt[iCurrent];
                    }
                }
            }
            catch
            {
                NewPrompt = RawPrompt;
            }

            return NewPrompt;
        }

        ITerminal _Terminal = null;
        string    _DefaultPrompt = "Shango>";
	}
}
