using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LCore
    {
    public class WebClientTimeOut : System.Net.WebClient
        {
        public const int SleepInterval = 100;

        public int TimeOutMS = 20000;

        public WebClientTimeOut()
            : base()
            {
            }

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
                throw new Exception("Unable to process, another request is already being made: " + address.AbsoluteUri);

            int Waited = 0;

            this.UploadDataCompleted += this.UploadData_Completed;

            FinishedResponse = null;

            base.UploadDataAsync(address, data);

            while (Waited < TimeOutMS && FinishedResponse == null)
                {
                System.Threading.Thread.Sleep(SleepInterval);
                Waited += SleepInterval;
                }

            if (FinishedResponse == null)
                {
                this.CancelAsync();
                throw new Exception("Timeout occurred: " + address.AbsoluteUri);
                }

            return FinishedResponse;
            }

        public void UploadData_Completed(object o, UploadDataCompletedEventArgs e)
            {
            FinishedResponse = e.Result;
            }

        public byte[] FinishedResponse = null;
        }
    }