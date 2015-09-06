using System;
using System.Threading;

namespace SystemInterface
{
    public interface IEnvironment
    {
        void
            SetSystemEnvironmentVariable(
            string VariableName,
            string Value );        
    }

    public interface ISynchronization
    {
        bool
            AlertableWaitForMultiple(
            WaitHandle[] waits,
            int          timeout,
            bool         fWaitAll,
            bool         fAlertable,
            out int      signaledIndex  );
    }

    public class SystemInterfaceLayer
    {
        static
            SystemInterfaceLayer()
        {
            if ( System.PlatformID.Win32NT == System.Environment.OSVersion.Platform )
            {
                InitializeWin32();               
            }
        }
       

        private
            static
            void
            InitializeWin32()
        {
            Environment = new Win32Environment();
            Synchronization = new Win32Synchronization();
        }

        public  static IEnvironment     Environment = null;
        public  static ISynchronization Synchronization = null;

        public  const int WAIT_INFINITE = -1;
    }
    public class SystemInterfaceException : System.Exception
    {
        public int systemCode;
    }

    public class SynchronizationIOException : SystemInterfaceException
    {
    }
}
