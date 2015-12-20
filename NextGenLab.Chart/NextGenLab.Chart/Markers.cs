/*
Copyright (C) 2005 Carsten Wulff

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the

GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace  NextGenLab.Chart
{
	/// <summary>
	/// Summary description for Markers.
	/// </summary>
	public class Markers : System.Windows.Forms.UserControl
	{
		#region Generated Code


		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Markers()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader5,
																						this.columnHeader6,
																						this.columnHeader4,
																						this.columnHeader7});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(496, 128);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 94;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "X1";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Y1";
			this.columnHeader3.Width = 91;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "DiffX";
			this.columnHeader4.Width = 78;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "X2";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Y2";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "DiffY";
			// 
			// Markers
			// 
			this.Controls.Add(this.listView1);
			this.Name = "Markers";
			this.Size = new System.Drawing.Size(496, 128);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		PointF[] prev = new PointF[0];
		
		public void AddPoints(PointF[] real,string[] names,Color[] colors)
		{
			this.listView1.Items.Clear();
			ListViewItem lv;
			string name;
			for(int i=0;i<real.Length;i++)
			{
				
				if(real[i] != PointF.Empty)
				{

					name = (i +1) +  ": No Name";
					if(i < names.Length)
						name = names[i];

					if(prev.Length != real.Length)
					{
						
						lv = new ListViewItem(new string[]{name,DblToString(real[i].X),DblToString(real[i].Y)});
					}
					else
					{

						
						lv = new ListViewItem(new string[]{name,
															 DblToString(real[i].X),
															 DblToString(real[i].Y),
															 DblToString(prev[i].X),
															 DblToString(prev[i].Y),
															 DblToString(((float)(real[i].X - prev[i].X))),
															 DblToString(((float)(real[i].Y - prev[i].Y)))
														 });					
					}
					lv.ForeColor = Color.FromArgb(128,colors[i]);
					this.listView1.Items.Add(lv);
					
				}
			}
			prev = real;
		}

		string DblToString(double d)
		{
			//string postfix;
			//double denum;
			//GraphMath.GetPostfix(GraphMath.Power(d),out postfix, out denum);
			//d = d/denum;
			return d.ToString("E") ;//+ postfix;
		}
	}
}
