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
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for ChartPrint.
	/// </summary>
	public class ChartPrint
	{
		PrintDocument pd;
		ChartControl cc;

		public PrintDocument PrintDocument
		{
			get
			{
				return pd;
			}
			set
			{
				if(pd != null)
				{
					pd.PrintPage -=new PrintPageEventHandler(pd_PrintPage);
				}
				pd = value;
				pd.PrintPage +=new PrintPageEventHandler(pd_PrintPage);
			}
		}

		public ChartPrint(ChartControl cc)
		{			
			this.cc = cc;
			pd = new PrintDocument();
			pd.PrintPage +=new PrintPageEventHandler(pd_PrintPage);
			
		}

		private void pd_PrintPage(object sender, PrintPageEventArgs e)
		{
			if(e.PageSettings.Landscape)
			{
				GraphicsContainer gc = e.Graphics.BeginContainer();
				ChartControl cs = new ChartControl();
                cs.ChartDataList = cc.ChartDataList;
				cs.Size = new Size(e.MarginBounds.Width,e.MarginBounds.Height);
				e.Graphics.TranslateTransform(e.MarginBounds.Left,e.MarginBounds.Top);
				cs.PaintMe(e.Graphics);
				e.Graphics.EndContainer(gc);
				
			}
			else
			{
				GraphicsContainer gc = e.Graphics.BeginContainer();
				ChartControl cs = new ChartControl();
                cs.ChartDataList = cc.ChartDataList;
				cs.Size = new Size(e.MarginBounds.Width,(int)((double)e.MarginBounds.Width * 2/3));
				e.Graphics.TranslateTransform(e.MarginBounds.Left,e.MarginBounds.Top);
				cs.PaintMe(e.Graphics);
				e.Graphics.EndContainer(gc);
			}
			e.HasMorePages = false;
		}
	}
}
