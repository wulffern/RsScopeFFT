using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NextGenLab.Chart
{
    public partial class ThemeGenerator : Form
    {
        public ThemeGenerator()
        {
            InitializeComponent();

            KnownColor enumColor = new KnownColor();
            List<KnownColor> colors = new List<KnownColor>();
            colors.AddRange((KnownColor[])Enum.GetValues(enumColor.GetType()));
            //colors.RemoveRange(0, 27);

            ColorPick cp;
            foreach (KnownColor kc in colors)
            {
                cp = new ColorPick(kc);
                this.flowLayoutPanel1.Controls.Add(cp);
                
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string themepath = Application.StartupPath + Path.DirectorySeparatorChar + "Themes";
            if (!Directory.Exists(themepath))
                Directory.CreateDirectory(themepath);

            using (StreamWriter sw = new StreamWriter(themepath + Path.DirectorySeparatorChar + tbThemeName.Text + ".txt"))
            {

                foreach (ColorPick c in this.flowLayoutPanel1.Controls)
                {
                    if (c.Checked)
                    {
                        sw.WriteLine(c.PickColor.ToString());
                    }

                }
            }
        }
    }

    public class ColorPick : CheckBox
    {
        KnownColor color;
        public KnownColor PickColor { get { return color; } }
        public ColorPick(KnownColor c)
        {
            this.Width = 200;
            int width = 32;
            int height = 16;
            this.ImageAlign = ContentAlignment.MiddleRight;
      
            Text = c.ToString();
            Bitmap bp = new Bitmap(width,height);
            Graphics g = Graphics.FromImage(bp);
            color = c;
            SolidBrush sb = new SolidBrush(Color.FromKnownColor( color));
            g.FillRectangle(sb, 0, 0, width, height);
            g.DrawRectangle(Pens.Black, 1, 1, width - 1, height - 1);
            Image = bp;
            g.Dispose();
        }

    }
}