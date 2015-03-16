using System;
using System.Collections.Generic;
using System.IO;

namespace LCore
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
        String Content { get; }
        Stream FileContent { get; }
        String FileName { get; }
        }
    }