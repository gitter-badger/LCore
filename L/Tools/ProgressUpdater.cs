using System;

namespace LCore.Tools
    {
    public class ProgressUpdater
        {
        public IProgress<string> UpdateStatus { get; set; }
        public IProgress<string> UpdateLog { get; set; }
        public IProgress<int> UpdateProgress { get; set; }
        public IProgress<int> UpdateMaximum { get; set; }

        public ProgressUpdater(Action<string> UpdateStatus = null,
            Action<string> UpdateLog = null,
            Action<int> UpdateProgress = null,
            Action<int> UpdateMaximum = null)
            {
            this.UpdateStatus = new Progress<string>(UpdateStatus);
            this.UpdateLog = new Progress<string>(UpdateLog);
            this.UpdateProgress = new Progress<int>(UpdateProgress);
            this.UpdateMaximum = new Progress<int>(UpdateMaximum);
            }

        public void Status(string Message)
            {
            this.UpdateStatus?.Report(Message);
            }

        public void Log(string Message)
            {
            this.UpdateLog?.Report(Message);
            }

        public void Progress(int Progress)
            {
            this.UpdateProgress?.Report(Progress);
            }

        public void Maximum(int Maximum)
            {
            this.UpdateMaximum?.Report(Maximum);
            }

        public void Clear()
            {
            this.Status("");
            this.Progress(0);
            this.Maximum(0);
            }
        }
    }
