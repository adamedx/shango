using System;

namespace Shango
{
    using ConsoleProcessRedirection;
    using SystemInterface;

    /// <summary>
    /// Summary description for PromptCommand
    /// </summary>
    public class PromptCommand : MultiInstanceCommand
    {
        public
            PromptCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string [] Arguments )
        {
            if ( Arguments.Length > 1 )
            {
                SystemInterfaceLayer.Environment.SetSystemEnvironmentVariable(
                    "prompt",
                    Arguments[1]);
            }

            return 0;
        }            	
    }
}
