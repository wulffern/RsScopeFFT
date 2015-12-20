using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using NextGenLab.Chart;
using NextGenLab.Chart.FileTypes;
using System.Xml;
using System.Drawing.Printing;
using System.Xml.XPath;

namespace  NextGenLab.Chart
{
	/// <summary>
	/// Summary description for Chart.
	/// </summary>
	public class ChartControl2 : System.Windows.Forms.Control
	{

		#region Generated Code

		private NextGenLab.Chart.MouseMarkerControl mouseMarkerControl1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem miChartType;
		private System.Windows.Forms.MenuItem miXaxis;
		private System.Windows.Forms.MenuItem miYaxis;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem miTrace;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem miShow;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem cmdMerge;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem cmdCopyToClip;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem cmdExport;
		private System.Windows.Forms.MenuItem miFFT;
		private System.Windows.Forms.MenuItem miAdjX;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem miPrint;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.MenuItem miPrinting;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Windows.Forms.MenuItem miPrintSetup;
		private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem miFFTDi;
        private MenuItem menuItem21;
        private IContainer components;

        public ChartControl2()
		{
			InitializeComponent();
			Initialize();
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Chart));
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.miTrace = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.miChartType = new System.Windows.Forms.MenuItem();
			this.miXaxis = new System.Windows.Forms.MenuItem();
			this.miYaxis = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miShow = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.cmdMerge = new System.Windows.Forms.MenuItem();
			this.cmdExport = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.miPrintSetup = new System.Windows.Forms.MenuItem();
			this.miPrint = new System.Windows.Forms.MenuItem();
			this.miPrinting = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.cmdCopyToClip = new System.Windows.Forms.MenuItem();
			this.miFFT = new System.Windows.Forms.MenuItem();
			this.miFFTDi = new System.Windows.Forms.MenuItem();
			this.miAdjX = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.miTrace,
																						 this.menuItem10,
																						 this.miChartType,
																						 this.miXaxis,
																						 this.miYaxis,
																						 this.menuItem5,
																						 this.miShow,
																						 this.menuItem18,
																						 this.menuItem19,
																						 this.menuItem20,
																						 this.menuItem21});
			// 
			// miTrace
			// 
			this.miTrace.Index = 0;
			this.miTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem4,
																					this.menuItem11});
			this.miTrace.Text = "Pick Points";
			this.miTrace.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "Enabled";
			this.menuItem4.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Enabled = false;
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "Trace";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click_1);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Text = "-";
			// 
			// miChartType
			// 
			this.miChartType.Index = 2;
			this.miChartType.Text = "ChartType";
			// 
			// miXaxis
			// 
			this.miXaxis.Index = 3;
			this.miXaxis.Text = "X-Axis";
			// 
			// miYaxis
			// 
			this.miYaxis.Index = 4;
			this.miYaxis.Text = "Y-Axis";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 5;
			this.menuItem5.Text = "-";
			// 
			// miShow
			// 
			this.miShow.Index = 6;
			this.miShow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.menuItem16,
																				   this.menuItem15});
			this.miShow.Text = "Show";
			// 
			// menuItem16
			// 
			this.menuItem16.Checked = true;
			this.menuItem16.Index = 0;
			this.menuItem16.Text = "Legend";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Checked = true;
			this.menuItem15.Index = 1;
			this.menuItem15.Text = "Title";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 7;
			this.menuItem18.Text = "-";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 8;
			this.menuItem19.Text = "Adjust Axis";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 9;
			this.menuItem20.Text = "FFT";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 10;
			this.menuItem21.Text = "FFT Dialog";
			this.menuItem21.Click += new System.EventHandler(this.miFFTDi_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem13,
																					  this.menuItem6});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.cmdMerge,
																					  this.cmdExport,
																					  this.menuItem7,
																					  this.menuItem22,
																					  this.miPrintSetup,
																					  this.miPrint,
																					  this.miPrinting,
																					  this.menuItem9,
																					  this.menuItem8,
																					  this.menuItem12});
			this.menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.menuItem1.Text = "File";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItem3.Text = "Open";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// cmdMerge
			// 
			this.cmdMerge.Index = 1;
			this.cmdMerge.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.cmdMerge.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
			this.cmdMerge.Text = "Merge";
			this.cmdMerge.Click += new System.EventHandler(this.cmdMerge_Click);
			// 
			// cmdExport
			// 
			this.cmdExport.Index = 2;
			this.cmdExport.Text = "Export";
			this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem7.Text = "Save";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_1);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 4;
			this.menuItem22.Text = "-";
			// 
			// miPrintSetup
			// 
			this.miPrintSetup.Index = 5;
			this.miPrintSetup.Text = "Print Setup";
			this.miPrintSetup.Click += new System.EventHandler(this.miPrintSetup_Click);
			// 
			// miPrint
			// 
			this.miPrint.Index = 6;
			this.miPrint.Text = "Print Preview";
			this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
			// 
			// miPrinting
			// 
			this.miPrinting.Index = 7;
			this.miPrinting.Text = "Print";
			this.miPrinting.Click += new System.EventHandler(this.miPrinting_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "-";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 9;
			this.menuItem8.Text = "Close";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 10;
			this.menuItem12.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 1;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem17,
																					   this.menuItem14,
																					   this.menuItem2});
			this.menuItem13.MergeOrder = 2;
			this.menuItem13.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.menuItem13.Text = "View";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "-";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.menuItem14.Text = "Pick Points";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.cmdCopyToClip,
																					  this.miFFT,
																					  this.miFFTDi,
																					  this.miAdjX});
			this.menuItem6.Text = "Edit";
			// 
			// cmdCopyToClip
			// 
			this.cmdCopyToClip.Index = 0;
			this.cmdCopyToClip.Text = "Copy to Clipboard";
			this.cmdCopyToClip.Click += new System.EventHandler(this.cmdCopyToClip_Click);
			// 
			// miFFT
			// 
			this.miFFT.Index = 1;
			this.miFFT.Text = "FFT";
			this.miFFT.Click += new System.EventHandler(this.miFFT_Click);
			// 
			// miFFTDi
			// 
			this.miFFTDi.Index = 2;
			this.miFFTDi.Text = "FFT Dialog";
			this.miFFTDi.Click += new System.EventHandler(this.miFFTDi_Click);
			// 
			// miAdjX
			// 
			this.miAdjX.Index = 3;
			this.miAdjX.Text = "Adujst Axis";
			this.miAdjX.Click += new System.EventHandler(this.miAdjX_Click);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(731, 17);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// Chart
			// 
			//this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(648, 361);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			//this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			//this.KeyPreview = true;
			//this.Menu = this.mainMenu1;
			this.Name = "Chart";
			this.Text = "Chart";

		}
		#endregion

		#endregion

		MenuItem prev_charttype;
		MenuItem p_xaxt;
		MenuItem p_xayt;
		MenuItem p_ctt;
		MenuItem miTraceType;
		Markers markers;
		ChartPrint cp;
		FFTDialog fftdialog;

		public PrintDocument PrintDocument{get{return cp.PrintDocument;}set{cp.PrintDocument = value;}}		

		private void Initialize()
		{
			
			
			//Init original ChartData
			ChartData original = ChartData.GetInstance();

			//Initialize mousemarkercontrol
			this.mouseMarkerControl1 = new MouseMarkerControl();
			this.mouseMarkerControl1.Dock = DockStyle.Fill;
			this.mouseMarkerControl1.ContextMenu = this.contextMenu1;
			this.mouseMarkerControl1.PickPoints = false;
			this.mouseMarkerControl1.TraceValues = false;
			this.mouseMarkerControl1.NewMarker += new NextGenLab.Chart.MouseMarkerControl.NewMarkerHandler(mouseMarkerControl1_NewMarker);
			this.mouseMarkerControl1.ForeColor = ForeColor;
			this.mouseMarkerControl1.BackColor = BackColor;
			
			//	this.mouseMarkerControl1.ChartData = original;
			this.Controls.Add(this.mouseMarkerControl1);


			//Initialize printer
			cp = new ChartPrint(mouseMarkerControl1);

			//Init splitter
			Splitter sp = new Splitter();
			sp.Dock = DockStyle.Bottom;
			sp.MinSize = 3;
			this.Controls.Add(sp);

			//Init markers window
			markers = new Markers();
			markers.Visible = false;
			markers.Dock = DockStyle.Bottom;
			markers.Size = new Size(50,100);
			this.Controls.Add(markers);

			MenuItem m;
			
			//Get ChartTypes
			string[] strs = Enum.GetNames(typeof(ChartType));
			foreach(string s in strs)
			{
				m = new MenuItem(s,new EventHandler(Click_ChartType));
				this.miChartType.MenuItems.Add(m);
			}

			//X-Axis
			//MenuItem mi = new MenuItem("Type");
			//miXaxis.MenuItems.Add(mi);
			strs = Enum.GetNames(typeof(AxisType));
			foreach(string s in strs)
			{
				m = new MenuItem(s,new EventHandler(Click_AxisTypeX));
				miXaxis.MenuItems.Add(m);
			}

			//Y-Axis
			//mi = new MenuItem("Type");
			//miYaxis.MenuItems.Add(mi);
			foreach(string s in strs)
			{
				m = new MenuItem(s,new EventHandler(Click_AxisTypeY));
				miYaxis.MenuItems.Add(m);
			}

			//Trace
			miTraceType = new MenuItem("Type");
			miTraceType.Enabled = false;
			miTrace.MenuItems.Add(miTraceType);
			strs = Enum.GetNames(typeof(ChartTraceType));
			foreach(string s in strs)
			{
				m= new MenuItem(s,new EventHandler(Click_ChartTraceType));
				miTraceType.MenuItems.Add(m);
			}
		}


		#region Open 
		private void menuItem3_Click(object sender, System.EventArgs e){Open(false);}
		private void cmdMerge_Click(object sender, System.EventArgs e){Open(true);}

		
		void Open(bool Merge)
		{
			if(!Merge)
				this.mouseMarkerControl1.ChartDataList.Clear();

			FileFactory fc = new FileFactory(this.mouseMarkerControl1);

			this.openFileDialog1.Filter = fc.GetOpenFilter();
			this.openFileDialog1.InitialDirectory = Application.StartupPath;
			this.openFileDialog1.Multiselect = Merge;
			if(DialogResult.OK == this.openFileDialog1.ShowDialog())
			{
				IChartFile icf = fc.GetChartFile(this.openFileDialog1.FilterIndex);

				if(icf == null)
					return;

				icf.NewChartData +=new NewChartDataHandler(Open);
				this.mouseMarkerControl1.SuspendDrawing = true;

				foreach(string filename in this.openFileDialog1.FileNames)
				{
					using(Stream s = File.OpenRead(filename))
					{
						icf.Open(s,Merge);
					}
				}
				this.mouseMarkerControl1.SuspendDrawing = false;
				this.mouseMarkerControl1.Invalidate();
			}
			GC.Collect();
		}

		public void Open(string filename, bool Merge)
		{
			using(Stream s = File.OpenRead(filename))
			{
				Open(s,Merge);
			}
		}

		public void Open(Stream s, bool Merge)
		{
			this.mouseMarkerControl1.SuspendDrawing = true;
			if(!Merge)
				this.mouseMarkerControl1.ChartDataList.Clear();

			IChartFile cf = FileFactory.GetChartFile(s);
			cf.NewChartData +=new NewChartDataHandler(Open);
			cf.Open(s,Merge);
			//GC.Collect();
			this.mouseMarkerControl1.SuspendDrawing = false;
			this.mouseMarkerControl1.Invalidate();
		}
		
		public void Open(ChartData cd, bool Merge)
		{
			if(!Merge)
				this.mouseMarkerControl1.ChartDataList.Clear();

			this.mouseMarkerControl1.AddChartData(cd);
			this.Text = this.mouseMarkerControl1.ChartDataList[0].Title;

			//fftdialog = new FFTDialog(this.mouseMarkerControl1.ChartDataList, this.MdiParent);
		}
		
		#endregion

		#region Save
		//Save file
		private void menuItem7_Click_1(object sender, System.EventArgs e){Save(false);}
		private void cmdExport_Click(object sender, System.EventArgs e){Save(true);}
		
		void Save(bool export)
		{
			this.saveFileDialog1.AddExtension = true;
			FileFactory ff = new FileFactory(this.mouseMarkerControl1);
			if(export)
			{
				this.saveFileDialog1.Filter = ff.GetExportFilter();
			}
			else
			{
				this.saveFileDialog1.Filter = ff.GetSaveFilter(this.mouseMarkerControl1.ChartDataList);
			}

			if(DialogResult.OK == this.saveFileDialog1.ShowDialog(this))
			{
				IChartFile icf = ff.GetChartFile(this.saveFileDialog1.FilterIndex);
				if(icf != null)
				{
					using(Stream s = File.Open(this.saveFileDialog1.FileName,FileMode.Create,FileAccess.ReadWrite))
					{
						icf.Save(s,this.mouseMarkerControl1.ChartDataList);
					}
				}
			}
		}

		#endregion
		
		#region Trace Handlers

		//Enable trace
		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			this.menuItem4.Checked = !this.menuItem4.Checked;
			this.menuItem14.Checked = !this.menuItem14.Checked;
			this.menuItem11.Enabled = this.menuItem4.Checked;
			this.mouseMarkerControl1.PickPoints = this.menuItem14.Checked;
			markers.Visible = this.menuItem14.Checked;
		}

		private void Click_ChartTraceType(object sender,System.EventArgs e)
		{
			MenuItem m = (MenuItem)sender;
			this.mouseMarkerControl1.TraceType = (ChartTraceType)Enum.Parse(typeof(ChartTraceType),m.Text,true);
			m.Checked = true;
			if(p_ctt != null)
				p_ctt.Checked = false;
			p_ctt = m;
			this.mouseMarkerControl1.Invalidate();
		}

		//Trace values handler
		private void menuItem11_Click_1(object sender, System.EventArgs e)
		{
			this.menuItem11.Checked = ! this.menuItem11.Checked;
			this.mouseMarkerControl1.TraceValues = this.menuItem11.Checked;
			miTraceType.Enabled = this.menuItem11.Checked;
			this.mouseMarkerControl1.Invalidate();
		
		}

		//New Trace value captured
		private void mouseMarkerControl1_NewMarker(PointF[] real,string[] names,Color[] colors)
		{
			markers.Visible= true;
			markers.AddPoints(real,names,colors);
			this.menuItem14.Checked = true;
		}

		#endregion

		#region Axis Handlers
		private void Click_AxisTypeY(object sender,System.EventArgs e)
		{
			MenuItem m = (MenuItem)sender;
			this.mouseMarkerControl1.AxisTypeY = (AxisType)Enum.Parse(typeof(AxisType),m.Text,true);
			m.Checked = true;
			if(p_xayt != null)
				p_xayt.Checked = false;
			p_xayt = m;
			this.mouseMarkerControl1.Invalidate();

		}

		private void Click_AxisTypeX(object sender,System.EventArgs e)
		{
			MenuItem m = (MenuItem)sender;
			this.mouseMarkerControl1.AxisTypeX = (AxisType)Enum.Parse(typeof(AxisType),m.Text,true);
			m.Checked = true;
			if(p_xaxt != null)
				p_xaxt.Checked = false;
			p_xaxt = m;
			this.mouseMarkerControl1.Invalidate();
		}

		#endregion

		#region Chart Handlers
		//ChartType
		private void Click_ChartType(object sender,System.EventArgs e)
		{
			MenuItem m = (MenuItem)sender;
			this.mouseMarkerControl1.ChartType = (ChartType)Enum.Parse(typeof(ChartType),m.Text,true);
			m.Checked = true;
			if(prev_charttype != null)
				prev_charttype.Checked = false;
			prev_charttype = m;
			this.mouseMarkerControl1.Invalidate();
		}

		//Show Title
		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			this.menuItem15.Checked = !this.menuItem15.Checked;
			this.mouseMarkerControl1.ShowTitle = this.menuItem15.Checked;
			this.mouseMarkerControl1.Invalidate();
		
		}
		
		//Show Legend
		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			this.menuItem16.Checked = !this.menuItem16.Checked;
			this.mouseMarkerControl1.ShowLegend = this.menuItem16.Checked;		
			this.mouseMarkerControl1.Invalidate();
		}
		#endregion

		#region About Handler
		Form f;
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			f = new Form();
			f.FormBorderStyle = FormBorderStyle.None;
			f.StartPosition = FormStartPosition.CenterParent;
			f.BackColor = Color.White;
			f.Size = new Size(200,100);
			Panel p = new Panel();
			p.Dock = DockStyle.Fill;
			p.BorderStyle = BorderStyle.FixedSingle;
			f.Controls.Add(p);
			Label rt = new Label();
			rt.Enabled = true;
			rt.Dock = DockStyle.Fill;
			p.Controls.Add(rt);
			rt.Text = @"Ngl Chart Control:
Zoom     Ctrl-Right Mouse Button
UnZoom   Z

Copyright NTNU 2004
";
			LinkLabel close = new LinkLabel();
			close.Text = "Close";
			close.Dock = DockStyle.Bottom;
			p.Controls.Add(close);
			close.Click +=new EventHandler(close_Click);
			f.ShowDialog(this);

		}

		private void close_Click(object sender, EventArgs e)
		{
			if(f != null)
				f.Close();
		}
		#endregion


		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			this.mouseMarkerControl1.Invalidate();
			base.OnInvalidated (e);
		}


		private void cmdCopyToClip_Click(object sender, System.EventArgs e)
		{
			
			System.Windows.Forms.Clipboard.SetDataObject(this.mouseMarkerControl1.GetImage(),true);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			//this.Close();
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			foreach(MenuItem m in this.miChartType.MenuItems)
			{
				if(m.Text == this.mouseMarkerControl1.ChartType.ToString())
				{
					m.Checked = true;
					prev_charttype = m;
				}
				else
					m.Checked = false;
			}

			foreach(MenuItem m in this.miXaxis.MenuItems)
			{
				if(m.Text == this.mouseMarkerControl1.AxisTypeX.ToString())
				{
					m.Checked = true;
					p_xaxt = m;
				}
				else
					m.Checked = false;
			}

			foreach(MenuItem m in this.miYaxis.MenuItems)
			{
				if(m.Text == this.mouseMarkerControl1.AxisTypeY.ToString())
				{
					m.Checked = true;
					p_xayt = m;
				}
				else
					m.Checked = false;
			}

			foreach(MenuItem m in this.miTraceType.MenuItems)
			{
				if(m.Text == this.mouseMarkerControl1.TraceType.ToString())
				{
					m.Checked = true;
					p_ctt = m;
				}
				else
					m.Checked = false;
			}

			base.OnPaint (e);
		}

		private void miFFT_Click(object sender, System.EventArgs e)
		{
			double[][] vals;
			FFT fft = new FFT();
			ChartData cdr;
			ChartData[] cds = this.mouseMarkerControl1.ChartDataList.ToArray();
			foreach(ChartData cd in cds)
			{
				vals = cd.Y;
				for(int i=0;i<vals.Length;i++)
				{
					fft.PowerSpectralDensity(vals[i],out cdr,new Hanning(),1);
					Chart c= new Chart();
                    if(cd.TitlesY.Length > i)
					    cdr.Title = "fft(" + cd.TitlesY[i] + ")";
					cdr.TitleX = "frequency";
					cdr.AxisLabelX = "[fs]";
			//		c.MdiParent = this.MdiParent;
					c.Open(cdr,false);
					c.Show();
				}
			}
		}

		private void miFFTDi_Click(object sender, System.EventArgs e)
		{
           // fftdialog.MdiPar = this.MdiParent;
            fftdialog.ShowDialog(this);
		
		}

		private void miAdjX_Click(object sender, System.EventArgs e)
		{
			FormAdjAxis fad = new FormAdjAxis(this.mouseMarkerControl1);
			fad.Text = "Adjust axis: " + this.Text;
			fad.Dock = DockStyle.Bottom;
			this.Controls.Add(fad);
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			miAdjX_Click(null,null);
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			miFFT_Click(null,null);
		}

		private void miPrint_Click(object sender, System.EventArgs e)
		{
			this.printPreviewDialog1.Document = cp.PrintDocument;
			this.printPreviewDialog1.ShowDialog();
		}

		private void miPrinting_Click(object sender, System.EventArgs e)
		{
			this.printDialog1.Document = cp.PrintDocument;
			this.printDialog1.ShowDialog();
		}

		private void miPrintSetup_Click(object sender, System.EventArgs e)
		{
			this.pageSetupDialog1.Document = cp.PrintDocument;
			this.pageSetupDialog1.ShowDialog();
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			if(this.mouseMarkerControl1 != null)
			this.mouseMarkerControl1.ForeColor = this.ForeColor;
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			if(this.mouseMarkerControl1 !=null)
			this.mouseMarkerControl1.BackColor = this.BackColor;
		}



		

		


	}
}
