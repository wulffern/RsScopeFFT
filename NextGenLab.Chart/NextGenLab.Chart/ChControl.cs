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
namespace NextGenLab.Chart
{

	internal delegate void PaintHandler(ChControl cc, Graphics g);

	/// <summary>
	/// Base class for Charting controls
	/// </summary>
	internal abstract class ChControl
	{
		Point	location;
		Size	size;
		Font	font;
		Color	forecolor;
		Color	backcolor;
		ChControlCollection children;
		ChControl parent;

		#region Properties
		/// <summary>
		/// Where'd u want it?
		/// </summary>
		public Point	Location{get{return location;}set{location = value;}}
		/// <summary>
		/// Wat size do ya want?
		/// </summary>
		public Size		Size{get{return size;}set{size = value;}}
		/// <summary>
		/// Duh
		/// </summary>
		public Font		Font{get{return font;}set{font = value;}}
		/// <summary>
		/// Uuh, back color, no, foreground color
		/// </summary>
		public Color	ForeColor{get{return forecolor;}set{forecolor = value;}}
		/// <summary>
		/// background color
		/// </summary>
		public Color	BackColor{get{return backcolor;}set{backcolor = value;}}
		/// <summary>
		/// Width, gets it from Size
		/// </summary>
		public int		Width{get{return Size.Width;}}
		/// <summary>
		/// Height, gets it from Size
		/// </summary>
		public int		Height{get{return Size.Height;}}
		/// <summary>
		/// Chart child controls
		/// </summary>
		public ChControlCollection Children{get{return children;}}
		/// <summary>
		/// Parent of this ChControl
		/// </summary>
		public ChControl Parent{get{return parent;}set{parent = value;}}
		#endregion

		#region Events
		/// <summary>
		/// Called just before the control is painted
		/// </summary>
		public event PaintHandler PrePaint;
		/// <summary>
		/// Called just after the control is painted
		/// </summary>
		public event PaintHandler PostPaint;
		#endregion

		/// <summary>
		/// constructor
		/// </summary>
		public ChControl()
		{
			children = new ChControlCollection();
			forecolor = Color.Black;
			backcolor = Color.Transparent;
			Font = new Font("Microsoft Sans Serif",8.25f);
		}

		/// <summary>
		/// Wrapps child in a graphics container and draws this in the correct place
		/// </summary>
		/// <param name="g"></param>
		public virtual void Paint(Graphics g)
		{
			//Create container and move it to the correct Location
			
            GraphicsContainer gc = g.BeginContainer();

			g.TranslateTransform(Location.X,Location.Y);

			//Fill the background with BackColor
			g.FillRectangle(new SolidBrush(BackColor),0,0,Width,Height);

			//Call Prepaint
			if(PrePaint != null)
				PrePaint(this,g);

			//Paint this ChControl
			OnPaint(g);

			//Call PostPaint
			if(PostPaint != null)
				PostPaint(this,g);

			//End Container
			g.EndContainer(gc);
		}

		public void Init(Graphics g)
		{
			OnInit(g);
		}

		/// <summary>
		/// Paint the chart control
		/// </summary>
		/// <param name="g"></param>
		protected abstract void OnPaint(Graphics g);

		protected virtual void OnInit(Graphics g)
		{
			foreach(ChControl c in this.Children)
			{
				c.Init(g);
			}

		}
	}
}
