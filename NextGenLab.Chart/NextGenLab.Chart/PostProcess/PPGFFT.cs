using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NextGenLab.Chart.PostProcess
{
    public class PPGFFT:PostProcessGraphBase
    {

        public PPGFFT(Form f, ChartControl cc)
            : base(f, cc)
        {
            name = "Fast Fourier Transform";
            description = "FFT";
            category = "Statistics";

        }

        protected override ChartDataList DoExecute()
        {
            double[][] vals;
            FFT fft = new FFT();
            ChartData cdr;
            ChartDataList cdso = new ChartDataList();
            ChartData[] cds1 = cds.ToArray();
            foreach (ChartData cd in cds1)
            {
                vals =cd.Y;
                for (int i = 0; i < vals.Length; i++)
                {
                    double[] valscopy = new double[vals[i].Length];
                    Array.Copy(vals[i], valscopy, vals[i].Length);

                    fft.PowerSpectralDensity(valscopy, out cdr, new Hanning(), 1,1);
                    if (cd.TitlesY.Length > i)
                        cdr.Title = "fft(" + cd.TitlesY[i] + ")";
                    cdr.TitleX = "frequency";
                    cdr.AxisLabelX = "[fs]";
                    cdso.Add(cdr);
                }
            }

            return cdso;
        }
    }
}
