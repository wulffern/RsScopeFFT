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
using System.Collections.Generic;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for ChartDataList.
	/// </summary>
	[Serializable()]
	public class ChartDataList
	{

		ChartData[] list;
		
		//Position of the last element
		int end = 0;

		//Initial capacity
		int capacity = 15;

        bool showfullname = true;

        bool autoscale = false;
		AxisData arx = new AxisData(double.MaxValue,double.MinValue,1);
		AxisData ary = new AxisData(double.MaxValue,double.MinValue,1);
		AxisData oarx = new AxisData(double.MaxValue,double.MinValue,1);
		AxisData oary = new AxisData(double.MaxValue,double.MinValue,1);
		AxisType atx = AxisType.LIN;
		AxisType aty = AxisType.LIN;

        public bool AutoScale
		{
			get
			{
				return autoscale;
			}
			set
			{
				autoscale = value;
			}
		}

        public bool ShowFullnameLegend
        {
            get { return showfullname; }
            set
            {
                showfullname = value;
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].ShowFullNameLegend = value;
                }
            }

        }

        public AxisData AxisRangeX
		{
			get
			{
				return arx;
			}
			set
			{
				arx = value;
			}
		}

		public AxisData AxisRangeY
		{
			get
			{
				return ary;

			}
			set
			{
				ary = value;
			}
		}

		public AxisType AxisTypeX
		{
			get
			{
				return atx;
			}
			set
			{
				atx = value;
			}
		}
		public AxisType AxisTypeY
		{
			get
			{
				return aty;

			}
			set
			{
				aty = value;
			}
		}

		public int Length{get{return end;}}

		public ChartDataList()
		{
			list = new ChartData[capacity];
		}

		public ChartDataList(int capacity)
		{
			this.capacity = capacity;
			list = new ChartData[capacity];
		}

		public void RestoreOriginalAxis()
		{
			arx = oarx;
			ary = oary;
		}
		public ChartData this[int index]{get{return list[index];}set{list[index] = value;}}

		public int Add(ChartData d)
		{
			int index = end;

			if(index > (list.Length - 1))
			{
				ChartData[] list1 = new ChartData[list.Length*2];
				list.CopyTo(list1,0);
				list = list1;
			}
			list[index] = d;
			end++;

			//Set default values
			if(d.AutoScale)
				autoscale = true;

			if(d.AxisTypeX == AxisType.LOG)
				atx = AxisType.LOG;

			if(d.AxisTypeY == AxisType.LOG)
				aty = AxisType.LOG;

			//Rescale();

			return index;            
		}

        public void Rescale()
		{
			//Get max and min value and compare too current;
			AxisData tarx;
			AxisData tary;

			arx = new AxisData(double.MaxValue,double.MinValue,1);
			ary = new AxisData(double.MaxValue,double.MinValue,1);


			oarx = new AxisData(double.MaxValue,double.MinValue,1);
			oary = new AxisData(double.MaxValue,double.MinValue,1);

			ChartData d;
			for(int i=0;i<this.Length;i++)
			{
				d = this[i];

				if(d.AxisRangeX.Max != 1e-31 && (d.AxisRangeX.Max != d.AxisRangeX.Min) && !AutoScale)
					tarx = d.AxisRangeX;
				else
				{
					switch(AxisTypeX)
					{
						case AxisType.LOG:
							tarx = GraphMath.GetMaxMinLog(d.X);
							break;
						case AxisType.LIN:
							tarx = GraphMath.TransformNoScale(d.X);
							break;
						default:
							tarx = GraphMath.TransformNoScale(d.X);
							break;
					}
				}
				if(d.AxisRangeY.Max != 1e-31 && (d.AxisRangeY.Max != d.AxisRangeY.Min) && !AutoScale)
					tary = d.AxisRangeY;
				else
				{
					switch(AxisTypeY)
					{
						case AxisType.LOG:
							tary = GraphMath.GetMaxMinLog(d.Y);
							break;
						case AxisType.LIN:
							tary = GraphMath.TransformNoScale(d.Y);
							break;
						default:
							tary = GraphMath.TransformNoScale(d.Y);
							break;

					}

				}	

				if(arx.Max < tarx.Max)
					arx.Max = tarx.Max;
				if(arx.Min > tarx.Min)
					arx.Min = tarx.Min;

				if(ary.Max < tary.Max)
					ary.Max = tary.Max;
				if(ary.Min > tary.Min)
					ary.Min = tary.Min;
			}

            if (arx.Max == double.MinValue)
                arx.Max = 10;
            if (arx.Min == double.MaxValue)
                arx.Min = arx.Max - 10;

            if (ary.Max == double.MinValue)
                ary.Max = 10;
            if (ary.Min == double.MaxValue)
                ary.Min = ary.Max - 10;

            arx.Step = Math.Abs(arx.Max - arx.Min) / 5;
            ary.Step = Math.Abs(ary.Max - ary.Min) / 5;

            oarx = arx;
			oary = ary;

		}

		public ChartData[] ToArray()
		{
			ChartData[] list1 = new ChartData[end];
			for(int i=0;i<list1.Length;i++)
			{
				list1[i] = list[i];
			}
			return list1;
		}

		public void Clear()
		{
			list = new ChartData[capacity];
			end = 0;
			autoscale = false;
			
			atx = AxisType.LIN;
			aty = AxisType.LIN;
		}

	}
}
