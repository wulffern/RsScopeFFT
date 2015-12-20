using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NextGenLab.Chart.FileTypes
{
    public class FtImage:IChartFile 
    {

        ChartControl cc;
        ImageFormat im;
        public FtImage(ChartControl cc,ImageFormat im)
        {
            this.im = im;
            this.cc = cc;

        }
        #region IChartFile Members

        public event NewChartDataHandler NewChartData;

        public event MessageHandler ErrorMessage;

        public void Open(System.IO.Stream s, bool Merge)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Save(System.IO.Stream s, ChartDataList cds)
        {

            Bitmap bm = cc.GetImage();

            bm.Save(s, im);
            bm.Dispose();

        }

        #endregion
}
}
