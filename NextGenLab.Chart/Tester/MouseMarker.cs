using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tester
{
	/// <summary>
	/// Summary description for MouseMarker.
	/// </summary>
	public class MouseMarkerControl:ZoomControl
	{
		public MouseMarkerControl()
		{			
		}

		int x;
		int y;

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{

			base.OnMouseMove (e);
			if(!Zooming)
			{
				x = e.X;
				y = e.Y;
				Rectangle r = this.CurveArea;
				if(r.Contains(new Point(x,y)))
					this.Invalidate(this.CurveArea);
			}
		}


		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint (e);
			Rectangle r = this.CurveArea;
			Graphics g = e.Graphics;

			Pen p = new Pen(Color.Black);
			p.DashStyle = DashStyle.Dash;

			double dist = double.MaxValue;
			PointF pf;
			PointF[] points =  new PointF[this.ScreenPoints.Length];
			PointF[] real = new PointF[this.ScreenPoints.Length];
			for(int i=0;i<this.ScreenPoints.Length;i++)
			{
				dist = double.MaxValue;
				for(int j=0;j<this.ScreenPoints[i].Length;j++)
				{
					pf = this.ScreenPoints[i][j];
				
					if(dist > Math.Abs((r.X + pf.X)- x))
					{
						real[i] = this.RealPoints[i][j];
						points[i] = this.ScreenPoints[i][j];
						dist = Math.Abs((r.X + pf.X)- x);
					}                	
				}
			}
			
			
			float y = 0.0f;
			SizeF sf;
			PointF pr;
			for(int i=0;i<points.Length;i++)
			{
				pf = points[i];
				pr = real[i];
				p.Color = NextGenLab.Chart.Colors.GetColor(i);
				g.DrawLine(p,r.X + pf.X,r.Top,r.X + pf.X,r.Bottom);
				g.DrawLine(p,r.Left,r.Y + pf.Y,r.Right,r.Y + pf.Y);
				sf = g.MeasureString(pr.ToString(),Font);
				g.DrawString(pr.ToString(),Font,new SolidBrush(Color.FromArgb(200,p.Color)),r.X,r.Y+y);
				y += sf.Height;
			}

		}



	}
}
