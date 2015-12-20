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
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for FormAdjXaxis.
	/// </summary>
	public class FormAdjAxis : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbXMax;
		private System.Windows.Forms.TextBox tbXMin;
		private System.Windows.Forms.CheckBox cbAuto;
		private System.Windows.Forms.TextBox tbYMin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbYMax;
		private System.Windows.Forms.GroupBox gbXaxis;
		private System.Windows.Forms.GroupBox gbYaxis;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        ChartControl cc;
		//AxisData ax;
		private System.Windows.Forms.Button btnApply;
		//AxisData ay;

        public event EventHandler Hide;
		public FormAdjAxis(ChartControl cc)
		{

			

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			this.cc = cc;
			
			this.cbAuto.DataBindings.Add("Checked",cc,"AutoScale");
			this.cbAuto.Checked = cc.AutoScale;

			//ax = cc.AxisRangeX;
			//ay = cc.AxisRangeY;
			
			//this.tbXMax.DataBindings.Add("Text",ax,"Max");
			//this.tbXMin.DataBindings.Add("Text",ax,"Min"); 
			//this.tbXStep.DataBindings.Add("Text",ax,"Step"); 
			
			//this.tbYMax.DataBindings.Add("Text",ay,"Max");
			//this.tbYMin.DataBindings.Add("Text",ay,"Min"); 
			//this.tbYStep.DataBindings.Add("Text",ay,"Step"); 
			
	
			this.tbXMax.Text = cc.AxisRangeX.Max.ToString();
			this.tbXMin.Text = cc.AxisRangeX.Min.ToString();

			this.tbYMax.Text = cc.AxisRangeY.Max.ToString();
			this.tbYMin.Text = cc.AxisRangeY.Min.ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tbXMax = new System.Windows.Forms.TextBox();
            this.tbXMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbXaxis = new System.Windows.Forms.GroupBox();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.gbYaxis = new System.Windows.Forms.GroupBox();
            this.tbYMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbYMax = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbXaxis.SuspendLayout();
            this.gbYaxis.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbXMax
            // 
            this.tbXMax.Location = new System.Drawing.Point(96, 16);
            this.tbXMax.Name = "tbXMax";
            this.tbXMax.Size = new System.Drawing.Size(100, 20);
            this.tbXMax.TabIndex = 0;
            // 
            // tbXMin
            // 
            this.tbXMin.Location = new System.Drawing.Point(96, 48);
            this.tbXMin.Name = "tbXMin";
            this.tbXMin.Size = new System.Drawing.Size(100, 20);
            this.tbXMin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbXaxis
            // 
            this.gbXaxis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbXaxis.Controls.Add(this.tbXMin);
            this.gbXaxis.Controls.Add(this.label2);
            this.gbXaxis.Controls.Add(this.label1);
            this.gbXaxis.Controls.Add(this.tbXMax);
            this.gbXaxis.Location = new System.Drawing.Point(0, 8);
            this.gbXaxis.Name = "gbXaxis";
            this.gbXaxis.Size = new System.Drawing.Size(216, 80);
            this.gbXaxis.TabIndex = 6;
            this.gbXaxis.TabStop = false;
            this.gbXaxis.Text = "X Axis";
            // 
            // cbAuto
            // 
            this.cbAuto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAuto.Location = new System.Drawing.Point(282, 93);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAuto.Size = new System.Drawing.Size(88, 24);
            this.cbAuto.TabIndex = 4;
            this.cbAuto.Text = "Auto Scale";
            this.cbAuto.CheckedChanged += new System.EventHandler(this.cbAuto_CheckedChanged);
            // 
            // gbYaxis
            // 
            this.gbYaxis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbYaxis.Controls.Add(this.tbYMin);
            this.gbYaxis.Controls.Add(this.label5);
            this.gbYaxis.Controls.Add(this.label6);
            this.gbYaxis.Controls.Add(this.tbYMax);
            this.gbYaxis.Location = new System.Drawing.Point(224, 8);
            this.gbYaxis.Name = "gbYaxis";
            this.gbYaxis.Size = new System.Drawing.Size(216, 80);
            this.gbYaxis.TabIndex = 7;
            this.gbYaxis.TabStop = false;
            this.gbYaxis.Text = "Y Axis";
            // 
            // tbYMin
            // 
            this.tbYMin.Location = new System.Drawing.Point(96, 48);
            this.tbYMin.Name = "tbYMin";
            this.tbYMin.Size = new System.Drawing.Size(100, 20);
            this.tbYMin.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Max";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbYMax
            // 
            this.tbYMax.Location = new System.Drawing.Point(96, 16);
            this.tbYMax.Name = "tbYMax";
            this.tbYMax.Size = new System.Drawing.Size(100, 20);
            this.tbYMax.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(376, 94);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(64, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FormAdjAxis
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbAuto);
            this.Controls.Add(this.gbXaxis);
            this.Controls.Add(this.gbYaxis);
            this.Name = "FormAdjAxis";
            this.Size = new System.Drawing.Size(448, 125);
            this.gbXaxis.ResumeLayout(false);
            this.gbXaxis.PerformLayout();
            this.gbYaxis.ResumeLayout(false);
            this.gbYaxis.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void cbAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			
			this.gbXaxis.Enabled = !this.cbAuto.Checked;
			this.gbYaxis.Enabled = !this.cbAuto.Checked;
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			if(this.cbAuto.Checked)
			{
				cc.ChartDataList.RestoreOriginalAxis();
			}
			else
			{
				AxisData ax = new AxisData(Double.Parse(tbXMin.Text),Double.Parse(tbXMax.Text),1);
				AxisData ay = new AxisData(Double.Parse(tbYMin.Text),Double.Parse(tbYMax.Text),1);
				cc.AxisRangeX = new AxisData(ax.Min,ax.Max,Math.Abs(ax.Max-ax.Min)/5);
				cc.AxisRangeY = new AxisData(ay.Min,ay.Max,Math.Abs(ay.Max-ay.Min)/5);
			}
			cc.Invalidate();
		
		}

		private void btnHide_Click(object sender, System.EventArgs e)
		{
			this.Parent.Controls.Remove(this);
            if (Hide != null)
                Hide(null,null);
		}
	}
}
