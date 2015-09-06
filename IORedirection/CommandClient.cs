using System;

namespace ConsoleProcessRedirection
{
    public
        enum ServerStatus
    {
        Terminated
    }

    public interface ICommandClient
    {
        void
            NotifyServerStatus(
            ServerStatus Status );
    }	
}
