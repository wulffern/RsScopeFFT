using System;
using System.Collections.Generic;
using System.Text;

namespace NextGenLab.Chart.PostProcess
{
    public class PPRMS:PostProcessBase
    {
        public PPRMS(ChartDataList cds)
            : base(cds)
        {
            name = "Mean/RMS";
            description = "Prints the mean and RMS of y values";
            category = "General";
        }

        public override void Execute(out string Output)
        {

 double meansquare = 0;
 double mean = 0;
            StringBuilder sb = new StringBuilder();
            for(int j=0;j<cds.Length;j++)
            {

                ChartData cd = cds[j];
               
                for (int i = 0; i < cd.Y.Length; i++)
                {
                    if (cd.TitlesY.Length > i)
                        sb.Append(cd.TitlesY[i]);
                    else
                        sb.Append("Y(" + i + ")");

                    sb.Append("\n");

                    for (int k = 0; k < cd.Y[i].Length; k++)
                    {
                        mean += cd.Y[i][k]; 
                        meansquare += Math.Pow(2,cd.Y[i][k]);
                    }
                    double rms = Math.Sqrt(meansquare)/cd.Y[i].Length;
                    mean = mean/cd.Y[i].Length;

                    sb.Append("RMS = ");
                    sb.Append(rms);

sb.Append("\nMean = ");    
                    sb.Append(mean);
                    sb.Append("\n");

                }

                
            }
            Output = sb.ToString();
        }
    }
}
