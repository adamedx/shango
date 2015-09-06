using System;


namespace ConsoleProcessRedirection
{
    using System.Text;
    using System.Drawing;
/*
    public
        enum OutputType
    {
        StandardOutput,
        StandardError
    }
*/
    public interface ITerminalOutput
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

    public interface ITerminalError : ITerminalOutput
    {
    }
}
