using System;
using System.Drawing;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for DrawMarkerData.
	/// </summary>
	internal class DrawMarkerData:ChControl
	{
		ChControl cc;
		DecorateMarkers dm;
		
		public DrawMarkerData(ChControl cc,DecorateMarkers dm)
		{
			this.cc = cc;
			this.dm = dm;
			this.Children.Add(cc);
			this.cc.Parent = this;

		}

		protected override void OnPaint(System.Drawing.Graphics g)
		{
			double maxheight = DoPaint(g,false,0);
			cc.Size = new Size(Width,(int)Math.Ceiling(Height - maxheight));
			cc.Paint(g);
			DoPaint(g,true,Height - maxheight);
		}

		private double DoPaint(Graphics g, bool DoPaint,double y)
		{
			SizeF sf;
			double maxheight = 0.0f;
			double x =5.0f;
			double width = 5.0f;
			foreach(PointF pf in dm.Points)
			{
				sf = g.MeasureString(PointToString(pf),Font);
				if(maxheight < sf.Height)
					maxheight = (int)Math.Ceiling(sf.Height);
				width += (int)Math.Ceiling(sf.Width);
				if(width > Width)
				{
					y += maxheight;
					maxheight = 0.0f;
					x = 5.0f;
					width = 5.0f;
				}

				if(DoPaint)
					g.DrawString(PointToString(pf),Font,new SolidBrush(ForeColor),(float)x,(float)y);

				x += (int)Math.Ceiling(sf.Width);
			}
			return y;
		}

		private string PointToString(PointF p)
		{
			string s = p.X.ToString("0.##") + ":" + p.Y.ToString("0.##");
			return s;

		}

	}
}
