using System;

namespace Shango
{
    using System.Drawing;
    using System.Windows.Forms;
    using ConsoleProcessRedirection;
    using System.Text;

	/// <summary>
	/// Summary description for Terminal.
	/// </summary>
	public class TextTerminal : ITerminal
	{
		public TextTerminal(
            MainWindow Screen )
		{
            _Screen = Screen;

			_CrossThreadTextboxAccess = new MethodInvoker( AddText );
		}

        public
        void
            WriteTo( 
            StringBuilder OutputText,
            OutputType    OutType )
        {
            WriteTo(
                OutputText,
                false,
                Color.Black,
                OutType);
        }

        void
            WriteTo( 
            StringBuilder OutputText,
            bool          bColor,
            Color         OutputColor,
            OutputType    OutType )
        {
            lock ( this )
            {
                _bColor = bColor;
                _OutputColor = OutputColor;
                _OutputType = OutType;
                _NewText = OutputText.ToString();
                _Screen.Invoke( _CrossThreadTextboxAccess );			
            }
        }

        public
        void
            WriteTo( 
            StringBuilder OutputText,
            Color         OutputColor,
            OutputType    OutType )
        {
            WriteTo(
                OutputText,
                true,
                OutputColor,
                OutType);
        }
        
		void
			AddText()
		{
            string NewText = ProcessText();

            if ( ! _bColor )
            {
                _Screen.AddText( NewText, OutputType.StandardError == _OutputType );
            }
            else
            {
                _Screen.AddText( NewText, OutputType.StandardError == _OutputType, _OutputColor );
            }
		}

        string
            ProcessText()
        {
            //return _NewText;
            //return _NewText.Replace( "\r\n", "\n" ).Replace( "\r", "\n" );
            return _NewText.Replace( "\r\n", "\n" ).Replace( "\r", "" );
        }

        MainWindow    _Screen;
		MethodInvoker _CrossThreadTextboxAccess;
		string        _NewText = "";
        Color         _OutputColor;
        bool          _bColor;
        OutputType    _OutputType = OutputType.StandardError;
	}
}
