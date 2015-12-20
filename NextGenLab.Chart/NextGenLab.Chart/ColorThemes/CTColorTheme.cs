using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace NextGenLab.Chart.ColorThemes
{
    public class CTColorTheme:ColorThemeBase
    {
        public CTColorTheme(string filename)
        {
            if (File.Exists(filename))
            {
                NAME = Path.GetFileNameWithoutExtension(filename);

                string[] buffer = File.ReadAllLines(filename);
                Color curcol;
                foreach (string s in buffer)
                {
                    curcol = Color.FromName(s);
                    if (curcol.IsKnownColor)
                        Colors.Add(curcol);
                }

            }
            else
            {
                Colors.AddRange(new Color[] { Color.Red, Color.Blue, Color.LightSeaGreen, Color.Indigo, Color.DeepSkyBlue });
            }
        }


}
}
