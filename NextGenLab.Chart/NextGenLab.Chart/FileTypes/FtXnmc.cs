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
using System.Xml;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Diagnostics;

namespace NextGenLab.Chart.FileTypes
{
	/// <summary>
	/// Summary description for FtXnmc.
	/// </summary>
	public class FtXnmc:IChartFile
	{
		public FtXnmc()
		{
			
		}
		#region IChartFile Members

		public event NextGenLab.Chart.FileTypes.NewChartDataHandler NewChartData;
		public event NextGenLab.Chart.FileTypes.MessageHandler ErrorMessage;

		public void Open(System.IO.Stream s, bool Merge)
		{
			OpenXmlReader(s,Merge);
		}

		//39MB testfil == 210Meg minne, 19 sekunder
		public void OpenXmlDocument(Stream s,bool Merge)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(s);
			XmlNodeList xnl = xmlDoc.GetElementsByTagName("ChartData");
			MemoryStream ms1;
			foreach(XmlNode xn in xnl)
			{
				using(MemoryStream ms = new MemoryStream())
				{
					XmlDocument xd = new XmlDocument();
					xd.AppendChild(xd.CreateXmlDeclaration("1.0","UTF-8",""));
					XmlNode xn1 = xd.ImportNode(xn,true);
					xd.AppendChild(xn1);
					xd.Save(ms);
					using(ms1 = new MemoryStream(ms.GetBuffer()))
					{
						string text = Encoding.UTF8.GetString(ms.GetBuffer());
						if(NewChartData != null)
							NewChartData(ChartData.FromXml(ms1),true);
						ms1.Close();
					}
					ms.Close();
				}
			}
			s.Close();
		}

		void OpenXmlSerializer(Stream s,bool Merge)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ChartDataList),"ngl.fysel.ntnu.no.chartdatalist");
			ChartDataList cds = null;
			try
			{
				cds = (ChartDataList)xs.Deserialize(s);;
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			if(cds == null)
				return;

			for(int i=0;i<cds.Length;i++)
			{
				if(NewChartData != null)
					NewChartData(cds[i],true);
			}
			
		}

		//39MB testfil == 50Meg minne, 13 sekunder
		void OpenXmlReader(Stream s,bool Merge)
		{
			XmlTextReader xr = new XmlTextReader(s);
			MemoryStream ms;
			while(xr.Read())
			{
				if(xr.NodeType == XmlNodeType.Element)
				{
					if(xr.Name == "ChartData")
					{
						using(ms = new MemoryStream(Encoding.ASCII.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"+xr.ReadOuterXml())))
						{
							if(NewChartData != null)
								NewChartData(ChartData.FromXml(ms),true);
							ms.Close();
						}
					}
				}
			}
		}


		public void Save(System.IO.Stream s,ChartDataList cds)
		{
			//SaveXmlSerializer(s,cds);
			SaveXmlDocument(s,cds);
		}

		void SaveXmlDocument(Stream s, ChartDataList cds)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
		
				//Create Declaration
				xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0","UTF-8",""));

				//Create root node
				XmlNode root = xmlDoc.AppendChild(xmlDoc.CreateElement("NextGenMultipleChart"));
	
				ChartData cd;
				XmlDocument xcd ;
				XmlNode cdroot;
				XmlNode xntmp;
				for(int i=0;i<cds.Length;i++)
				{
					cd = cds[i];
					MemoryStream ms1;
					using(MemoryStream ms = new MemoryStream())
					{
						cd.ToXML(ms);
						xcd = new XmlDocument();
						ms1 = new MemoryStream(ms.GetBuffer());
						ms.Close();
						xcd.Load(ms1);
						ms1.Close();
						cdroot = xcd.DocumentElement;
						xntmp = xmlDoc.ImportNode(cdroot,true);
						root.AppendChild(xntmp);
					}
				}
				xmlDoc.Save(s);
			}
			catch(Exception ex)
			{
				// TODO: Better Message
				if(this.ErrorMessage != null)
					this.ErrorMessage(ex.Message);
			}

		}


		void SaveXmlSerializer(Stream s, ChartDataList cds)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ChartDataList),"ngl.fysel.ntnu.no.chartdatalist");
			xs.Serialize(s,cds);
		}

		#endregion
	}
}
