using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NextGenLab.Chart.ColorThemes
{
    public class CTDefault:ColorThemeBase
    {
        public CTDefault()
        {
            NAME = "Default";

            Colors.AddRange(new Color[] { Color.Red, Color.Blue, Color.LightSeaGreen, Color.Indigo, Color.DeepSkyBlue });
        }
}
}
