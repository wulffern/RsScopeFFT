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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Collections;

namespace NextGenLab.Chart
{

	/// <summary>
	/// Structure for defining data needed for Chart
	/// </summary>
	[Serializable()]
	public struct ChartData
	{
		#region Private Fields
		double[] x;
		double[][] y;
        double[] z;
        double[] xmarkers;
		double[] ymarkers;
		AxisData adx;
		AxisData ady;
		AxisType atx;
		AxisType aty;
		string title;
		string titlex;
		string[] titlesy;
        string[] cptitlesy;
        string axislabelx;
		string axislabely;
		ChartType charttype;
		bool showzero;
		int _Width;
		int _Height;
		bool autoscale;
        bool showfullname;
		#endregion

		#region Properties
		/// <summary>
		/// Xvalue series
		/// </summary>
		public double[] X{get{return x;}set{x = value;}}
		/// <summary>
		/// Yvalues series
		/// </summary>
		public double[][] Y{get{return y;}set{y = value;}}

        public double[] Z { get { return z; } set { z = value; } }
        /// <summary>
		/// Max, Min and Step values for X grid
		/// </summary>
		public AxisData AxisRangeX{get{return adx;}set{adx = value;}}
		/// <summary>
		/// Max, Min and Step values for Y grid
		/// </summary>
		public AxisData AxisRangeY{get{return ady;}set{ady = value;}}
		/// <summary>
		/// Defines LOG or LIN for X axis
		/// </summary>
		public AxisType AxisTypeX{get{return atx;}set{atx = value;}}
		/// <summary>
		/// Defines LOG or LIN for Y axis
		/// </summary>
		public AxisType AxisTypeY{get{return aty;}set{aty = value;}}
		/// <summary>
		/// Title for plot
		/// </summary>
		public string Title{get{return title;}set{title = value;}}
		/// <summary>
		/// Titles for X axis
		/// </summary>
		public string TitleX{get{return titlex;}set{titlex = value;}}
		/// <summary>
		/// Titles for Y legened
		/// </summary>
		public string[] TitlesY{get{return titlesy;}set{titlesy =value;}}
		/// <summary>
		/// Label for X axis
		/// </summary>
		public string AxisLabelX{get{return axislabelx;}set{axislabelx = value;}}
		/// <summary>
		/// Label for Y axis
		/// </summary>
		public string AxisLabelY{get{return axislabely;}set{axislabely = value;}}
		/// <summary>
		/// Type of Chart to draw
		/// </summary>
		public ChartType ChartType{get{return charttype;}set{charttype = value;}}
		/// <summary>
		/// When markers are set the y values for this is extracted
		/// </summary>
		public double[] Xmarkers{get{return xmarkers;}set{xmarkers = value;}}
		/// <summary>
		/// When markers are set the x values for this is extracted
		/// </summary>
		public double[] Ymarkers{get{return ymarkers;}set{ymarkers = value;}}
		/// <summary>
		/// Show y=0 zero line
		/// </summary>
		public bool ShowZero{get{return showzero;}set{showzero = value;}}

		/// <summary>
		/// If true the axis are automatically scaled
		/// </summary>
		public bool AutoScale{get{return autoscale;}set{autoscale = value;}}

        public bool ShowFullNameLegend { get { return showfullname; } 
            set 
            { 
               
                showfullname = value;
                if (showfullname)
                {
                    if (cptitlesy != null)
                    {
                        if (titlesy.Length == cptitlesy.Length)
                        {
                            Array.Copy(cptitlesy, titlesy, titlesy.Length);
                        }

                    }
                }
                else
                {
                    if (titlesy != null)
                    {

                        cptitlesy = new string[titlesy.Length];
                        Array.Copy(titlesy, cptitlesy, titlesy.Length);

                        int index = -1;
                        for (int i = 0; i < titlesy.Length; i++)
                        {
                            if ((index = titlesy[i].LastIndexOf(".")) > -1)
                            {
                                titlesy[i] = titlesy[i].Substring(index+1);
                            }
                        }
                    }
                }

            } 
        }

        /// <summary>
		/// Only used in webservice!!
		/// </summary>
		public int Width{get{return _Width;}set{_Width = value;}}

		/// <summary>
		/// Only used in webservice!!
		/// </summary>
		public int Height{get{return _Height;}set{_Height = value;}}

		#endregion

		public ChartData Clone()
		{
			ChartData cd = new ChartData();
			cd.AxisTypeX = this.AxisTypeX;
			cd.AxisTypeY = this.AxisTypeY;
			cd.AxisRangeX = this.AxisRangeX;
			cd.AxisRangeY = this.AxisRangeY;
			cd.AxisLabelX = this.AxisLabelX;
			cd.AxisLabelY = this.AxisLabelY;
			cd.ChartType = this.ChartType;
			cd.Title = this.Title;
			cd.TitleX = this.TitleX;
			cd.TitlesY = this.TitlesY;
			cd.Xmarkers = this.Xmarkers;
			cd.Ymarkers = this.Ymarkers;
			cd.X = this.X;
			cd.Y = this.Y;
			cd.AutoScale = this.AutoScale;
			cd.ShowZero = this.ShowZero;
			cd.Width = this.Width;
			cd.Height = this.Height;
			return cd;
		}

		/// <summary>
		/// Get instance of ChartData with default values
		/// </summary>
		/// <returns>ChartDate with default values</returns>
		public static ChartData GetInstance()
		{
			ChartData cd = new ChartData();
			cd.AxisTypeX = AxisType.LIN;
			cd.AxisTypeY = AxisType.LIN;
			cd.ChartType = ChartType.Curve;
			cd.Title = "";
			cd.TitleX = "";
			cd.TitlesY = new string[]{};
			cd.AxisRangeX = new AxisData(0,1e-31,1e-31);
			cd.AxisRangeY = new AxisData(0,1e-31,1e-31);
			cd.AxisLabelX = "";
			cd.AxisLabelY = "";
			cd.Xmarkers = new double[]{};
			cd.Ymarkers = new double[]{};
			cd.X = new double[]{};
			cd.Y = new double[][]{};
			cd.AutoScale = false;
			cd.ShowZero = false;
			return cd;
		}

		/// <summary>
		/// Generate ChartData with default values. Autoscale axisrange for X and Y 
		/// arrays
		/// </summary>
		/// <param name="x">xvalue series</param>
		/// <param name="y">yvalues series</param>
		/// <returns>ChartData</returns>
		public static ChartData GetAutoScaleInstance(double[] x, double[][] y)
		{
			ChartData cd = GetInstance();
			cd.AxisRangeX = GraphMath.Transform(x);
			cd.AxisRangeY = GraphMath.Transform(y);
			cd.X = x;
			cd.Y = y;
			return cd;
		}


		public void Merge(ChartData cd)
		{
			if(cd.X.Length != this.X.Length)
				throw new MergeException("X values do not match!!");

			for(int i=0;i<this.X.Length;i++)
			{
				if(this.X[i] != cd.X[i])
				{
					throw new MergeException("X values do not match!!");
				}
			}

			double[][] newy = new double[this.Y.Length + cd.Y.Length][];
			int offset = 0;
			for(int i=0;i<this.Y.Length;i++)
			{
				newy[i] = this.Y[i];
				offset = i+1;
			}
			for(int i=0;i<cd.Y.Length;i++)
			{
				newy[i + offset] = cd.Y[i];
			}
			this.Y = newy;
			
			string[] newyt = new string[this.TitlesY.Length + cd.TitlesY.Length];
			offset = 0;
			for(int i=0;i<this.TitlesY.Length;i++)
			{
				newyt[i] = this.TitlesY[i];
				offset = i+1;
			}
			for(int i=0;i<cd.TitlesY.Length;i++)
			{
				newyt[offset + i] = cd.TitlesY[i];
			}
			this.TitlesY = newyt;
		}

        public bool IsOK()
        {
            bool okxaxis = false;
            for (int i = 0; i < this.x.Length; i++)
            {
                if (this.x[i].CompareTo(double.NaN) != 0)
                    okxaxis = true;
            }

            bool okyaxis = false;
            bool okyaxisx = false;
            for (int z = 0; z < this.y.Length; z++)
            {
                okyaxisx = false;
                for (int i = 0; i < this.y[z].Length; i++)
                {
                    if (this.y[z][i].CompareTo(double.NaN) != 0)
                        okyaxisx = true;
                }

                if (okyaxisx)
                    okyaxis = true;
            }

            return (okxaxis && okyaxis);

        }

        #region Convert methods
        /// <summary>
        /// Convert to XML
        /// </summary>
        /// <param name="s"></param>
        public void ToXML(Stream s)
		{
			
			XmlSerializer xs = new XmlSerializer(typeof(ChartData),"ngl.fysel.ntnu.no.chartdata");
			xs.Serialize(s,this);
		}

		/// <summary>
		/// Import from XML
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static ChartData FromXml(Stream s)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ChartData),"ngl.fysel.ntnu.no.chartdata");
			return (ChartData)xs.Deserialize(s);
		}

		/// <summary>
		/// Import from XML
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static ChartData FromXml(XmlReader xr)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ChartData),"ngl.fysel.ntnu.no.chartdata");
			return (ChartData)xs.Deserialize(xr);
		}

		/// <summary>
		/// Convert to HTML
		/// </summary>
		/// <param name="s"></param>
		public void ToHtml(Stream s)
		{
				//Reorder values
				double[][] d = new double[Y.Length +1][];
				d[0] = X;
				for(int i =1;i<Y.Length +1;i++)
				{
					d[i] = Y[i-1];
				}

				//Make header
				StringBuilder sr = new StringBuilder();
				sr.Append(@"<html><head><title>" + DateTime.Now + "</title></head>");
				sr.Append(@"<body onload='window.focus()'><table border=0 cellspacing=0
			style='font-family:verdana;font-size:10pt;' ><tr
			style='background-color:#cccccc;'><td>");

				//Print X Title
				if(this.TitleX != "")
					sr.Append(this.TitleX );
				else
					sr.Append("Xvalues");
				sr.Append("<td width=150>");

				//Print Y Titles
				for(int i=0;i<Y.Length;i++)
				{
					if(this.TitlesY.Length > i)
					{
						if(this.TitlesY[i] != "")
						{
							sr.Append(this.TitlesY[i]);
						}
						else
						{
							sr.Append("Y" + i );
						}
					}
					else
					{
						sr.Append("Y" + i);
					}
					sr.Append("<td width=150>");
				}
				sr.Append("<tr><td width=150>");

				//Print Values
				for(int i=0;i<X.Length;i++)
				{
					for(int z=0;z<d.Length;z++)
					{
						if(i < d[z].Length)
						{	
							sr.Append(d[z][i].ToString() + "\t");	
						}
						sr.Append("<td width=150>");
					}
					sr.Append("\r\n<tr><td width=150>");
				}

				//Print footer
				sr.Append("</table></body></html>");

				//Write to stream
				using(StreamWriter sw = new StreamWriter(s))
				{
					sw.Write(sr.ToString());
				}
			
		}

		
		#endregion
	}
}
