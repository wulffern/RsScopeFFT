using System;
using System.Collections.Generic;
using System.Text;

namespace NextGenLab.Chart.PostProcess
{
    public class PPMinMax:PostProcessBase
    {
        public PPMinMax(ChartDataList cds)
            : base(cds)
        {
            name = "Min & Max";
            description = "Prints the minimum an maximum Y values";
            category = "General";
        }

        public override void Execute(out string Output)
        {
            double max;
            double min;
            double max_x = 0;
            double min_x = 0;

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

                    max = double.MinValue;
                    min = double.MaxValue;

                    for (int k = 0; k < cd.Y[i].Length; k++)
                    {
                        if (max < cd.Y[i][k])
                        {
                            max = cd.Y[i][k];

                            if (cd.X.Length > k)
                                max_x = cd.X[k];
                            else
                                max_x = double.NaN;
                        }

                        if (min > cd.Y[i][k])
                        {
                            min = cd.Y[i][k];
                            if (cd.X.Length > k)
                                min_x = cd.X[k];
                            else
                                min_x = double.NaN;
                        }

                    }

                    sb.Append("Max = ");
                    sb.Append(max);
                    sb.Append(" , at X = ");
                    sb.Append(max_x);
                    sb.Append("\n");
                    sb.Append("Min = ");
                    sb.Append(min);
                    sb.Append(" , at X = ");
                    sb.Append(min_x);
                    sb.Append("\n");
                }

                
            }
            Output = sb.ToString();
        }
    }
}
