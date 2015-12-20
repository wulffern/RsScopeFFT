using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for LayerStack.
	/// </summary>
	internal class LayeredDrawGrid:ChControl
	{
		public LayeredDrawGrid()
		{
		}

		public DrawGrid this[int index]
		{
			get
			{
				if(this.Children[index] is DrawGrid)
					return (DrawGrid)this.Children[index];
				else
					return null;
			}
		}

		public int Add(DrawGrid gr)
		{			
			gr.Parent = this;
			return this.Children.Add(gr);
		}

		public int Length{get{return this.Children.Count;}}

		protected override void OnPaint(System.Drawing.Graphics g)
		{
			//Set Location and Size of ChControl and Paint it
			GraphicsContainer gc = g.BeginContainer();
			foreach(ChControl cc in this.Children)
			{
				cc.Location = new Point(0,0);
				cc.Size = new Size(this.Width,this.Height);
				cc.Paint(g);
			}
			g.EndContainer(gc);
		}

	}
}
