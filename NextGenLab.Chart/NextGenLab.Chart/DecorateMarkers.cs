using System;
using System.Drawing;
using System.Collections;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for DecorateMarkers.
	/// </summary>
	internal class DecorateMarkers:DecorateChControlBase
	{
		double[] xmarkers;
		double[] ymarkers;
		
		ArrayList points;

		public PointF[] Points{get{return (PointF[])points.ToArray(typeof(PointF));}}

		public DecorateMarkers(DrawGrid gr, ChartData cd):base(gr)
		{
			xmarkers = cd.Xmarkers;
			ymarkers = cd.Ymarkers;
			points = new ArrayList();

			foreach(PointF[] pf in gr.RealPoints)
			{
				for(int i=0;i<pf.Length;i++)
				{
					for(int j=0;j<xmarkers.Length;j++)
					{
						if( pf[i].X == xmarkers[j])
						{
							points.Add(pf[i]);
						}
					}

					for(int j=0;j<ymarkers.Length;j++)
					{
						if( pf[i].Y == ymarkers[j])
						{
							points.Add(pf[i]);
						}

					}
				}
			}	
		}

		protected override void OnPrePaint(ChControl cc, Graphics g)
		{

		}


		protected override void OnPostPaint(ChControl cc,Graphics g)
		{
			DrawGrid gr = cc as DrawGrid;
			if(gr != null)
			{
				foreach(PointF p in points)
				{
					DrawMarker(gr,g,p);
				}
			}
			
		}

		private void DrawMarker(DrawGrid gr, Graphics g,PointF p)
		{
			float x;
			float y;
			x = p.X;
			y = p.Y;

			if(gr.XAxisType == AxisType.LOG)
				x = (float)Math.Log10(x);
			if(gr.YAxisType == AxisType.LOG)
				y = (float)Math.Log10(y);

			x = gr.GraphTransform.TranslateX(x);
			y = gr.GraphTransform.TranslateY(y);

			if(!(double.IsNaN(x) || double.IsInfinity(x) || double.IsInfinity(y) || double.IsNaN(y)))
			{
				g.DrawLine(Pens.Black,x -2,y,x+2,y);
				g.DrawLine(Pens.Black,x,y-2,x,y+2);
			}

		}


	}
}
