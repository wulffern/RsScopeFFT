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
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for MouseMarker.
	/// </summary>
	public class MouseMarkerControl:DragDropControl
	{

		#region Private Fields
		ChartTraceType tracetype;
		bool pickpoints = true;
		bool tracevalues = false;
		int x;
		int[] cindex = new int[0];
		int[][] markers = new int[2][];
		int markerindex = 0;
		//short runningindex = 0;
		Stack rasterstack = new Stack(3);
		#endregion

		#region Properties
		/// <summary>
		/// Trace type for Chart
		/// </summary>
		public ChartTraceType TraceType{get{return tracetype;}set{tracetype = value;}}
		/// <summary>
		/// Do Trace ?
		/// </summary>
		public bool PickPoints{get{return pickpoints;}set{pickpoints = value;}}
		/// <summary>
		/// Show Trace Values
		/// </summary>
		public bool TraceValues{get{return tracevalues;}set{tracevalues = value;}}
		#endregion

		/// <summary>
		/// Handler for new marker point
		/// </summary>
		public delegate void NewMarkerHandler(PointF[] real,string[] names,Color[] colors);
		/// <summary>
		/// Called when a marker is ste
		/// </summary>
		public event NewMarkerHandler NewMarker;

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public MouseMarkerControl()
		{		
			PickPoints = true;
			TraceType = ChartTraceType.Advanced;
		}
		#endregion

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			

			//Set marker
			if(e.Button == MouseButtons.Left && PickPoints)
			{
				if(!TraceValues)
					FindXIndexes();

				for(int i=0;i<cindex.Length;i++)
				{
					if(markers[markerindex] == null)
						markers[markerindex] = new int[cindex.Length];
					if(markers[markerindex].Length != cindex.Length)
						markers[markerindex] = new int[cindex.Length];

					//cindex is the current index of current trace value
					markers[markerindex][i] = cindex[i];

				}
				

				//Toggle between first and second marker
				if(markerindex == 0)
					markerindex = 1;
				else
					markerindex = 0;
				
				ArrayList realtmp = new ArrayList();
				ArrayList titles = new ArrayList();
				ArrayList colors = new ArrayList();
				DrawPlot dp;
				for(int j=0;j<this.DrawnPlots.Length;j++)
				{
					dp = DrawnPlots[j];
					//Scan through the real points and find the correct values
					//PointF[] real = new PointF[dp.RealPoints.Length];
					for(int i = 0;i<dp.RealPoints.Length;i++)
					{
						//Check that screenpoint_h is with the current point array
						if(cindex[j] > 0 && cindex[j] < dp.RealPoints[i].Length)
						{
							realtmp.Add(dp.RealPoints[i][cindex[j]]);
							titles.Add(dp.GetTitle(i));
							colors.Add(dp.GetColor(i));
						}
					}
				}

				try
				{
					//Fire event if anybody is listening
					if(NewMarker != null)
						NewMarker(
							(PointF[])realtmp.ToArray(typeof(PointF)),
							(string[])titles.ToArray(typeof(string)),
							(Color[])colors.ToArray(typeof(Color))
							);
				}
				catch{}

				if(!TraceValues)
				{
					RedrawChart();
				}

			}

			//Do parent stuff (Zooming)
			base.OnMouseDown (e);
		}

		/// <summary>
		/// Record mouse position
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			//Do parent stuff (Zooming)
			base.OnMouseMove (e);

			//Record mouse position if were not zooming and trace is enabled
			if(!Zooming && PickPoints )
			{
				x = e.X;
				Rectangle r = this.CurveArea;

				if(r.Contains(new Point(e.X,e.Y)))
				{
					if(TraceValues)
					{
						this.RedrawChart();
					}
					else
					{
						RasterPaintStack();
						RasterPaintLine(x,r.Top,r.Bottom);
					}
				}

				
			}
		}

		/// <summary>
		/// PaintMe
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			//If the control is redrawn pop the raster stack
			while(rasterstack.Count > 0)
				rasterstack.Pop();

			//Do parent stuff (Zooming)
			base.OnPaint (e);

			//Skip rest if trace is not enabled
			if(!PickPoints)
				return;

			//Init
			Graphics g = e.Graphics;
			Pen p = new Pen(Color.Black);
			Rectangle r = this.CurveArea;
			
			//Paint Markers
			PaintMarkers(g);
		

			//Paint values if enabled
			if(!TraceValues)
			{
				//p.Color = Color.FromArgb(50,this.Colors[0]);
				//g.DrawLine(p,x ,r.Top,x,r.Bottom);
			}
			else
			{
				FindXIndexes();
				PaintTrace(g);
			}
			
		}

		void PaintMarkers(Graphics g)
		{
			DrawPlot dp;
			Pen p = new Pen(Color.Black);
			Rectangle r = this.CurveArea;
			int[] mark;
			//Paint markers in each series
			for(int z=0;z<markers.Length;z++)
			{
				mark = markers[z];
				if(mark == null)
					continue;
				if(mark.Length != this.DrawnPlots.Length)
					continue;

				for(int j=0;j<this.DrawnPlots.Length;j++)
				{
					dp = DrawnPlots[j];
					for(int i=0;i<dp.ScreenPoints.Length;i++)
					{
						if(mark[j] >0 && mark[j] < dp.ScreenPoints[i].Length)
						{
							PointF psf = dp.ScreenPoints[i][mark[j]];
							p.Color = dp.GetColor(i);
							psf = new PointF(psf.X + r.X,psf.Y+ r.Y);
							g.DrawLine(p,psf.X,psf.Y-5,psf.X,psf.Y + 5);
							g.DrawLine(p,psf.X - 5,psf.Y,psf.X + 5,psf.Y);
							//g.DrawString((z+1).ToString(),Font,Brushes.Black,psf.X-2,this.CurveArea.Top);
						}
					}
				}
			}

		}

		void FindXIndexes()
		{
			Pen p = new Pen(Color.Black);
			Rectangle r = this.CurveArea;
			DrawPlot dp;
			//Run through the X values and find the point closest to the cursor
			double dist = double.MaxValue;
			double tmpx = 0;
			cindex = new int[this.DrawnPlots.Length];
			for(int j=0;j<this.DrawnPlots.Length;j++)
			{
				dp = DrawnPlots[j];
				tmpx = 0;
				dist = double.MaxValue;
				for(int i=0;i<dp.X.Length;i++)
				{
					//Transform mouse position into real value
					tmpx = this.GraphTransform.InvTranslateX(x - r.X);

					//If logarithmic axis take the power to get correct value
					if(this.Grid.AxisTypeX == AxisType.LOG)
						tmpx = Math.Pow(10,tmpx);
					
				
					//Calculate the distance between real x and converted mouse position and store
					//if it is less than the previous
					if(dist > Math.Abs(tmpx - dp.X[i]))
					{
						cindex[j] = i;
						dist = Math.Abs(tmpx - dp.X[i]);
					}
				}
			}
		}

		void PaintTrace(Graphics g)
		{
			//Init
			PointF pf;
			PointF pr;
			double y= 0.0f;
			SizeF sf;
			DrawPlot dp;
			Pen p = new Pen(Color.Black);
			Rectangle r = this.CurveArea;

			for(int j=0;j<this.DrawnPlots.Length;j++)
			{
				dp = DrawnPlots[j];
				//Run through screenpoints series and paint the current values
				for(int i=0;i<dp.ScreenPoints.Length;i++)
				{
					//Only paint the value if the screen and real points at cindex exist
					if(cindex[j] < dp.ScreenPoints[i].Length && dp.RealPoints[i].Length== dp.ScreenPoints[i].Length)
					{
						//Get the real and screen points
						pf = dp.ScreenPoints[i][cindex[j]];
						pr = dp.RealPoints[i][cindex[j]];

						//Get the color for the current series
						p.Color = dp.GetColor(i);

						//Transform the screen point is painted correctly
						pf = new PointF(r.Left + pf.X,r.Top + pf.Y);

						//Paint the Trace according to type
						switch(TraceType)
						{
							case ChartTraceType.Lines:
								g.DrawLine(p,pf.X,r.Top,pf.X,r.Bottom);
								g.DrawLine(p,r.Left,pf.Y,r.Right,pf.Y);
								break;
							case ChartTraceType.Cross:
								g.DrawLine(p,pf.X,pf.Y-5,pf.X,pf.Y + 5);
								g.DrawLine(p,pf.X - 5,pf.Y,pf.X + 5,pf.Y);
								break;
							case ChartTraceType.Dot:
								g.DrawEllipse(p,pf.X-2,pf.Y-2,4,4);
								break;
							case ChartTraceType.Advanced:
								g.DrawLine(p,pf.X,pf.Y-5,pf.X,pf.Y + 5);
								g.DrawLine(p,pf.X - 5,pf.Y,pf.X + 5,pf.Y);

								g.DrawLine(p,pf.X,r.Bottom -5,pf.X,r.Bottom + 5);
								g.DrawLine(p,r.Left - 5,pf.Y,r.Left + 5,pf.Y);
								break;
						}
						
						
						sf = g.MeasureString(pr.ToString(),Font);
						g.DrawString(pr.ToString(),Font,new SolidBrush(Color.FromArgb(200,p.Color)),(float)r.X,(float)(r.Y+y));
						y += sf.Height;
					}
				}
			}

		}
		void RasterPaintStack()
		{
			while(rasterstack.Count > 0)
			{
				Point[] pre = (Point[])rasterstack.Pop();
				ControlPaint.DrawReversibleLine(pre[0],pre[1],this.BackColor);
				//Debug.WriteLine("Popped " + pre[0] + pre[1] + " " + rasterstack.Count);
			}
		}

		void RasterPaintLine(int x,int top, int bottom)
		{
			Point p1 = new Point(x,top);
			Point p2 = new Point(x,bottom);

			p1 = this.PointToScreen(p1);
			p2 = this.PointToScreen(p2);
			
			ControlPaint.DrawReversibleLine(p1,p2,this.BackColor);
			
			rasterstack.Push(new Point[]{p1,p2});
			//Debug.WriteLine("Pushed " + p1 + p2 + " " + rasterstack.Count);			
		}

	}
}
