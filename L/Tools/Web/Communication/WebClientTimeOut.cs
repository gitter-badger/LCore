using System;
using System.Net;

namespace LCore.Web
    {
    public class WebClientTimeOut : WebClient
        {
        public const int SleepInterval = 100;

        public int TimeOutMS = 20000;

        public new byte[] UploadData(string address, byte[] data)
            {
            return this.UploadData(new Uri(address), data);
            }

        public new byte[] UploadData(Uri address, byte[] data)
            {
            return this.UploadData(address, "POST", data);
            }

        public new byte[] UploadData(string address, string method, byte[] data)
            {
            return this.UploadData(new Uri(address), method, data);
            }

        public new byte[] UploadData(Uri address, string method, byte[] data)
            {
            if (this.IsBusy)
                throw new Exception($"Unable to process, another request is already being made: {address.AbsoluteUri}");

            int Waited = 0;

            this.UploadDataCompleted += this.UploadData_Completed;

            this.FinishedResponse = null;

            this.UploadDataAsync(address, data);

            while (Waited < this.TimeOutMS && this.FinishedResponse == null)
                {
                System.Threading.Thread.Sleep(SleepInterval);
                Waited += SleepInterval;
                }

            if (this.FinishedResponse == null)
                {
                this.CancelAsync();
                throw new Exception($"Timeout occurred: {address.AbsoluteUri}");
                }

            return this.FinishedResponse;
            }

        public void UploadData_Completed(object o, UploadDataCompletedEventArgs e)
            {
            this.FinishedResponse = e.Result;
            }

        public byte[] FinishedResponse;
        }
    }