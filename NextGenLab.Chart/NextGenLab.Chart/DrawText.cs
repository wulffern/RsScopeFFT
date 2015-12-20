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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Decorate a Chart control with title and legends
	/// </summary>
	internal class DrawText:ChControl
	{
		#region Private fields
		string		Title;
		string		XLabel;
//		string[]	YLabels;
		string		XType;
		string		YType;
		ChControl	cc;
		Font		bold;
		StringFormat tsf;
		DrawLegend ly;
		bool showtitle = true;
		bool showlegend = true;
		bool legendhorizontal = true;
		#endregion

		#region Properties
		public bool ShowTitle{get{return showtitle;}set{showtitle = value;}}
		public bool ShowLegend{get{return showlegend;}set{showlegend = value;}}
		#endregion

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		/// <param name="cc">Chart Control</param>
		public DrawText(ChControl cc,ChartData cd)
		{
			//Init Properties
			this.Title = cd.Title;
			this.XLabel = cd.TitleX;
//			this.YLabels = cd.TitlesY;
			this.XType = cd.AxisLabelX;
			this.YType = cd.AxisLabelY;
		

			if(cd.TitlesY != null && cd.TitlesY.Length == 1)
				legendhorizontal = false;
			//Set ChControl
			this.cc = cc;

			//Init legend 
			ly = new DrawLegend();
			
			//Add legend and ChControl to Children
			this.Children.Add(cc);
			this.Children.Add(ly);

			//Set Parents of legend and ChControl
			ly.Parent = this;
			cc.Parent = this;
		}

		public void SetLegend(DrawLegend ly)
		{
			this.ly = ly;
		}

		protected override void OnInit(Graphics g)
		{

			//Init variables
			tsf = new StringFormat();
			tsf.Alignment = StringAlignment.Center;
			bold = new Font(Font,FontStyle.Bold);

			//Y coordinate for ChControl
			int y = 5;

			//X coordiante for ChControl
			int x = 5;

			//Height of ChControl
			int height = Height;

			//Width of ChControl
			int width = Width;

			//Draw title
			if(ShowTitle)
			{
				SizeF ts = g.MeasureString(Title,bold,Width,tsf);
				//Add Title Height to y coordinate
				y += (int)Math.Ceiling(ts.Height);
			}


			//Draw XLabel
			SizeF xs = g.MeasureString(XLabel,Font,Width,tsf);
			//Subtract X Label height from ChControl height
			height -= (int)Math.Ceiling(xs.Height);

			//Draw Y Titles
			if(ShowLegend)
			{
					//Draw Y labels
					ly.Font = Font;
					ly.MeasureContent(g);
						
				if(legendhorizontal)
					//Subtract legend width from ChControl width
					width -= ly.Width+1;
				else
					x += ly.Width + 1;

			}

			//Draw X axis label
			if(XType != null)
			{
				SizeF xss = g.MeasureString(XType,Font);
				//Subtract Height of x axis label from ChControl height
				height -= (int)Math.Ceiling(xss.Height);
			}

			//Draw Y axis label
			if(YType != null)
			{
				SizeF xss = g.MeasureString(YType,Font);
				//Set the x coordinate to new value if it is too small
				if(x < (int)Math.Ceiling(xss.Width))
				{
					x = (int)Math.Ceiling(xss.Width);
				}
			}

			cc.Size = new Size(width - x,height - y);
			cc.Init(g);

			//base.OnInit (g);
		}


		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			
			
			//Y coordinate for ChControl
			int y = 5;

			//X coordiante for ChControl
			int x = 5;

			//Height of ChControl
			int height = Height;

			//Width of ChControl
			int width = Width;

			//Draw title
			if(ShowTitle)
			{
				SizeF ts = g.MeasureString(Title,bold,Width,tsf);
				g.DrawString(Title,
					bold,
					new SolidBrush(ForeColor),
					new RectangleF(new Point(0,y),new SizeF(Width,ts.Height)),
					tsf);

				//Add Title Height to y coordinate
				y += (int)Math.Ceiling(ts.Height);
			}


			//Draw XLabel
			SizeF xs = g.MeasureString(XLabel,Font,Width,tsf);
			g.DrawString(XLabel,
				Font,
				new SolidBrush(ForeColor),
				new RectangleF(new Point(0,Height - (int)Math.Ceiling(xs.Height)),new SizeF(Width,xs.Height)),
				tsf);
			//Subtract X Label height from ChControl height
			height -= (int)Math.Ceiling(xs.Height);

			//Draw Y Titles
			if(ShowLegend)
			{
//				//Draw Legend

				if(legendhorizontal)
				{
					ly.Font = Font;
					ly.MeasureContent(g);
					GraphicsContainer gc1 = g.BeginContainer();
					g.TranslateTransform(Width - ly.Width -1,1);
					ly.Paint(g);
					g.EndContainer(gc1);
						
					//Subtract legend width from ChControl width
					width -= ly.Width+1;
				}
				else
				{
					GraphicsContainer gc1 = g.BeginContainer();
					g.TranslateTransform(1,this.Height/2 - ly.Height/2);
					ly.Paint(g);
					g.EndContainer(gc1);
					x += ly.Width + 1;
				}
//				}
//				//Draw Single Y Title
//				else if (YLabels.Length == 1)
//				{
//					GraphicsContainer gc1 = g.BeginContainer();
//					SizeF ys = g.MeasureString(YLabels[0],Font,Height,tsf);
//					g.RotateTransform(-90);
//					g.DrawString(YLabels[0],Font,new SolidBrush(ForeColor),
//						new RectangleF(new PointF(-Height,0),new SizeF(Height,ys.Height)),tsf);
//					g.EndContainer(gc1);
//
//					//Add Y title height to ChControl X coordinate
//					x += (int)Math.Ceiling(ys.Height);
//				}
			}

			//Draw X axis label
			if(XType != null)
			{
				SizeF xss = g.MeasureString(XType,Font);
				g.DrawString(XType,Font,new SolidBrush(ForeColor),width - xss.Width,height - xss.Height);

				//Subtract Height of x axis label from ChControl height
				height -= (int)Math.Ceiling(xss.Height);
			}

			//Draw Y axis label
			if(YType != null)
			{
				SizeF xss = g.MeasureString(YType,Font);
				g.DrawString(YType,Font,new SolidBrush(ForeColor),0,y);

				//Set the x coordinate to new value if it is too small
				if(x < (int)Math.Ceiling(xss.Width))
				{
					x = (int)Math.Ceiling(xss.Width);
				}
			}
            
			//Set Location and Size of ChControl and Paint it
			GraphicsContainer gc = g.BeginContainer();
			cc.Location = new Point(x,y);
			cc.Paint(g);
			g.EndContainer(gc);
		}
	}
}
