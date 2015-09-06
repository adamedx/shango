using System;


namespace ConsoleProcessRedirection
{
    using System.Text;
    using System.Drawing;

    public
        enum OutputType
    {
        StandardOutput,
        StandardError
    }

    public interface ITerminal
    {
        void
            WriteTo( 
            StringBuilder OutputText,
            OutputType    OutType );        

        void
            WriteTo( 
            StringBuilder OutputText,
            Color         OutputColor,
            OutputType    OutType );  
    }

    public class NullTerminal : ITerminal
    {
        public
            void
            WriteTo( 
            StringBuilder OutputText,
            OutputType    OutType )
        {}

        public
            void
            WriteTo( 
            StringBuilder OutputText,
            Color         OutputColor,
            OutputType    OutType )
        {}

    }

    public class CTerminal
    {
        public
            CTerminal(
            ITerminalInput  TerminalInput,
            ITerminalOutput TerminalOutput,
            ITerminalError  TerminalError)
        {
            _TerminalOutput = TerminalOutput;
            _TerminalInput = TerminalInput;
            _TerminalError = TerminalError;
        }

        public
        ITerminalOutput
        Output
        {
            get
            {
                return _TerminalOutput;
            }            
        }

        public
            ITerminalInput
            Input
        {
            get
            {
                return _TerminalInput;
            }            
        }

        public
            ITerminalError
            Error
        {
            get
            {
                return _TerminalError;
            }            
        }    

        ITerminalOutput _TerminalOutput;
        ITerminalInput  _TerminalInput;
        ITerminalError  _TerminalError;
    }

    public class TermUtil
    {
        public
            static
            void
            WriteText( 
            ITerminal Terminal,
            string    Text )
        {
            StringBuilder NewText = new StringBuilder( Text );

            try 
            {
                Terminal.WriteTo( NewText, OutputType.StandardOutput );
            }
            catch
            {
            }
        }
    }
}
