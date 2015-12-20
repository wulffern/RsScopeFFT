using System;
using System.Collections;
using System.Xml;
using System.Globalization;
using System.Text;
using NextGenLab.DataSets;
using System.IO;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for NglTranslator.
	/// </summary>
	public class XmlTranslator
	{
		private XmlTranslator()
		{
		}

		/// <summary>
		/// Heights from the prev conv
		/// </summary>
		public static int[] Widths;
		/// <summary>
		/// Widths from the prev conv
		/// </summary>
		public static int[] Heights;

		/// <summary>
		/// Reads an old xml file and translates into Chart
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static ChartData[] ReadXml(string xml)
		{
			XmlDocument xd = new XmlDocument();
			xd.LoadXml(xml);

			XmlTranslator xt = new XmlTranslator();
			ChartData[] cds = new ChartData[]{};
			XmlNode n = xd.LastChild;
			string uri = n.NamespaceURI;
			switch(uri)
			{
				case "http://ngl.fysel.ntnu.no/NglXml1.xsd":
					cds =  xt.ReadXmlv2(xml);
					break;
				case "":
					cds = xt.ReadXmlv1(xml);
					break;
				default:
					throw new Exception("NameSpace " + uri + " not found");
			}
			return cds;
		}


		private ChartData[] ReadXmlv2(string xml)
		{
			NextGenLab.DataSets.NglXml1 nx = new NextGenLab.DataSets.NglXml1();
			nx.DataSetName = "NglXml1";
			nx.Locale = new System.Globalization.CultureInfo("en-US");

			nx.ReadXml(new MemoryStream(Encoding.Unicode.GetBytes(xml)));

			if(nx.Results.Count > 1)
				throw new Exception("To many results, can't handle more than one");
			if(nx.Results.Count == 0)
				throw new ArgumentException("Can't find any results!!");
				
			NglXml1.Plot[] plots = nx.Results[0].GetPlots();
			ChartData[] charts = new ChartData[plots.Length];
			NglXml1.Plot p;
			ChartData cd ;
			Widths = new int[plots.Length];
			Heights = new int[plots.Length];
			for(int j=0;j<plots.Length;j++)
			{
				p = plots[j];
				cd = ChartData.GetInstance();
					
				NglXml1.YVal[] yv = p.GetYVals();
				cd.Y = new double[yv.Length][];
				for(int i=0;i<yv.Length;i++)
				{						
					cd.Y[i] = ParseValueString(yv[i].Y);
				}
					
				cd.X = ParseValueString(p.X);
				cd.Title = p.YLabel;
				cd.TitleX = p.XLabel;
				cd.AxisLabelX = "[" + p.XUnit + "]";
				cd.AxisLabelY = "[" + p.YUnit + "]";
				cd.AxisTypeX = (AxisType)Enum.Parse(typeof(AxisType),p.XScale,true);
				cd.AxisTypeY = (AxisType)Enum.Parse(typeof(AxisType),p.YScale,true);

				switch(cd.AxisTypeX)
				{
					case AxisType.LOG:
						cd.AxisRangeX = GraphMath.TransformNoScale(cd.X);
						break;
					case AxisType.LIN:
						cd.AxisRangeX = GraphMath.Transform(cd.X);
						break;

				}

				switch(cd.AxisTypeY)
				{
					case AxisType.LOG:
						cd.AxisRangeY = GraphMath.TransformNoScale(cd.Y);
						break;
					case AxisType.LIN:
						cd.AxisRangeY = GraphMath.Transform(cd.Y);
						break;
				}

				Widths[j] = p.Width;
				Heights[j] = p.Height;
				cd.ShowZero = true;
				charts[j] = cd;
			}

			return charts;


		}

		/// <summary>
		/// Reads Graph Xml from a string
		/// </summary>
		/// <param name="ResultXml">Graph Xml</param>
		/// <returns>Array of GraphDTO objects</returns>
		private ChartData[] ReadXmlv1(string ResultXml)
		{
			ArrayList graphs = new ArrayList();
			ArrayList yvals = new ArrayList();
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(ResultXml);
			XmlNodeList graphList = doc.DocumentElement.GetElementsByTagName("GRAPH");
			Widths = new int[graphList.Count];
			Heights = new int[graphList.Count];
			for(int j=0;j<graphList.Count;j++)
			{
				XmlNode graph = graphList[j];
				try
				{
					XmlDocument graph_doc = new XmlDocument();
					graph_doc.LoadXml(graph.OuterXml);

					ChartData cd = ChartData.GetInstance();

					//Get YValues
					yvals = new ArrayList();
					XmlNodeList temp_node_list = graph_doc.DocumentElement.GetElementsByTagName("YVALUES");
					
					cd.Y = new double[temp_node_list.Count][];
					for(int i=0;i<temp_node_list.Count;i++)
					{
						XmlNode TempNode = temp_node_list[i];
						cd.Y[i] = ParseValueString(TempNode.InnerText);
					}		
					//Get XValues
					cd.X =ParseValueString(graph_doc.DocumentElement.GetElementsByTagName("XVALUES")[0].InnerText);

					cd.Title = graph_doc.DocumentElement.GetElementsByTagName("YLABEL")[0].InnerText;
					cd.TitleX = graph_doc.DocumentElement.GetElementsByTagName("XLABEL")[0].InnerText;
					cd.TitlesY = new string[]{};
					cd.AxisLabelX = "[" + graph_doc.DocumentElement.GetElementsByTagName("XVAL")[0].InnerText + "]";
					cd.AxisLabelY = "[" + graph_doc.DocumentElement.GetElementsByTagName("YVAL")[0].InnerText + "]";

					cd.AxisTypeX = (AxisType)Enum.Parse(typeof(AxisType),graph_doc.DocumentElement.GetElementsByTagName("TYPE_X")[0].InnerText,false);
					cd.AxisTypeY = (AxisType)Enum.Parse(typeof(AxisType),graph_doc.DocumentElement.GetElementsByTagName("TYPE_Y")[0].InnerText,false);
					
					Heights[j]= Int32.Parse(graph_doc.DocumentElement.GetElementsByTagName("VSIZE")[0].InnerText);
					Widths[j] = Int32.Parse(graph_doc.DocumentElement.GetElementsByTagName("HSIZE")[0].InnerText);
				
					switch(cd.AxisTypeX)
					{
						case AxisType.LOG:
							cd.AxisRangeX = GraphMath.TransformNoScale(cd.X);
							break;
						case AxisType.LIN:
							cd.AxisRangeX = GraphMath.Transform(cd.X);
							break;

					}

					switch(cd.AxisTypeY)
					{
						case AxisType.LOG:
							cd.AxisRangeY = GraphMath.TransformNoScale(cd.Y);
							break;
						case AxisType.LIN:
							cd.AxisRangeY = GraphMath.Transform(cd.Y);
							break;
					}
				

					cd.ShowZero = true;

					graphs.Add(cd);
				}
				catch
				{
					//Could not parse graph
				}
			}

			if(graphs.Count > 0)
			{
				return (ChartData[]) graphs.ToArray(typeof(ChartData));
			}
			else
			{	
				return null;
			}
		}

		/// <summary>
		/// Writes Graph Xml
		/// </summary>
		/// <param name="Graphs">Array of GraphDTO objects</param>
		/// <returns>Graph Xml</returns>
		private string WriteXmlv1(ChartData[] Graphs)
		{
			string XmlGraph = "";
			string XmlHeader;
			string XmlFooter;
		
			XmlHeader = "<?xml version='1.0'?><RESULT ID=\"XML CREATOR\" TIME=\"" + DateTime.Now.ToShortDateString() + "," + DateTime.Now.ToShortTimeString() +"\" >";
			XmlFooter = "</RESULT>";

			foreach(ChartData cd in Graphs)
			{
				XmlGraph += "<GRAPH>\n";
				XmlGraph += "<XVALUES>" + JoinValueArray(cd.X)  + "</XVALUES>\n";

				foreach(double[] yvals in cd.Y)
				{
					XmlGraph += "<YVALUES>" + JoinValueArray(yvals) + "</YVALUES>\n";
				}

				XmlGraph += "<YLABEL></YLABEL>\n";
				XmlGraph += "<XLABEL>" + cd.TitleX + "</XLABEL>\n";

				XmlGraph += "<YVAL>" + cd.AxisLabelY + "</YVAL>\n";
				XmlGraph += "<XVAL>" + cd.AxisLabelX  + "</XVAL>\n";

				XmlGraph += "<TYPE_Y>" + cd.AxisTypeY.ToString() + "</TYPE_Y>\n";
				XmlGraph += "<TYPE_X>" + cd.AxisTypeX.ToString() + "</TYPE_X>\n";

				XmlGraph += "<VSIZE></VSIZE>\n";
				XmlGraph += "<HSIZE></HSIZE>\n";
				XmlGraph += "<SAMELINE></SAMELINE>\n";
				XmlGraph += "</GRAPH>\n\n";
			}

			return XmlHeader + XmlGraph + XmlFooter;
		}

		/// <summary>
		/// Parses a comma separated values
		/// </summary>
		/// <example>
		/// <code>
		/// string s = "1.2,3.2,3.4";
		/// double[] d = GraphDTO.ParseValueString(s);
		/// //d = {1.2, 3.2, 3.4}
		/// </code>
		/// </example>
		/// <param name="values">Comma separated values</param>
		/// <returns>Values from string</returns>
		private double[] ParseValueString(string values)
		{

			NumberFormatInfo number_format = new NumberFormatInfo();
			number_format.NumberDecimalSeparator = ".";
			number_format.CurrencyDecimalSeparator = ".";
			string[] string_vals = values.Split(',');
			ArrayList double_vals  = new ArrayList();

			foreach(string val in string_vals){double_vals.Add(Double.Parse(val,number_format) );}
			return (double[])double_vals.ToArray(typeof(double));
		}

		/// <summary>
		/// Converts from a double array into comma separated values
		/// </summary>
		/// <example>
		/// <code>
		/// double[] d  = new double[]{1.2, 3.2, 3.4};
		/// string s = GraphDTO.ParseValueString(s);
		/// //s = "1.2,3.2,3.4";
		/// </code>
		/// </example>
		/// <param name="values">Values to convert</param>
		/// <returns></returns>
		private string JoinValueArray(double[] values)
		{
			NumberFormatInfo number_format = new NumberFormatInfo();
			number_format.NumberDecimalSeparator = ".";
			number_format.CurrencyDecimalSeparator = ".";

			StringBuilder string_vals = new StringBuilder();
			for(int i=0;i<values.Length;i++)
			{
				string_vals.Append(values[i].ToString(number_format));
				if((values.Length -1) > i)
					string_vals.Append(",");
			}
			return string_vals.ToString();
		}
	}


}
