using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NextGenLab.Chart.ColorThemes
{
    public class CTAutoRGB:ColorThemeBase
    {
        public CTAutoRGB()
        {
            NAME = "Rainbow";

            int[] colind = new int[] { 00, 51, 102, 153, 204, 255 };
            int blue = 66;
            Color[] cols = new Color[colind.Length * (colind.Length / 2)];
            for (int i = 0; i < colind.Length; i++)
            {
                for (int z = 0; z < colind.Length / 2; z++)
                {
                    cols[(colind.Length / 2) * i + z] = Color.FromArgb(128, colind[(colind.Length - 1) - i], colind[z * 2], blue);
                }
            }

            Color[] cols1 = new Color[cols.Length];
            Array.Copy(cols, cols1, cols.Length);

            for (int i = 0; i < cols.Length / 2; i++)
            {
                cols[i] = cols1[2 * i];
            }
            for (int i = 0; i < cols.Length / 2; i++)
            {
                cols[cols.Length / 2 + i] = cols1[2 * i + 1];
            }

            Colors.AddRange(cols);
           
        }
}
}
