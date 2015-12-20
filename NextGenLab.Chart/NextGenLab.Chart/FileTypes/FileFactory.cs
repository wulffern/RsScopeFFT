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
using System.IO;
using System.Xml;

namespace NextGenLab.Chart.FileTypes
{
	/// <summary>
	/// Summary description for FileFactory.
	/// </summary>
	public class FileFactory
	{

		enum filetypes{xnmc,xnc,html,none,tab,csvsemi,cvscomma,bnmc,jpeg,gif,bmp,png,tiff};

		filetypes[] fts = new filetypes[0];
        ChartControl cc;
		public FileFactory(ChartControl cc)
		{
            this.cc = cc;
		}

		public string GetSaveFilter(ChartDataList cds)
		{
			string 	filter;
			if(cds.Length > 1)
			{
				filter = "Multiple Chart file|*.xnmc|Binary Multiple Chart file|*.bnmc";
				fts = new filetypes[]{filetypes.xnmc,filetypes.bnmc};
			}
			else
			{
				filter = "Multiple Chart file|*.xnmc|Binary Multiple Chart file|*.bnmc|Single Chart file|*.xnc";
				fts = new filetypes[]{filetypes.xnmc,filetypes.bnmc,filetypes.xnc};
			}
			return filter;
		}

		public string GetExportFilter()
		{
			string filter = "Html|*.htm|Tab separated|*.txt|CSV \";\" delimiter|*.csv|CVS \",\" delimiter|*.csv" +
                "|JPEG|*.jpg|Bitmap|*.bmp|Gif|*.gif|PNG|*.png|TIFF|*.tif";
			fts = new filetypes[]{filetypes.html,filetypes.tab,filetypes.csvsemi,filetypes.cvscomma,filetypes.jpeg,filetypes.gif,filetypes.bmp,filetypes.png,filetypes.tiff};
			return filter;
		}

		public string GetOpenFilter()
		{
			string filter = "Multiple Chart files|*.xnmc|Binary Multiple Chart file|*.bnmc|Single Chart files|*.xnc";
			fts = new filetypes[]{filetypes.xnmc,filetypes.bnmc,filetypes.xnc};
			return filter;
		}

		public IChartFile GetChartFile(int filterindex)
		{
			filterindex -= 1;
			filetypes ft = filetypes.none;
			if(fts.Length > filterindex)
				ft = fts[filterindex];

			IChartFile icf = null;
			switch(ft)
			{
				case filetypes.xnmc:
					icf = new FtXnmc();
					break;
				case filetypes.xnc:
					icf = new FtXnc();
					break;
				case filetypes.bnmc:
					icf = new FtBnmc();
					break;
				case filetypes.html:
					icf = new FtHtml();
					break;
				case filetypes.tab:
					icf = new FtText("\t");
					break;
				case filetypes.csvsemi:
					icf = new FtText(";");
					break;
				case filetypes.cvscomma:
					icf = new FtText(",");
					break;
                case filetypes.jpeg:
                    icf = new FtImage(cc, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case filetypes.bmp:
                    icf = new FtImage(cc, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case filetypes.gif:
                    icf = new FtImage(cc, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case filetypes.png:
                    icf = new FtImage(cc, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case filetypes.tiff:
                    icf = new FtImage(cc, System.Drawing.Imaging.ImageFormat.Tiff);
                    break;
        
			}
			return icf;
		}


		public static IChartFile GetChartFile(Stream s)
		{
			IChartFile icf = null;
			//Try to discover filetype
			try
			{
				XmlTextReader xr = new XmlTextReader(s);
				while(xr.Read())
				{
					if(xr.NodeType == XmlNodeType.Element)
						break;
				}
				
				if(xr.Name == "ChartData")
				{
					s.Position = 0;
                    icf = new FtXnc();		
				}
				else if(xr.Name == "NextGenMultipleChart")
				{
					s.Position = 0;
					icf = new FtXnmc();		
				}
			}
			catch(Exception ex)
			{
				// TODO: Better Message
			}
			return icf;
		}

		public static IChartFile GetChartFile(string filename)
		{

			IChartFile icf = null;
			switch(Path.GetExtension(filename))
			{
				case ".xnc":
					icf = new FtXnc();
					break;
				case ".xnmc":
					icf = new FtXnmc();
					break;
			}
			return null;
		}

		
	}
}
