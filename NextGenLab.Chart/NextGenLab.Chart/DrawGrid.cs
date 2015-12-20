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
	internal class DrawGrid:ChControl
	{	
		#region Private fields
		AxisType xAxisType;
		AxisType yAxisType;
		AxisData _Y;
		AxisData _X;
		Color majorline;
		Color minorline;
		Color gridline;
		Pen pen1;
		Pen pen2;
		PointF[][] screen_points;
		GraphMath gm;
		bool showzero;
		int _GridLinesXCount = 0;
		int _GridLinesYCount = 0;
		bool nogrid = false;
        
		#endregion

		#region Protected fields
		//protected PointF[][] Points;
		
		#endregion
		
		#region Properties
        
        public int GridLinesXCount{get{return _GridLinesXCount;}set{_GridLinesXCount = value;}}
		public int GridLinesYCount{get{return _GridLinesYCount;}set{_GridLinesYCount = value;}}
//		/// <summary>
//		/// Real world points
//		/// </summary>
//		public PointF[][] RealPoints{get{return Points;}}
//		/// <summary>
//		/// Screen points
//		/// </summary>
//		public PointF[][] ScreenPoints{get{return screen_points;}}
		/// <summary>
		/// AxisData for X axis
		/// </summary>
		public AxisData X{get{return _X;}set{_X = value;}}
		/// <summary>
		/// AxisData for Y axis
		/// </summary>
		public AxisData Y{get{return _Y;}set{_Y = value;}}

		public AxisData AxisRangeX{get{return X;}}
		public AxisData AxisRangeY{get{return Y;}}
		public AxisType AxisTypeX{get{return XAxisType;}}
		public AxisType AxisTypeY{get{return YAxisType;}}
			/// <summary>
			/// Base color for grid lines
			/// </summary>
			public Color GridColor{get{return gridline;}
			set
			{
				gridline = value;
				majorline = Color.FromArgb(50,gridline);
				minorline = Color.FromArgb(30,gridline);
			}
		}
		/// <summary>
		/// Type for X axis
		/// </summary>
		public AxisType XAxisType{get{return xAxisType;}set{xAxisType = value;}}
		/// <summary>
		/// Type for Y axis
		/// </summary>
		public AxisType YAxisType{get{return yAxisType;}set{yAxisType = value;}}
		/// <summary>
		/// GraphTransform contains functions needed to transform from
		/// "real" values to graphics points
		/// </summary>
		public GraphMath GraphTransform{get{return gm;}}

		/// <summary>
		/// Do not draw grid
		/// </summary>
		//public bool NoGrid{get{return nogrid;}set{nogrid = value;}}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cd">Chart Data</param>
		public DrawGrid(ChartDataList cds):base()
		{
			//Initialize fields
			this.X = cds.AxisRangeX;
			this.Y = cds.AxisRangeY;
			this.GridColor = Color.LightGray;

			xAxisType = cds.AxisTypeX;
			yAxisType = cds.AxisTypeY;

			//Check if were gonna do autoscale
			if(cds.AutoScale)
			{
				//Scale X values
				if(this.XAxisType == AxisType.LOG)
					this.X = GraphMath.TransformLogX(cds.AxisRangeX.Min,cds.AxisRangeX.Max);
				else
					this.X = GraphMath.AxisScale(cds.AxisRangeX);

				//Scale Y values
				if(this.YAxisType == AxisType.LOG)
					this.Y = GraphMath.TransformLogY(cds.AxisRangeY.Min,cds.AxisRangeY.Max);
				else
					this.Y = GraphMath.AxisScale(cds.AxisRangeY);
			}
			else
			{
				//Scale X values with axisdata for X as limiter
				if(this.XAxisType == AxisType.LOG)
					this.X = GraphMath.TransformLog(X,GraphMath.TransformLogX(cds.AxisRangeX.Min,cds.AxisRangeX.Max));
				else	
					if( ( (X.Max - X.Min) /X.Step ) >30) this.X = GraphMath.AxisScale(cds.AxisRangeX);

			
				//Scale Y values with axisdata for Y as limiter
				if(this.YAxisType == AxisType.LOG)
					this.Y = GraphMath.TransformLog(Y,GraphMath.TransformLogY(cds.AxisRangeY.Min,cds.AxisRangeY.Max));
				else
					if( ( (Y.Max - Y.Min) /Y.Step ) >30) this.Y = GraphMath.AxisScale(cds.AxisRangeY);
			}

            if (cds.Length > 0)
                showzero = cds[0].ShowZero;

		}

		public DrawPlot this[int index]
		{
			get
			{
				if(this.Children[index] is DrawPlot)
					return (DrawPlot)this.Children[index];
				else
					return null;
			}
		}

		public int Add(DrawPlot dp)
		{			
			dp.Parent = this;
			dp.MyGrid = this;
			return this.Children.Add(dp);
		}

		public int Length{get{return this.Children.Count;}}

		protected override void OnInit(Graphics g)
		{
			pen1 = new Pen(this.majorline);
			pen2 = new Pen(this.minorline);
			gm = new GraphMath(Size,this.X,this.Y);
			base.OnInit (g);
		}


		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
				GridLinesXCount = 0;
				GridLinesYCount = 0;

				#region Draw X Grid
				switch(XAxisType)
				{
						//Draw gridlines for linear axis
					case AxisType.LIN:
						double tmpXval = X.Min;
						while(tmpXval <= (X.Max + X.Step/2))
						{
							//Translate into screen coordinates
							float x = gm.TranslateX(tmpXval);

							//Draw gridline
							PointF p1 = new PointF((float)x,0);
							PointF p2 = new PointF((float)x,Height);
							g.DrawLine(pen1,p2,p1);

							//Increase tmpval
							tmpXval += X.Step;
						
							//Increase GridLines counter
							GridLinesXCount++;

						}
						break;

						//Draw gridlines for logarithmic axis
					case AxisType.LOG:
						for(int i = (int)X.Min; i < (int)X.Max+1;i++)
						{
							//Translate into screen coordinates;
							int x = (int)gm.TranslateX(i);

							//Draw main axis
							g.DrawLine(pen1,
								new PointF(x,0),
								new PointF(x,Height));
											
							//Draw intermediate axis
							if( i< X.Max)
							{
								for(int z=2;z<10;z++)
								{
									//Get intermediate value
									double xs = (double)Math.Log10(z) + i;

									//Translate into screen coordinates
									x = (int)gm.TranslateX(xs);

									g.DrawLine(pen2,
										new PointF(x,0),
										new PointF(x,Height));
								}
							}

							//Increase GridLines counter
							GridLinesXCount++;
						}
						break;
				}
				#endregion

				#region Draw Y Grid
				float y;
				switch(YAxisType)
				{
						//Draw gridlines for linear y axis
					case AxisType.LIN:
						double temp_y = Y.Min;
						while(temp_y <= (Y.Max + Y.Step/2))
						{
							//Translate into screen coordinates
							y = gm.TranslateY(temp_y);

							//Draw Grid lines
							g.DrawLine(pen1,
								new PointF(Width, y),
								new PointF(0, y));

							//Increase tmpval
							temp_y+= Y.Step;

							//Increase GridLines counter
							GridLinesYCount++;

						}
					
						//Draw GidLine for Zero
						if(showzero)
						{
							y = gm.TranslateY(0);
							g.DrawLine(pen1,
								new PointF(0,y),
								new PointF(Width,y));
						}
						break;

						//Draw gridlines for logarithmic y axis
					case AxisType.LOG:
						for(int i = (int)Y.Min; i < Y.Max+1;i++)
						{
							//Translate into screen coordinates
							y = gm.TranslateY(i);

							//Draw major line
							g.DrawLine(pen1,
								new PointF(0,y),
								new PointF(Width,y));
									
							//Draw minor lines
							if( i< Y.Max)
							{
								for(int z=2;z<10;z++)
								{
									//Get minor line position
									double ys = (double)Math.Log10(z) + i;

									//Translate into screen coordinates
									y = gm.TranslateY(ys);

									//Draw minor line
									g.DrawLine(pen2,
										new PointF(0,(float)y),
										new PointF(Width,(float)y));
								}
							}

							//Increase GridLines counter
							GridLinesYCount++;
						}
						break;
				}
				#endregion

			//Set Location and Size of ChControl and Paint it
			GraphicsContainer gc = g.BeginContainer();
			foreach(ChControl cc in this.Children)
			{
//				if(cc is DrawPlot)
//					((DrawPlot)cc).Initialize();
				cc.Location = new Point(0,0);
				cc.Size = new Size(this.Width,this.Height);
				cc.Paint(g);
			}
			g.EndContainer(gc);
			
		}

	}
}
