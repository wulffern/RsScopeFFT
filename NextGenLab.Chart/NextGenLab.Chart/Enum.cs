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
	/// Defines the axis type 
	/// </summary>
	[Serializable()]
	public enum AxisType
	{
		/// <summary>
		/// Linear axis
		/// </summary>
		LIN,
		/// <summary>
		/// Logarithmic axis
		/// </summary>
		LOG
	}

	/// <summary>
	/// Defines the Chart type
	/// </summary>
	[Serializable()]
	public enum ChartType
	{
		/// <summary>
		/// Stem Chart
		/// </summary>
		Stem,
		/// <summary>
		/// Curve Chart
		/// </summary>
		Curve,
		/// <summary>
		/// Fast Curve Chart (does not do windowing)
		/// </summary>
		Fast,
		/// <summary>
		/// Histogram
		/// </summary>
		Histogram,
		/// <summary>
		/// Draws Points
		/// </summary>
		Points,
        Cross,
		Step,
		CurveWide
	}


	/// <summary>
	/// Trace type for Chart
	/// </summary>
	[Serializable()]
	public enum ChartTraceType
	{
		/// <summary>
		/// Draw Cross at trace points
		/// </summary>
		Cross,
		/// <summary>
		/// Draw Lines with center at trace points
		/// </summary>
		Lines,
		/// <summary>
		/// Draw dot at trace points
		/// </summary>
		Dot,
		/// <summary>
		/// Draw cross at trace points + marker at axis
		/// </summary>
		Advanced
	}
}
