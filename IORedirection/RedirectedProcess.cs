using System;


namespace ConsoleProcessRedirection
{
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    using System.Text;
    using SystemInterface;

	/// <summary>
	/// Summary description for RedirectedProcess.
	/// </summary>
	public class RedirectedProcess
	{
        public RedirectedProcess( ITerminal ClientTerminal, ICommandClient CommandClient )
        {
            _InputHandler = new InputHandler();

            _TerminalClient = ClientTerminal;

            _ProcessExit = new ManualResetEvent( false );

            _CommandClient = CommandClient;
        }

        public
            void
            Start( string CommandLine, string Arguments )
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo( CommandLine );

            StartInfo.Arguments = Arguments;
            StartInfo.UseShellExecute = false;
            
			StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardInput = true;

			StartInfo.CreateNoWindow = true;

            _Process = Process.Start( StartInfo );
            
            //
            // Register for process exit notification
            //
            _Process.EnableRaisingEvents = true;
            _Process.Exited += new EventHandler( this.HandleProcessExit );

            InitiateIO();
        }

		public
			bool
			GetCurrentDir( ref string CurrentDir )
		{
			return false;
		}

        public
            void
            Join (
            string Machine,
            string UserDefinedName )
        {
        }

        public
            void
            Stop()
        {
            try
            {
                try
                {
                    _IOThread.Interrupt();
                }
                catch
                {
                }

                _Process.CloseMainWindow();

            }
            catch
            {
            }
        }

        public
            void
            SendInput( string NewInput )
        {
            _InputHandler.AddNewIO( NewInput );
        }

        public
            Process
            GetProcess()
        {
            return _Process;
        }

        public
            void
            Terminate()
        {
            _Process.Kill();
        }

		public
			void
			WaitForTermination()
		{
			_Process.WaitForExit();
		}

        public
            bool
            WaitForTermination( int Milliseconds )
        {
            return _Process.WaitForExit( Milliseconds );
        }

        void
            InitiateIO()
        {
            _IOThread = new Thread( new ThreadStart( ProcessIO ) );

            _IOThread.Start();
        }

        void
            ProcessIO()
        {
            OutputHandler OutHandler = new OutputHandler ( _Process.StandardOutput );
            OutputHandler ErrorHandler = new OutputHandler ( _Process.StandardError );
            
            StreamWriter InputStream = _Process.StandardInput;

            WaitHandle[] Events = new WaitHandle[]
            {
                OutHandler.HandleIO(),
                ErrorHandler.HandleIO(),
                _InputHandler.HandleIO(),
                _ProcessExit
            };

            bool bTerminated = false;

            try 
            {
                do
                {
                    //int iEvent = WaitHandle.WaitAny( Events );

                    int iEvent;

                    bool newIOWaiting;

                    try
                    {
                        newIOWaiting = SystemInterfaceLayer.Synchronization.AlertableWaitForMultiple(
                            Events,
                            SystemInterfaceLayer.WAIT_INFINITE,
                            false,
                            true,
                            out iEvent );
                    }
                    catch ( SynchronizationIOException )
                    {
                        continue;
                    }

                    if ( ! newIOWaiting )
                    {
                        break;
                    }                    

                    switch ( iEvent )
                    {
                        case 0:
                            //
                            // New standard output
                            //
                            try
                            {
                                StringBuilder OutString;

                                OutString = new StringBuilder ( OutHandler.GetIO() );

                                _TerminalClient.WriteTo(
                                    OutString,
                                    OutputType.StandardOutput);
                            }
                            catch
                            {
                                bTerminated = true;
                            }
                            break;
                        case 1:
                            //
                            // New error output
                            //
                            try
                            {
                                StringBuilder ErrorString;

                                ErrorString = new StringBuilder ( ErrorHandler.GetIO() );

                                _TerminalClient.WriteTo(
                                    ErrorString,
                                    OutputType.StandardError);
                            }
                            catch
                            {
                                bTerminated = true;
                            }
                            break;
                        case 2:
                            //
                            // New input
                            //
                            try
                            {
                                InputStream.Write( _InputHandler.GetIO() );
                            }
                            catch
                            {
                                bTerminated = true;
                            }

                            break;
                        case 3:
                            //
                            // The process has terminated
                            //
                            bTerminated = true;
                            
                            break;
                    }
                } while ( ! bTerminated );
            }
            catch ( ThreadInterruptedException )
            {
            }

            _InputHandler.Stop();
            OutHandler.Stop();
            ErrorHandler.Stop();

            if ( null != _CommandClient)
            {
                lock ( _CommandClient )
                {
                    _CommandClient.NotifyServerStatus( ConsoleProcessRedirection.ServerStatus.Terminated );
                }
            }
        }

        
        void
            HandleProcessExit( Object Sender, EventArgs ExitArgs )
        {
            _ProcessExit.Set();
        }

        public
            bool
            IsDetachedProcess()
        {
            bool bAttached = false; 
         
            int  ProcessId = _Process.Id;

            try
            {
                _Process.WaitForInputIdle(0);
            }
            catch
            {
                bAttached = true;
            }

            return ! bAttached;
        }

        public
            bool
            IsRunning()
        {
            if ( null == _Process )
            {
                return false;
            }

            if ( _Process.HasExited )
            {
                return false;
            }

            return true;
        }

        public
            void
            Disconnect()
        {
            if ( null != _CommandClient )
            {
                lock( _CommandClient )
                {
                    _CommandClient = null;
                }
            }
        }

        InputHandler       _InputHandler;
        ITerminal          _TerminalClient;
        ICommandClient     _CommandClient;
        Process            _Process;
        Thread             _IOThread;
               
        ManualResetEvent   _ProcessExit;

	}
}
