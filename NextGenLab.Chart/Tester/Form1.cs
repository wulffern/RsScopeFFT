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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NextGenLab.Chart;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Diagnostics;
//using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NextGenLab.Chart.FileTypes;

namespace NglChart
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region Generated Code

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem11;
        private IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Initialize();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem3});
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9});
            this.menuItem7.MergeOrder = 2;
            this.menuItem7.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem7.Text = "View";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "Group by Title";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MdiList = true;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6});
            this.menuItem3.MergeOrder = 6;
            this.menuItem3.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem3.Text = "Window";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "New Chart Window";
            this.menuItem11.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Tile Horizontal";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "Tile Vertical";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.Text = "Cascade";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Ngl Chart";
            this.ResumeLayout(false);

		}
		#endregion


		#endregion

		//ColorsChart cc;
		static Form1 FirstForm;
		bool chartsamewindow = false;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			Process ri = RunningInstance();
			if(ri  != null)
			{
					if(args.Length > 0)
					{
						string s = args[0];
						if(File.Exists(s))
						{
							ChartNetClient cnc = new ChartNetClient();
							if(!cnc.Send(s))
								MessageBox.Show(cnc.ErrorLog);
						}
					}
			}
			else
			{
				FirstForm = new Form1();
				if(args.Length > 0)
				{
					string s = args[0];
					if(File.Exists(s))
					{

						FirstForm.OpenFile(s);
					}
				}

				ChartNetServer cns = new ChartNetServer();
				cns.NewChartData +=new NglChart.ChartNetServer.NewDataHandler(cns_NewChartData);

                Application.EnableVisualStyles();
				Application.Run(FirstForm);
				
			}
		}


		public static Process RunningInstance() 
		{ 
			try
			{
				Process current = Process.GetCurrentProcess(); 
				Process[] processes = Process.GetProcessesByName (current.ProcessName); 

				//Loop through the running processes in with the same name 
				foreach (Process process in processes) 
				{ 
					//Ignore the current process 
					if (process.Id != current.Id) 
					{ 
						//Make sure that the process is running from the exe file. 
						if (Assembly.GetExecutingAssembly().Location.
							Replace("/", "\\") == current.MainModule.FileName) 
 
						{  
							//Return the other process instance.  
							return process; 
 
						}  
					}  
				} 
				//No other instance was found, return null. 
			}
			catch{}
			return null;  
		}


		private void Initialize()
		{

			this.IsMdiContainer = true;

#if DEBUG
		
			Chart c = new Chart();
			c.MdiParent = this;
			c.WindowState = FormWindowState.Maximized;
			c.Show();
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart1.xnc"),true);
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart2.xnc"),true);
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart3.xnc"),true);
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart1.xnc"),true);
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart2.xnc"),true);
//			c.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart3.xnc"),true);


            //Generate som random data to test chart

            ChartData cd = new ChartData();
            Random r = new Random();
            int numdatas = 10;
            double[] xval = new double[numdatas];
            double[] yval;
            double[][] yvals = new double[numdatas][];
            string[] ytitles = new string[numdatas];
            for (int z = 0; z < numdatas; z++)
            {
                yval = new double[numdatas];
                for (int i = 0; i < numdatas; i++)
                {
                    if (z == 0)
                        xval[i] = i;
                    yval[i] = r.NextDouble() * 5 - (z * 10);
                }

                yvals[z] = yval;
                ytitles[z] = "nr " + z;
            }

            cd.X = xval;
            cd.Y = yvals;
            cd.TitlesY = ytitles;

            cd.ChartType = ChartType.CurveWide;
            cd.AutoScale = true;
            c.Open(cd, true);

            //c.ForeColor = Color.Yellow;
            //c.BackColor = Color.Black;

			//NextGenLab.Chart.Form2  f = new Form2();
			//f.chartControl21.Open(this.GetType().Assembly.GetManifestResourceStream("NglChart.chart1.xnc"),true);
			//f.MdiParent = this;
			//f.Show();

            //c.Open(File.OpenRead(@"c:\temp\fft.xnmc"), true);
            //c.Open(File.OpenRead(@"..\..\chart1.xnc"), true);
            //c.Open(File.OpenRead(@"..\..\chart2.xnc"), true);
            //c.Open(File.OpenRead(@"..\..\chart3.xnc"), true);
			
//			Form2 cd = new Form2();
//			cd.chartControl21.Open(File.OpenRead(@"c:\temp\balle.xnc"),false);
//			cd.Show();
			//c.Open(File.OpenRead(@"c:\temp\test.xnc"),false);
			//cd.Show();
			
#else
			Chart c = new Chart();
			c.MdiParent = this;
			c.WindowState = FormWindowState.Maximized;
			c.Show();
#endif
		}

        void OpenFile(byte[] b)
        {
			//bool chartdata = true;

			IChartFile icf = FileFactory.GetChartFile(new MemoryStream(b));

			string s = Encoding.ASCII.GetString(b);

			string sb = s.Substring(s.Length-20);
			
			if(icf is FtXnc)
			{
				OpenFile(ChartData.FromXml(new MemoryStream(b)));
			}
			else if( icf is FtXnmc)
			{
				Chart c =  new Chart();
				c.MdiParent = this;
				c.Show();

				using(MemoryStream ms = new MemoryStream(b))
				{
					try
					{
						
						c.Open(ms,false);
					}	
					catch
					{
		
					}
					ms.Close();
				}
			}

		}

		public void OpenFile(string s)
		{
			if(this.MdiChildren.Length >0)
			{
				Chart c =this.MdiChildren[0] as Chart;
				if(c != null)
				{
					c.Open(s,false);
					c.BringToFront();
					this.BringToFront();
				}

			}
		}

		public void OpenFile(ChartData cd)
		{
			Chart c = null;
			
			//Merge if needed
			if(this.chartsamewindow)
			{
				//If open in same window
				foreach(Form f in this.MdiChildren)
				{
					if(!(f is Chart))

						if(cd.Title == "")
							continue;
			
					if(f.Text == cd.Title)
					{
						c = (Chart)f;
		
						//Merge the current file into this
						c.Open(cd,true);
									
						break;
					}
				}
			}
			
			if(c == null)
			{
				c =  new Chart();
				c.MdiParent = this;
				c.Show();
				c.Open(cd,false);
			}	
			
			this.BringToFront();
			this.Focus();			
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Chart c = new Chart();
			c.MdiParent = this;
			//c.WindowState = FormWindowState.Maximized;
			c.Show();
			c.BringToFront();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Chart c = new Chart();
			c.MdiParent = this;
			c.WindowState = FormWindowState.Maximized;
			c.Show();
		
		}

		private void cc_NewColor(object sender, EventArgs e)
		{
			foreach(Form f in this.MdiChildren)
			{
				f.Refresh();
			}
		}

		private static void cns_NewChartData(byte[] cd)
		{
			FirstForm.Invoke(new ChartNetServer.NewDataHandler(FirstForm.OpenFile),new object[]{cd});
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.menuItem9.Checked = !this.menuItem9.Checked;
			this.chartsamewindow = this.menuItem9.Checked;
			
		}
	}
}
