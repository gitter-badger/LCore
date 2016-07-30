using System;
using System.IO;
#pragma warning disable 1591

namespace LMVC.Web

    {
    public interface IAsyncProgress
        {
        ASyncProgress.FinishedAction Action { get; }
        Guid RequestID { get; }
        long RequestLength { get; }
        long RequestProgress { get; }

        int BytesPerSecond { get; }
        int ETA { get; }

        ASyncProgress.RequestStatus Status { get; }
        string Content { get; }
        Stream FileContent { get; }
        string FileName { get; }
        }
    }