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

namespace NextGenLab.Chart
{
	/// <summary>
	/// Max, min and step values for defining window grid
	/// </summary>
	[Serializable()]
	public struct AxisData
	{
		double max;
		double min;
		double step;

		/// <summary>
		/// Max value for axis
		/// </summary>
		public double Max{get{return max;}set{max = value;}}
		/// <summary>
		/// Min value for axis
		/// </summary>
		public double Min{get{return min;}set{min = value;}}
		/// <summary>
		/// Step value
		/// </summary>
		public double Step{get{return step;}set{step = value;}}

		/// <summary>
		/// .constructor
		/// </summary>
		/// <param name="Min">Minimum grid value</param>
		/// <param name="Max">Maximum grid value</param>
		/// <param name="Step">Step value</param>
		public AxisData(double Min,double Max,double Step)
		{
			max = Max;
			min = Min;
			step = Step;
		}

		public static bool operator < (AxisData a1,AxisData a2)
		{
			double r1 = a1.Max - a1.Min;
			double r2 = a2.Max - a2.Min;
			return r1 < r2;
		}

		public static bool operator > (AxisData a1,AxisData a2)
		{
			double r1 = a1.Max - a1.Min;
			double r2 = a2.Max - a2.Min;
			return r1 > r2;
		}
	}
}
