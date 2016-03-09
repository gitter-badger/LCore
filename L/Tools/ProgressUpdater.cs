using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCore
    {
    public class ProgressUpdater
        {
        public IProgress<String> UpdateStatus { get; set; }
        public IProgress<String> UpdateLog { get; set; }
        public IProgress<int> UpdateProgress { get; set; }
        public IProgress<int> UpdateMaximum { get; set; }

        public ProgressUpdater(Action<String> UpdateStatus = null,
            Action<String> UpdateLog = null,
            Action<int> UpdateProgress = null,
            Action<int> UpdateMaximum = null)
            {
            this.UpdateStatus = new Progress<String>(UpdateStatus);
            this.UpdateLog = new Progress<String>(UpdateLog);
            this.UpdateProgress = new Progress<int>(UpdateProgress);
            this.UpdateMaximum = new Progress<int>(UpdateMaximum);
            }

        public void Status(String Message)
            {
            if (this.UpdateStatus != null)
                this.UpdateStatus.Report(Message);
            }

        public void Log(String Message)
            {
            if (this.UpdateLog != null)
                this.UpdateLog.Report(Message);
            }

        public void Progress(int Progress)
            {
            if (this.UpdateProgress != null)
                this.UpdateProgress.Report(Progress);
            }

        public void Maximum(int Maximum)
            {
            if (this.UpdateMaximum != null)
                this.UpdateMaximum.Report(Maximum);
            }

        public void Clear()
            {
            Status("");
            Progress(0);
            Maximum(0);
            }
        }
    }
