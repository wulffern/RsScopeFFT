using System;
using System.Collections.Generic;
using System.Text;
using NextGenLab.Chart;
using System.Windows.Forms;

namespace NextGenLab.Chart.PostProcess
{
    

    public abstract class PostProcessGraphBase
    {

        ChartControl cc;
        Form f;
        EventHandler executer;
        protected string name;
        protected string category;
        protected string description;
        protected ChartDataList cds { get { return cc.ChartDataList; } }

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string Category { get { return category; } }
        public EventHandler Executer { get { return executer; } }

        public PostProcessGraphBase(Form f, ChartControl cc)
        {
            executer = new EventHandler(Execute);
            category = "Unspecified";
            this.cc = cc;
            this.f = f;
        }

        public void Execute(object sender, EventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            Chart c = new Chart();
            ChartDataList cds = DoExecute();
            for(int i=0;i<cds.Length;i++)
            {
                c.Open(cds[i], false);
            }

            if (f.MdiParent != null)
                c.MdiParent = f.MdiParent;

            c.Show();
        }

        protected abstract ChartDataList DoExecute();

        protected double[] GetX(int length)
        {
            double[] x = new double[length];
            for (int i = 0; i < x.Length; i++)
                x[i] = i;
            return x;
        }
    }
}
