using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NextGenLab.Chart
{
    public abstract class ColorThemeBase
    {
        List<Color> colors = new List<Color>();

        int currentindex = -1;
        Color defaultcolor = Color.Red;

        protected string NAME = "Default";

        public string Name { get { return NAME; } }
        
        protected List<Color> Colors { get { return colors; } }

        public ColorThemeBase()
        {
           
        }

        public Color Next()
        {
            if (colors.Count == 0)
                return defaultcolor;

            currentindex++;

            if (colors.Count <= currentindex)
                currentindex = 0;
            return colors[currentindex];
            
            
        }

        public void Reset()
        {
            currentindex = -1;
        }

        //public Color Previous()
        //{
        //    if (colors.Count == 0)
        //        return defaultcolor;

        //}

       // public abstract void GenerateColors(int number);

        
    }
}
