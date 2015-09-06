using System;

namespace SystemInterface
{
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Text;

    /// <summary>
    /// Summary description for Win32Environment
    /// </summary>
    public class Win32Environment : IEnvironment
    {
        public
            void
            SetSystemEnvironmentVariable(
            string VariableName,
            string Value )
        {
            int bSuccess;

            bSuccess = SetEnvironmentVariable(
                VariableName,
                Value);

            if ( 0 == bSuccess )
            {
                throw new SystemInterfaceException();
            }
        }
       

        [DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
        private static extern int SetEnvironmentVariable(
            string VariableName,
            string Value);

    }

    
    public class Win32Synchronization : ISynchronization
    {
        #region ISynchronization Members

        public 
        bool
            AlertableWaitForMultiple(
            WaitHandle[] waits,
            int          timeout,
            bool         fWaitAll,
            bool         fAlertable,
            out int      signaledIndex )
        {
            IntPtr[] handles = new IntPtr[ waits.Length ];

            int handleIndex = 0;

            signaledIndex = 0;

            foreach( WaitHandle wait in waits )
            {
                handles[ handleIndex++ ] = wait.Handle;
            }

            int retval = WaitForMultipleObjects(
                handles.Length,
                handles,
                fWaitAll,
                timeout,
                fAlertable);

            bool   isWaitSignaled = false;
           
            int possibleIndex = retval - WIN32_WAIT_OBJECT0;

            if ( possibleIndex < handles.Length )
            {
                signaledIndex = possibleIndex;
                isWaitSignaled = true;
            }
            else
            {
                switch ( retval )
                {
                    case WIN32_WAIT_TIMEOUT:
                        break;
                    case WIN32_WAIT_IO:
                        throw new SynchronizationIOException();
                    default:
                        SystemInterfaceException waitException = new SystemInterfaceException();
                        waitException.systemCode = retval;
                        throw waitException;
                }
            }

            return isWaitSignaled;
        }

        #endregion

        [DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
        private static extern int WaitForMultipleObjects(
            int           handleCount,
            IntPtr[]      handles,
            bool          bWaitAll,
            int           waitMilliseconds,
            bool          bAlertable );

        const int WIN32_WAIT_OBJECT0 = 0x0;
        const int WIN32_WAIT_IO =      0xc0;
        const int WIN32_WAIT_TIMEOUT = 0x102;

    }

}
