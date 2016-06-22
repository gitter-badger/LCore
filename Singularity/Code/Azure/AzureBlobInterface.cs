using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public class AzureBlobInterface
        {
        public static CloudBlobClient GetBlobClient()
            {
            CloudStorageAccount StorageAccount = AzureInterface.GetStorageAccount();

            CloudBlobClient BlobClient = StorageAccount.CreateCloudBlobClient();

            return BlobClient;
            }

        public static CloudBlobContainer GetContainer(string ContainerName)
            {
            CloudBlobClient Client = GetBlobClient();

            CloudBlobContainer Container = Client.GetContainerReference(ContainerName);
            Container.CreateIfNotExist();

            return Container;
            }

        public static CloudBlobDirectory GetContainerDirectory(string ContainerName, string DirName)
            {
            CloudBlobContainer Container = GetContainer(ContainerName);

            CloudBlobDirectory FilesDir = Container.GetDirectoryReference(DirName);

            return FilesDir;
            }
        }
    }