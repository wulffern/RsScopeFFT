using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NextGenLab.Chart
{



    public partial class PropertiesControl : UserControl
    {

        int labelWidth = 80;
        int labelHeight = 20;
        int boxWidth = 150;
        ChartDataProperties cdp;

        public PropertiesControl(ChartControl cc)
        {
            InitializeComponent();

            if (cc.ChartDataList.Length > 0)
            {
                cdp = new ChartDataProperties(cc.ChartDataList);

               AddStringField("Title", cdp);
               AddStringField("TitleX", cdp);
               AddStringField("AxisLabelX", cdp);
               AddStringField( "AxisLabelY", cdp);

               AddBoolField("ShowZero", cdp);
               AddBoolField("ShowFullNameLegend", cdp);

               TabPage tp;
               for(int i=0;i<cdp.TitlesY.Count;i++)
               {
                   tp = new TabPage("Y Series " + i);
                   tp.BackColor = Color.White;
                   FlowLayoutPanel flp = new FlowLayoutPanel();
                   flp.Dock = DockStyle.Fill;
                   flp.AutoScroll = true;
                   flp.Tag = i;
                   tp.Controls.Add(flp);
                   this.tabControl1.TabPages.Add(tp);
                   for (int k = 0; k < cdp.TitlesY[i].Count; k++)
                   {
                       TextBox tb = new TextBox();
                       Label l = new Label();

                       l.Text = "TitlesY["+ i  +"][" + k + "]" + ":";
                       l.TextAlign = ContentAlignment.MiddleLeft;
                       l.Size = new Size(labelWidth, labelHeight);
                       l.ForeColor = Color.Black;
                       //tb.DataBindings.Add("Text", datasource, name);
                       tb.Text = cdp.TitlesY[i][k];
                       tb.Tag = k;

                       tb.LostFocus += new EventHandler(tb_LostFocus);
                       //tb.LostFocus += delegate{
                           
                       //};

                       
                       tb.Size = new Size(boxWidth, labelHeight);
                       flp.Controls.AddRange(new Control[] { l, tb });
                   }

               }

            }

            Button apply = new Button();
            apply.Text = "Apply";
            apply.Click += delegate { cdp.Apply(); cc.Invalidate(); };
            apply.Dock = DockStyle.Bottom;
            this.Controls.Add(apply);

            this.BackColor = Color.White;
        }

        void tb_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int kk = (int)tb.Tag;
            int ii = (int)tb.Parent.Tag;
            cdp.TitlesY[ii][kk] = tb.Text;
        }

        void AddStringField(string name, object datasource)
        {
            AddStringField(this.flowLayoutPanel1,name,datasource);
        }

        void AddStringField(Control c, string name, object datasource)
        {
            TextBox tb = new TextBox();
            Label l = new Label();

            l.Text = name + ":";
            l.TextAlign = ContentAlignment.MiddleLeft;
            l.Size = new Size(labelWidth, labelHeight);
            l.ForeColor = Color.Black;
            tb.DataBindings.Add("Text", datasource, name);
            tb.Size = new Size(boxWidth, labelHeight);

            c.Controls.AddRange(new Control[] { l, tb });
        }

        void AddBoolField(string name, object datasource)
        {
            CheckBox cb = new CheckBox();
            cb.Text = name;
            cb.Size = new Size(boxWidth, labelHeight);
            cb.DataBindings.Add("Checked", datasource, name);
            this.flowLayoutPanel1.Controls.AddRange(new Control[] { cb });

        }
    }
}
