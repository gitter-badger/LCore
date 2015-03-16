using System;
using System.Collections.Generic;
using System.IO;

namespace LCore
    {
    public class ASyncProgress : IAsyncProgress
        {
        public static List<ASyncProgress> _Progress = new List<ASyncProgress>();
        public static ASyncProgress Progress(Guid UploadID)
            {
            for (int i = 0; i < _Progress.Count; i++)
                {
                if (_Progress[i].RequestID == UploadID)
                    return _Progress[i];
                }

            ASyncProgress Out = new ASyncProgress() { RequestID = UploadID };

            _Progress.Add(Out);

            return Out;
            }

        public enum FinishedAction { SaveAs };

        public FinishedAction Action { get; set; }
        public Guid RequestID { get; set; }
        public long RequestLength { get; set; }
        public long RequestProgress { get; set; }

        public int BytesPerSecond { get; set; }
        public int ETA { get; set; }

        public RequestStatus Status { get; set; }
        public String Content { get; set; }
        public Stream FileContent { get; set; }
        public String FileName { get; set; }

        public enum RequestStatus { None, In_Progress, Complete, Error, Error_Too_Large };
        }
    }