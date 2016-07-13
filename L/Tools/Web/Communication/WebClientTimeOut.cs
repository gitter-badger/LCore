using System;
using System.Net;
#pragma warning disable 1591

namespace LCore.Web
    {
    public class WebClientTimeOut : WebClient
        {
        public const int SleepInterval = 100;

        public int TimeOutMS { get; } = 20000;

        /// <exception cref="InvalidOperationException">Unable to process, another request is already being made</exception>
        /// <exception cref="TimeoutException">Timeout occurred</exception>
        public new byte[] UploadData(string Address, byte[] Data)
            {
            return this.UploadData(new Uri(Address), Data);
            }

        /// <exception cref="InvalidOperationException">Unable to process, another request is already being made</exception>
        /// <exception cref="TimeoutException">Timeout occurred</exception>
        public new byte[] UploadData(Uri Address, byte[] Data)
            {
            return this.UploadData(Address, "POST", Data);
            }

        /// <exception cref="InvalidOperationException">Unable to process, another request is already being made</exception>
        /// <exception cref="TimeoutException">Timeout occurred</exception>
        public new byte[] UploadData(string Address, string Method, byte[] Data)
            {
            return this.UploadData(new Uri(Address), Method, Data);
            }

        /// <exception cref="InvalidOperationException">Unable to process, another request is already being made</exception>
        /// <exception cref="TimeoutException">Timeout occurred</exception>
        // ReSharper disable once UnusedParameter.Global
        public new byte[] UploadData(Uri Address, string Method, byte[] Data)
            {
            if (this.IsBusy)
                throw new InvalidOperationException($"Unable to process, another request is already being made: {Address.AbsoluteUri}");

            int Waited = 0;

            this.UploadDataCompleted += this.UploadData_Completed;

            this.FinishedResponse = null;

            this.UploadDataAsync(Address, Data);

            while (Waited < this.TimeOutMS && this.FinishedResponse == null)
                {
                System.Threading.Thread.Sleep(SleepInterval);
                Waited += SleepInterval;
                }

            if (this.FinishedResponse == null)
                {
                this.CancelAsync();
                throw new TimeoutException($"Timeout occurred: {Address.AbsoluteUri}");
                }

            return this.FinishedResponse;
            }

        // ReSharper disable once InconsistentNaming
        public void UploadData_Completed(object o, UploadDataCompletedEventArgs e)
            {
            this.FinishedResponse = e.Result;
            }

        public byte[] FinishedResponse;
        }
    }