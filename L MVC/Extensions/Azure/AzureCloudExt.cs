using System;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;

namespace LMVC.Extensions
    {
    /// <summary>
    /// Provides extensions to allow easier interaction with Azure Cloud Blobs and Azure Queues.
    /// </summary>
    public static class AzureCloudExt
        {
        /// <summary>
        /// Returns whether a particular file exists within a CloudBlobDirectory.
        /// </summary>
        public static bool Exists(this CloudBlobDirectory Dir, string FileName)
            {
            var BlockBlob = Dir.GetBlockBlobReference(FileName);

            try { BlockBlob.FetchAttributes(); }
            catch { }

            return !string.IsNullOrEmpty(BlockBlob.Properties?.ContentType);
            }

        /// <summary>
        /// Uploads a file (Stream) to a CloudBlobDirectory
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Dir"></param>
        /// <param name="Stream"></param>
        /// <param name="Overwrite">Overwrite existing files (default false)</param>
        /// <returns>A CloudBlockBlob for the file you uploaded</returns>
        public static CloudBlockBlob UploadFile(this CloudBlobDirectory Dir, Stream Stream, string FileName, bool Overwrite = false)
            {
            if (Overwrite ||
                !Dir.Exists(FileName))
                {
                var BlockBlob = Dir.GetBlockBlobReference(FileName);

                BlockBlob.UploadFromStream(Stream);

                return BlockBlob;
                }

            return null;
            }

        /// <summary>
        /// Gets a file from a CloudBlobDirectory by name if it exists.
        /// </summary>
        /// <returns>A CloudBlockBlob if the file exists.</returns>
        public static CloudBlockBlob GetBlob(this CloudBlobDirectory Dir, string FileName)
            {
            return Dir.GetBlockBlobReference(FileName);
            }

        /// <summary>
        /// Downloads a file by name if it exists.
        /// </summary>
        /// <returns>A byte[] of the cloud file</returns>
        public static byte[] DownloadFile(this CloudBlobDirectory Dir, string FileName)
            {
            var Blob = GetBlob(Dir, FileName);

            return Blob.DownloadByteArray();
            }

        /// <summary>
        /// Deletes a file by name if it exists.
        /// </summary>
        public static void DeleteFile(this CloudBlobDirectory Dir, string FileName)
            {
            var Blob = GetBlob(Dir, FileName);

            Blob.DeleteIfExists();
            }

        //////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Returns a CloudQueueClient by name if it exists.
        /// </summary>
        public static CloudQueue GetQueue(this CloudQueueClient Client, string QueueName)
            {
            var Queue = Client.GetQueueReference(QueueName);
            Queue.CreateIfNotExist();

            return Queue;
            }

        /// <summary>
        /// Adds a message to a CloudQueue
        /// </summary>
        public static void AddMessage(this CloudQueue Queue, string Message, TimeSpan? TimeToLive = null, TimeSpan? InitialVisibilityDelay = null)
            {
            var CloudMessage = new CloudQueueMessage(Message);

            Queue.AddMessage(CloudMessage, TimeToLive, InitialVisibilityDelay);
            }

        /// <summary>
        /// Returns the current length of <paramref name="Queue" />
        /// </summary>
        public static int GetQueueLength(this CloudQueue Queue)
            {
            int? CachedMessageCount = Queue.ApproximateMessageCount;

            return CachedMessageCount ?? 0;
            }
        }
    }