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
	/// Decorates chart controls in a chart with funstuff
	/// </summary>
	internal class DecorateSkin:DecorateChControlBase
	{

		Color forecolor;
		Color backcolor;
		Font font;
		
		/// <summary>
		/// constructor, calls base constructor
		/// </summary>
		/// <param name="cc">Chart control</param>
		/// <param name="ForeColor">Foreground color</param>
		/// <param name="BackColor">Background color</param>
		/// <param name="Font">Font</param>
		public DecorateSkin(ChControl cc,Color ForeColor,Color BackColor,Font Font):base(cc)
		{
			forecolor = ForeColor;
			backcolor = BackColor;
			this.font = Font;
		
		}

		protected override void OnPostPaint(ChControl cc, Graphics g)
		{

		}

		/// <summary>
		/// Decorates the chart control
		/// </summary>
		/// <param name="cc">chart control</param>
		/// <param name="g">Graphics</param>
		protected override void OnPrePaint(ChControl cc,Graphics g)
		{
			cc.Font = font;
			cc.BackColor = backcolor;
			cc.ForeColor = forecolor;
		}

		
	}
}
