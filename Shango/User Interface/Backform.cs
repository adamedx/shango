using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Shango
{
	/// <summary>
	/// Summary description for Backform.
	/// </summary>
	public class Backform : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Backform( MainWindow Screen )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            _Screen = Screen;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            // 
            // Backform
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Backform";
            this.ShowInTaskbar = false;
            this.Text = "Backform";
            this.Activated += new System.EventHandler(this.Backform_Activated);

        }
		#endregion

        MainWindow _Screen;

        private void Backform_Activated(object sender, System.EventArgs e)
        {
             _Screen.Activate();
        }       
	}
}
