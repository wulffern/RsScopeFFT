using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for Plotter.
	/// </summary>
	public class Plotter : System.Windows.Forms.Form
	{

		#region Generated Code

		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Plotter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Initialize();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 273);
			this.panel1.TabIndex = 0;
			// 
			// Plotter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.panel1);
			this.Name = "Plotter";
			this.Text = "Plotter";
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		ChartData[] cds;

		private void Initialize()
		{


		}

		public void Plot(ChartData[] cds)
		{
			try
			{
				this.cds = cds;
				int y =0;
				int height = (int)Math.Floor(2*((double)this.Width)/3);
				foreach(ChartData cd in cds)
				{
			
					ZoomControl cc = new ZoomControl(cd);
					cc.Size = new Size(this.Width,height);
					cc.Location = new Point(0,y);
					panel1.Controls.Add(cc);
					y += height;
				}
			}
			catch{}
		}
	}
}
