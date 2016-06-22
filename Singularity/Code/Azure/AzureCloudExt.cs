using System;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public static class AzureCloudExt
        {
        public static bool Exists(this CloudBlobDirectory Dir, string FileName)
            {
            CloudBlockBlob BlockBlob = Dir.GetBlockBlobReference(FileName);

            try { BlockBlob.FetchAttributes(); }
            catch { }

            return !string.IsNullOrEmpty(BlockBlob.Properties?.ContentType);
            }
        
        public static void UploadFile(this CloudBlobDirectory Dir, Stream Stream, string FileName, bool Overwrite = false)
            {
            if (Overwrite ||
                !Dir.Exists(FileName))
                {
                CloudBlockBlob BlockBlob = Dir.GetBlockBlobReference(FileName);

                BlockBlob.UploadFromStream(Stream);
                }
            }

        public static CloudBlockBlob GetBlob(this CloudBlobDirectory Dir, string FileName)
            {
            return Dir.GetBlockBlobReference(FileName);
            }

        public static byte[] DownloadFile(this CloudBlobDirectory Dir, string FileName)
            {
            CloudBlockBlob Blob = GetBlob(Dir, FileName);

            return Blob.DownloadByteArray();
            }

        public static void DeleteFile(this CloudBlobDirectory Dir, string FileName)
            {
            CloudBlockBlob Blob = GetBlob(Dir, FileName);

            Blob.DeleteIfExists();
            }

        //////////////////////////////////////////////////////////////////////////////////////////

        public static CloudQueue GetQueue(this CloudQueueClient Client, string QueueName)
            {
            CloudQueue Queue = Client.GetQueueReference(QueueName);
            Queue.CreateIfNotExist();

            return Queue;
            }

        public static void AddMessage(this CloudQueue Queue, string Message, TimeSpan? TimeToLive = null, TimeSpan? InitialVisibilityDelay = null)
            {
            CloudQueueMessage CloudMessage = new CloudQueueMessage(Message);

            Queue.AddMessage(CloudMessage, TimeToLive, InitialVisibilityDelay);
            }

        public static int GetQueueLength(this CloudQueue Queue)
            {
            int? CachedMessageCount = Queue.ApproximateMessageCount;

            return CachedMessageCount ?? 0;
            }
        }
    }