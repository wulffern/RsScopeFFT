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
using System.Drawing.Drawing2D;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Draw Grid 
	/// </summary>
	internal class DrawPlot:ChControl
	{	
		#region Private fields
		PointF[][] screen_points;
		DrawGrid mygrid;
		SmoothingMode smoothmode = SmoothingMode.HighSpeed;
		Color[] colors = new Color[]{Color.Red,Color.Blue,Color.LightSeaGreen,Color.Indigo,Color.DeepSkyBlue};
		string[] TitleY = new string[0];
		double[] x;
		double[][] y;
		#endregion

		#region Protected fields
		protected PointF[][] Points;
		
		#endregion

		#region Properties
		/// <summary>
		/// Real world points
		/// </summary>
		public PointF[][] RealPoints{get{return Points;}}
		/// <summary>
		/// Screen points
		/// </summary>
		public PointF[][] ScreenPoints{get{return screen_points;}}
		public DrawGrid MyGrid{get{return mygrid;}set{mygrid = value;}}
		public SmoothingMode SmoothingMode{get{return smoothmode;}set{smoothmode = value;}}
		public Color[] Colors{get{return colors;}set{colors = value;}}
		public double[] X{get{return x;}}
		public double[][] Y{get{return y;}}
		#endregion

	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public DrawPlot(double[] X, double[][] Y,string[] TitleY):base()
		{
			this.x = X;
			this.y = Y;
			this.TitleY = TitleY;
			//Transform X and Y values into Points
			Points = new PointF[Y.Length][];
			for(int i=0;i<Points.Length;i++)
			{
				Points[i] = new PointF[Y[i].Length];
				for(int j=0;j<Y[i].Length;j++)
				{
					Points[i][j] = new PointF((float)X[j],(float)Y[i][j]);
				}
			}
			screen_points = new PointF[Points.Length][];
		}

//		public void Initialize()
//		{
//						
//		}

		protected override void OnInit(Graphics g)
		{
			//Translate real points into screen points
			for(int i=0;i<Points.Length;i++)
			{
				PointF[] p = Points[i];

				if(MyGrid.XAxisType == AxisType.LOG)
					p = MyGrid.GraphTransform.LogX(p);
				if(MyGrid.YAxisType == AxisType.LOG)
					p = MyGrid.GraphTransform.LogY(p);

				p = MyGrid.GraphTransform.Translate(p);
				screen_points[i] = p;
			}

			g.SmoothingMode = SmoothingMode;
			base.OnInit (g);
		}


		public string GetTitle(int index)
		{
			if(this.TitleY.Length > index)
				return this.TitleY[index];
			else
				return "";

		}

		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			
		}

		public Color GetColor(int i)
		{
			int index = i % Colors.Length;		
			return Colors[index];
        }

	}
}
