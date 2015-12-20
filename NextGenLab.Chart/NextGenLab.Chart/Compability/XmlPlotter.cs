using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;

using NextGenLab.Chart;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for LoWPlot.
	/// </summary>
	[WebService(Namespace="http://ngl.fysel.ntnu.no/webservices/")]
	public class XmlPlotter : System.Web.Services.WebService
	{
		/// <summary>
		/// constructor
		/// </summary>
		public XmlPlotter()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		/// <summary>
		/// Returns images
		/// </summary>
		/// <returns></returns>
		[WebMethod(true)]
		public byte[][] GetImages()
		{
			if(this.Session["LastImages"] == null)
				return new byte[][]{};

			string[] abs = (string[])this.Session["LastImages"];
			if(abs == null)
				return new byte[][]{};

			byte[][] buffer = new byte[abs.Length][];
			BinaryReader br;
			Stream s;
			for(int i = 0;i<abs.Length;i++)
			{

				using(s = File.OpenRead(abs[i]))
				{					
					br = new BinaryReader(s);
					buffer[i] = br.ReadBytes((int)s.Length);
					br.Close();
				}

			}
			return buffer;
		}

		/// <summary>
		/// Plots an xml
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		[WebMethod(true)]
		public string[] PlotXml(string xml)
		{			
			//Set Properties
			string Xml = xml;
			string RelativePath = (string)Application["RelativePath"];
			string AbsolutePath = (string)Application["PhysicalPath"];

			if(!Directory.Exists((string)Application["PhysicalPath"]))
				Directory.CreateDirectory((string)Application["PhysicalPath"]);

			ArrayList sc = new ArrayList();
			ArrayList absc = new ArrayList();

			//Make images
			ChartService cs = new ChartService();
			ChartData[] cds  = cs.GetFromXml(xml);
			ChartControl cc;
			ChartData cd;
			int width;
			int height;
			Image image;
			for(int i=0;i<cds.Length;i++)
			{
				cd = cds[i];
				width = XmlTranslator.Widths[i];
				height = XmlTranslator.Heights[i];

				cc = new ChartControl();
				cc.AddChartData(cd);
				cc.Width = width;
				cc.Height = height;
				cc.BackColor = Color.White;

				image = cc.GetImage();
				string filename = "/plot_" + DateTime.Now.Ticks + ".png";
				string physPath = AbsolutePath + filename;
				string relativePath = RelativePath  + filename;
				image.Save(physPath,ImageFormat.Png);
							
				absc.Add(physPath);
				sc.Add(relativePath);
			}
			string[] relPaths = (string[])sc.ToArray(typeof(string));

			//Get AbsolutePaths
			this.Session["LastImages"] = (string[])absc.ToArray(typeof(string));
			
			if(relPaths != null)
			{
				//Add http:// + MachineName to filenames;
				IPHostEntry ihe = Dns.GetHostByName(this.Server.MachineName);
				string local = "http://"  + ihe.HostName;
				ArrayList al = new ArrayList();
				foreach(string s in relPaths)
				{
					al.Add(local + s);
				}
				return (string[])al.ToArray(typeof(string));
			}
			else
			{
				return new string[]{};
			}
		}		

	}
}
