/*
Copyright (C) 2005 Carsten Wulff

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the

GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
#region Using directives

using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

#endregion

namespace NextGenLab.Chart
{
    public class FFTDialog:Form
    {
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.TextBox tbStart;
		private System.Windows.Forms.TextBox tbStop;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckedListBox clbDisp;
		private System.Windows.Forms.CheckBox cbSel;
		private System.Windows.Forms.Label label1;
	
		#region Generated code
		private void InitializeComponent()
		{
			this.tbStart = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbStop = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.clbDisp = new System.Windows.Forms.CheckedListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbSel = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbStart
			// 
			this.tbStart.Location = new System.Drawing.Point(72, 32);
			this.tbStart.Name = "tbStart";
			this.tbStart.Size = new System.Drawing.Size(80, 20);
			this.tbStart.TabIndex = 0;
			this.tbStart.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Stop:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbStop
			// 
			this.tbStop.Location = new System.Drawing.Point(72, 64);
			this.tbStop.Name = "tbStop";
			this.tbStop.Size = new System.Drawing.Size(80, 20);
			this.tbStop.TabIndex = 2;
			this.tbStop.Text = "0";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbStart);
			this.groupBox1.Controls.Add(this.tbStop);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(200, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(186, 182);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Samples";
			// 
			// btnRun
			// 
			this.btnRun.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRun.Location = new System.Drawing.Point(200, 182);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(186, 23);
			this.btnRun.TabIndex = 5;
			this.btnRun.Text = "Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// clbDisp
			// 
			this.clbDisp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbDisp.Location = new System.Drawing.Point(3, 16);
			this.clbDisp.Name = "clbDisp";
			this.clbDisp.Size = new System.Drawing.Size(194, 154);
			this.clbDisp.TabIndex = 6;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.clbDisp);
			this.groupBox2.Controls.Add(this.cbSel);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 205);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Do FFT on";
			// 
			// cbSel
			// 
			this.cbSel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cbSel.Location = new System.Drawing.Point(3, 178);
			this.cbSel.Name = "cbSel";
			this.cbSel.Size = new System.Drawing.Size(194, 24);
			this.cbSel.TabIndex = 7;
			this.cbSel.Text = "Select / Deselect All";
			this.cbSel.CheckedChanged += new System.EventHandler(this.cbSel_CheckedChanged);
			// 
			// FFTDialog
			// 
			this.AcceptButton = this.btnRun;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(386, 205);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FFTDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	
		#endregion



		struct ChartDisp
		{
			public double[] values;
			public string name;

			public override string ToString()
			{
				return name;
			}

		}

		ChartDataList cds;
        Form midpar;

        public Form MdiPar { get { return midpar; } set { midpar = value; } }

        public FFTDialog(ChartDataList cds,Form MdiPar)
        {
			this.InitializeComponent();

            this.Text = "Fast Fourier Transform Dialog";

            this.MdiPar = MdiPar;
            this.cds = cds;
			
        }

		protected override void OnActivated(EventArgs e)
		{

			this.tbStart.Text = "0";

			ChartData cd;
			int maxvalue = int.MinValue;
			string name;
			for(int i=0;i< cds.Length;i++)
			{
				cd = cds[i];
				for(int j=0;j<cd.Y.Length;j++)
				{
					
					if(cd.TitlesY.Length > j)
					{
						name = i + ":" +  cd.TitlesY[j];
					}
					else
					{
						name = i + ":" + j;
					}

					ChartDisp cdisp = new ChartDisp();
					cdisp.values = cd.Y[j];
					cdisp.name = name;
                
					this.clbDisp.Items.Add(cdisp,CheckState.Checked);
					if(maxvalue < cd.Y[j].Length)
						maxvalue = cd.Y[j].Length;
				}
			}
			this.tbStop.Text = maxvalue.ToString();
			this.cbSel.Checked = true;
		}


		protected override void OnGotFocus(EventArgs e)
		{
			

		}


		private void btnRun_Click(object sender, System.EventArgs e)
		{

            int start = 0;
            int stop = -1;
            try
            {
                start = Int32.Parse(this.tbStart.Text);
                stop = Int32.Parse(this.tbStop.Text);
            }
            catch {}

			double[] y;
			double[] y1;
			ChartData cdr;
			FFT fft = new FFT();
			foreach(ChartDisp cd in this.clbDisp.CheckedItems)
			{
				y = (double[])cd.values.Clone();
				if (y.Length > start && y.Length > stop && start > 0 && stop > 0)
				{
					y1 = new double[stop - start];
					Array.Copy(y, start, y1, 0, stop - start);

				}
				else
				{
					y1 = y;
				}

				fft.PowerSpectralDensity(y1, out cdr, new Hanning(),1);
				Chart c = new Chart();
				cdr.Title = "fft(" + cd.name + ")";
				cdr.TitleX = "frequency";
				cdr.AxisLabelX = "[fs]";
				c.MdiParent = this.MdiPar;
				c.Open(cdr, false);
				c.Show();

			}
            this.Close();

        }

		private void cbSel_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0;i<clbDisp.Items.Count;i++){
				this.clbDisp.SetItemChecked(i,cbSel.Checked);
				}
		}


    }
}
