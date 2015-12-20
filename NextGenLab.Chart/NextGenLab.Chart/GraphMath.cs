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

namespace NextGenLab.Chart
{
	/// <summary>
	/// Support functions for drawing Chart
	/// </summary>
	public class GraphMath
	{
		Size Size;
		double xScaleFactor;
		double yScaleFactor;
		AxisData Xd;
		AxisData Yd;

		/// <summary>
		/// Create a GraphMath object. Used to transform from "real" values to
		/// control points
		/// </summary>
		/// <param name="Size">Size of graphics object to draw on</param>
		/// <param name="X">AxisData for X axis</param>
		/// <param name="Y">AxisData for Y axis</param>
		public GraphMath(Size Size,AxisData X, AxisData Y)
		{
			this.Size = Size;
			this.Xd = X;
			this.Yd = Y;

			//Calculate scalefactors to convert from real points to screen points
			this.xScaleFactor = ((double)this.Size.Width)/(Xd.Max - Xd.Min);
			this.yScaleFactor  =  ((double)this.Size.Height)/(Yd.Max - Yd.Min);
		}

		/// <summary>
		/// Translate x value from "real" to screen value
		/// </summary>
		/// <param name="X">"real" x value</param>
		/// <returns>control x value</returns>
		public float	TranslateX(double X)
		{
			X = 0 + ((X*(double)this.xScaleFactor)) - ((double)Xd.Min * (double)this.xScaleFactor);
			return (float)X;
		}

		/// <summary>
		/// Translate y value from "real" to screen value
		/// </summary>
		/// <param name="Y">"real" y value</param>
		/// <returns>control y value</returns>
		public float	TranslateY(double Y)
		{
			Y = Size.Height-((Y -Yd.Min) * this.yScaleFactor);
			return (float)Y;
		}

		
		/// <summary>
		/// Translate x value from screen to real value
		/// </summary>
		/// <param name="X">"real" x value</param>
		/// <returns>control x value</returns>
		public double	InvTranslateX(double X)
		{
			return (X + (double)Xd.Min*(double)xScaleFactor)/(double)xScaleFactor;
		}

		/// <summary>
		/// Translate y value from screen to real value
		/// </summary>
		/// <param name="Y">"real" y value</param>
		/// <returns>control y value</returns>
		public double	InvTranslateY(double Y)
		{
			Y  = (Y - Size.Height)/(-yScaleFactor) + (double)Yd.Min;
			return Y;
		}


		/// <summary>
		/// Translate a set of points from "real" to screen points
		/// </summary>
		/// <param name="points">"real" points</param>
		/// <returns>control points</returns>
		public PointF[] Translate(PointF[] points)
		{
			PointF[] p = new PointF[points.Length];
			for(int i=0;i<points.Length;i++)
			{
				p[i] = new PointF(TranslateX(points[i].X),TranslateY(points[i].Y));
			}
			return p;
		}


		/// <summary>
		/// Transform points from linear X axis to logarhitmic X axis
		/// </summary>
		/// <param name="points">linear x axis points</param>
		/// <returns>logarithmic x axis points</returns>
		public PointF[] LogX(PointF[] points)
		{
			PointF[] p = new PointF[points.Length];
			for(int i=0;i<points.Length;i++)
			{
				double x = points[i].X;

				//Don't draw the point if the logarithm will fail
				if(x <= 0)
				{
					p[i] = new PointF(float.NaN,float.NaN);
				}
				else
				{
					p[i] = new PointF((float)Math.Log10(x),points[i].Y);	
				}
			}
			return p;
		}

		/// <summary>
		/// Transform points from linear Y axis to logarithmic axis
		/// </summary>
		/// <param name="points">linear y axis points</param>
		/// <returns>logartihmic y axis points</returns>
		public PointF[] LogY(PointF[] points)
		{
			PointF[] p = new PointF[points.Length];
			for(int i=0;i<points.Length;i++)
			{
				double y = points[i].Y;

				//Don't draw the point if the logarithm will fail
				if(y <= 0)
				{
					p[i] = new PointF(float.NaN,float.NaN);

				}
				else
				{
					p[i] = new PointF(points[i].X,(float)Math.Log10(y));
				}
			}
			return p;
		}

		/// <summary>
		/// Calculates prefix of a number from yocto(1e-24) to yotta(1e24)
		/// </summary>
		/// <param name="axis_val_temp">Value to compute prefix of</param>
		/// <returns>Pretty print string </returns>
		public static string GetPrettyString(double  axis_val_temp)
		{
			
			double axis_val_adjusted;
			string axis_val_label;
			if(axis_val_temp==0) { axis_val_adjusted=0; axis_val_label="";}
				
			double pos_neg=1;
				
			if(axis_val_temp < 0) {axis_val_temp*=-1; pos_neg=-1;}
	
			if(axis_val_temp == 0)
			{
				axis_val_adjusted = 0;
				axis_val_label=  "";

			}
			else if(axis_val_temp >= 1e24)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-24)/10; 
				axis_val_label=  "Y";
			} // yotta = 1e24
			else if	(axis_val_temp >= 1e21) 
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-21)/10; 
				axis_val_label=  "Z";
			} // zetta = 1e21
			else if	(axis_val_temp >= 1e18)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-18)/10; 
				axis_val_label=  "E";
			} // exa   = 1e18
			else if	(axis_val_temp >= 1e15)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-15)/10; 
				axis_val_label=  "P";
			} // peta  = 1e15
			else if	(axis_val_temp >= 1e12)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-12)/10; 
				axis_val_label=  "T";
			} // tera  = 1e12
			else if (axis_val_temp >= 1e9)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-9)/10;  
				axis_val_label=  "G";
			} // giga  = 1e9
			else if (axis_val_temp >= 1e6)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-6)/10;  
				axis_val_label=  "M";
			} // mega  = 1e6
			else if (axis_val_temp >= 1e3)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e-3)/10; 
				axis_val_label=  "k";
			} // kilo  = 1e3
			else if (axis_val_temp >= 1)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp)/10;	   
				axis_val_label=  "";
			}     
			else if (axis_val_temp >= 1e-3)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e3)/10;   
				axis_val_label=  "m";
			} // milli = 1e-3
			else if (axis_val_temp >= 1e-6)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e6)/10;   
				axis_val_label=  "µ";
			} // micro = 1e-6
			else if (axis_val_temp >= 1e-9)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e9)/10;   
				axis_val_label=  "n";
			} // nano  = 1e-9
			else if (axis_val_temp >= 1e-12)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e12)/10;  
				axis_val_label=  "p";
			} // pico  = 1e-12
			else if (axis_val_temp >= 1e-15)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e15)/10; 
				axis_val_label=  "f";
			} // femto = 1e-15
			else if (axis_val_temp >= 1e-18)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e18)/10;  
				axis_val_label=  "a";
			} // atto  = 1e-18
			else if (axis_val_temp >= 1e-21)
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e21)/10;  
				axis_val_label=  "z";
			} // zepto = 1e-21
			else 
			{
				axis_val_adjusted = Math.Round(10*pos_neg*axis_val_temp*1e24)/10;  
				axis_val_label=  "y";
			} // yocto = 1e-24
			return axis_val_adjusted.ToString("#.##")  + axis_val_label;
		}

		/// <summary>
		/// Calculates prefix and denumerator of a power from yocto(1e-24) to yotta(1e24)
		/// </summary>
		/// <param name="axis_val_temp">Power</param>
		public static void GetPostfix(int  power, out string axis_val_label, out double axis_val_adjusted)
		{
			
			double axis_val_temp = Math.Pow(10,power);
			if(axis_val_temp==0) { axis_val_adjusted=0; axis_val_label="";}
				
			double pos_neg=1;
				
			if(axis_val_temp < 0) {axis_val_temp*=-1; pos_neg=-1;}
	
			if(axis_val_temp == 0)
			{
				axis_val_adjusted = 1;
				axis_val_label=  "";

			}
			else if(axis_val_temp >= 1e24)
			{
				axis_val_adjusted = 1e24; 
				axis_val_label=  "Y";
			} // yotta = 1e24
			else if	(axis_val_temp >= 1e21) 
			{
				axis_val_adjusted = 1e21; 
				axis_val_label=  "Z";
			} // zetta = 1e21
			else if	(axis_val_temp >= 1e18)
			{
				axis_val_adjusted = 1e18; 
				axis_val_label=  "E";
			} // exa   = 1e18
			else if	(axis_val_temp >= 1e15)
			{
				axis_val_adjusted = 1e15; 
				axis_val_label=  "P";
			} // peta  = 1e15
			else if	(axis_val_temp >= 1e12)
			{
				axis_val_adjusted = 1e12; 
				axis_val_label=  "T";
			} // tera  = 1e12
			else if (axis_val_temp >= 1e9)
			{
				axis_val_adjusted = 1e9;  
				axis_val_label=  "G";
			} // giga  = 1e9
			else if (axis_val_temp >= 1e6)
			{
				axis_val_adjusted = 1e6;  
				axis_val_label=  "M";
			} // mega  = 1e6
			else if (axis_val_temp >= 1e3)
			{
				axis_val_adjusted = 1e3; 
				axis_val_label=  "k";
			} // kilo  = 1e3
			else if (axis_val_temp >= 1)
			{
				axis_val_adjusted = 1;	   
				axis_val_label=  "";
			}     
			else if (axis_val_temp >= 1e-3)
			{
				axis_val_adjusted = 1e-3;   
				axis_val_label=  "m";
			} // milli = 1e-3
			else if (axis_val_temp >= 1e-6)
			{
				axis_val_adjusted = 1e-6; 
				axis_val_label=  "µ";
			} // micro = 1e-6
			else if (axis_val_temp >= 1e-9)
			{
				axis_val_adjusted = 1e-9;
				axis_val_label=  "n";
			} // nano  = 1e-9
			else if (axis_val_temp >= 1e-12)
			{
				axis_val_adjusted = 1e-12;
				axis_val_label=  "p";
			} // pico  = 1e-12
			else if (axis_val_temp >= 1e-15)
			{
				axis_val_adjusted = 1e-15;
				axis_val_label=  "f";
			} // femto = 1e-15
			else if (axis_val_temp >= 1e-18)
			{
				axis_val_adjusted = 1e-18; 
				axis_val_label=  "a";
			} // atto  = 1e-18
			else if (axis_val_temp >= 1e-21)
			{
				axis_val_adjusted = 1e-21; 
				axis_val_label=  "z";
			} // zepto = 1e-21
			else 
			{
				axis_val_adjusted = Math.Pow(10,power); 
				axis_val_label=  "e" + power;
			} // yocto = 1e-24
			//return  axis_val_label;
		}

		/// <summary>
		/// Gets the power of a double
		/// </summary>
		/// <param name="val">double value</param>
		/// <returns>power of the double</returns>
		public static int Power(double val)
		{
            if (double.IsInfinity(val) || double.IsNaN(val))
                return 0;

			int d=-31;
			double tmp;
			while(true)
			{
				if(val == 0.0)
				{
					break;
				}
				tmp = Math.Abs(val)/Math.Pow(10,d);
				if(tmp > 0 && tmp <10)
					break;
				d++;
				if(d > 31)
					break;
			}
			return d;
		}

		/// <summary>
		/// Gets the maximum power of two double values
		/// </summary>
		/// <param name="val1">double 1</param>
		/// <param name="val2">double 2</param>
		/// <returns>maximum power</returns>
		public static int MaxPower(double val1, double val2)
		{
			int pow_max = Power(val1);
			int pow_min = Power(val2);

			int t = pow_max > pow_min ? pow_max:pow_min;
			return t;
		}

		/// <summary>
		/// Returns sensible max, min and step value for a certain max and min input
		/// </summary>
		/// <param name="ad">AxisData</param>
		/// <returns>AxisData</returns>
		public static AxisData	AxisScale(AxisData ad)
		{
			//Don't do anything if the values are fubar
			if(double.IsNaN(ad.Max) || double.IsInfinity(ad.Max)||double.IsNaN(ad.Min) || double.IsInfinity(ad.Min))
			{
				return ad;
			}

			//Make sure that Max != Min
			if(ad.Max == ad.Min)
			{
				if(ad.Max == 0)
				{
					ad.Max += 0.5;
					ad.Min -= 0.5;
				}
				else
				{
					ad.Max += Math.Pow(10,Power(ad.Max))*0.5;
					ad.Min -= Math.Pow(10,Power(ad.Max))*0.5;
				}
					
			}
			
			//Get maximum power
			int t = MaxPower(ad.Max,ad.Min);

			//Get the 1eMaxPower
			double pow = Math.Pow(10,t);
			
			//Scale maximum up to closest mantisse
			double temp_min = pow * Math.Floor(ad.Min / pow);

			//Scale minimum down to closest mantisse
			double temp_max = pow * Math.Ceiling(ad.Max / pow);

			//If min and max is equal add 1 to max
			if(temp_min == temp_max)
				temp_max += 1;

			//Calculate the range of mantisse's
			double tmp = Math.Abs(temp_max/pow - temp_min/pow);

			//Try with step 1eMaxPower
			double temp_step =  1 * pow;
			
			//Scale step according to the range of mantisse's
			if ( tmp < 2)
			{
				temp_step = 0.2 * pow;
			}
			else if(tmp < 5)
			{
				temp_step =  0.5 * pow;
			}
			else if (tmp > 10)
			{
				temp_step = 2 * pow;
			}			

			//Set max, min, step and return
			ad.Max = temp_max;
			ad.Min = temp_min;
			ad.Step = temp_step;
			return ad;
		}


		public static AxisData GetMaxMinLog(double[] f)
		{
			//Init axisdata
			AxisData ad = new AxisData(double.MaxValue,double.MinValue,double.MinValue);

			//Get max and min from data
			for(int i =0;i<f.Length;i++)
			{
				if(!double.IsInfinity(f[i]) && !double.IsNaN(f[i]) &&f[i] > 0)
				{
					if(f[i] < ad.Min)
						ad.Min = f[i];
					if(f[i] > ad.Max)
						ad.Max = f[i];
				}
			}

			//If max is not found set to 10
			if(ad.Max == double.MinValue)
				ad.Max = 10;

			//if max is not found set to 1
			if(ad.Min == double.MaxValue)
				ad.Min = 1;
			
			return ad;
		}

		/// <summary>
		/// Get sensible max, min and step for logarithmic X axis
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static AxisData TransformLogX(double[] f)
		{
			AxisData ad = GetMaxMinLog(f);
			return TransformLogX(ad.Max,ad.Min);
		}

		public static AxisData TransformLogX(double Min, double Max)
		{
			
			//Get the power of minimum
			double pow_min = Power(Min);

			//Get the power of maximum
			double pow_max = Power(Max)+1;

			return new AxisData(pow_min,pow_max,1);
		}

		/// <summary>
		/// Get sensible max, min and step for logarithmic Y axis
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static AxisData TransformLogY(double[][] f)
		{
			
			AxisData ad = GetMaxMinLog(f);
			return TransformLogY(ad.Min,ad.Max);			
		}

		public static AxisData GetMaxMinLog(double[][] f)
		{
			//Init axisdata
			AxisData ad = new AxisData(double.MaxValue,double.MinValue,double.MinValue);

			//Get max and min from data
			for(int i =0;i<f.Length;i++)
			{
				for(int j=0;j<f[i].Length;j++)
				{
					if(!double.IsInfinity(f[i][j]) && !double.IsNaN(f[i][j]) && f[i][j] > 0)
					{
						if(f[i][j] < ad.Min)
							ad.Min = f[i][j];

						if(f[i][j] > ad.Max)
							ad.Max = f[i][j];
					}
				}
			}

			//If max is not found set to 10
			if(ad.Max == double.MinValue)
				ad.Max = 10;

			//if max is not found set to 1
			if(ad.Min == double.MaxValue)
				ad.Min = 1;
			return ad;
		}

		public static AxisData TransformLogY(double Min, double Max)
		{
			//Get the power of minimum
			double pow_min = Power(Min);

			//Get the power of maximum + 1
			double pow_max = Power(Max)+1;

			return new AxisData(pow_min,pow_max,1);
		}

		/// <summary>
		/// Transform AxisData from linear axis to logarithmic axis
		/// </summary>
		/// <param name="ad">linear AxisData</param>
		/// <param name="auto">logarithmic autoscaled axisdata</param>
		/// <returns>logarithmic AxisData</returns>
		public static AxisData	TransformLog(AxisData ad,AxisData auto)
		{

			//NOTE!!: ad uses linear axis, auto uses logarithmic axis

			//This tries to convert from linear axisdata to logarithmic axisdata
			//It should be noted that it primarily uses the ad axisdata for
			//the conversion. The auto axisdata is used to limit the ad axisdata in case of illegal values

			//If original(ad) is smaller than auto.Min or zero
			//it probably is an illegal value, therefore set it to the autoscaled one
			if(ad.Min <=0 || ad.Min < Math.Pow(10,auto.Min))
				ad.Min = auto.Min;
			else
				ad.Min = Power(ad.Min);

			//See above, removes illegal values from ad
			if(ad.Max <= 0 || ad.Max > Math.Pow(10,auto.Max))
				ad.Max = auto.Max;
			else
				ad.Max = Power(ad.Max) +1;

			ad.Step = 1;
			return ad;
		}

		/// <summary>
		/// Transform double[] to float[]
		/// </summary>
		/// <param name="d">double array</param>
		/// <returns>float array</returns>
		public static float[]	TransformF(double[] d)
		{
			float[] f = new float[d.Length];
			
			for(int i=0;i<d.Length;i++)
			{
				f[i] = (float)d[i];
			}
			return f;
		}

		/// <summary>
		/// Transform double[][] to float[][]
		/// </summary>
		/// <param name="d">double[][]</param>
		/// <returns>float[][]</returns>
		public static float[][] TransformF(double[][] d)
		{
			float[][] f = new float[d.Length][];
			for(int j=0;j<d.Length;j++)
			{
				f[j] = new float[d[j].Length];

				for(int i=0;i<f[j].Length;i++)
				{
					f[j][i] = (float)d[j][i];
				}
			}
			return f;
		}

		/// <summary>
		/// Get AxisData (Min, Max, Step) from double[] array
		/// </summary>
		/// <param name="f">double[] array</param>
		/// <returns>AxisData</returns>
		public static AxisData	Transform(double[] f)
		{
			return GraphMath.AxisScale(TransformNoScale(f));
		}

		/// <summary>
		/// Get AxisData (Min, Max, Step) from double[][] array
		/// </summary>
		/// <param name="f">double[][]</param>
		/// <returns>AxisData</returns>
		public static AxisData	Transform(double[][] f)
		{
			return GraphMath.AxisScale(TransformNoScale(f));
		}

		/// <summary>
		/// Get AxisData (Min, Max, Step) from double[] array but do not autoscale axisdata
		/// </summary>
		/// <param name="f">double[] array</param>
		/// <returns>AxisData</returns>
		public static AxisData	TransformNoScale(double[] f)
		{
			AxisData ad = new AxisData(double.MaxValue,double.MinValue,double.MinValue);

			for(int i =0;i<f.Length;i++)
			{
				if(!double.IsInfinity(f[i]) && !double.IsNaN(f[i]))
				{
					if(f[i] < ad.Min)
						ad.Min = f[i];
					if(f[i] > ad.Max)
						ad.Max = f[i];
				}
			}

            if (ad.Max == double.MaxValue)
                ad.Max = 10;
            if (ad.Min == double.MinValue)
                ad.Min = ad.Max - 10;    


            ad.Step = Math.Abs(ad.Max - ad.Min) / 5;

            return ad;
		}

		/// <summary>
		/// Get AxisData (Min, Max, Step) from double[][] array but do not autoscale
		/// </summary>
		/// <param name="f">double[][]</param>
		/// <returns>AxisData</returns>
		public static AxisData	TransformNoScale(double[][] f)
		{
			AxisData ad = new AxisData(double.MaxValue,double.MinValue,double.MinValue);
			for(int i =0;i<f.Length;i++)
			{
				if(f[i] == null)
					continue;

				for(int j=0;j<f[i].Length;j++)
				{
					if(!double.IsInfinity(f[i][j]) && !double.IsNaN(f[i][j]))
					{
						if(f[i][j] < ad.Min)
							ad.Min = f[i][j];

						if(f[i][j] > ad.Max)
							ad.Max = f[i][j];
					}
				}
			}

            if (ad.Max == double.MaxValue)
                ad.Max = 10;
            if (ad.Min == double.MinValue)
            ad.Min = ad.Max - 10;    

            ad.Step = Math.Abs(ad.Max - ad.Min) / 5;
            return ad;
		}
	}
}
