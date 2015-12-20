using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
    public partial class DockContainer : UserControl
    {
        public event EmptyHandler Closing;

        public DockContainer()
        {
            InitializeComponent();

            button1.Click += delegate { if (Closing != null) { Closing(); } };
        }


        public void AddToForm(String Title, Control c, Form f, DockStyle Dock,MenuItem m)
        {
            AddToForm(Title, c, f, Dock);

            if (m != null) m.Checked = true;
            button1.Click += delegate { m.Checked = false; };
        }

        public void AddToForm(String Title, Control c, Form f, DockStyle Dock, ToolStripMenuItem tsi)
        {
            AddToForm(Title, c, f, Dock);

            if (tsi != null) tsi.Checked = true;
            button1.Click += delegate { tsi.Checked = false; };
        }

        public void AddToForm(String Title, Control c, Form f,DockStyle Dock)
        {

            this.label1.Text = Title;

         //   FormPostProcess fpp = new FormPostProcess(this.mouseMarkerControl1.ChartDataList);
            Splitter sp = new Splitter();

            c.Dock = DockStyle.Fill;

            sp.Dock = Dock;
            this.Dock = Dock;

            this.button1.Click += delegate { f.Controls.Remove(this); f.Controls.Remove(sp);};

            this.Controls.Add(c);

            c.BringToFront();

            f.Controls.Add(sp);
            f.Controls.Add(this);

        }

        public void Close()
        {
            button1.PerformClick();
        }
    }
}
