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
using System.Windows.Forms;
using System.Drawing;
using NextGenLab.Chart;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for ZoomControl.
	/// </summary>
	public class DragDropControl:NextGenLab.Chart.ZoomControl
	{
		

        bool ctrl = false;



        public DragDropControl()
		{
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
            }
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = false;
            }
			base.OnKeyUp (e);
		}
		
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
            if (e.Button == MouseButtons.Left && ctrl)
            {
                FileTypes.FtBnmc bnmc = new NextGenLab.Chart.FileTypes.FtBnmc();
                string data;
                using (MemoryStream ms = new MemoryStream((int)Math.Pow(2, 15)))
                {
                    bnmc.Save(ms, this.ChartDataList);
                    data = Convert.ToBase64String(ms.GetBuffer());
                    ms.Close();
                }

                DragDropEffects df = DragDropEffects.Copy;
                this.DoDragDrop(data, df);             
               
                
            }
			base.OnMouseDown (e);
		}




	}
}
