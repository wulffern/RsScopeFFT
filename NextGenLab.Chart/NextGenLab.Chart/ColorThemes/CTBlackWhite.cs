using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NextGenLab.Chart.ColorThemes
{
    public class CTBlackWhite:ColorThemeBase
    {
        public CTBlackWhite()
        {

            int number = 4;

            NAME = "Black & White";

            int x = 0;
            for (int i = 0; i < number; i++)
            {
                x = 255 / (number + 1) * (i + 1);
                Colors.Add(Color.FromArgb(x, x, x));
            }
        }
}
}
