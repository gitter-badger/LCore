﻿using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public class AzureQueueInterface
        {
        public static CloudQueueClient GetQueueClient()
            {
            var StorageAccount = AzureInterface.GetStorageAccount();

            var BlobClient = StorageAccount.CreateCloudQueueClient();

            return BlobClient;
            }
        }
    }