using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using NextGenLab.Chart;
using NextGenLab.Chart.FileTypes;
using System.Xml;
using System.Drawing.Printing;
using System.Xml.XPath;
using System.Threading;

namespace NextGenLab.Chart
{
    /// <summary>
    /// Summary description for Chart.
    /// </summary>
    public class Chart : System.Windows.Forms.Form
    {

        #region Generated Code

        private NextGenLab.Chart.MouseMarkerControl mouseMarkerControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem miChartType;
        private System.Windows.Forms.MenuItem miXaxis;
        private System.Windows.Forms.MenuItem miYaxis;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem miTrace;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem miShow;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private MenuStrip menuStrip1;

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem mergeToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem printSetupToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator asdfToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copytoClipboardToolStripMenuItem;
        private ToolStripMenuItem fFTDialogToolStripMenuItem;
        private ToolStripMenuItem adjustAxisToolStripMenuItem;
        private ToolStripMenuItem pickPointsToolStripMenuItem;
        private MenuItem miFullNameLegend;
        private MenuItem miNumberDecimals;
        private MenuItem miND2;
        private MenuItem miND4;
        private MenuItem miND6;
        private ToolStripMenuItem asVectorToolStripMenuItem;
        private ToolStripMenuItem asBitmapToolStripMenuItem;
        private MenuItem menuItem1;
        private MenuItem miProperties;
        private MenuItem menuItem3;
        private MenuItem miMath;
        private ToolStripMenuItem colorThemesToolStripMenuItem;
        private ToolStripMenuItem themeGeneratorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton4;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem1;
        private ToolStripDropDownButton tEdit;
        private ToolStripMenuItem adjustAxisToolStripMenuItem2;
        private ToolStripMenuItem propertiesToolStripMenuItem1;
        private ToolStripMenuItem copyToClipboardToolStripMenuItem2;
        private ToolStripMenuItem bitmapToolStripMenuItem1;
        private ToolStripMenuItem vectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem printSetupToolStripMenuItem2;
        private ToolStripMenuItem printPreviewToolStripMenuItem2;
        private ToolStripMenuItem printToolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem miColorThemes;
        private ToolStripMenuItem createColorThemeToolStripMenuItem;
        private ToolStripMenuItem traceToolStripMenuItem;
        private ToolStripMenuItem numberOfDecimalsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton tSetOversample;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox toolStripTextBox2;
        private IContainer components;
        double fs_scope = 16;
        private ToolStripTextBox textBoxADC;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox textBoxIDDA;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox textBoxText;
        private ToolStripLabel toolStripLabel5;
        private ToolStripButton tReadCont;
        private ToolStripButton tSupplyLow;
        private ToolStripLabel toolStripLabel6;
        private ToolStripTextBox tbMSB;
        double pow_scope = 16;

        public Chart()
        {
            InitializeComponent();
            Initialize();

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
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
            this.miFullNameLegend = new System.Windows.Forms.MenuItem();
            this.miNumberDecimals = new System.Windows.Forms.MenuItem();
            this.miND2 = new System.Windows.Forms.MenuItem();
            this.miND4 = new System.Windows.Forms.MenuItem();
            this.miND6 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miProperties = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miMath = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdfToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copytoClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asVectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.colorThemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printSetupToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.adjustAxisToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.numberOfDecimalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.traceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miColorThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.createColorThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tReadCont = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.textBoxText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.textBoxIDDA = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.textBoxADC = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tSetOversample = new System.Windows.Forms.ToolStripButton();
            this.tSupplyLow = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tbMSB = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuItem1,
            this.miProperties,
            this.menuItem3,
            this.miMath});
            // 
            // miTrace
            // 
            this.miTrace.Index = 0;
            this.miTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem11});
            this.miTrace.Text = "Pick Points";
            this.miTrace.Click += new System.EventHandler(this.EhEnableTrace);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Enabled";
            this.menuItem4.Click += new System.EventHandler(this.EhEnableTrace);
            // 
            // menuItem11
            // 
            this.menuItem11.Enabled = false;
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "Trace";
            this.menuItem11.Click += new System.EventHandler(this.EhTrace);
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
            this.menuItem15,
            this.miFullNameLegend,
            this.miNumberDecimals});
            this.miShow.Text = "Show";
            // 
            // menuItem16
            // 
            this.menuItem16.Checked = true;
            this.menuItem16.Index = 0;
            this.menuItem16.Text = "Legend";
            this.menuItem16.Click += new System.EventHandler(this.EhShowLegend);
            // 
            // menuItem15
            // 
            this.menuItem15.Checked = true;
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "Title";
            this.menuItem15.Click += new System.EventHandler(this.EhShowTitle);
            // 
            // miFullNameLegend
            // 
            this.miFullNameLegend.Index = 2;
            this.miFullNameLegend.Text = "Fullname on legend";
            this.miFullNameLegend.Click += new System.EventHandler(this.EhShowFullnames);
            // 
            // miNumberDecimals
            // 
            this.miNumberDecimals.Index = 3;
            this.miNumberDecimals.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miND2,
            this.miND4,
            this.miND6});
            this.miNumberDecimals.Text = "Number of decimals";
            // 
            // miND2
            // 
            this.miND2.Checked = true;
            this.miND2.Index = 0;
            this.miND2.Text = "2";
            this.miND2.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // miND4
            // 
            this.miND4.Index = 1;
            this.miND4.Text = "4";
            this.miND4.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // miND6
            // 
            this.miND6.Index = 2;
            this.miND6.Text = "6";
            this.miND6.Click += new System.EventHandler(this.EhChangeNumberDecimals);
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
            this.menuItem19.Click += new System.EventHandler(this.EhShowAdjustAxis);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 9;
            this.menuItem1.Text = "Post Process";
            this.menuItem1.Click += new System.EventHandler(this.EhShowPostProcess);
            // 
            // miProperties
            // 
            this.miProperties.Index = 10;
            this.miProperties.Text = "Properties";
            this.miProperties.Click += new System.EventHandler(this.EhShowProperties);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 11;
            this.menuItem3.Text = "-";
            // 
            // miMath
            // 
            this.miMath.Index = 12;
            this.miMath.Text = "Math";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.pickPointsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.asdfToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.EhOpen);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.mergeToolStripMenuItem.Text = "Merge";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.EhMerge);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.EhSaveAs);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.EhSave);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printSetupToolStripMenuItem.Text = "Print Setup";
            this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.EhPrintSetup);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.EhShowPrintPreview);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.EhPrint);
            // 
            // asdfToolStripMenuItem
            // 
            this.asdfToolStripMenuItem.Name = "asdfToolStripMenuItem";
            this.asdfToolStripMenuItem.Size = new System.Drawing.Size(140, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copytoClipboardToolStripMenuItem,
            this.fFTDialogToolStripMenuItem,
            this.adjustAxisToolStripMenuItem,
            this.toolStripSeparator1,
            this.colorThemesToolStripMenuItem,
            this.themeGeneratorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copytoClipboardToolStripMenuItem
            // 
            this.copytoClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asVectorToolStripMenuItem,
            this.asBitmapToolStripMenuItem});
            this.copytoClipboardToolStripMenuItem.Name = "copytoClipboardToolStripMenuItem";
            this.copytoClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copytoClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            // 
            // asVectorToolStripMenuItem
            // 
            this.asVectorToolStripMenuItem.Name = "asVectorToolStripMenuItem";
            this.asVectorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.asVectorToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.asVectorToolStripMenuItem.Text = "As Vector";
            this.asVectorToolStripMenuItem.Click += new System.EventHandler(this.EhCopyClipboardVector);
            // 
            // asBitmapToolStripMenuItem
            // 
            this.asBitmapToolStripMenuItem.Name = "asBitmapToolStripMenuItem";
            this.asBitmapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.asBitmapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.asBitmapToolStripMenuItem.Text = "As Bitmap";
            this.asBitmapToolStripMenuItem.Click += new System.EventHandler(this.EhCopyClipboardBitmap);
            // 
            // fFTDialogToolStripMenuItem
            // 
            this.fFTDialogToolStripMenuItem.Name = "fFTDialogToolStripMenuItem";
            this.fFTDialogToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fFTDialogToolStripMenuItem.Text = "FFT Dialog";
            this.fFTDialogToolStripMenuItem.Click += new System.EventHandler(this.EhFFTDialog);
            // 
            // adjustAxisToolStripMenuItem
            // 
            this.adjustAxisToolStripMenuItem.Name = "adjustAxisToolStripMenuItem";
            this.adjustAxisToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.adjustAxisToolStripMenuItem.Text = "Adjust Axis";
            this.adjustAxisToolStripMenuItem.Click += new System.EventHandler(this.EhShowAdjustAxis);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // colorThemesToolStripMenuItem
            // 
            this.colorThemesToolStripMenuItem.Name = "colorThemesToolStripMenuItem";
            this.colorThemesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.colorThemesToolStripMenuItem.Text = "Color Themes";
            // 
            // themeGeneratorToolStripMenuItem
            // 
            this.themeGeneratorToolStripMenuItem.Name = "themeGeneratorToolStripMenuItem";
            this.themeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.themeGeneratorToolStripMenuItem.Text = "Theme Generator";
            this.themeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.EhShowThemeGenerator);
            // 
            // pickPointsToolStripMenuItem
            // 
            this.pickPointsToolStripMenuItem.Name = "pickPointsToolStripMenuItem";
            this.pickPointsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.pickPointsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.pickPointsToolStripMenuItem.Text = "Pick Points";
            this.pickPointsToolStripMenuItem.Click += new System.EventHandler(this.EhEnableTrace);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton4,
            this.tEdit,
            this.toolStripButton1,
            this.toolStripButton2,
            this.tReadCont,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripLabel2,
            this.toolStripTextBox2,
            this.textBoxText,
            this.toolStripLabel5,
            this.textBoxIDDA,
            this.toolStripLabel4,
            this.textBoxADC,
            this.toolStripLabel3,
            this.tSetOversample,
            this.tSupplyLow,
            this.toolStripLabel6,
            this.tbMSB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(828, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.printSetupToolStripMenuItem2,
            this.printPreviewToolStripMenuItem2,
            this.printToolStripMenuItem2,
            this.toolStripSeparator4,
            this.closeToolStripMenuItem1});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton4.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem1.Image")));
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.EhOpen);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.EhSave);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.EhSaveAs);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // printSetupToolStripMenuItem2
            // 
            this.printSetupToolStripMenuItem2.Name = "printSetupToolStripMenuItem2";
            this.printSetupToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.printSetupToolStripMenuItem2.Text = "Print Setup";
            this.printSetupToolStripMenuItem2.Click += new System.EventHandler(this.EhPrintSetup);
            // 
            // printPreviewToolStripMenuItem2
            // 
            this.printPreviewToolStripMenuItem2.Name = "printPreviewToolStripMenuItem2";
            this.printPreviewToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.printPreviewToolStripMenuItem2.Text = "Print Preview";
            this.printPreviewToolStripMenuItem2.Click += new System.EventHandler(this.EhShowPrintPreview);
            // 
            // printToolStripMenuItem2
            // 
            this.printToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem2.Image")));
            this.printToolStripMenuItem2.Name = "printToolStripMenuItem2";
            this.printToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.printToolStripMenuItem2.Text = "Print";
            this.printToolStripMenuItem2.Click += new System.EventHandler(this.EhPrint);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.EhClose);
            // 
            // tEdit
            // 
            this.tEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustAxisToolStripMenuItem2,
            this.propertiesToolStripMenuItem1,
            this.numberOfDecimalsToolStripMenuItem,
            this.traceToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem2,
            this.toolStripSeparator2,
            this.miColorThemes,
            this.createColorThemeToolStripMenuItem});
            this.tEdit.Image = ((System.Drawing.Image)(resources.GetObject("tEdit.Image")));
            this.tEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tEdit.Name = "tEdit";
            this.tEdit.Size = new System.Drawing.Size(40, 22);
            this.tEdit.Text = "Edit";
            // 
            // adjustAxisToolStripMenuItem2
            // 
            this.adjustAxisToolStripMenuItem2.Name = "adjustAxisToolStripMenuItem2";
            this.adjustAxisToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.adjustAxisToolStripMenuItem2.Size = new System.Drawing.Size(183, 22);
            this.adjustAxisToolStripMenuItem2.Text = "Adjust Axis";
            this.adjustAxisToolStripMenuItem2.Click += new System.EventHandler(this.EhShowAdjustAxis);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.EhShowProperties);
            // 
            // numberOfDecimalsToolStripMenuItem
            // 
            this.numberOfDecimalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.numberOfDecimalsToolStripMenuItem.Name = "numberOfDecimalsToolStripMenuItem";
            this.numberOfDecimalsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.numberOfDecimalsToolStripMenuItem.Text = "Number of Decimals";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem6.Text = "2";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "4";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "6";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem5.Text = "10";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.EhChangeNumberDecimals);
            // 
            // traceToolStripMenuItem
            // 
            this.traceToolStripMenuItem.Name = "traceToolStripMenuItem";
            this.traceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.traceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.traceToolStripMenuItem.Text = "Pick Points";
            this.traceToolStripMenuItem.Click += new System.EventHandler(this.EhEnableTrace);
            // 
            // copyToClipboardToolStripMenuItem2
            // 
            this.copyToClipboardToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitmapToolStripMenuItem1,
            this.vectorToolStripMenuItem});
            this.copyToClipboardToolStripMenuItem2.Name = "copyToClipboardToolStripMenuItem2";
            this.copyToClipboardToolStripMenuItem2.Size = new System.Drawing.Size(183, 22);
            this.copyToClipboardToolStripMenuItem2.Text = "Copy To Clipboard";
            // 
            // bitmapToolStripMenuItem1
            // 
            this.bitmapToolStripMenuItem1.Name = "bitmapToolStripMenuItem1";
            this.bitmapToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.bitmapToolStripMenuItem1.Text = "Bitmap";
            this.bitmapToolStripMenuItem1.Click += new System.EventHandler(this.EhCopyClipboardBitmap);
            // 
            // vectorToolStripMenuItem
            // 
            this.vectorToolStripMenuItem.Name = "vectorToolStripMenuItem";
            this.vectorToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.vectorToolStripMenuItem.Text = "Vector";
            this.vectorToolStripMenuItem.Click += new System.EventHandler(this.EhCopyClipboardVector);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // miColorThemes
            // 
            this.miColorThemes.Name = "miColorThemes";
            this.miColorThemes.Size = new System.Drawing.Size(183, 22);
            this.miColorThemes.Text = "Color Themes";
            // 
            // createColorThemeToolStripMenuItem
            // 
            this.createColorThemeToolStripMenuItem.Name = "createColorThemeToolStripMenuItem";
            this.createColorThemeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.createColorThemeToolStripMenuItem.Text = "Create Color Theme";
            this.createColorThemeToolStripMenuItem.Click += new System.EventHandler(this.EhShowThemeGenerator);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton1.Text = "Read";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton2.Text = "Read FFT";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tReadCont
            // 
            this.tReadCont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tReadCont.Image = ((System.Drawing.Image)(resources.GetObject("tReadCont.Image")));
            this.tReadCont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tReadCont.Name = "tReadCont";
            this.tReadCont.Size = new System.Drawing.Size(33, 22);
            this.tReadCont.Text = "Play";
            this.tReadCont.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tReadCont.Click += new System.EventHandler(this.tReadCont_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel1.Text = "FS:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(30, 25);
            this.toolStripTextBox1.Text = "16";
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "SMPL:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(30, 25);
            this.toolStripTextBox2.Text = "16";
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.toolStripTextBox2_TextChanged);
            // 
            // textBoxText
            // 
            this.textBoxText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(50, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel5.Text = "TXT";
            // 
            // textBoxIDDA
            // 
            this.textBoxIDDA.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.textBoxIDDA.Name = "textBoxIDDA";
            this.textBoxIDDA.Size = new System.Drawing.Size(30, 25);
            this.textBoxIDDA.Text = "18";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel4.Text = "IDDA";
            // 
            // textBoxADC
            // 
            this.textBoxADC.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.textBoxADC.Name = "textBoxADC";
            this.textBoxADC.Size = new System.Drawing.Size(20, 25);
            this.textBoxADC.Text = "6";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel3.Text = "ADC";
            // 
            // tSetOversample
            // 
            this.tSetOversample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSetOversample.Image = ((System.Drawing.Image)(resources.GetObject("tSetOversample.Image")));
            this.tSetOversample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSetOversample.Name = "tSetOversample";
            this.tSetOversample.Size = new System.Drawing.Size(39, 22);
            this.tSetOversample.Text = "OSR1";
            this.tSetOversample.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSetOversample.Click += new System.EventHandler(this.tSetOversampleClick);
            // 
            // tSupplyLow
            // 
            this.tSupplyLow.BackColor = System.Drawing.Color.Green;
            this.tSupplyLow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSupplyLow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSupplyLow.Name = "tSupplyLow";
            this.tSupplyLow.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel6.Text = "CalVal";
            // 
            // tbMSB
            // 
            this.tbMSB.Name = "tbMSB";
            this.tbMSB.Size = new System.Drawing.Size(100, 25);
            this.tbMSB.Text = "0,0,0";
            this.tbMSB.Click += new System.EventHandler(this.tbMSB_Click);
            // 
            // Chart
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(828, 467);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Chart";
            this.Text = "Chart";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        double osr = 1;
        FFTDialog fftdialog;
        FormAdjAxis fad;
        Form f;
        RsReadFFT rs;
        Thread playThread;
        string savePath;


        public delegate void OpenChartData(ChartData cd);

        event OpenChartData openChart; 

        public PrintDocument PrintDocument { get { return cp.PrintDocument; } set { cp.PrintDocument = value; } }

        private void Initialize()
        {
            osr = 1;

            openChart += Chart_openChart;
            //Init original ChartData
            ChartData original = ChartData.GetInstance();
            
            //Initialize mousemarkercontrol
            this.mouseMarkerControl1 = new MouseMarkerControl();
            this.mouseMarkerControl1.Dock = DockStyle.Fill;
            this.mouseMarkerControl1.ContextMenu = this.contextMenu1;
            this.mouseMarkerControl1.PickPoints = false;
            this.mouseMarkerControl1.TraceValues = false;
            this.mouseMarkerControl1.NewMarker += new NextGenLab.Chart.MouseMarkerControl.NewMarkerHandler(mouseMarkerControl1_NewMarker);
            //	this.mouseMarkerControl1.ChartData = original;
            this.mouseMarkerControl1.ForeColor = this.ForeColor;
            this.mouseMarkerControl1.BackColor = this.BackColor;
            this.Controls.Add(this.mouseMarkerControl1);
            this.mouseMarkerControl1.BringToFront();
            this.mouseMarkerControl1.AllowDrop = true;
            this.mouseMarkerControl1.DragDrop += new DragEventHandler(mouseMarkerControl1_DragDrop);
            this.mouseMarkerControl1.DragEnter += delegate(object sender, DragEventArgs e) { e.Effect = DragDropEffects.All; };


            //initialize instrument connection and storage
            //rs = new RsReadFFT("TCPIP::129.241.3.121::hislip0::INSTR");
            rs = new RsReadFFT("TCPIP::129.241.3.145::HISLIP");
            savePath = @"C:\cawu\measurements\river_mpw2\data\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;


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
            markers.Size = new Size(50, 100);
            this.Controls.Add(markers);

            MenuItem m;

            //Get ChartTypes
            string[] strs = Enum.GetNames(typeof(ChartType));
            foreach (string s in strs)
            {
                m = new MenuItem(s, new EventHandler(EhChangeChartType));
                this.miChartType.MenuItems.Add(m);
            }

            //X-Axis
            //MenuItem mi = new MenuItem("Type");
            //miXaxis.MenuItems.Add(mi);
            strs = Enum.GetNames(typeof(AxisType));
            foreach (string s in strs)
            {
                m = new MenuItem(s, new EventHandler(EhChangeAxisTypeX));
                miXaxis.MenuItems.Add(m);
            }

            //Y-Axis
            //mi = new MenuItem("Type");
            //miYaxis.MenuItems.Add(mi);
            foreach (string s in strs)
            {
                m = new MenuItem(s, new EventHandler(EhChangeAxisTypeY));
                miYaxis.MenuItems.Add(m);
            }

            //Trace
            miTraceType = new MenuItem("Type");
            miTraceType.Enabled = false;
            miTrace.MenuItems.Add(miTraceType);
            strs = Enum.GetNames(typeof(ChartTraceType));
            foreach (string s in strs)
            {
                m = new MenuItem(s, new EventHandler(EhChangeTraceType));
                miTraceType.MenuItems.Add(m);
            }

            PostProcess.PostProcessGraphLoad ppgl = new NextGenLab.Chart.PostProcess.PostProcessGraphLoad(this, this.mouseMarkerControl1, this.miMath, null);

            LoadThemes();
        }

        

        void LoadThemes()
        {
            //Load Color Themes

            this.miColorThemes.DropDownItems.Clear();

            List<ColorThemeBase> colorthemes = new List<ColorThemeBase>();
            colorthemes.Add(new ColorThemes.CTDefault());
            colorthemes.Add(new ColorThemes.CTBlackWhite());
            colorthemes.Add(new ColorThemes.CTAutoRGB());


            string themepath = Application.StartupPath + Path.DirectorySeparatorChar + "Themes";
            if (Directory.Exists(themepath))
            {
                string[] themefiles = Directory.GetFiles(themepath);
                foreach (string themefile in themefiles)
                {
                    colorthemes.Add(new ColorThemes.CTColorTheme(themefile));
                }
            }

            foreach (ColorThemeBase ct in colorthemes)
            {
                ToolStripMenuItem mt = new ToolStripMenuItem(ct.Name);
                mt.Tag = ct;
                mt.Click += new EventHandler(ColorThemeSelect);
                this.miColorThemes.DropDownItems.Add((ToolStripItem)mt);
            }

        }

        void ColorThemeSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem mt = (ToolStripMenuItem)sender;
            this.mouseMarkerControl1.ColorTheme = (ColorThemeBase)mt.Tag;
            this.mouseMarkerControl1.Invalidate();   
        }

        void Open(bool Merge)
        {


            FileFactory fc = new FileFactory(this.mouseMarkerControl1);

            this.openFileDialog1.Filter = fc.GetOpenFilter();
            this.openFileDialog1.InitialDirectory = Application.StartupPath;
            this.openFileDialog1.Multiselect = Merge;
            if (DialogResult.OK == this.openFileDialog1.ShowDialog())
            {
                if (!Merge)
                    this.mouseMarkerControl1.ChartDataList.Clear();

                IChartFile icf = fc.GetChartFile(this.openFileDialog1.FilterIndex);

                if (icf == null)
                    return;

                icf.NewChartData += new NewChartDataHandler(Open);
                this.mouseMarkerControl1.SuspendDrawing = true;

                foreach (string filename in this.openFileDialog1.FileNames)
                {
                    using (Stream s = File.OpenRead(filename))
                    {
                        icf.Open(s, Merge);
                    }
                }
                this.mouseMarkerControl1.SuspendDrawing = false;
                this.mouseMarkerControl1.Invalidate();
            }
            GC.Collect();
        }

        public void Open(string filename, bool Merge)
        {
            using (Stream s = File.OpenRead(filename))
            {
                Open(s, Merge);
            }
        }

        public void Open(Stream s, bool Merge)
        {
            this.mouseMarkerControl1.SuspendDrawing = true;
            if (!Merge)
                this.mouseMarkerControl1.ChartDataList.Clear();

            IChartFile cf = FileFactory.GetChartFile(s);
            cf.NewChartData += new NewChartDataHandler(Open);
            cf.Open(s, Merge);
            //GC.Collect();
            this.mouseMarkerControl1.SuspendDrawing = false;
            this.mouseMarkerControl1.Invalidate();
        }

        public void Open(ChartData cd, bool Merge)
        {
            if (!Merge)
                this.mouseMarkerControl1.ChartDataList.Clear();

            // if (cd.IsOK())
            // {

            this.mouseMarkerControl1.AddChartData(cd);

            // }
            this.Text = this.mouseMarkerControl1.ChartDataList[0].Title;

            fftdialog = new FFTDialog(this.mouseMarkerControl1.ChartDataList, this.MdiParent);
        }

        void Save(bool export)
        {
            this.saveFileDialog1.AddExtension = true;
            FileFactory ff = new FileFactory(this.mouseMarkerControl1);
            if (export)
            {
                this.saveFileDialog1.Filter = ff.GetExportFilter();
            }
            else
            {
                this.saveFileDialog1.Filter = ff.GetSaveFilter(this.mouseMarkerControl1.ChartDataList);
            }

            if (DialogResult.OK == this.saveFileDialog1.ShowDialog(this))
            {
                IChartFile icf = ff.GetChartFile(this.saveFileDialog1.FilterIndex);
                if (icf != null)
                {
                    using (Stream s = File.Open(this.saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        icf.Save(s, this.mouseMarkerControl1.ChartDataList);
                    }
                }
            }
        }

        void mouseMarkerControl1_NewMarker(PointF[] real, string[] names, Color[] colors)
        {
            markers.Visible = true;
            markers.AddPoints(real, names, colors);
            this.pickPointsToolStripMenuItem.Checked = true;
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            this.mouseMarkerControl1.Invalidate();
            base.OnInvalidated(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (MenuItem m in this.miChartType.MenuItems)
            {
                if (m.Text == this.mouseMarkerControl1.ChartType.ToString())
                {
                    m.Checked = true;
                    prev_charttype = m;
                }
                else
                    m.Checked = false;
            }

            foreach (MenuItem m in this.miXaxis.MenuItems)
            {
                if (m.Text == this.mouseMarkerControl1.AxisTypeX.ToString())
                {
                    m.Checked = true;
                    p_xaxt = m;
                }
                else
                    m.Checked = false;
            }

            foreach (MenuItem m in this.miYaxis.MenuItems)
            {
                if (m.Text == this.mouseMarkerControl1.AxisTypeY.ToString())
                {
                    m.Checked = true;
                    p_xayt = m;
                }
                else
                    m.Checked = false;
            }

            foreach (MenuItem m in this.miTraceType.MenuItems)
            {
                if (m.Text == this.mouseMarkerControl1.TraceType.ToString())
                {
                    m.Checked = true;
                    p_ctt = m;
                }
                else
                    m.Checked = false;
            }

            base.OnPaint(e);
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            if (this.mouseMarkerControl1 != null)
                this.mouseMarkerControl1.ForeColor = this.ForeColor;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.mouseMarkerControl1 != null)
                this.mouseMarkerControl1.BackColor = this.BackColor;
        }

        void mouseMarkerControl1_DragDrop(object sender, DragEventArgs e)
        {


            try
            {
                if (e.KeyState == 8)
                {
                    string s = (string)e.Data.GetData(DataFormats.StringFormat);
                    byte[] buffer = Convert.FromBase64String(s);
                    FileTypes.FtBnmc bnmc = new FtBnmc();
                    using (MemoryStream ms = new MemoryStream(buffer))
                    {
                        bnmc.NewChartData += new NewChartDataHandler(Open);
                        bnmc.Open(ms, true);
                        //GC.Collect();
                        this.mouseMarkerControl1.SuspendDrawing = false;
                        this.mouseMarkerControl1.Invalidate();
                        ms.Close();
                    }
                }
                else
                {
                    object[] files = (object[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string s in files)
                    {
                        Open(s, true); ;
                    }
                }
            }
            catch { }
        }

        private void EhOpen(object sender, System.EventArgs e) { Open(false); }
        private void EhMerge(object sender, System.EventArgs e) { Open(true); }
        private void EhSave(object sender, System.EventArgs e) { Save(false); }
        private void EhSaveAs(object sender, System.EventArgs e) { Save(true); }
        private void EhEnableTrace(object sender, System.EventArgs e)
        {
            this.menuItem4.Checked = !this.menuItem4.Checked;
            this.pickPointsToolStripMenuItem.Checked = !this.pickPointsToolStripMenuItem.Checked;
            //miTraceType.Enabled = this.menuItem4.Checked;
            this.menuItem11.Enabled = this.menuItem4.Checked;
            this.mouseMarkerControl1.PickPoints = this.pickPointsToolStripMenuItem.Checked;
            markers.Visible = this.pickPointsToolStripMenuItem.Checked;
        }
        private void EhChangeTraceType(object sender, System.EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            this.mouseMarkerControl1.TraceType = (ChartTraceType)Enum.Parse(typeof(ChartTraceType), m.Text, true);
            m.Checked = true;
            if (p_ctt != null)
                p_ctt.Checked = false;
            p_ctt = m;
            this.mouseMarkerControl1.Invalidate();
        }
        private void EhTrace(object sender, System.EventArgs e)
        {
            this.menuItem11.Checked = !this.menuItem11.Checked;
            this.mouseMarkerControl1.TraceValues = this.menuItem11.Checked;
            miTraceType.Enabled = this.menuItem11.Checked;
            this.mouseMarkerControl1.Invalidate();

        }
        private void EhChangeAxisTypeY(object sender, System.EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            this.mouseMarkerControl1.AxisTypeY = (AxisType)Enum.Parse(typeof(AxisType), m.Text, true);
            m.Checked = true;
            if (p_xayt != null)
                p_xayt.Checked = false;
            p_xayt = m;
            this.mouseMarkerControl1.Invalidate();

        }
        private void EhChangeAxisTypeX(object sender, System.EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            this.mouseMarkerControl1.AxisTypeX = (AxisType)Enum.Parse(typeof(AxisType), m.Text, true);
            m.Checked = true;
            if (p_xaxt != null)
                p_xaxt.Checked = false;
            p_xaxt = m;
            this.mouseMarkerControl1.Invalidate();
        }
        private void EhChangeChartType(object sender, System.EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            this.mouseMarkerControl1.ChartType = (ChartType)Enum.Parse(typeof(ChartType), m.Text, true);
            m.Checked = true;
            if (prev_charttype != null)
                prev_charttype.Checked = false;
            prev_charttype = m;
            this.mouseMarkerControl1.Invalidate();
        }
        private void EhShowTitle(object sender, System.EventArgs e)
        {
            this.menuItem15.Checked = !this.menuItem15.Checked;
            this.mouseMarkerControl1.ShowTitle = this.menuItem15.Checked;
            this.mouseMarkerControl1.Invalidate();

        }
        private void EhShowLegend(object sender, System.EventArgs e)
        {
            this.menuItem16.Checked = !this.menuItem16.Checked;
            this.mouseMarkerControl1.ShowLegend = this.menuItem16.Checked;
            this.mouseMarkerControl1.Invalidate();
        }
        private void EhAbout(object sender, System.EventArgs e)
        {
            f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.CenterParent;
            f.BackColor = Color.White;
            f.Size = new Size(200, 100);
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

Copyright Carsten Wulff 2004
";
            LinkLabel close = new LinkLabel();
            close.Text = "Close";
            close.Dock = DockStyle.Bottom;
            p.Controls.Add(close);
            close.Click += new EventHandler(EhAboutClose);
            f.ShowDialog(this);

        }
        private void EhAboutClose(object sender, EventArgs e)
        {
            if (f != null)
                f.Close();
        }
        private void EhCopyClipboardVector(object sender, System.EventArgs e)
        {
            Cursor tmp = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.mouseMarkerControl1.CopyToClipboard();
            this.Cursor = tmp;
        }
        private void EhCopyClipboardBitmap(object sender, EventArgs e)
        {
            Cursor tmp = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Clipboard.SetDataObject(this.mouseMarkerControl1.GetImage(), true);
            this.Cursor = tmp;
        }
        private void EhClose(object sender, System.EventArgs e)
        {

            this.Close();

        }
        private void EhFFTDialog(object sender, System.EventArgs e)
        {
            fftdialog.MdiPar = this.MdiParent;
            fftdialog.ShowDialog(this);

        }
        private void EhShowAdjustAxis(object sender, System.EventArgs e)
        {
            if (!this.adjustAxisToolStripMenuItem.Checked)
            {
                FormAdjAxis fa = new FormAdjAxis(this.mouseMarkerControl1);
                DockContainer dc = new DockContainer();
                dc.Size = new Size(100, 145);
                dc.AddToForm("Adjust axis:" + this.Text, fa, this, DockStyle.Bottom, this.adjustAxisToolStripMenuItem);
            }
        }
        private void EhShowPostProcess(object sender, EventArgs e)
        {
            if (!menuItem1.Checked)
            {
                FormPostProcess fpp = new FormPostProcess(this.mouseMarkerControl1.ChartDataList);

                DockContainer dc = new DockContainer();
                dc.AddToForm("Post Process", fpp, this, DockStyle.Right, this.menuItem1);
            }
        }
        private void EhShowProperties(object sender, EventArgs e)
        {

            if (!miProperties.Checked)
            {
                PropertiesControl pc = new PropertiesControl(this.mouseMarkerControl1);
                //FormPostProcess fpp = new FormPostProcess(this.mouseMarkerControl1.ChartDataList);

                DockContainer dc = new DockContainer();
                dc.Size = new Size(320, 200);
                dc.AddToForm("Properties", pc, this, DockStyle.Right, this.miProperties);
            }
        }
        private void EhShowPrintPreview(object sender, System.EventArgs e)
        {
            this.printPreviewDialog1.Document = cp.PrintDocument;
            this.printPreviewDialog1.ShowDialog();
        }
        private void EhPrint(object sender, System.EventArgs e)
        {
            this.printDialog1.Document = cp.PrintDocument;
            this.printDialog1.ShowDialog();
        }
        private void EhPrintSetup(object sender, System.EventArgs e)
        {
            this.pageSetupDialog1.Document = cp.PrintDocument;
            this.pageSetupDialog1.ShowDialog();
        }
        private void EhShowFullnames(object sender, EventArgs e)
        {
            this.mouseMarkerControl1.ChartDataList.ShowFullnameLegend = !this.miFullNameLegend.Checked;
            this.miFullNameLegend.Checked = !this.miFullNameLegend.Checked;
            this.mouseMarkerControl1.Refresh();
        }
        private void EhChangeNumberDecimals(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            foreach (ToolStripMenuItem m in this.numberOfDecimalsToolStripMenuItem.DropDownItems)
            {
                if (m != mi)
                {
                    m.Checked = false;
                }
                else
                {
                    m.Checked = true;
                }
            }

            int decimals = Int32.Parse(mi.Text);
            this.mouseMarkerControl1.NumberOfDecimals = decimals;
            this.mouseMarkerControl1.Refresh();
        }
        private void EhShowThemeGenerator(object sender, EventArgs e)
        {
            ThemeGenerator tg = new ThemeGenerator();
            tg.ShowDialog();
            this.LoadThemes();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            ChartData cd = rs.Capture(100,9);
          
            
            this.Open(cd, false);
            this.UseWaitCursor = false;

        }


        bool saveData = false;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            

            isPlay = false;
            saveData = true;
            playThread = new Thread(new ThreadStart(RunThread));
            playThread.Start();
            
           
          
        }

        bool isPlay = false;
        int count = 0;

        private void Chart_openChart(ChartData cd)
        {
            cd.Title = cd.Title + ", N=" + cd.X.Length*2  + "  (" + count.ToString() + ")";
            count++;
            this.Open(cd, false);
        }

    

        private void RunThread()
        {
            do
            {
                ChartData cd = RunFFT();
                object[] obj = new object[1];
                obj[0] = cd;
                this.Invoke(new OpenChartData(Chart_openChart), obj);

            } while (isPlay);

        }

        private void setColorRed()
        {
            tSupplyLow.BackColor = Color.Red;

        }

        private void setColorGreen()
        {

            tSupplyLow.BackColor = Color.Green;
        }

        private ChartData RunFFT()
        {


            string filename = "adc" + textBoxADC.Text + "_" + fs_scope + "MHz_" + textBoxIDDA.Text + "uA_" + textBoxText.Text + "_"  + DateTime.Now.Hour + "_" + DateTime.Now.Minute+ "_"+ DateTime.Now.Second + ".dat";

            string[] arr = tbMSB.Text.Split(',');
            if (arr.Length > 0)
            {
                rs.calval_msb = Convert.ToDouble(arr[0]);
            }
            if (arr.Length > 1)
            {
                rs.calval_msb1 = Convert.ToDouble(arr[1]);
            }
            if (arr.Length > 2)
            {
                    rs.calval_msb2 = Convert.ToDouble(arr[2]);
            }


            ChartData cd = rs.CaptureFFT(fs_scope,pow_scope,savePath,filename,saveData,osr);
            cd.AutoScale = false;

            if (rs.supplyLow)
            {
                this.Invoke(new EmptyHandler(setColorRed));
                
            }
            else
            {
                this.Invoke(new EmptyHandler(setColorGreen));
            }
           
            cd.Title = "SNDR=" + rs.sndr.ToString("f2") + "dB, SNR=" + rs.snr.ToString("f2") + "dB, ENOB=" + rs.enob.ToString("f2") + "bit A="  + rs.amp.ToString() + " Max=" + rs.max.ToString() + " Min=" + rs.min.ToString()  + " Mean=" + rs.mean.ToString("F2") + " Sigma=" + rs.sigma.ToString("F2");

            saveData = false;

            return cd;
            
        }



        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

                if (this.toolStripTextBox1.Text.Length < 1)
            {
                return;
            }
            double fs_scope = Convert.ToDouble(this.toolStripTextBox1.Text);
            if(fs_scope > 0.01)
            {
                this.fs_scope = fs_scope;
            }
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.toolStripTextBox2.Text.Length < 1)
            {
                return;
            }
            double pow_scope = Convert.ToDouble(this.toolStripTextBox2.Text);
            if (pow_scope > 8 && pow_scope < 24)
            {
                this.pow_scope = pow_scope;
            }
        }


        
        private void tSetOversampleClick(object sender, EventArgs e)
        {

            if (osr == 1)
            {
                osr = 2;
                this.tSetOversample.Text = "OSR2";

            }else if (osr == 2)
            {
                osr = 4;
                this.tSetOversample.Text = "OSR4";

            
            }else if (osr == 4)
            {
                osr = 8;
                this.tSetOversample.Text = "OSR8";

            }
            else
            {
                osr = 1;
                this.tSetOversample.Text = "OSR1";

            }


        }

        private void tReadCont_t(object sender, EventArgs e)
        {

        }

        private void tReadCont_Click(object sender, EventArgs e)
        {
            if (isPlay)
            {
                this.tReadCont.Text = "Play";
                isPlay = false;

            }
            else
            {
                this.tReadCont.Text = "Pause";
                isPlay = true;
                playThread = new Thread(new ThreadStart(RunThread));
                playThread.Start();
            }


        }

        private void tbMSB_Click(object sender, EventArgs e)
        {
            
                
               

            
        }
    }
}
