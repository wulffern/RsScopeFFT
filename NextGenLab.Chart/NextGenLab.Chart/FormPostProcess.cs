using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextGenLab.Chart.PostProcess;

namespace NextGenLab.Chart
{
    public partial class FormPostProcess : System.Windows.Forms.UserControl
    {

        ChartDataList cds;

        List<PostProcessBase> commands = new List<PostProcessBase>();

        public FormPostProcess(ChartDataList cds)
        {
            this.cds = cds;
            InitializeComponent();


            Type[] types = this.GetType().Assembly.GetTypes();
            foreach (Type t in types)
            {
                if (t.IsSubclassOf(typeof(PostProcessBase)))
                {
                    try
                    {

                        PostProcessBase ppb = (PostProcessBase)Activator.CreateInstance(t, new object[] { cds });
                        commands.Add(ppb);
                    }
                    catch { }
                }
            }


            foreach (PostProcessBase ppb in commands)
            {
                ToolStripItem tsi;
                //if (this.functionsMenu.Items.ContainsKey(ppb.Category))
                //    tsi = this.functionsMenu.Items[ppb.Category];
                //else
                //    tsi = this.functionsMenu.Items.Add(ppb.Category);

                this.functionsMenu.Items.Add(ppb.Name, null, delegate
                {
                    string str;
                    ppb.Execute(out str);
                    this.richTextBox1.AppendText(str);
                });



            }
        }


    }
}