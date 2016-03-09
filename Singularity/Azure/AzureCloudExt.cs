using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public static class AzureCloudExt
        {
        public static Boolean Exists(this CloudBlobDirectory Dir, String FileName)
            {
            CloudBlockBlob BlockBlob = Dir.GetBlockBlobReference(FileName);

            try { BlockBlob.FetchAttributes(); }
            catch { }

            if (BlockBlob.Properties == null ||
                String.IsNullOrEmpty(BlockBlob.Properties.ContentType))
                {
                return false;
                }

            return true;
            }

        public static void UploadFile(this CloudBlobDirectory Dir, Stream Stream, String FileName)
            {
            UploadFile(Dir, Stream, FileName, false);
            }

        public static void UploadFile(this CloudBlobDirectory Dir, Stream Stream, String FileName, Boolean Overwrite = false)
            {
            if (Overwrite ||
                !Dir.Exists(FileName))
                {
                CloudBlockBlob BlockBlob = Dir.GetBlockBlobReference(FileName);

                BlockBlob.UploadFromStream(Stream);
                }
            }

        public static CloudBlockBlob GetBlob(this CloudBlobDirectory Dir, String FileName)
            {
            return Dir.GetBlockBlobReference(FileName);
            }

        public static Byte[] DownloadFile(this CloudBlobDirectory Dir, String FileName)
            {
            CloudBlockBlob Blob = GetBlob(Dir, FileName);

            return Blob.DownloadByteArray();
            }

        public static void DeleteFile(this CloudBlobDirectory Dir, String FileName)
            {
            CloudBlockBlob Blob = GetBlob(Dir, FileName);

            Blob.DeleteIfExists();
            }

        //////////////////////////////////////////////////////////////////////////////////////////

        public static CloudQueue GetQueue(this CloudQueueClient Client, String QueueName)
            {
            CloudQueue Queue = Client.GetQueueReference(QueueName);
            Queue.CreateIfNotExist();

            return Queue;
            }

        public static void AddMessage(this CloudQueue Queue, String Message, TimeSpan? TimeToLive = null, TimeSpan? InitialVisibilityDelay = null)
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