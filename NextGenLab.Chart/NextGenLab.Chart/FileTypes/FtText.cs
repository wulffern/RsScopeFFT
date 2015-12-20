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
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Globalization;

namespace NextGenLab.Chart.FileTypes
{
	/// <summary>
	/// Summary description for FtTabLimited.
	/// </summary>
	public class FtText:IChartFile
	{
		string newline = "\n";
		string delimiter = "\t";

		public FtText(string Delimiter)
		{
			delimiter = Delimiter;
		}
		#region IChartFile Members

		public event NextGenLab.Chart.FileTypes.NewChartDataHandler NewChartData;

		public event NextGenLab.Chart.FileTypes.MessageHandler ErrorMessage;

		public void Open(System.IO.Stream s, bool Merge)
		{
			
		}

		public void Save(System.IO.Stream s, ChartDataList cds)
		{
			
				ArrayList table = new ArrayList();
				
				NumberFormatInfo nfi = new NumberFormatInfo();
				nfi.NumberDecimalSeparator = ".";
				StringCollection cols;
				ChartData cd;
				for(int j=0;j<cds.Length;j++)
				{
					cd = cds[j];
					cols = new StringCollection();
					cols.Add(cd.TitleX);
					foreach(double d in cd.X)
					{
						cols.Add(d.ToString(nfi));
					}
					table.Add(cols);
					
					for(int i=0;i<cd.Y.Length;i++)
					{
						cols = new StringCollection();
						if(cd.TitlesY.Length > i)
							cols.Add(cd.TitlesY[i]);
						else
							cols.Add("No Name");

						foreach(double d in cd.Y[i])
						{
							cols.Add(d.ToString(nfi));
						}
						table.Add(cols);
					}
				}

			using(StreamWriter sw = new StreamWriter(s))
			{	
				int index = 0;

				while(true)
				{
					bool nomore = true;
					StringCollection sc;
					for(int i=0;i<table.Count;i++)
					{
						sc = (StringCollection)table[i];

						if(sc.Count > index){
							nomore = false;
							sw.Write(sc[index]);
						}

						if(i < table.Count -1)
							sw.Write(delimiter);
					}
					sw.Write(newline);
					index++;
					if(nomore)
						break;
				}
			}
			
		}

		#endregion
	}
}
