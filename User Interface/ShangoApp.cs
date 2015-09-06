using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Shango
{
    using ConsoleProcessRedirection;    
    using System.Threading;
    using System.Text;
    
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class MainWindow : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainWindow( string[] Arguments )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            _OutputWindow = new AdvancedText( this );

            _OutputWindow.Parent = this;

            _OutputWindow.Show();

            if ( Arguments.Length > 1 )
            {
                foreach ( string Argument in Arguments )
                {   
                    _RequestedCommandLine += Argument;
                }
            }

            if ( "" == _RequestedCommandLine )
            {
                _RequestedCommandLine = "cmd.exe";
            }

            TextTerminal Terminal = new TextTerminal( this );

			_CommandProcessor = new CommandProcessor( this, Terminal, 50 );

			_History = _CommandProcessor.GetHistory();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainWindow));
            // 
            // MainWindow
            // 
            this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
            this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
            this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
            this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
            this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
            this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
            this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
            this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
            this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
            this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
            this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
            this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
            this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
            this.Name = "MainWindow";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
            this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
            this.Tag = "";
            this.Text = resources.GetString("$this.Text");
            this.Visible = ((bool)(resources.GetObject("$this.Visible")));
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Move += new System.EventHandler(this.MainWindow_Move);

        }
		#endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main() 
        {
           Application.Run(new MainWindow( Environment.GetCommandLineArgs() ));
        }

        public
            void
            AddText( string NewText, bool bError )
        {
            Color NewColor = _OutputWindow.ForeColor;

            if ( bError )
            {
                NewColor = Color.Red;
            }
         
            AddText( NewText, NewColor );
        }

        public
            void
            AddText( string NewText, bool bError, Color OutputColor )
        {
            AddText( NewText, OutputColor );
        }

        void
            AddText( string NewText, Color OutputColor )
        {
            Color OriginalColor = _OutputWindow.ForeColor;

            _OutputWindow.SelectionColor = OutputColor;
         
            _OutputWindow.AddText( NewText );

            _OutputWindow.SelectionColor = OriginalColor;
        }

        private
            void 
            MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _CommandProcessor.TerminateCommand( 5000 );
        }

        private
            void
            MainWindow_Load(object sender, System.EventArgs e)
        {
            InitWindow();
       
            AddText( "Shango Command Shell\n", false );
            AddText( "Copyright (C) 2002 Adam Edwards\n", false );
            AddText( "All Rights Reserved.\n\n", false );

            ProcessCommand( _RequestedCommandLine );
        }
		

		public
			void
			ProcessCommand( string CommandLine )
		{
            _CommandProcessor.ProcessCommand( CommandLine, _bExistsInHistory, _bInitialCommand );			

            if ( _bInitialCommand )
            {
                _bInitialCommand = false;
            }
		}

        void
            SetSize()
        {
            _OutputWindow.Left = 0;
            _OutputWindow.Top = 0;

            _OutputWindow.Size = ClientSize;

            if ( null != _Backform )
            {
                _Backform.Size = ClientSize;

                Bitmap NewBackground = new Bitmap( GetWallpaper(), _Backform.Size );

                _Backform.BackgroundImage = NewBackground;
            }
        }

        void 
            SetPosition()
        {
            if ( null != _Backform )
            {
                _Backform.Location = _OutputWindow.RectangleToScreen( _OutputWindow.ClientRectangle ).Location;
            }
        }

        private
            void
            MainWindow_SizeChanged(object sender, System.EventArgs e)
        {
            SetSize();         
        }

        void
            InitWindow()
        {
            SetSize();

            SetPosition();

            System.Drawing.Icon OldIcon = Icon;

            System.Drawing.Icon NewIcon = new Icon( Icon, Icon.Width, Icon.Height );

            Icon = NewIcon;

         /*   Thread AsyncInit = new Thread( new ThreadStart( InitThread ) );

            AsyncInit.Start();*/
        }

        public
        AdvancedText
            GetDisplay()
        {
            return _OutputWindow;
        }

        public
            Bitmap
            GetWallpaper()
        {
            if ( null == _Wallpaper )
            {
                _Wallpaper = new Bitmap( "c:\\windows\\web\\wallpaper\\bliss.bmp" );
            }

            return _Wallpaper;
        }

        public
            void
            ToggleBackground()
        {
            if ( null == _Backform )
            {
                _Backform = new Backform( this );

                // _Backform.Opacity = .8;

                _Backform.Show();     

                _OutputWindow.BackColor = Color.FromArgb(255,1,2,3);

                TransparencyKey = _OutputWindow.BackColor;

                _OutputWindow.ForeColor = Color.Yellow;

                SetPosition();

                SetSize();
            }
            else
            {
                Opacity = 1;

                _OutputWindow.BackColor = Color.LightYellow;
                _OutputWindow.ForeColor = Color.Black;

                _Backform.Close();

                _Backform.BackgroundImage = null;

                _Backform = null;
            }
        }

		public
			bool
			GetTextFromHistory( bool bPrevious, out string Command )
		{
			_bExistsInHistory = _History.GetCurrentCommand( bPrevious, out Command );

			return _bExistsInHistory;
		}

		public
			bool
			CompleteCommand( 
				string PartialText,
			out string FullText )
		{
			_bCompletingCommand = _History.Find( ! _bCompletingCommand, PartialText, out FullText );

			return _bCompletingCommand;
		}

		public
			void
			ResetHistoryState()
		{
			_bExistsInHistory = false;            
			_bCompletingCommand = false;
		}

        public
            void
            TerminateAction()
        {
            _CommandProcessor.TerminateCommand( 0 );
        }

        public
            CommandProcessor
            GetCommandProcessor()
        {
            return _CommandProcessor;
        }

        Backform           _Backform;
        AdvancedText       _OutputWindow;

        string             _RequestedCommandLine = "";

        Bitmap             _Wallpaper = null;

		CommandProcessor   _CommandProcessor;
		History            _History;

		bool               _bExistsInHistory = false;
		bool               _bCompletingCommand = false;
        bool               _bInitialCommand = true;

        private void MainWindow_Move(object sender, System.EventArgs e)
        {
            SetPosition();
        }       
    }    
 
}
