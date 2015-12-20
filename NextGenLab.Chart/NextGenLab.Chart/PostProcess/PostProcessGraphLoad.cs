using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NextGenLab.Chart.PostProcess
{
    public class PostProcessGraphLoad
    {
        ChartControl cc;
        Form f;
       // MenuItem mi;

        List<PostProcessGraphBase> commands = new List<PostProcessGraphBase>();

        public PostProcessGraphLoad(Form f,ChartControl cc, MenuItem mi,PostProcessGraphBase[] list)
        {
            this.cc = cc;

            if (list != null)
                commands.AddRange(list);

            Type[] types = this.GetType().Assembly.GetTypes();
            foreach (Type t in types)
            {
                if (t.IsSubclassOf(typeof(PostProcessGraphBase)))
                {
                    try
                    {

                        PostProcessGraphBase ppb = (PostProcessGraphBase)Activator.CreateInstance(t, new object[] { f,cc });
                        commands.Add(ppb);
                    }
                    catch { }
                }
            }

            CreateMenu(mi);
        }

        public void CreateMenu(MenuItem mi)
        {
            foreach (PostProcessGraphBase ppg in commands)
            {
                MenuItem mi1 = new MenuItem(ppg.Name,
                    ppg.Executer);
                mi.MenuItems.Add(mi1);
            }
        }


    }
}
