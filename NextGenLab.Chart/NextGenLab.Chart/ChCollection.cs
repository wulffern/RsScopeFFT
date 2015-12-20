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
using System.Collections;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Chart Control collection
	/// </summary>
	internal class ChControlCollection:System.Collections.CollectionBase
	{
		/// <summary>
		/// Accessor for ChControlCollection
		/// </summary>
		public ChControl this[int index]
		{
			get
			{
				object o = this.List[index];
				if(o is ChControl)
					return (ChControl)o;
				else
					return null;
			}
			set
			{
				this.List[index] = value;
			}
		}

		/// <summary>
		/// Add control to collection
		/// </summary>
		/// <param name="cc">Chart control</param>
		/// <returns>index</returns>
		public int Add(ChControl cc)
		{
			return this.List.Add(cc);
		}
	}
}
