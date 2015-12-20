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
	/// Summary description for DrawPoints.
	/// </summary>
	internal class Points:DrawPlot
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public Points(double[] X, double[][] Y,string[] TitleY):base(X,Y,TitleY)
		{
		}

		/// <summary>
		/// Paints the control
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			base.OnPaint(g);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen myPen;
			for(int i=0;i<ScreenPoints.Length;i++)
			{
				PointF[] p = ScreenPoints[i];
				myPen = new Pen(this.GetColor(i),2);

				for(int j=0;j<p.Length;j++)
				{
					
					if(p[j].X >= 0 && p[j].X <= this.Width )
					{
						if(p[j].Y <= Height && p[j].Y >= 0 )
						{
							g.DrawEllipse(myPen,p[j].X,p[j].Y,2,2);
						}

					}
				}
			}
		}
	}
}
