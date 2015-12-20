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
using System.Windows.Forms;
using System.Drawing;
using NextGenLab.Chart;
using System.Drawing.Drawing2D;
using System.Collections;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for ZoomControl.
	/// </summary>
	public class ZoomControl:NextGenLab.Chart.ChartControl
	{
		
		protected bool Zooming;
		Rectangle r;
		int xstart;
		int ystart;
		int x;
		int y;
		bool shift = false;
		int grid = 10;
		//bool first = true;
		Stack rasterstack = new Stack();

		#region Constructors
		public ZoomControl()
		{
		}

//		public ZoomControl(ChartData cd):base(cd)
//		{
//
//		}
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			//Mark the shiftkey as pressed
			if(e.KeyCode == Keys.ShiftKey)
			{
				shift = true;
               
			}
			
			//Rescale to original data if z is pressed
			if(e.KeyData == Keys.Z)
			{
				this.ChartDataList.RestoreOriginalAxis();
				this.AutoScale = true;
				this.Invalidate();
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			//Unmark the shift key
			if(e.KeyCode == Keys.ShiftKey)
			{
				shift = false;
			}
			base.OnKeyUp (e);
		}
		
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			//Start Zoom
			if(e.Button == MouseButtons.Left && shift)
			{
				Zooming = true;
				if(this.CurveArea.Contains(new Point(e.X,e.Y)))
				{
					xstart = e.X;
					ystart = e.Y;
					this.RedrawChart();
				}
				this.Focus();
			}
			base.OnMouseDown (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			//Tell it to readraw zoom rectangle
			if(this.CurveArea.Contains(new Point(e.X,e.Y)) && shift)
			{
				//Only redraw if the  difference from last point is more than grid
				if(Math.Abs(x -e.X) > grid || Math.Abs(y - e.Y) > grid)
				{
					x = e.X;
					y = e.Y;

					//Paint the zoom rectangle if Zooming is enabled
					if(Zooming)
					{
						r = new Rectangle(xstart,ystart,(x-xstart),(y-ystart));
						RasterPaintStack();
						this.RasterPaintFrame(x,y,xstart,ystart);
					}
				}
			}
			base.OnMouseMove (e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			//Stop zoom and resize axis
			if(Zooming && r != Rectangle.Empty)
			{
				Zooming = false;
				RasterPaintStack();
				ResizeAxis(r);
				
			}
			base.OnMouseUp (e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{

			//Clear the raster stack
			while(rasterstack.Count > 0)
				rasterstack.Pop();
			base.OnPaint (e);
		}


		void ResizeAxis(Rectangle r)
		{
			//If the rectangle has zero width or zero height return
			if(r.Width == 0)
				return;
			if(r.Height == 0)
				return;

			//Get the points from the rectangle
			double x1 = r.X - this.CurveArea.X;
			double y1 = r.Y - this.CurveArea.Y;
			double x2 = x1+ r.Width;
			double y2 = y1 + r.Height;

			//Transform rectangle points into real values
			x1 = GraphTransform.InvTranslateX(x1);
			y1 = GraphTransform.InvTranslateY(y1);
			x2 = GraphTransform.InvTranslateX(x2);
			y2 = GraphTransform.InvTranslateY(y2);

			//If logarithmic x axis transform x values
			if(this.AxisTypeX == AxisType.LOG)
			{
				x1 = (double)Math.Pow(10,x1);
				x2 = (double)Math.Pow(10,x2);
			}

			//If logarithmic y axis transform y values
			if(this.AxisTypeY == AxisType.LOG)
			{
				y1 = (double)Math.Pow(10,y1);
				y2 = (double)Math.Pow(10,y2);
			}

			//If this chart has autoscale enabled disable it
			if(this.AutoScale)
				this.AutoScale = false;
			
			//Set the new axisrange
			this.AxisRangeX = new AxisData(x1,x2,Math.Abs(x2-x1)/5);
			this.AxisRangeY = new AxisData(y2,y1,Math.Abs(y1-y2)/5);
			
			//Redraw the control
			RedrawChart();
			

		}

		void RasterPaintStack()
		{
			while(rasterstack.Count > 0)
			{
				Point[] p = (Point[])rasterstack.Pop();
                ControlPaint.DrawSelectionFrame(this.CreateGraphics(), true, new Rectangle(p[0].X, p[0].Y, p[1].X - p[0].X, p[1].Y - p[0].Y), new Rectangle(p[0].X, p[0].Y, p[1].X - p[0].X, p[1].Y - p[0].Y), this.BackColor);
				//Debug.WriteLine("Popped " + pre[0] + pre[1] + " " + rasterstack.Count);
			}
		}

		void RasterPaintFrame(int x,int y,int xs, int ys)
		{
			Point p1 = new Point(xs,ys);
			Point p2 = new Point(x,y);

			p1 = this.PointToScreen(p1);
			p2 = this.PointToScreen(p2);

            ControlPaint.DrawSelectionFrame(this.CreateGraphics(), true, new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y),new Rectangle(p1.X -1 , p1.Y -1 , p2.X - p1.X + 1, p2.Y - p1.Y + 1), this.BackColor);
			
			rasterstack.Push(new Point[]{p1,p2});
			//Debug.WriteLine("Pushed " + p1 + p2 + " " + rasterstack.Count);			
		}




	}
}
