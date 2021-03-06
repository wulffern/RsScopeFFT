﻿/*
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
using System.Text;

#endregion

namespace NextGenLab.Chart
{
    public class Hamming:WindowBase
    {
        public Hamming()
        {
        }


        public override void Calc(out double d, double n, double M)
        {
            d = 0.54 - 0.46 * Math.Cos(2 * Math.PI * n/(M- 1));
        }


        public override double[] Calc(int M)
        {
            double[] d = new double[M];
            for (int n = 0; n < M; n++)
            {
                d[n] = 0.54 - 0.46 * Math.Cos(2 * Math.PI * n / (M - 1));
            }
            return d;
        }


    }
}
