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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using NextGenLab.Chart;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Net;
using System.Web.SessionState;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Webservice for Chart maker
	/// </summary>
	[WebService(Namespace="http://ngl.fysel.ntnu.no/webservices/")]
	public class ChartService : System.Web.Services.WebService
	{
		#region Generated Code
		/// <summary>
		/// Constructor
		/// </summary>
		public ChartService()
		{
			InitializeComponent();
			if(!Directory.Exists((string)Application["PhysicalPath"] + "/"))
				Directory.CreateDirectory((string)Application["PhysicalPath"] + "/");
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
		#endregion

		#region WebMethods
		/// <summary>
		/// Make Chart and return as image
		/// </summary>
		/// <param name="cd">Chart data</param>
		/// <param name="Width">Width of image</param>
		/// <param name="Height">Height of image</param>
		/// <returns></returns>
		[WebMethod(true)]
		public byte[]	MakeChart(ChartData cd,int Width, int Height)
		{
			//Initialize
			ChartControl cc = new ChartControl();
			cc.AddChartData(cd);
			cc.Width = Width;
			cc.Height = Height;
			cc.BackColor = Color.White;

			//Make Image
			Image image = cc.GetImage();

			//Save Image to tmp file
			string tmp = Path.GetTempFileName();
			image.Save(tmp,ImageFormat.Png);

			//Read Image from disk and fill byte[]
			byte[] b;
			BinaryReader br;
			using(Stream s = File.OpenRead(tmp))
			{					
				br = new BinaryReader(s);
				b = br.ReadBytes((int)s.Length);
				br.Close();
			}
			
			//Delete tmp file
			File.Delete(tmp);
			
			//Cleanup image
			image.Dispose();

			return b;
		}

		/// <summary>
		/// Make Html file containing charts
		/// </summary>
		/// <param name="cds">ChartData</param>
		/// <param name="Width">Width</param>
		/// <param name="Height">Height</param>
		/// <param name="Title">Title of Html</param>
		/// <returns></returns>
		[WebMethod(true)]
		public string	MakeHtmlChart(ChartData[] cds,int Width, int Height,string Title)
		{
			//Get  paths, set in global.cs
			string RelativePath = (string)Application["RelativePath"] + "/";
			string AbsolutePath = (string)Application["PhysicalPath"] + "/";

			//Gen filename
			string filename = DateTime.Now.Ticks.ToString();

			//Make Html file
			StringBuilder sr = new StringBuilder();
			sr.Append("<html><title>" + Title + "</title>");
			sr.Append("<style>a{font-family:Verdana;font-size:10pt}</style>");
			sr.Append("<body onload='focus()'>");
			sr.Append(MakeInnerHtmlChart(cds,Width,Height));
			sr.Append("</body></html>");
			
			//Write file to disk
			using(StreamWriter sw = new StreamWriter(AbsolutePath + filename + ".html"))
			{
				sw.Write(sr.ToString());
			}

			//Add http:// + MachineName to filenames;
			IPHostEntry ihe = Dns.GetHostByName(this.Server.MachineName);
           
			this.AddToDelete(new string[]{"http://"  + ihe.HostName + AbsolutePath + filename + ".html"});
			return  "http://"  + ihe.HostName + RelativePath + filename + ".html";
		}

		/// <summary>
		/// Make Insertable HTML chart
		/// </summary>
		/// <param name="cds">ChartData</param>
		/// <param name="Width">Width</param>
		/// <param name="Height">Height</param>
		/// <returns></returns>
		[WebMethod(true)]
		public string	MakeInnerHtmlChart(ChartData[] cds,int Width, int Height)
		{
			//Check that we have some data
			if(cds == null)
				return "An error occured, could not find any plots!";

			try
			{
				//Get paths, set in global.cs
				string RelativePath = (string)Application["RelativePath"] + "/";
				string AbsolutePath = (string)Application["PhysicalPath"] + "/";

				//Generate unique filename
				string filename = DateTime.Now.Ticks.ToString();

				//Get hostinfo
				IPHostEntry ihe = Dns.GetHostByName(this.Server.MachineName);

				//Initialize variables
				string[] imgs = new string[cds.Length];
				StringBuilder sr = new StringBuilder();
				string[] datanames = new string[cds.Length];
				string xmldata;
				string tabdata;
				ArrayList files = new ArrayList();

				//Run through ChartData[] and create charts
				for(int i=0;i<cds.Length;i++)
				{
					//Initialize chart
					ChartControl cc = new ChartControl();
					cc.AddChartData(cds[i]);
					cc.BackColor = Color.White;

					//Check X and Y values
					if(cds[i].X == null || cds[i].Y == null)
						continue;

					//Check y values
					bool ok=false;
					foreach(double[] d in cds[i].Y)
					{
						if(d != null)
							ok = true;
					}
					if(!ok)
						continue;

					//Check if the current ChartData has Width and Height set
					try
					{
						if(cds[i].Width != 0)
							cc.Width = cds[i].Width;
						else
							cc.Width = Width;

						if(cds[i].Height != 0)
							cc.Height = cds[i].Height;
						else
							cc.Height = Height;
					}
					catch{}
				
					//Create Image
					Image img = cc.GetImage();

					if(img == null)
						continue;

					//Save image to disk
					img.Save(AbsolutePath + filename + "_" + i + ".png",ImageFormat.Png);				
					
					//Store relative path to image
					imgs[i] = RelativePath + filename + "_" + i + ".png";

					//Save ChartData as XML
					try
					{
						xmldata = filename +"_" +i + ".xnc";
						using(Stream s = File.OpenWrite(AbsolutePath + xmldata))
						{
							cds[i].ToXML(s);
						}
					}
					catch
					{
						xmldata = null;
					}
	
					//Save ChartData as HTML
					try
					{
						tabdata = filename + "_" +i + ".html";					
						using(Stream s = File.OpenWrite(AbsolutePath + tabdata))
						{
							cds[i].ToHtml(s);
						}
					}
					catch
					{
						tabdata = null;
					}

					//Create HTML to return to client
					sr.Append("<table cellpadding=0 cellspacing=2><tr><td >");
					sr.Append("<img src='" + "http://" + ihe.HostName + imgs[i] + "'>\n");

					if(xmldata != null)
						sr.Append("<tr><td align=right><a href='http://" + ihe.HostName + RelativePath + xmldata + "'>Xml format</a> | ");
					
					if(tabdata != null)
						sr.Append("<a href='http://" + ihe.HostName + RelativePath + tabdata + "' target='htmldata'>Html format</a></table><br>");
			
					//Files to be deleted at the end of session
					files.Add(AbsolutePath + filename + "_" + i + ".png");
					files.Add(AbsolutePath + xmldata);
					files.Add(AbsolutePath + tabdata);
				}

				//Add to session end delete
				AddToDelete((string[])files.ToArray(typeof(string)));

				//Return HTML
				return sr.ToString();
			}
			catch(Exception e)
			{ 
				return "An unknown error occured. Please send the following message to the administrator:<br>" + e.Message + "<br>" + e.StackTrace +
					"<br>" + cds.Length + ", " + Width + ", " + Height;
			}
		}

		/// <summary>
		/// Gets default ChartData
		/// </summary>
		/// <returns>ChartData</returns>
		[WebMethod()]
		public ChartData GetDefault()
		{
			return ChartData.GetInstance();
		}

		/// <summary>
		/// Gets default ChartData
		/// </summary>
		/// <returns>ChartData</returns>
		[WebMethod()]
		public ChartData[] GetFromXml(string xml)
		{
			return XmlTranslator.ReadXml(xml);
		}

		/// <summary>
		/// Get a scaled version of ChartData with the current x and y series
		/// </summary>
		/// <param name="x">xvalue series</param>
		/// <param name="y">yvalues series</param>
		/// <returns>ChartData</returns>
		[WebMethod(MessageName="GetScaledDouble")]
		public ChartData GetScaled(double[] x, double[][] y)
		{
			ChartData cd  = ChartData.GetInstance();
			cd.AxisRangeX = GraphMath.Transform(x);
			cd.AxisRangeY = GraphMath.Transform(y);
			cd.X = x;
			cd.Y = y;
			return cd;
		}


		[WebMethod()]
		public bool SendChartData(string hostname, ChartData[] cds)
		{
			bool ok = true;

			ChartNetClient cnc = new ChartNetClient(hostname);
			foreach(ChartData cd in cds)
			{
				if(!ok)
					break;
				ok = cnc.Send(cd);
			}
			return ok;
		}

		#endregion

		/// <summary>
		/// Adds files to Session delete store
		/// </summary>
		/// <param name="s"></param>
		public void	AddToDelete(string[] s)
		{
			if(this.Session["TempObjects"] == null)
			{
				this.Session["TempObjects"] = new ArrayList();
			}
			((ArrayList)this.Session["TempObjects"]).Add(s);
		}


		/// <summary>
		/// Delete files in Session delete store
		/// </summary>
		/// <param name="MySession"></param>
		public static void DeleteSession(HttpSessionState MySession)
		{
			if(MySession["TempObjects"] != null)
			{
				foreach(string[] strs in (ArrayList)MySession["TempObjects"])
				{
					foreach(string s in strs)
					{
						File.Delete(s);
					}
				}
			}
		}

	}
}
