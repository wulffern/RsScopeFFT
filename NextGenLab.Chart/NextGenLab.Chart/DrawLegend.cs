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
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Y Legend
	/// </summary>
	internal class DrawLegend:ChControl
	{
		//string[]	Labels = new string[0];
		StringCollection labels = new StringCollection();
		ArrayList colors = new ArrayList();
		int			margin = 5;
		bool		showcolors;

        public StringCollection Labels { get { return labels; } }

        public bool ShowColors{get{return showcolors;}set{showcolors = value;}}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Labels">Y Labels</param>
		public DrawLegend()
		{
			
			showcolors = true;
		}

		public void Add(Color color,string legend)
		{
            colors.Add(color);
			Labels.Add(legend);
		}

		protected override void OnInit(Graphics g)
		{
			base.OnInit (g);
		}


		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			if(Labels.Count == 0)
				return;
			else if( Labels.Count == 1)
			{
				StringFormat tsf = new StringFormat();
				tsf.Alignment = StringAlignment.Center;
				//GraphicsContainer gc1 = g.BeginContainer();
				SizeF ys = g.MeasureString(Labels[0],Font,Height,tsf);
				g.RotateTransform(-90);
				g.DrawString(Labels[0],Font,new SolidBrush(ForeColor),
					new RectangleF(new PointF(-Height,0),new SizeF(Height,ys.Height)),tsf);
				//g.EndContainer(gc1);
				
//				//Add Y title height to ChControl X coordinate
//				x += (int)Math.Ceiling(ys.Height);

			}
			else if(Labels.Count > 1)
			{

				//Draw Legend
				SizeF ys;
				double ys_height = 5.0f;
				string ly;
				int x = 5;
				for(int i=0;i<Labels.Count;i++)
				{
					ly = Labels[i];

					ys = g.MeasureString(ly,Font);
				
					if(showcolors)
					{
						g.FillRectangle(new SolidBrush((Color)colors[i]),10,(float)ys_height+3,5,ys.Height-6);
						x = 20;
					}

					g.DrawString(ly,Font,new SolidBrush(ForeColor),x,(float)ys_height);

					if(i < Labels.Count -1)
						ys_height += ys.Height  + margin;
					else
						ys_height += margin;
				}

				g.DrawRectangle(new Pen(ForeColor),0,0,Width-1,Height-1);
			}
		}

		/// <summary>
		/// Measure the size of this legend
		/// </summary>
		/// <param name="g">Graphics to paint on</param>
		public void MeasureContent(Graphics g)
		{
			if(Labels.Count == 1)
			{
				StringFormat tsf = new StringFormat();
				tsf.Alignment = StringAlignment.Center;
				//GraphicsContainer gc1 = g.BeginContainer();
				SizeF ys = g.MeasureString(Labels[0],Font);
				this.Size = new Size((int)Math.Ceiling(ys.Height),(int)Math.Ceiling(ys.Width));

			}
			if(Labels.Count > 1)
			{
				SizeF ys;
				double ys_height = 0.0f;
				double ys_width = 0.0f;
				string ly;
				int x = 5;
				for(int i=0;i<Labels.Count;i++)
				{
					ly = Labels[i];
					ys = g.MeasureString(ly,Font);
					if(i < Labels.Count-1)
						ys_height += ys.Height  + margin;
					else
						ys_height += ys.Height/2;

					if(ys.Width > ys_width)
						ys_width = ys.Width;
				}

				if(showcolors)
					x = 20;

				this.Size = new Size((int)Math.Ceiling(ys_width) + x,(int)Math.Ceiling(ys_height) +20);
			}
		}
	}
}
