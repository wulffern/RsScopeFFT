using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NglChart
{
	/// <summary>
	/// Summary description for ColorsChart.
	/// </summary>
	public class ColorsChart : System.Windows.Forms.Control
	{

		#region Generated Code

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ColorsChart()
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
			// 
			// ColorsChart
			// 
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(222, 273);
			this.Name = "ColorsChart";

		}
		#endregion

		#endregion

		public event EventHandler NewColor;

		Color[] colors;
		string[] ecols;
		ComboBox[] c;
		private void Initialize()
		{
			colors = NextGenLab.Chart.Colors.GetColors();
			ecols = Enum.GetNames(typeof(KnownColor));
			//ecols.RemoveRange(0,27);

			int x = 10;
			int y = 10;

			c = new ComboBox[colors.Length];

			for(int i=0;i<colors.Length;i++)
			{
				Label l = new Label();
				l.Text = "Color " + i;
				l.Location = new Point(x,y);
				l.Size = new Size(50,20);
				x += 60;

				c[i] = new ComboBox();
				c[i].DropDownStyle = ComboBoxStyle.DropDownList;
				c[i].Items.AddRange(ecols);
				c[i].DisplayMember = "Name";
				c[i].Location = new Point(x,y);
				c[i].Size = new Size(100,20);
				c[i].SelectedIndexChanged +=new EventHandler(ColorsChart_SelectedIndexChanged);
				

				y += 25;
				x =10;

				this.Controls.Add(l);
				this.Controls.Add(c[i]);	
			}

			this.Size = new Size(180,y +25);

			
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			for(int i=0;i<colors.Length;i++)
			{
				c[i].SelectedItem = colors[i].Name;
			}

			base.OnPaint (e);
		}

		private void ColorsChart_SelectedIndexChanged(object sender, EventArgs e)
		{
			for(int i=0;i<c.Length;i++)
			{
				if(c[i] == sender)
				{
					try
					{
						Color color = Color.FromName((string)c[i].SelectedItem);
						if(c != null)
						{
							NextGenLab.Chart.Colors.Replace(color,i);
							colors[i] = color;
						}
						if(NewColor != null)
							NewColor(this,null);
						

					}
					catch(Exception ef)
					{
						short z =0;

					}

				}
			}
		}
	}
}
