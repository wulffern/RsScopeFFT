using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenLab.Chart;

namespace rscapture
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                Console.WriteLine("Usage: rscapture <ip address> <sample frequency> <power of number of samples> [<calibration string>]");

            string ip = args[0];
            double samplefreq = Convert.ToDouble(args[1]);
            double powersamples = Convert.ToDouble(args[2]);

            RsReadFFT rs = new RsReadFFT("TCPIP::"+ ip + "::HISLIP");

 

           List<double> values = this.CaptureRsScope(fs_scope, pow_scope);

        }

        void captureData()
        {
            
            savePath = @"C:\cawu\measurements\river_mpw2\data\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;



        }
    }
}
