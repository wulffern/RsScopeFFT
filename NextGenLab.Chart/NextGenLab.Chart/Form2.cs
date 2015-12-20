using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		public NextGenLab.Chart.ChartControl2 chartControl21;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.chartControl21 = new NextGenLab.Chart.ChartControl2();
			this.SuspendLayout();
			// 
			// chartControl21
			// 
			this.chartControl21.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.chartControl21.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartControl21.ForeColor = System.Drawing.SystemColors.Highlight;
			this.chartControl21.Location = new System.Drawing.Point(0, 0);
			this.chartControl21.Name = "chartControl21";
			this.chartControl21.Size = new System.Drawing.Size(680, 510);
			this.chartControl21.TabIndex = 0;
			this.chartControl21.Text = "chartControl21";
			this.chartControl21.Click += new System.EventHandler(this.chartControl21_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 510);
			this.Controls.Add(this.chartControl21);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnForeColorChanged(EventArgs e)
		{
			
			this.chartControl21.ForeColor = this.ForeColor;
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			this.chartControl21.BackColor = this.BackColor;
		}



		private void Form2_Load(object sender, System.EventArgs e)
		{
		
		}

		private void chartControl21_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
