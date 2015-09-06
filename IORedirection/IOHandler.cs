using System;

namespace ConsoleProcessRedirection
{
    using System.Threading;
    using System.Text;
    using System.IO;

    /// <summary>
    /// Summary description for IOHandler.
    /// </summary>
    
    interface IIOHandler
    {
        WaitHandle
            HandleIO();

        void
            Stop();

        string
            GetIO();

        void
            AddNewIO( string IOData );
    }

    public class IOBuffer : IIOHandler
    {
        public
            IOBuffer()
        {
            _EventIOAvailable = new AutoResetEvent( false );   
        }

        public
        WaitHandle
            HandleIO()
        {
            return _EventIOAvailable;
        }

        public
        void
            Stop()
        {
        }

        public
            string
            GetIO()
        {
            string NewData;

            NewData = _NewData;

            _NewData = "";

            return NewData;
        }
        
        public
            void
            AddNewIO( string IOData )
        {
            if ( null == IOData )
            {
                return;
            }

            _NewData += IOData;

            _EventIOAvailable.Set();
        }

        protected
        string           _NewData = "";
        
        protected
        AutoResetEvent _EventIOAvailable;
    }

    public class OutputHandler : IOBuffer
    {
        public OutputHandler( StreamReader OutputStream )
        {
            _OutputStream = OutputStream.BaseStream;

			_Encoding = OutputStream.CurrentEncoding; 
        }

        public
            new
            WaitHandle
            HandleIO()
        {
            AsyncCallback OutputAsyncCallback = new AsyncCallback( HandleOutput );


            IAsyncResult Result = _OutputStream.BeginRead( 
                _Buffer,
                0,
                _Buffer.Length,
                OutputAsyncCallback,
                this);

            return _EventIOAvailable;
        }   

        public
            new
            void
            Stop()
        {
            _OutputStream.Close();
        }

        void
            HandleOutput( 
            IAsyncResult Result )
        {
            try
            {
                if ( Result.IsCompleted )
                {                  
                    int BytesRead;

                    BytesRead = _OutputStream.EndRead( Result );
        				
                    if ( BytesRead > 0 )
                    {
                        string NewOutput = _Encoding.GetString( _Buffer, 0, BytesRead );
        		
                        AddNewIO( NewOutput );
                    }
                    
                    HandleIO();
                }
            }
            catch
            {
            }
        }

        Stream       _OutputStream;
		Encoding     _Encoding;
        byte[]       _Buffer = new byte[4096];
    }

    public class InputHandler : IOBuffer
    {
    }
}


