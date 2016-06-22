using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public class AzureQueueInterface
        {
        public static CloudQueueClient GetQueueClient()
            {
            CloudStorageAccount StorageAccount = AzureInterface.GetStorageAccount();

            CloudQueueClient BlobClient = StorageAccount.CreateCloudQueueClient();

            return BlobClient;
            }
        }
    }