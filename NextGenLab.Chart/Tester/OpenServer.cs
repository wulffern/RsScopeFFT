using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NextGenLab.Chart;

namespace NglChart
{
	/// <summary>
	/// Summary description for OpenServer.
	/// </summary>
	public class OpenServer: MarshalByRefObject
	{
		TcpListener tcl;

		public delegate void NewChartDataHandler(ChartData cd);
		public event NewChartDataHandler NewChartData;
		public OpenServer()
		{
			
			IPEndPoint ipep = new IPEndPoint(IPAddress.Any,10203);

			tcl = new TcpListener(ipep);
			tcl.Start();
			ThreadPool.QueueUserWorkItem(new WaitCallback(Listen));
		}

		private void Listen(object o)
		{
			while(true)
			{
				byte[] data = new byte[1024];
				TcpClient client = tcl.AcceptTcpClient();
				NetworkStream ns = client.GetStream();	
				StringBuilder sb = new StringBuilder();
				try
				{
					ChartData cd = ChartData.FromXml(ns);
					if(NewChartData != null)
						NewChartData(cd);

				}
				catch(Exception ef)
				{
					short i=0;
				}
				

				ns.Close();
				client.Close();
			}

		}


	}
}
