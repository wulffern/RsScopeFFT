using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NextGenLab.Chart.FileTypes
{
    public class FtWmf:IChartFile   
    {
        #region IChartFile Members

        public event NewChartDataHandler NewChartData;

        public event MessageHandler ErrorMessage;

        public void Open(System.IO.Stream s, bool Merge)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Save(System.IO.Stream s, ChartDataList cds)
        {
            ChartControl c = new ChartControl();
            ChartData cd;
            for(int i=0;i<cds.Length;i++)
            {
                cd = cds[i];
                cd.AutoScale = false;
                cd.AxisRangeX = cds.AxisRangeX;
                cd.AxisRangeY = cds.AxisRangeY;
                cd.AxisTypeX = cds.AxisTypeX;
                cd.AxisTypeY = cds.AxisTypeY;
                //cd.ChartType = cds.
                c.AddChartData(cds[i]);
            }

            Metafile mf = new Metafile();


            Metafile.

            Graphics g = Graphics.FromImage(mf);

            c.PaintMe(g);

           

            //Metafile mf = c.GetWmf();
            //if(mf != null)
            //    mf.Save(s,System.Drawing.Imaging.ImageFormat.Wmf);
        }

        #endregion
}
}
