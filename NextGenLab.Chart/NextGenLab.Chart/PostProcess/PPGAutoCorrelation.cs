using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NextGenLab.Chart.PostProcess
{
    public class PPGAutoCorrelation:PostProcessGraphBase
    {
        int maxlength = 16384;
        bool isToLarge = false;
        public PPGAutoCorrelation(Form f,ChartControl cc)
            : base(f,cc)
        {
            name = "Auto correlate";
            description = "Does autocorrelation on Y values";
            category = "Statistics";
        }
        protected override ChartDataList DoExecute()
        {
            ChartDataList cdso = new ChartDataList();
            ChartData cdo;
            //throw new Exception("The method or operation is not implemented.");
            for (int i = 0; i < cds.Length; i++)
            {
                ChartData cd = cds[i];
                for (int j = 0; j < cd.Y.Length; j++)
                {
                    cdo = ChartData.GetInstance();
                    double[] autocor = AutoCorrelate(cd.Y[j]);
                    cdo.Y = new double[][] { autocor };
                    if (cd.TitlesY.Length > j)

                        cdo.Title = "AutoCorrelate(" + cd.TitlesY[j] + ")";
                    else
                        cdo.Title = "AutoCorrelate(" + i + "," + j + ")";
                    cdo.X = GetX(autocor.Length);
                    cdso.Add(cdo);
                }
            }

            if(isToLarge){
            Thread t = new Thread(new ThreadStart(delegate{MessageBox.Show(null,"Autocorrelation is limited to " + maxlength + " because of the time it takes to calculate","Limitation on number of points in Autocorrelation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);}));
            t.Start();
            }

            return cdso;

           
        }

        double[] AutoCorrelate(double[] a)
        {
            if (a.Length > maxlength)
            {
                if (!isToLarge)
                    isToLarge = true;
                double[] ab = new double[maxlength];
                Array.Copy(a, ab, maxlength);
                a = ab;

            }


            double[] p = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                 
                for (int j = 0; j < a.Length; j++)
                {
                    p[i] += a[j] * a[(j + i) % a.Length];
                }
            }

            double[] pa = new double[p.Length / 2];
            Array.Copy(p, pa, p.Length / 2);
            

            return pa;
        }

        
    }
}
