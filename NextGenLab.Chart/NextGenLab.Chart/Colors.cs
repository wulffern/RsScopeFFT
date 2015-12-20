using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Colors used in Charts
	/// </summary>
	public class Colors
	{

		//Container for colors
		private static ArrayList colors;

		#region Constructors
		private Colors()
		{
		}

		static Colors()
		{
			colors = new ArrayList();

			

			colors.Add(Color.Red);
			colors.Add(Color.Blue);
			colors.Add(Color.LightSeaGreen);
			colors.Add(Color.Indigo);
			colors.Add(Color.DeepSkyBlue);
		}
		#endregion

		/// <summary>
		/// Get color arrays
		/// </summary>
		/// <returns>Array of Color</returns>
//		public static ArrayList GetColors()
//		{
//			return (Color[])colors.ToArray(typeof(Color));
//		}

		/// <summary>
		/// Get the color at i % colors.Length
		/// </summary>
		/// <param name="i">i</param>
		/// <returns>Color</returns>
		public static Color GetColor(int i)
		{
			int index = i % colors.Length;
			return colors[index];
		}

		/// <summary>
		/// Add color to container
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static int Add(Color c)
		{
			return colors.Add(c);
		}

		/// <summary>
		/// Remove color from container
		/// </summary>
		/// <param name="c"></param>
		public static void Remove(Color c)
		{
            colors.Remove(c);
		}

		/// <summary>
		/// Replace Color at index in container
		/// </summary>
		/// <param name="c"></param>
		/// <param name="index"></param>
		public static void Replace(Color c,int index)
		{
			colors[index] = c;
		}

	
	}
}
