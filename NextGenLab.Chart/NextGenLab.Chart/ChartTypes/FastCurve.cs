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
	/// Draw fast curve. Can't do windowing
	/// </summary>
	internal class FastCurve:DrawPlot
	{

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public FastCurve(double[] X, double[][] Y,string[] TitleY):base(X,Y,TitleY)
		{
		}

		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			//Draw Grid
			base.OnPaint(g);

			g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen myPen;

			//Run through all series and draw
			for(int i=0;i<ScreenPoints.Length;i++)
			{
				PointF[] p = ScreenPoints[i];
				myPen = new Pen(this.GetColor(i),1);
				g.DrawLines(myPen,p);
			}
		}

	}
}
