﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RohdeSchwarz.RsScope;
using Ivi.Driver;
using System.Windows.Forms;

namespace NextGenLab.Chart
{
    class RsReadFFT
    {
        RsScope driver;
        public double sndr;
        public double snr;
        public double enob;
        public RsReadFFT(string connection)
        {
            sndr = 0;
            snr = 0;
            enob = 0;
            

            try
            {
                if (driver == null)
                    driver = new RsScope(connection, true,false);
            }
            catch (Exception ex)
            {
                String message;

                message = "Instrument Status Error: ";
                message += ex.Message;
                MessageBox.Show(message);
            }


        }

       ~RsReadFFT()
        {
            try
            {
                if (driver != null)
                {
                    driver.Close();
                    driver.Dispose();
                    driver = null;
                }
            }
            catch (Exception ex)
            {
                String message;

                message = "Instrument Status Error: ";
                message += ex.Message;
                MessageBox.Show(message);
            }

        }

        public List<double> CaptureRsScope(double fs_scope,double pow_scope)
        {

            //driver.WaveformAcquisition.RunSingleWithoutWait();
            driver.Acquisition.HorizontalSampleRate = fs_scope*1e6;
            // driver.Acquisition.
            int length =(int)Math.Pow(2, pow_scope);
            double time = length/ driver.Acquisition.HorizontalSampleRate;
           PrecisionTimeSpan p = PrecisionTimeSpan.FromSeconds(time);
            driver.Acquisition.HorizontalTimePerRecord = p;
            //driver.Acquisition.HorizontalRecordLength = (int)Math.Pow(2, 16);
            driver.WaveformAcquisition.RunSingle();
          
            PrecisionTimeSpan maximumTime = PrecisionTimeSpan.FromSeconds(1000);
            bool[] b0 = new bool[length];
            bool[] b1 = new bool[length];
            bool[] b2 = new bool[length];
            bool[] b3 = new bool[length];
            bool[] b4 = new bool[length];
            bool[] b5 = new bool[length];
            bool[] b6 = new bool[length];
            bool[] b7 = new bool[length];
            bool[] b8 = new bool[length];
            bool[] b9 = new bool[length];
            bool[] b10 = new bool[length];
            bool[] b11 = new bool[length];
            bool[] b15 = new bool[length];


            driver.MixedSignalOption.DecodeResults.ReadSignals(0, maximumTime, out b0);
            driver.MixedSignalOption.DecodeResults.ReadSignals(1, maximumTime, out b1);
            driver.MixedSignalOption.DecodeResults.ReadSignals(2, maximumTime, out b2);
            driver.MixedSignalOption.DecodeResults.ReadSignals(3, maximumTime, out b3);
            driver.MixedSignalOption.DecodeResults.ReadSignals(4, maximumTime, out b4);
            driver.MixedSignalOption.DecodeResults.ReadSignals(5, maximumTime, out b5);
            driver.MixedSignalOption.DecodeResults.ReadSignals(6, maximumTime, out b6);
            driver.MixedSignalOption.DecodeResults.ReadSignals(7, maximumTime, out b7);
            driver.MixedSignalOption.DecodeResults.ReadSignals(8, maximumTime, out b8);
            driver.MixedSignalOption.DecodeResults.ReadSignals(9, maximumTime, out b9);
            driver.MixedSignalOption.DecodeResults.ReadSignals(10, maximumTime, out b10);
            driver.MixedSignalOption.DecodeResults.ReadSignals(11, maximumTime, out b11);
            driver.MixedSignalOption.DecodeResults.ReadSignals(15, maximumTime, out b15);

            bool sample = true;
            List<double> values = new List<double>();
          
            for (int i = 0; i < b15.Length; i++)
            {
                if (b15[i] == true && sample)
                {
                    double d11 = b11[i] ? -2048 : 0;
                    double d10 = b10[i] ? 1024 : 0;
                    double d9 = b9[i] ? 512 : 0;
                    double d8 = b8[i] ? 256 : 0;
                    double d7 = b7[i] ? 128 : 0;
                    double d6 = b6[i] ? 64 : 0;
                    double d5 = b5[i] ? 32 : 0;
                    double d4 = b4[i] ? 16 : 0;
                    double d3 = b3[i] ? 8 : 0;
                    double d2 = b2[i] ? 4 : 0;
                    double d1 = b1[i] ? 2 : 0;
                    double d0 = b0[i] ? 1 : 0;

                    values.Add(d11 + d10 + d9 + d8 + d7 + d6 + d5 + d4 + d3 + d2 + d1 + d0);
                    sample = false;
                }
                else if(b15[i] == false)
                {
                    sample = true;
                }
            }

            return values;


        }


        public ChartData CaptureFFT(double fs_scope,double pow_scope)
        {

            ChartData cd;
            FFT fft = new FFT();
            List<double> val = this.CaptureRsScope(fs_scope*3,pow_scope);
            double fs = fs_scope * 1e6;
            double n = Math.Floor(Math.Log(val.Count) / Math.Log(2)) ;
            IEnumerable<double> t= val.Take(Convert.ToInt32(Math.Pow(2.0,  n)));
            double[] dd = t.ToArray<double>();

            fft.PowerSpectralDensity(dd, out cd, new Hanning(),fs, 2048);
            this.enob = fft.enob;
            this.sndr = fft.sndr;
            this.snr = fft.snr;
            cd.AxisRangeY = new AxisData(-120, 0, 20);
            cd.AxisRangeX = new AxisData(0, fs/2, fs/10);

            return cd;

        }

        public ChartData Capture( double fs_scope, double pow_scope)
        {



            List<double> values = this.CaptureRsScope( fs_scope,  pow_scope);
            List<double> xaxis = null;

            ChartData cd = ChartData.GetInstance();
            // cd.Title = this.Name;
            cd.TitlesY = new string[] { "plot"};


            if (xaxis != null && xaxis.Count == values.Count)
            {
                cd.TitleX = "Samples";
                cd.AxisLabelX = "[s]";
                cd.X = xaxis.ToArray();
            }
            else
            {
                cd.TitleX = "Sample";
                double[] x = new double[values.Count];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = i;
                }
                cd.AxisLabelX = "[n]";
                cd.X = x;
            }

            cd.Y = new double[][] { values.ToArray() };
            return cd;
        }
    }
}
