using System;
using System.Collections.Generic;
using System.IO;
#pragma warning disable 1591

namespace LCore.Web
    {
    public class ASyncProgress : IAsyncProgress
        {
        public static List<ASyncProgress> _Progress = new List<ASyncProgress>();
        public static ASyncProgress Progress(Guid UploadID)
            {
            foreach (var Progress in _Progress)
                {
                if (Progress.RequestID == UploadID)
                    return Progress;
                }

            var Out = new ASyncProgress { RequestID = UploadID };

            _Progress.Add(Out);

            return Out;
            }

        public enum FinishedAction { SaveAs }

        public FinishedAction Action { get; set; }
        public Guid RequestID { get; set; }
        public long RequestLength { get; set; }
        public long RequestProgress { get; set; }

        public int BytesPerSecond { get; set; }
        public int ETA { get; set; }

        public RequestStatus Status { get; set; }
        public string Content { get; set; }
        public Stream FileContent { get; set; }
        public string FileName { get; set; }

        public enum RequestStatus { None, InProgress, Complete, Error, ErrorTooLarge }
        }
    }