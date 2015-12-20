using System;
using System.Collections.Generic;
using System.Text;
using NextGenLab.Chart;

namespace NextGenLab.Chart.PostProcess
{
    

    public abstract class PostProcessBase
    {

        protected ChartDataList cds;
        protected string name;
        protected string category;
        protected string description;

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string Category { get { return category; } }

        public PostProcessBase(ChartDataList cds)
        {
            category = "Unspecified";
            this.cds = cds;
        }

        public abstract void Execute(out string Output);
    }
}
