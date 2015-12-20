using System;
using System.Collections.Generic;
using System.Text;

namespace NextGenLab.Chart
{
    public class ChartDataProperties
    {

        ChartDataList cds;

        ChartData primary;

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string titlex;

        public string TitleX
        {
            get { return titlex; }
            set { titlex = value; }
        }

        private string axislabelx;

        public string AxisLabelX
        {
            get { return axislabelx; }
            set { axislabelx = value; }
        }

        private string axislabely;

        public string AxisLabelY
        {
            get { return axislabely; }
            set { axislabely = value; }
        }

        private bool showZero;

        public bool ShowZero
        {
            get { return showZero; }
            set { showZero = value; }
        }

        private bool showFullNameLegend;

        public bool ShowFullNameLegend
        {
            get { return showFullNameLegend; }
            set { showFullNameLegend = value; }
        }
	
	

        List<List<string>> ytitles = new List<List<string>>();

        public List<List<string>> TitlesY { get { return ytitles; } }

        public ChartDataProperties(ChartDataList cds)
        {
            if (cds.Length > 0)
            {
                this.cds = cds;
                primary = cds[0];

                title = primary.Title;
                titlex = primary.TitleX;
                axislabelx = primary.AxisLabelX;
                axislabely = primary.AxisLabelY;
                showZero = primary.ShowZero;
                showFullNameLegend = primary.ShowFullNameLegend;

                List<string> titlesy;
                for(int i=0;i<cds.Length;i++)
                {
                    titlesy = new List<string>();
                    titlesy.AddRange(cds[i].TitlesY);
                    ytitles.Add(titlesy);
                }

            }
        }

        public void Apply()
        {
            if (cds.Length > 0)
            {
                primary = cds[0];
                primary.Title = title;
                primary.TitleX = titlex;
                primary.AxisLabelX = axislabelx;
                primary.AxisLabelY = axislabely;
                primary.ShowZero = showZero;
                primary.ShowFullNameLegend = showFullNameLegend;

                cds[0] = primary;

                for (int i = 0; i < cds.Length; i++)
                {
                    ChartData cd = cds[i];
                    cd.TitlesY = ytitles[i].ToArray();
                    cds[i] = cd;
                }
            }
        }



    }
}
