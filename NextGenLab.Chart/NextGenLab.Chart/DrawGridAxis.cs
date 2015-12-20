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
using System.Text;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Decorate a grid with Axis values
	/// </summary>
	internal class DrawGridAxis:ChControl
	{
		DrawGrid gr;
		//LayeredDrawGrid lgr;
		int MarginBottom;
		int MarginLeft;
		int MarginTop;
		int MarginRight;
		SolidBrush sb;
		data[] xaxis;
		data[] yaxis;
        int numbdecimals = 2;


        public int NumberOfDecimals { get { return numbdecimals; } set { numbdecimals = value; } }

        /// <summary>
		/// constructor
		/// </summary>
		/// <param name="gr">DrawGrid control to decorate</param>
		public DrawGridAxis(DrawGrid gr)
		{
			this.gr = gr;
			this.Children.Add(gr);
			gr.Parent = this;
		}


		//Data for one gridline description
		struct data
		{
			public int Width;
			public int Height;
			public string Name;
			public double f;

			public int Ceiling(double f)
			{
				return (int)Math.Ceiling(f);
			}
		}

		protected override void OnInit(Graphics g)
		{
			//Initialize stuff
			sb = new SolidBrush(ForeColor);
			

			//Generate axislabels and calculate margins
			this.GenerateAxis(g);

			//Set size of DrawGrid
			gr.Size = new Size(Width - MarginLeft - MarginRight,Height - MarginBottom - MarginTop);
			base.OnInit (g);
		}

		/// <summary>
		/// Paint me
		/// </summary>
		/// <param name="g"></param>
		protected override void OnPaint(System.Drawing.Graphics g)
		{
			try
			{
				StringFormat xsf = new StringFormat();
				xsf.Alignment = StringAlignment.Center;
				StringFormat ysf = new StringFormat();
				ysf.Alignment = StringAlignment.Far;

				//Draw axislabels for X axis
				foreach(data d in xaxis)
				{
					//Check that the value is legal then draw
					if(!(double.IsInfinity(d.f) || double.IsNaN(d.f)))
						g.DrawString(d.Name,Font,sb,
							new RectangleF(
							new PointF((float)(MarginLeft + gr.GraphTransform.TranslateX((double)d.f) - d.Width/2),Height - MarginBottom+1),
							new SizeF(d.Width,MarginBottom)),xsf);
				}

				//Draw axislabels for Y axis
				foreach(data d in yaxis)
				{
					//Check that the value is legal then draw
					if(!(double.IsInfinity(d.f) || double.IsNaN(d.f)))
						g.DrawString(d.Name,Font,sb,
							new RectangleF(
							new PointF(0,(float)(MarginTop + gr.GraphTransform.TranslateY((double)d.f) - d.Height/2)),
							new SizeF(MarginLeft,d.Height)),ysf);
				}

			}
			catch{}

			//Paint DrawGrid
			GraphicsContainer gc = g.BeginContainer();
			gr.Location = new Point(MarginLeft,MarginTop);
			gr.Paint(g);
			g.EndContainer(gc);			
		}

		//Draw Axis labels
		private void GenerateAxis(Graphics g)
		{
			//Initialize variables
			data d;
			SizeF size;
			int maxwidth = int.MinValue;
			int maxheight = int.MinValue;
			double tmp = 0.0f;
			double tx = 0.0f;
			double ty = 0.0f;
			double dbl = 0.0f;
			int length = 0;
			int maxpower = 0;
			string postfix = "";
			double denum = 0;

			#region Make axislabels for X axis
			switch(gr.XAxisType)
			{
					//Generate axis labels for X axis
				case AxisType.LIN:
					//Get postfix and denumerator
					maxpower = GraphMath.MaxPower(gr.X.Max,gr.X.Min);
					GraphMath.GetPostfix(maxpower,out postfix, out denum);

					
					//Get number of steps
					length = 0;
					tmp = gr.X.Min;
					while(tmp < (gr.X.Max + gr.X.Step/2))
					{
						length++;
						if(length > 1000)
							break;
						tmp += gr.X.Step;
					}
					
					//Generated axis label
					xaxis = new data[length];
					tx = gr.X.Min;
					for(int i=0;i<length;i++)
					{
						//Init
						d = new data();

						//Adjust value and add postfix
                        d.Name = DoubleToString((double)(tx / denum)) + postfix;

                        //Get the screensize of the value
						size = g.MeasureString(d.Name,Font);
						if(maxheight < size.Height)
							maxheight = (int)Math.Ceiling(size.Height);
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);

						d.f = tx;
						
						//Save for later
						xaxis[i] = d;

						//Step
						tx += gr.X.Step;
					}
					break;

					//Make axislabel for logarithmic x axis
				case AxisType.LOG:
					//Get number of gridlines
					length = (int)Math.Ceiling((gr.X.Max+1) - gr.X.Min);

					//Make label
					xaxis = new data[length];
					for(int i= 0;i<length;i++)
					{
						//Get value;
						dbl = i + gr.X.Min;
						
						//Init
						d = new data();
						
						//Prettyfie the value
						d.Name = GraphMath.GetPrettyString(Math.Pow(10,dbl));

						//Measure Height of the value
						size = g.MeasureString(d.Name,Font);
						if(maxheight < size.Height)
							maxheight = (int)Math.Ceiling(size.Height);

						//Set width&Height
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);

						//Store value
						d.f = dbl;

						//Save for later
						xaxis[i] = d;
					}
					break;
			}
			#endregion


			#region Make axislabels for Y axis
			switch(gr.YAxisType)
			{
				case AxisType.LIN:
					
					//Make postfix and denummerator
					maxpower = GraphMath.MaxPower(gr.Y.Max,gr.Y.Min);
					GraphMath.GetPostfix(maxpower,out postfix, out denum);


					//Get number of steps
					length = 0;
					tmp = gr.Y.Min;
					while(tmp < (gr.Y.Max + gr.Y.Step/2))
					{
						length++;
						if(length > 1000)
							break;
						tmp += gr.Y.Step;
					}
					
					//Generate Axis
					bool zeroexist = false;
					yaxis = new data[length+1];
					ty = gr.Y.Min;
					for(int i=0;i<length;i++)
					{
						//Init
						d = new data();

						//Check if any of the values are zero
						if(ty == 0)
							zeroexist = true;

						//Adjust value and add postfix
                        d.Name = DoubleToString((double)(ty / denum)) + postfix;
                        d.f = (double)ty;

						//Get/set size
						size = g.MeasureString(d.Name,Font);
						if(maxwidth < size.Width)
							maxwidth = (int)Math.Ceiling(size.Width);
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);

						//Save for later
						yaxis[i] = d;

						//Step
						ty += gr.Y.Step;
					}
					
					//If there was a zero don't add zero line
					if(!zeroexist)
					{
						d = new data();
						d.Name = "0";
						size = g.MeasureString("0",Font);
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);
						d.f = 0;
						yaxis[yaxis.Length-1] = d;
					}
					else
					{
						d = new data();
						d.Name = "";
						size = g.MeasureString("",Font);
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);
						d.f = double.NaN;
						yaxis[yaxis.Length-1] = d;
					}
					break;

					//Make axislabels for logarithmic Y axis
				case AxisType.LOG:
					
					//Get Number of gridlines
					length = (int)Math.Ceiling((gr.Y.Max+1) - gr.Y.Min);

					//Make axislabels
					yaxis = new data[length];
					for(int i= 0;i<length;i++)
					{
						//Get value
						dbl = i + gr.Y.Min;

						//Initialize
						d = new data();

						//Prettyfy value
						d.Name = GraphMath.GetPrettyString(Math.Pow(10,dbl));
						d.f = (double)dbl;

						//Get/Set Size
						size = g.MeasureString(d.Name,Font);
						if(maxwidth < size.Width)
							maxwidth = (int)Math.Ceiling(size.Width);
						d.Width = d.Ceiling(size.Width);
						d.Height = d.Ceiling(size.Height);
						
						//Store
						yaxis[i] = d;
					}
					break;
			}
			#endregion

			//Set margins from calculated width and height of the axislabels
			this.MarginLeft = maxwidth;
			this.MarginBottom = maxheight;
	
			//Set the Right Margin
			if(xaxis != null)
			{
				if(xaxis.Length >0)
					this.MarginRight = (int)Math.Ceiling((double)xaxis[xaxis.Length-1].Width/2);
			}
            
			//Set the Left Margin
			if(yaxis != null)
			{
				if(yaxis.Length > 0)
                    this.MarginTop = (int)Math.Ceiling((double)yaxis[yaxis.Length - 1].Height / 2);
            }
			

		}

        int prevnumbdecimal = 2;
        StringBuilder dFormatString;

        string DoubleToString(double d)
        {
            if (prevnumbdecimal != numbdecimals || dFormatString == null)
            {
                dFormatString = new StringBuilder();
                dFormatString.Append("0.");
                for (int i = 0; i < numbdecimals; i++)
                {
                    dFormatString.Append("#");
                }
            }

            return d.ToString(dFormatString.ToString());
        }


    }
}
