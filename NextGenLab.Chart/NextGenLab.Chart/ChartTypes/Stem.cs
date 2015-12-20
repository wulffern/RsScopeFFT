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
using System.Collections;

namespace NextGenLab.Chart.ChartTypes
{
	/// <summary>
	/// Stem Chart
	/// </summary>
	internal class Stem:DrawPlot
	{


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public Stem(double[] X, double[][] Y,string[] TitleY):base(X,Y,TitleY)
		{
		}

		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			//Draw grid
			base.OnPaint(g);

			//Init
			Pen myPen;
			PointF tmp;
			bool modifiedPoint;

			//Run through series
			for(int i=0;i<ScreenPoints.Length;i++)
			{
				//Init
				PointF[] p = ScreenPoints[i];
				myPen = new Pen(this.GetColor(i),1);

				//Run through points
				foreach(PointF pf in p)
				{
					//Get start point for stem
					double zero = MyGrid.GraphTransform.TranslateY(0.0f);
					if(MyGrid.Y.Min > 0)
						zero = MyGrid.GraphTransform.TranslateY(MyGrid.Y.Min);
					
					//Modify point if Y is below screen 0 or above screen height
					tmp = pf;
					modifiedPoint = false;
					if(pf.Y < 0)
					{
						tmp = new PointF(pf.X,0);
						modifiedPoint = true;
					}
					else if(pf.Y > Height)
					{
						tmp = new PointF(pf.X,Height);
						modifiedPoint = true;
					}

					//Draw point if X value is within bounds
					if(pf.X >= 0 && pf.X <= Width)
					{
						//Draw the Stem line
						g.DrawLine(myPen,new PointF(tmp.X,(float)zero),new PointF(tmp.X,tmp.Y));

						//Draw the circle if point is within bounds
						if(!modifiedPoint)
						{
							g.DrawEllipse(myPen,tmp.X-1,tmp.Y-1,2,2);
						}
					}

				}
			}
		}
	}
}
