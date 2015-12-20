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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NextGenLab.Chart
{
	/// <summary>
	/// Summary description for ChartNetClient.
	/// </summary>
	public class ChartNetClient:ChartNet
	{

		string error;
		string hostname = "localhost";

		public string ErrorLog{get{return error;}}

		public ChartNetClient()
		{	
		}

		public ChartNetClient(string HostName)
		{

			this.hostname = HostName;

			//Convert to hostname if Ipaddress was recieved
			Regex rx = new Regex(@"\d+\.\d+\.\d+\.\d+");
			if(rx.Match(hostname).Success)
			{
				hostname = Dns.Resolve(hostname).HostName;
			}
		}

		public bool Send(ChartData cd)
		{
			try
			{
				using(MemoryStream ms = new MemoryStream())
				{
					cd.ToXML(ms);

					

					TcpClient client = new TcpClient(hostname,Port);
					using(NetworkStream ns = client.GetStream())
					{
						ns.Write(ms.GetBuffer(),0,ms.GetBuffer().Length);
						ns.Close();
					}
					client.Close();
					ms.Close();
				}
				return true;
			}
			catch(Exception e)
			{
				error += e.Message;
				Debug.WriteLine(e.Message);
				return false;
			}
		}

		public bool Send(string path)
		{
			byte[] buffer = new byte[1024];
			long length = 0;
			try
			{
				TcpClient client = new TcpClient(hostname,Port);
				NetworkStream ns = client.GetStream();
				
				using(StreamReader sr = new StreamReader(path))
				{
					using(StreamWriter sw = new StreamWriter(ns))
					{
						sw.Write(sr.ReadToEnd());
					}
				}
				ns.Close();
				client.Close();
				return true;
			}
			catch(Exception e)
			{
				error += e.Message  + "Length: " + length +  "\n"+ Encoding.ASCII.GetString(buffer);
				Debug.WriteLine(e.Message);
				return false;
			}
		}
	}
}
