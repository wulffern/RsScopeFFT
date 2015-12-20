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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NextGenLab.Chart;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace NglChart
{
	/// <summary>
	/// Summary description for OpenServer.
	/// </summary>
	public class ChartNetServer: ChartNet
	{
		TcpListener tcl;
		bool die = false;

	
		public delegate void NewDataHandler(byte[] cd);
		public event NewDataHandler NewChartData;

		public ChartNetServer()
		{
			IPEndPoint ipep = new IPEndPoint(IPAddress.Any,Port);

			tcl = new TcpListener(ipep);
			tcl.Start();

			Application.ThreadExit +=new EventHandler(Application_ThreadExit);
			
			ThreadPool.QueueUserWorkItem(new WaitCallback(Listen));
		
		}

		//Server listening for connections
		private void Listen(object o)
		{
			while(true)
			{
				//byte[] data = new byte[1024];
				TcpClient client = tcl.AcceptTcpClient();
				NetworkStream ns = client.GetStream();	
				StringBuilder sb = new StringBuilder();
				try
				{

					// Check to see if this NetworkStream is readable.
					if(ns.CanRead)
					{
//						byte[] myReadBuffer = new byte[1024];
//						int numberOfBytesRead = 0;

						using(StreamReader sr = new StreamReader(ns))
						{
							if(NewChartData != null)
							{
								NewChartData(Encoding.ASCII.GetBytes(sr.ReadToEnd()));
							}

						}						
					}
					else
					{
						Debug.WriteLine("Sorry.  You cannot read from this NetworkStream.");
					}
					

				}
				catch(Exception ef)
				{
					Debug.WriteLine(ef.Message);
				}
				

				if(die)
					break;

				ns.Close();
				client.Close();
			}

		}

		//Kill server
		private void Application_ThreadExit(object sender, EventArgs e)
		{
			try
			{
				die = true;
				TcpClient tc = new TcpClient("localhost",Port);
				using(NetworkStream ns = tc.GetStream())
				{
					ns.Write(new byte[]{0x00},0,1);
				}
				
				tc.Close();
				tcl.Stop();
			}
			catch(Exception ef)
			{
				Debug.WriteLine(ef.Message);
			}
			

		}
	}
}
