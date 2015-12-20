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

namespace NextGenLab.Chart.ChartTypes
{
	/// <summary>
	/// Summary description for Step.
	/// </summary>
	internal class Step:DrawPlot
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public Step(double[] X, double[][] Y,string[] TitleY):base(X,Y,TitleY)
		{
		}

		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			//Paint Grid
			base.OnPaint(g);

			//Init
			//g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen myPen;

			//Run through data series
			for(int i=0;i<ScreenPoints.Length;i++)
			{
				PointF[] p = ScreenPoints[i];
				myPen = new Pen(Color.FromArgb(250,this.GetColor(i)),1);

				for(int j=0;j<p.Length-1;j++)
				{
					PointF p1 = p[j];
					PointF p2 = p[j+1];
					
					//Check that we have legal Y values
					if(p1.X < p2.X && p1.X >= 0 && p1.X <= this.Width && p2.X >= 0 && p2.X <= Width)
					{
						float y1 = p1.Y;
						float y2 = p2.Y;

						if(y1 >= Height && y2 >= Height)
							continue;
						if(y1 < 0 && y2 < 0)
							continue;

						if(y1 >Height)
							y1 = Height;
						if(y1 < 0)
							y1 = 0;

						if(y2 > Height)
							y2 = Height;
						if(y2 < 0)
							y2 = 0;

						g.DrawLine(myPen,p1.X,y1,p2.X,y1);
						g.DrawLine(myPen,p2.X,y1,p2.X,y2);

					}
					
				}
			}
		}
	}
}
