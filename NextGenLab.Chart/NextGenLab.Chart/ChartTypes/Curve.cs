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

namespace NextGenLab.Chart.ChartTypes
{
	/// <summary>
	/// Draw a curve
	/// </summary>
	internal class Curve:DrawPlot
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
	    protected int pen_width = 1;
		public Curve(double[] X, double[][] Y,string[] TitleY):base(X,Y,TitleY)
		{
			
		}

		/// <summary>
		/// Paints the control
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			//Paint Grid
			base.OnPaint(g);
			Pen myPen;
			

			//Run through all y series
			for(int i=0;i<ScreenPoints.Length;i++)
			{
				PointF[] p = ScreenPoints[i];
				myPen = new Pen(this.GetColor(i),pen_width);

				//Run through all points and try to draw
				for(int j=0;j<p.Length-1;j++)
				{
					PointF p1 = p[j];
					PointF p2 = p[j+1];
					
					//Check that the points are within legal bounds
					if(p1.X < p2.X && p1.X >= 0 && p1.X <= this.Width && p2.X >= 0 && p2.X <= Width)
					{
						if(p1.Y <= Height && p1.Y >= 0 && p2.Y <= Height && p2.Y >=0)
						{
							g.DrawLine(myPen,p1,p2);
						}
					}
				}
			}
		}

	}
}
