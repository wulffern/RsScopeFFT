using System;
using System.Windows.Forms;
using System.Drawing;
using NextGenLab.Chart;

namespace Tester
{
	/// <summary>
	/// Summary description for ZoomControl.
	/// </summary>
	public class ZoomControl:NextGenLab.Chart.ChartControl
	{
		public ZoomControl()
		{
			first = true;
		}

		protected bool Zooming;
		Rectangle r;
		int xstart;
		int ystart;
		int x;
		int y;

		AxisData xOrig;
		AxisData yOrig;
		bool first;

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				Zooming = true;
				if(this.CurveArea.Contains(new Point(e.X,e.Y)))
				{
					xstart = e.X;
					ystart = e.Y;
					this.Invalidate();
				}

				this.Focus();
				
			}
			base.OnMouseDown (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(this.CurveArea.Contains(new Point(e.X,e.Y)))
			{
				x = e.X;
				y = e.Y;
				this.Invalidate();
			}
			
			base.OnMouseMove (e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(Zooming && r != Rectangle.Empty)
			{
				Zooming = false;
				ResizeAxis(r);
				
			}
			base.OnMouseUp (e);
		}

		private void ResizeAxis(Rectangle r)
		{
			if(r.Width == 0)
				return;
			if(r.Height == 0)
				return;

			double x1 = r.X - this.CurveArea.X;
			double y1 = r.Y - this.CurveArea.Y;
			double x2 = x1+ r.Width;
			double y2 = y1 + r.Height;

			x1 = GraphTransform.InvTranslateX(x1);
			y1 = GraphTransform.InvTranslateY(y1);
			x2 = GraphTransform.InvTranslateX(x2);
			y2 = GraphTransform.InvTranslateY(y2);

			if(this.AxisTypeX == AxisType.LOG)
			{
				x1 = Math.Pow(10,x1);
				x2 = Math.Pow(10,x2);
			}

			if(this.AxisTypeY == AxisType.LOG)
			{
				y1 = Math.Pow(10,y1);
				y2 = Math.Pow(10,y2);
			}
				
			this.AxisRangeX = new AxisData(x1,x2,Math.Abs(x2-x1)/5);
			this.AxisRangeY = new AxisData(y2,y1,Math.Abs(y1-y2)/5);
			
			
			Invalidate();
			

		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyData == Keys.Z)
			{
				this.AxisRangeX = xOrig;
				this.AxisRangeY = yOrig;
				this.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			
			base.OnPaint (e);

			if(first)
			{
				xOrig = this.AxisRangeX;
				yOrig = this.AxisRangeY;
				first = false;

			}
			if(Zooming)
			{
				r = new Rectangle(xstart,ystart,(x-xstart),(y-ystart));
				e.Graphics.DrawRectangle(Pens.Black,xstart,ystart, (x-xstart),( y-ystart));
			}
		}




	}
}
