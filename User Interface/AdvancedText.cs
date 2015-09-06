using System;

namespace Shango
{
    using System.Windows.Forms;
    using System.Drawing;

    /// <summary>
    /// Summary description for AdvancedText.
    /// </summary>
	public class AdvancedText : RichTextBox
	{
		public AdvancedText( MainWindow Screen )
		{
			_Screen = Screen;

			Initialize();
		}

		void
			Initialize()
		{
			AutoSize = true;
			BackColor = System.Drawing.Color.LightYellow;
			Font = new System.Drawing.Font( "Arial", (float)11 );
			ForeColor = System.Drawing.Color.Black;
			Multiline = true;
			Name = "OutputWindow";
			Size = new System.Drawing.Size( 756, 756 );
            ScrollBars = RichTextBoxScrollBars.ForcedBoth;			

			//this.AcceptsReturn = true;
            
			// this.Paint += new PaintEventHandler( this.OnPaint2 );

			//
			// Rich text specific handlers
			//
			RightMargin = 768;

            WordWrap = false;
			
			ShowSelectionMargin = true;
            Visible = true;
		}
		/*
				protected void OnPaint2( object sender, PaintEventArgs e )
				{
					Bitmap Wallpaper = new Bitmap( "%windir%\\web\\wallpaper\\bliss.bmp" );

					e.Graphics.DrawImage( Wallpaper, 0, 0, Wallpaper.Width, Wallpaper.Height );
				}

			  protected override void OnSizeChanged( EventArgs e )
				{
					Graphics Screen = CreateGraphics();
            
					Bitmap Wallpaper = new Bitmap( "c:\\windows\\web\\wallpaper\\bliss.bmp" );

					Screen.DrawImage( Wallpaper, 0, 0, Wallpaper.Width, Wallpaper.Height );

					Screen.Dispose();
				}

				protected override void OnResize( EventArgs e )
				{
					Graphics Screen = CreateGraphics();
            
					Bitmap Wallpaper = new Bitmap( "c:\\windows\\web\\wallpaper\\bliss.bmp" );

					Screen.DrawImage( Wallpaper, 0, 0, Wallpaper.Width, Wallpaper.Height );

					Screen.Dispose();
				}

				protected override void OnPaintBackground( PaintEventArgs e )
				{
					this.On
					Console.WriteLine( "Hello" );
            
				}
		*/
       
		protected
			override
			void
			WndProc(
			ref Message msg )
		{
			const int WinMsg_EraseBackground = 0x14;
			const int WinMsg_Paint = 0xf;
			//const int WinMsg_KeyDown = 0x100;

			//const int WinKey_Up = 0x26;
			//const int WinKey_Down = 0x28;

			switch ( (int) msg.Msg )
			{
				case WinMsg_EraseBackground:
					// base.WndProc( ref msg );
					//bConsole.WriteLine("Intercepted paint");
					//DrawBitmap( msg.HWnd );
					//msg.Result = (IntPtr) 0x1;
					//return;
					break;
                    
				case WinMsg_Paint:
					break;
					/*base.WndProc( ref msg );

					Console.WriteLine("Intercepted paint");                   
					DrawBitmap( msg.HWnd );
                    
					msg.Result = (IntPtr) 0x0;
					return;*/
					/*
									case WinMsg_KeyDown:
										switch( (int) msg.WParam )
										{
											case WinKey_Up:
												Console.WriteLine("Up");
												GetTextFromHistory( false );
												msg.Result = (IntPtr) 0;
												return;

											case WinKey_Down:
												Console.WriteLine("Down");
												GetTextFromHistory( true );
												msg.Result = (IntPtr) 0;
												return;
										}
										break;
										*/
			}

			base.WndProc( ref msg );
		}

		void
			DrawBitmap( IntPtr hWnd )
		{
			Graphics Surface = Graphics.FromHwnd( hWnd );

            
			Bitmap Wallpaper = new Bitmap( _Screen.GetWallpaper(), ClientSize );
    
			Wallpaper.MakeTransparent( ForeColor );

			Surface.DrawImage( Wallpaper, 0, 0, Wallpaper.Width, Wallpaper.Height );

		}

		protected
			override
			void
			OnKeyDown( KeyEventArgs KeyPress )
		{
			switch ( KeyPress.KeyCode )
			{
				case Keys.Return:
				{
					string NewLine = GetCurrentLine();

					_Screen.ProcessCommand( NewLine );

					KeyPress.Handled = true;
				}
					break;

				case Keys.Up:
					GetTextFromHistory( true );
					KeyPress.Handled = true;
					break;

				case Keys.Down:
					GetTextFromHistory( false );
					KeyPress.Handled = true;
					break;
                
				case Keys.Escape:
					ResetCurrentLine();
					KeyPress.Handled = true;
					break;

				case Keys.F8:
					CompleteCommand();
					KeyPress.Handled = true;
					return;

				case Keys.F10:
					_Screen.ToggleBackground();
					KeyPress.Handled = true;
					break;

                case Keys.C:

                    if ( (Keys.Control | Keys.C ) == KeyPress.KeyData )
                    {
                        if ( 0 == SelectedText.Length )
                        {
                            _Screen.ProcessCommand( "" + (char)3 );
                            KeyPress.Handled = true;
                        }                       
                    }
                    else if ( ( Keys.Control | Keys.C | Keys.Shift ) == KeyPress.KeyData )
                    {
                        _Screen.TerminateAction();
                    }

                    break;

                case Keys.Cancel:

                    Console.WriteLine("ctrlbreak");
                    break;
        
				default:
		            break;
			}

            if ( ! KeyPress.Handled )
            {
                base.OnKeyDown( KeyPress );
            }

			_Screen.ResetHistoryState();
		}



		void 
			ResetCurrentLine()
		{
			SetCurrentLine( "" );
		}

		public
		void
			SetCurrentLine( string NewText )
		{
			SelectCurrentLine();

			SelectedText = NewText;
		}

		bool
			SelectCurrentLine()
		{
			int    CurrentIndex = 0;
			int    NewTextLength;

			if ( Text.Length > 0 )
			{
				CurrentIndex = TextLength - 1;
			}

			NewTextLength = CurrentIndex - _LastIndex + 1;

			if ( NewTextLength > 0 )
			{
				Select( _LastIndex, NewTextLength );

				return true;
			}

			return false;
		}

		string
			GetCurrentLine()
		{
			int    CurrentIndex;
			string NewLine = "";

			CurrentIndex = SelectionStart;

			if ( SelectCurrentLine() )
			{
				NewLine = SelectedText;

				SelectedText = "";

				CurrentIndex = SelectionStart;                                  
			}
			else if ( Text.Length > 0 )
			{
				Select( Text.Length - 1, 0 );

				CurrentIndex = SelectionStart;                                  
			}

			_LastIndex = CurrentIndex;

			char[] buf = NewLine.ToCharArray();

			return NewLine;
		}

		public
			void
			AddText( string NewText )
		{
			int CurrentIndex;

			Select( MaxLength, 0 );

			CurrentIndex = SelectionStart;
            
			char[] fun = NewText.ToCharArray();

            
			AppendText( NewText );

			//_LastIndex += ( SelectionStart - CurrentIndex );
			_LastIndex = SelectionStart;
		}

		public
			void
			GetTextFromHistory( bool bPrevious )
		{
			string Command;

            if ( _Screen.GetTextFromHistory( bPrevious, out Command ) )
            {
                SetCurrentLine( Command );
            }
            else if ( ! bPrevious )
            {
                SetCurrentLine( "" );
            }
		}

        private void InitializeComponent()
        {
            // 
            // AdvancedText
            // 
            this.Visible = false;
            this.WordWrap = false;

        }

		public
			void
			CompleteCommand()
		{
			string FullCommand;
			bool   bFoundCommand;
			int    iCurrentIndex = SelectionStart;

			bFoundCommand = SelectCurrentLine();

			if ( bFoundCommand )
			{
				if ( _Screen.CompleteCommand( SelectedText, out FullCommand ) ) 
				{
					SetCurrentLine( FullCommand );
				}
				else
				{
					Select( iCurrentIndex, 0 );
				}
			}
		}

		MainWindow       _Screen;

		int              _LastIndex = 0;
	}
}
