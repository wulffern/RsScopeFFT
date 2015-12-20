#define COLOR
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
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Reflection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using NextGenLab.Chart.ColorThemes;




namespace NextGenLab.Chart
{
    /// <summary>
    /// Wrapped Chart 
    /// </summary>
    public class ChartControl : System.Windows.Forms.Control
    {
        #region Generated Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ChartControl
            // 
            this.Size = new System.Drawing.Size(300, 200);

        }
        #endregion

        #region Private Fields
        ChartDataList cds = new ChartDataList();
        //ChartData[] cd;
        DrawText l;
        DrawGridAxis lg;
        DrawGrid gr;
        Color gridcolor;
        bool changed;
        bool showtitle = true;
        bool showlegend = true;
        bool dontusechanged = false;
        
        int colorindex = 0;
        bool suspenddraw = false;
        int numbdecimals = 2;
        ColorThemeBase colorTheme = new CTDefault();
        #endregion;

        internal DrawLegend legend;

#if COLOR
        bool colorversion = true;
#else
        bool colorversion = false;
#endif
        #region Properties

        public ColorThemeBase ColorTheme { get { return colorTheme; } set { colorTheme = value; } }
       // public bool UseColors { get { return colorversion; } set { colorversion = value; } }
        /// <summary>
        /// Show title in chart
        /// </summary>
        [Category("Chart")]
        public bool ShowTitle { get { return showtitle; } set { showtitle = value; } }
        /// <summary>
        /// Show Legend in chart
        /// </summary>
        [Category("Chart")]
        public bool ShowLegend { get { return showlegend; } set { showlegend = value; } }
        /// <summary>
        /// Gets the GraphMath object used to transform from (among other things) "real" to screen points
        /// </summary>
        protected GraphMath GraphTransform { get { return gr.GraphTransform; } }

        public int NumberOfDecimals { get { return numbdecimals; } set { numbdecimals = value; if (lg != null)lg.NumberOfDecimals = value; } }

        public bool SuspendDrawing { get { return suspenddraw; } set { suspenddraw = value; if (!suspenddraw)cds.Rescale(); } }
        [Category("Axis")]
        public AxisType AxisTypeX { get { return cds.AxisTypeX; } set { cds.AxisTypeX = value; if (cds.AutoScale)cds.Rescale(); DesignTimePaint(); changed = true; } }
        /// <summary>
        /// LIN or LOG
        /// </summary>
        [Category("Axis")]
        public AxisType AxisTypeY { get { return cds.AxisTypeY; } set { cds.AxisTypeY = value; if (cds.AutoScale)cds.Rescale(); DesignTimePaint(); changed = true; } }
        /// <summary>
        /// Chart type
        /// </summary>
        [Category("Chart")]
        public ChartType ChartType { get { return cds[0].ChartType; } set { SetChartDataProperty("ChartType", value); changed = true; } }
        /// <summary>
        /// Base color for grid
        /// </summary>
        [Category("Chart")]
        public Color GridColor { get { return gridcolor; } set { gridcolor = value; DesignTimePaint(); changed = true; } }
        /// <summary>
        /// Markers for X-axis
        /// </summary>
        //public double[] Xmarkers{get{return cds[0].Xmarkers;}set{ChartData cd = cds[0];cd.Xmarkers = value;cds[0] = cd;changed = true;}}
        /// <summary>
        /// Range for X axis (Min, Max, Step)
        /// </summary>
        public AxisData AxisRangeX { get { return cds.AxisRangeX; } set { cds.AxisRangeX = value; changed = true; } }
        /// <summary>
        /// Range for Y axis (Min, Max, Step)
        /// </summary>
        public AxisData AxisRangeY { get { return cds.AxisRangeY; } set { cds.AxisRangeY = value; changed = true; } }
        /// <summary>
        /// ChartData 
        /// </summary>
        public ChartDataList ChartDataList { get { return cds; } set { cds = value; } }
        /// <summary>
        /// AutoScale the axis
        /// </summary>
        [Category("Chart")]
        public bool AutoScale { get { return cds.AutoScale; } set { cds.AutoScale = value; } }




        internal DrawGrid Grid { get { return gr; } }

        internal DrawPlot[] DrawnPlots
        {
            get
            {
                ArrayList al = new ArrayList();
                //DrawPlot[] plots = new DrawPlot[gr.Children.Count];
                foreach (ChControl cc in gr.Children)
                {
                    if (cc is DrawPlot)
                        al.Add(cc);
                }
                return (DrawPlot[])al.ToArray(typeof(DrawPlot));
            }

        }

        /// <summary>
        /// Rectangle that where the curve is drawn (the grid bounries)
        /// </summary>
        public Rectangle CurveArea
        {
            get
            {
                if (gr != null)
                {
                    return new Rectangle(GetParentLocation(gr), gr.Size);
                }
                return new Rectangle(this.Location, this.Size);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize with default values for ChartData
        /// </summary>
        public ChartControl()
        {
            this.InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }



        //		/// <summary>
        //		/// Initialize with ChartData
        //		/// </summary>
        //		/// <param name="cd"></param>
        //		public ChartControl(ChartData cd):this()
        //		{	
        //			this.cds.Add(cd);
        //			changed = true;	
        //		}

        #endregion

        #region Public Members
        /// <summary>
        /// Set Chart value series
        /// </summary>
        /// <param name="x">xvalue series</param>
        /// <param name="y">yvalue series</param>
        void SetValues(double[] x, double[] y)
        {
            SetValues(x, new double[][] { y });
        }

        /// <summary>
        /// Set Chart value series
        /// </summary>
        /// <param name="x">xvalue series</param>
        /// <param name="y">yvalues series</param>
        void SetValues(double[] x, double[][] y)
        {
            ChartData c = cds[0];
            c.X = x;
            c.Y = y;
            cds[0] = c;
            changed = true;
        }

        /// <summary>
        /// Set Chart value series and autoscale Axis
        /// </summary>
        /// <param name="x">xvalue series</param>
        /// <param name="y">yvalue series</param>
        void SetValuesAutoScale(double[] x, double[] y)
        {
            SetValuesAutoScale(x, new double[][] { y });
        }

        /// <summary>
        /// Set Chart value series and autoscale Axis
        /// </summary>
        /// <param name="x">xvalue series</param>
        /// <param name="y">yvalues series</param>
        void SetValuesAutoScale(double[] x, double[][] y)
        {
            ChartData cd = cds[0];

            cd.AxisRangeX = GraphMath.Transform(x);
            cd.AxisRangeY = GraphMath.Transform(y);
            cd.X = x;
            cd.Y = y;
            cds[0] = cd;
            changed = true;
        }

        public void AddChartData(ChartData cd)
        {
            this.cds.Add(cd);
            changed = true;

            if (!suspenddraw)
            {
                Rescale();
                this.Invalidate();
            }

            //this.Invalidate();
        }

        public void Rescale()
        {
            cds.Rescale();
        }



        /// <summary>
        /// Gets image of the Chart control
        /// </summary>
        /// <returns>image of chart control</returns>
        public Bitmap GetImage()
        {
            Bitmap b = null;
            try
            {
                b = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);
                g.DrawRectangle(new Pen(Color.Gray), 0, 0, Width - 1, Height - 1);
                DoPaint(g);
            }
            catch
            {
            }
            return b;
        }

        //public void PaintMe(ref Graphics g)
        //{
        //    g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);
        //    g.DrawRectangle(new Pen(Color.Gray), 0, 0, Width - 1, Height - 1);
        //    DoPaint(g);
        //}

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool OpenClipboard(IntPtr h);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EmptyClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetClipboardData(int
            type, IntPtr h);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseClipboard();

        public void CopyToClipboard()
        {

            Metafile mf = null;
            try
            {
                Graphics g = CreateGraphics();
                IntPtr hdc = g.GetHdc();
                mf = new Metafile(hdc, EmfType.EmfPlusDual);
                g.ReleaseHdc(hdc);
                g.Dispose();
                g = Graphics.FromImage(mf);
                g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);
                g.DrawRectangle(new Pen(Color.Gray), 0, 0, Width - 1, Height - 1);
                DoPaint(g);
                g.Dispose();


                IntPtr hwnd = this.Handle;
                if (OpenClipboard(hwnd))
                {
                    EmptyClipboard();
                    IntPtr hemf = mf.GetHenhmetafile();
                    SetClipboardData(14, hemf); //CF_ENHMETAFILE=14
                    CloseClipboard();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Paints the graphics control on a Graphics surface
        /// </summary>
        /// <param name="g">Graphics surface</param>
        public void PaintMe(Graphics g)
        {
            DoPaint(g);
        }
        #endregion

        #region Protected & Private Members
        /// <summary>
        /// Makes sure that the control repaints when resized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            changed = true;
            base.OnResize(e);
        }


        /// <summary>
        /// Makes sure that the control repaints when invalidated
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (suspenddraw)
                return;

            if (!dontusechanged)
                changed = true;
            base.OnInvalidated(e);
        }

        protected void RedrawChart()
        {
            if (suspenddraw)
                return;

            dontusechanged = true;
            this.Invalidate();
            dontusechanged = false;
        }

        /// <summary>
        /// Paint the chart control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            DoPaint(e.Graphics);
        }

        //		protected override void OnForeColorChanged(EventArgs e)
        //		{
        //			//if(gr != null)
        //		}


        /// <summary>
        /// Paints the chart
        /// </summary>
        /// <param name="g"></param>
        protected void DoPaint(Graphics g)
        {

            if (cds.Length == 0)
            {
                //Draw No Chart Data
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                Font f = new Font("Verdana", 15, FontStyle.Bold);
                SizeF sz = g.MeasureString("No ChartData loaded", f, this.Width, sf);
                g.DrawString("No ChartData loaded", f, new SolidBrush(Color.FromArgb(200, Color.Black)),
                    new RectangleF(this.Width / 2 - sz.Width / 2 + 1, this.Height / 2 + 1, sz.Width, sz.Height), sf);
                g.DrawString("No ChartData loaded", f, new SolidBrush(Color.FromArgb(200, Color.Red)),
                    new RectangleF(this.Width / 2 - sz.Width / 2, this.Height / 2, sz.Width, sz.Height), sf);
                return;
            }
            try
            {
                Debug.WriteLine("Painting Chart: changed ==" + changed.ToString() + " " + DateTime.Now.Ticks);
                if (changed)
                {
                    InitializeComponents(g);
                    changed = false;
                }
                if (l != null)
                {
                    l.Paint(g);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
				MessageBox.Show(null,ex.Message +"\n" + ex.StackTrace,"Unknown error occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
            }
        }


        /// <summary>
        /// Initialize the graph component, only called explicitly when the graph changes
        /// </summary>
        void InitializeComponents(Graphics g)
        {
            if (cds.Length == 0)
                return;

            gr = new DrawGrid(cds);
            colorTheme.Reset();
            legend = new DrawLegend();
            DrawPlot dp;
            for (int i = 0; i < cds.Length; i++)
            {
                ChartData cd = cds[i];

                if (cd.Y.Length == 0 || cd.X.Length == 0)
                    continue;

                //Choose chart
                switch (cd.ChartType)
                {
                    case ChartType.Curve:
                        dp = new ChartTypes.Curve(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Stem:
                        dp = new ChartTypes.Stem(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Fast:
                        dp = new ChartTypes.FastCurve(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Histogram:
                        dp = new ChartTypes.Histogram(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Points:
                        dp = new ChartTypes.Points(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Cross:
                        dp = new ChartTypes.Cross(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.Step:
                        dp = new ChartTypes.Step(cd.X, cd.Y, cd.TitlesY);
                        break;
                    case ChartType.CurveWide:
                        dp = new ChartTypes.CurveWide(cd.X, cd.Y, cd.TitlesY);
                        break;
                    default:
                        dp = new ChartTypes.Curve(cd.X, cd.Y, cd.TitlesY);
                        break;

                }


                //Set colors
                Color[] plotcolors = new Color[cd.Y.Length];
                for (int j = 0; j < cd.Y.Length; j++)
                {

                    if (cd.Z != null && cd.Z.Length > j)
                    {
                        //int index = (int)Math.Floor(cd.Z[j] % cols.Length);
                        //if (index > 0 && index < cols.Length)
                        //    plotcolors[j] = cols[index];
                        //plotcolors[j] = Color.FromArgb((int)cd.Z[j] * 25, 66, 99);
                    }
                    else
                    {
                        plotcolors[j] = colorTheme.Next();
                    }
                    //    }
                }
                dp.Colors = plotcolors;

                //Set legend
                for (int j = 0; j < cd.Y.Length; j++)
                {
                    if (cd.TitlesY != null)
                    {
                        if (cd.TitlesY.Length > j)
                            legend.Add(dp.Colors[j], cd.TitlesY[j]);
                    }
                }

                gr.Add(dp);
            }
            //Add axis labels
            lg = new DrawGridAxis(gr);
            lg.NumberOfDecimals = numbdecimals;

            //Add text
            l = new DrawText(lg, cds[0]);
            l.SetLegend(legend);
            l.ShowTitle = ShowTitle;
            l.ShowLegend = ShowLegend;
            l.Location = new System.Drawing.Point(0, 0);
            l.Size = this.Size;


            //Set ForeColors
            gr.GridColor = this.ForeColor;
            lg.ForeColor = this.ForeColor;
            legend.ForeColor = this.ForeColor;
            l.ForeColor = this.ForeColor;

            //Initialize Controls
            l.Init(g);

        }


        /// <summary>
        /// Control what happens during design time
        /// </summary>
        void DesignTimePaint()
        {
            if (this.DesignMode)
            {
                string exePath = Application.ExecutablePath;

                exePath = exePath.ToLower();

                if (Application.ExecutablePath.ToLower().IndexOf("devenv.exe") > -1)
                {

                    Invalidate();
                }
            }

        }

        /// <summary>
        /// Recursivly find the location of a ChControl refered to top ChControl parent
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        Point GetParentLocation(ChControl c)
        {
            if (c.Parent == null)
                return c.Location;
            else
            {
                Point p = GetParentLocation(c.Parent);
                Point pc = new Point(c.Location.X + p.X, c.Location.Y + p.Y);
                return pc;
            }
        }


        void SetChartDataProperty(string Name, object val)
        {
            ChartData cd;
            for (int i = 0; i < cds.Length; i++)
            {
                cd = cds[i];
                switch (Name)
                {
                    case "AxisRangeX":
                        cd.AxisRangeX = (AxisData)val;
                        break;
                    case "AxisRangeY":
                        cd.AxisRangeY = (AxisData)val;
                        break;
                    case "ChartType":
                        cd.ChartType = (ChartType)val;
                        break;
                    case "AxisTypeX":
                        cd.AxisTypeX = (AxisType)val;
                        break;
                    case "AxisTypeY":
                        cd.AxisTypeY = (AxisType)val;
                        break;

                }
                cds[i] = cd;
            }

        }
        #endregion
    }
}
