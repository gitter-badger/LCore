using System;

namespace LCore.Tools
    {
    /// <summary>
    /// For assisting asyncronous actions or UI threads,
    /// Progress keeps track of current progress and total size,
    /// to allow progress for bar updating.
    /// </summary>
    public class ProgressUpdater
        {
        private IProgress<string> UpdateStatus { get; }
        private IProgress<string> UpdateLog { get; }
        private IProgress<int> UpdateProgress { get; }
        private IProgress<int> UpdateMaximum { get; }

        /// <summary>
        /// Create a new ProgressUpdater
        /// </summary>
        public ProgressUpdater(
            Action<string> UpdateStatus = null,
            Action<string> UpdateLog = null,
            Action<int> UpdateProgress = null,
            Action<int> UpdateMaximum = null)
            {
            this.UpdateStatus = new Progress<string>(UpdateStatus);
            this.UpdateLog = new Progress<string>(UpdateLog);
            this.UpdateProgress = new Progress<int>(UpdateProgress);
            this.UpdateMaximum = new Progress<int>(UpdateMaximum);
            }

        /// <summary>
        /// Send a message to any UpdateStatus actions.
        /// </summary>
        public void Status(string Message)
            {
            this.UpdateStatus?.Report(Message);
            }

        /// <summary>
        /// Send a message to any UpdateLog actions.
        /// </summary>
        public void Log(string Message)
            {
            this.UpdateLog?.Report(Message);
            }

        /// <summary>
        /// Send a message to any UpdateProgress actions.
        /// </summary>
        public void Progress(int Progress)
            {
            this.UpdateProgress?.Report(Progress);
            }

        /// <summary>
        /// Send a message to any UpdateMaximum actions.
        /// </summary>
        public void Maximum(int Maximum)
            {
            this.UpdateMaximum?.Report(Maximum);
            }

        /// <summary>
        /// Clears current data and resets the ProgressUpdater.
        /// </summary>
        public void Clear()
            {
            this.Status("");
            this.Progress(0);
            this.Maximum(0);
            }
        }
    }
