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

namespace NextGenLab.Chart
{
	/// <summary>
	/// Decorator for Chart Controls
	/// </summary>
	internal abstract class DecorateChControlBase
	{
		ChControl cc;

		/// <summary>
		/// Constructor, adds prepaint handler to chart control and its children
		/// </summary>
		/// <param name="cc">Chart control</param>
		public DecorateChControlBase(ChControl cc)
		{
			this.cc = cc;
			cc.PrePaint +=new PaintHandler(cc_PrePaint);
			cc.PostPaint +=new PaintHandler(cc_PostPaint);

			//Add eventhandlers for PrePaint and PostPaint to all children
			RecursiveSearch(cc.Children);
		}

		/// <summary>
		/// Recursivly search through all children and add eventhandlers for PrePaint and PostPaint
		/// </summary>
		/// <param name="controls"></param>
		private void RecursiveSearch(ChControlCollection controls)
		{
			foreach(ChControl cc in controls)
			{
				cc.PrePaint +=new PaintHandler(cc_PrePaint);
				cc.PostPaint +=new PaintHandler(cc_PostPaint);
				if(cc.Children.Count > 0)
					RecursiveSearch(cc.Children);
			}
		}

		//Call OPrePaint
		private void cc_PrePaint(ChControl sender, Graphics g)
		{
			OnPrePaint(sender,g);
		}
		
		//Call OPostPaint
		private void cc_PostPaint(ChControl cc, Graphics g)
		{
			OnPostPaint(cc,g);
		}

		/// <summary>
		/// Called before the control is drawn
		/// </summary>
		/// <param name="cc">Chart Control</param>
		/// <param name="g">Graphics</param>
		protected abstract void OnPrePaint(ChControl cc,Graphics g);
		
		/// <summary>
		/// Called after the control has been drawn
		/// </summary>
		/// <param name="cc">Chart Control</param>
		/// <param name="g">Graphic g</param>
		protected abstract void OnPostPaint(ChControl cc,Graphics g);

		
	}
}
